using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Yamaya
{
    internal class Connector : IDisposable
    {
        #region Properties

        public DateTime? BatchDate { get; set; }
        private String ORI_APP_TITLE { get; set; }
        public const string PATH_SQLLOADER = "sqlLoader";
        private const string PATH_FTPFILES = "ftpFiles";
        private const string PATH_LOGFILES = "log";

        public enum FileType
        {
            Store,
            Item,
            Transaction
        }

        #endregion

        #region Public

        public void Run(FileType fileType, string filePath)
        {
            // Backup FTP Files
            if (!Directory.Exists(string.Format(@"{0}\{1}", Application.StartupPath, PATH_FTPFILES)))
                Directory.CreateDirectory(string.Format(@"{0}\{1}", Application.StartupPath, PATH_FTPFILES));
            File.Copy(filePath,
                      string.Format(@"{0}\{1}\{2}", Application.StartupPath, PATH_FTPFILES, GetBackupFileName(fileType, filePath)),
                      true);

            // Massage Data
            ORI_APP_TITLE = Application.OpenForms[0].Text;
            Application.OpenForms[0].Text = string.Format("Yamaya Files Upload - Massaging Data ({0})", BatchDate.Value.ToString("yyyy-MM-dd"));
            Application.DoEvents();
            DataMassage(fileType, filePath);

            // Upload to DB
            Application.OpenForms[0].Text = string.Format("Yamaya Files Upload - Uploading Records ({0})", BatchDate.Value.ToString("yyyy-MM-dd"));
            Application.DoEvents();
            OracleUpload(fileType);

            // Clear Message
            Application.OpenForms[0].Text = string.Format(ORI_APP_TITLE);
            Application.DoEvents();
        }

        public void Dispose()
        {
            BatchDate = null;
        }

        #endregion

        #region Private

        private void DataMassage(FileType fileType, string filePath)
        {
            //Show Massage
            Application.OpenForms[0].Text = string.Format("Yamaya Files Upload - Massaging {0} ({1})", GetTypePrefix(fileType), BatchDate.Value.ToString("yyyy-MM-dd"));
            Application.DoEvents();

            // Start Massaging
            var sr = GetReader(string.Format(@"{0}\{1}\{2}", Application.StartupPath, PATH_FTPFILES, GetBackupFileName(fileType, filePath)));
            var sw = GetWriter(string.Format(@"{0}\{1}\{2}", Application.StartupPath, PATH_SQLLOADER, GetMsgFileName(fileType)));
            switch (fileType)
            {
                case FileType.Store:
                case FileType.Item:
                    var strArrayRaw = new List<string>(sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
                    var strArrayMsg = new List<string>();
                    var strMsg = string.Empty;
                    var iColCount = (fileType == FileType.Store ? 12 : 13);
                    foreach (var strRaw in strArrayRaw)
                    {
                        strMsg = strMsg + strRaw;
                        if (strMsg.Split(',').Length != iColCount) 
                            continue;
                        if (fileType == FileType.Store)
                            strMsg = string.Format("やまや,{0}", strMsg);
                        strArrayMsg.Add(strMsg);
                        strMsg = string.Empty;
                    }
                    sw.WriteLine(string.Join(Environment.NewLine, strArrayMsg.ToArray()));
                    break;

                case FileType.Transaction:
                    strArrayRaw = new List<string>(sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
                    if (strArrayRaw.Count > 0)
                        strArrayRaw.RemoveAt(0);
                    sw.WriteLine(string.Join(Environment.NewLine, strArrayRaw.ToArray()));
                    break;
            }
            sr.Close();
            sw.Close();
        }

        private void OracleUpload(FileType fileType)
        {
            // Directory Check
            if (!Directory.Exists(string.Format(@"{0}\{1}", Application.StartupPath, PATH_LOGFILES)))
                Directory.CreateDirectory(string.Format(@"{0}\{1}", Application.StartupPath, PATH_LOGFILES));

            //Show Message
            Application.OpenForms[0].Text = string.Format("Yamaya Files Upload - {0} Update ({1})", GetTypePrefix(fileType), BatchDate.Value.ToString("yyyy-MM-dd"));
            Application.DoEvents();

            // Start Upload
            var oConn = DBUtil.OpenConnection();
            var oTran = oConn.BeginTransaction();
            var oCmd = oConn.CreateCommand();
            try
            {
                // Pre-Upload   
                Application.OpenForms[0].Text = string.Format("Yamaya Files Upload - Initializing {0} Update ({1})", GetTypePrefix(fileType), BatchDate.Value.ToString("yyyy-MM-dd"));
                Application.DoEvents();
                var sr = GetReader(string.Format(@"{0}\{1}\{2}", Application.StartupPath, PATH_SQLLOADER, GetCltFileName(fileType).Replace(".clt", "_PRE.cfg")));
                var strStmts = sr.ReadToEnd();
                sr.Close();
                if (!string.IsNullOrEmpty(strStmts))
                {
                    foreach (var stmt in strStmts.Replace(Environment.NewLine, " ").Split(new char[] {';'}))
                    {
                        if (string.IsNullOrEmpty(stmt))
                            continue;
                        oCmd.CommandText = string.Format(stmt, BatchDate.Value.ToString("yyyyMMdd"));
                        oCmd.Transaction = oTran;
                        oCmd.ExecuteNonQuery();
                    }
                }

                // Upload
                Application.OpenForms[0].Text = string.Format("Yamaya Files Upload - Updating {0} ({1})", GetTypePrefix(fileType), BatchDate.Value.ToString("yyyy-MM-dd"));
                Application.DoEvents();
                RunSqlLoader(fileType);

                // Post-Upload
                Application.OpenForms[0].Text = string.Format("Yamaya Files Upload - Closing {0} Update ({1})", GetTypePrefix(fileType), BatchDate.Value.ToString("yyyy-MM-dd"));
                Application.DoEvents();
                sr = GetReader(string.Format(@"{0}\{1}\{2}", Application.StartupPath, PATH_SQLLOADER, GetCltFileName(fileType).Replace(".clt", "_POST.cfg")));
                strStmts = sr.ReadToEnd();
                sr.Close();
                if (!string.IsNullOrEmpty(strStmts))
                {
                    foreach (var stmt in strStmts.Replace(Environment.NewLine, " ").Split(new char[] { ';' }))
                    {
                        if (string.IsNullOrEmpty(stmt))
                            continue;
                        oCmd.CommandText = string.Format(stmt, BatchDate.Value.ToString("yyyyMMdd"));
                        oCmd.Transaction = oTran;
                        oCmd.ExecuteNonQuery();
                    }
                }
                oTran.Commit();
            }
            catch (Exception)
            {
                oTran.Rollback();
                throw;
            }
            finally { oConn.Close(); }
        }

        #endregion

        #region Private Util

        private void RunSqlLoader(FileType fileType)
        {
            var strCmdText = string.Format(@"/C sqlldr userid='{0}/{1}@{2}' control='{3}/{4}/{5}' log='{3}/{6}/{7}'",
                                        DBUtil.UserID,
                                        DBUtil.Password,
                                        DBUtil.TNS,
                                        Application.StartupPath, 
                                        PATH_SQLLOADER,
                                        GetCltFileName(fileType),
                                        PATH_LOGFILES,
                                        GetLogFileName(fileType));
            Process p = Process.Start("CMD.exe", strCmdText);
            p.WaitForExit();
        }

        private string GetTypePrefix( FileType fileType )
        {
            switch (fileType)
            {
                case FileType.Store:
                    return "TENPO";
                case FileType.Item:
                    return "SHO";
                case FileType.Transaction:
                    return "URI";
            }
            return string.Empty;
        }

        private string GetBackupFileName(FileType fileType, string filePath)
        {
            return GetFileName(filePath);
            //string fileName = GetFileName(filePath);
            //switch (fileType)
            //{
            //    case FileType.Store:
            //        return string.Format("TENPO_{0}_{1}.csv", fileName, BatchDate.Value.ToString("yyyyMMdd"));
            //    case FileType.Item:
            //        return string.Format("SHO_{0}_{1}.csv", fileName, BatchDate.Value.ToString("yyyyMMdd"));
            //    case FileType.Transaction:
            //        return string.Format("URI_{0}_{1}.csv", fileName, BatchDate.Value.ToString("yyyyMMdd"));
            //}
            //return string.Empty;
        }

        private string GetMsgFileName(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Store:
                    return string.Format("TENPO_MASSAGED.csv");
                case FileType.Item:
                    return string.Format("SHO_MASSAGED.csv");
                case FileType.Transaction:
                    return string.Format("URI_MASSAGED.csv");
            }
            return string.Empty;
        }

        private string GetCltFileName(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Store:
                    return string.Format("TENPO_SQLLOADER.clt");
                case FileType.Item:
                    return string.Format("SHO_SQLLOADER.clt");
                case FileType.Transaction:
                    return string.Format("URI_SQLLOADER.clt");
            }
            return string.Empty;
        }

        private string GetLogFileName(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Store:
                    return string.Format("TENPO_{0}.log", BatchDate.Value.ToString("yyyyMMdd"));
                case FileType.Item:
                    return string.Format("SHO_{0}.log", BatchDate.Value.ToString("yyyyMMdd"));
                case FileType.Transaction:
                    return string.Format("URI_{0}.log", BatchDate.Value.ToString("yyyyMMdd"));
            }
            return string.Empty;
        }

        private StreamReader GetReader(Stream stream)
        {
            return new StreamReader(stream, Encoding.GetEncoding("Shift-JIS"), true);
        }

        private StreamReader GetReader(string filePath)
        {
            return new StreamReader(filePath, Encoding.GetEncoding("Shift-JIS"), true);
        }

        private StreamWriter GetWriter(string filePath)
        {
            return new StreamWriter(filePath, false, Encoding.UTF8);
        } 

        public static string GetFileName(string filePath)
        {
            return filePath.Substring(filePath.LastIndexOf(@"\") + 1);
        }

        #endregion

    }
}
