using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Xml;
using System.Reflection;

namespace DBConnectSetting
{
    public partial class FDBConnectSetting : Form
    {
        private static System.Collections.Specialized.NameValueCollection mAppSettings;

        private const string XPATH_FMT = "/configuration/appSettings/add[attribute::key='{0}']";
        private const string TAG_KEY   = "key";
        private const string TAG_VALUE = "value";

        private const string KEY_DBCONN = "DBConn";

        private string mFileLoc  = string.Empty;
        private XmlDocument mXml = new XmlDocument();


        public FDBConnectSetting()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {

        }

        private void tsbtnConnect_Click(object sender, EventArgs e)
        {
            Cursor.Current   = Cursors.WaitCursor;
            bool bassConnect = false;

            try
            {
                SimpleConnStr bassConnStr = new SimpleConnStr();
                bassConnStr.UserID     = txtUser.Text;
                bassConnStr.DataSource = txtTNSName.Text;
                bassConnStr.Password   = txtPassword.Text;
                bassConnStr.encode();
                bassConnStr.test();
                bassConnect = true;

                MessageBox.Show(string.Format("Successful connect [{0}] to database.", bassConnStr.UserID), "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                bassConnect = false;
                MessageBox.Show(ex.Message, "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SimpleConnStr bassConnStr = new SimpleConnStr();
            bassConnStr.UserID     = txtUser.Text;
            bassConnStr.DataSource = txtTNSName.Text;
            bassConnStr.Password   = txtPassword.Text;
            bassConnStr.encode();

            XmlDocument mXml = new XmlDocument();
            mXml.Load(mFileLoc);

            XmlNode node = null;
            node = mXml.SelectSingleNode(string.Format(XPATH_FMT, KEY_DBCONN));
            node.Attributes[TAG_VALUE].Value = EncryptionUtil.Encryption.Encrypt(bassConnStr.ConnStr);
            mXml.Save(mFileLoc);

            // Reads UTF8 file
            StreamReader fileStream = new StreamReader(mFileLoc);
            string fileContent      = fileStream.ReadToEnd();
            fileStream.Close();

            // Now writes the content in ANSI
            StreamWriter ansiWriter = new StreamWriter(mFileLoc, false, Encoding.GetEncoding(1250));
            ansiWriter.Write(fileContent);
            ansiWriter.Close();

            MessageBox.Show("Successfully Save.", "DBConnection Setting", MessageBoxButtons.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    mFileLoc = openFileDialog1.FileName;

                    txtLocation.Text = string.Format("{0}", Path.GetFullPath(mFileLoc));
                    loadXmlFile();
                }
            }
            catch (Exception ex)
            {
                //lblStatusBASSnet.Text = DateTime.Now.ToString() + "\r\n" + "Failed to open file with errors\n" + ex.ToString();
            }
        }

        private void loadXmlFile()
        {
            try
            {
                XmlDocument mXml = new XmlDocument();
                mXml.Load(mFileLoc);

                SimpleConnStr connStr = null;
                string mEncryptConn   = string.Empty;

                //if (mFileLocBASSnet.Length <= 0)
                //    return;

                XmlNode node = null;
                node = mXml.SelectSingleNode(string.Format(XPATH_FMT, "DBConn"));
                if (node != null)
                {
                    mEncryptConn = node.Attributes[TAG_VALUE].Value;
                }

                connStr = new SimpleConnStr();
                connStr.ConnStr = EncryptionUtil.Encryption.Decrypt(mEncryptConn);

                if (string.IsNullOrEmpty(connStr.ConnStr))
                {
                    txtTNSName.Text  = string.Empty;
                    txtUser.Text     = string.Empty;
                    txtPassword.Text = string.Empty;
                }
                else
                {
                    txtTNSName.Text  = connStr.DataSource;
                    txtUser.Text     = connStr.UserID;
                    txtPassword.Text = connStr.Password;
                }                
                
            }
            catch (Exception ex)
            {
                //lblStatusBASSnet.Text = DateTime.Now.ToString() + "\r\n" + ex.ToString();
            }
        }



    }
}
