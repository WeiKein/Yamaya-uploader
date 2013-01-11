using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace Yamaya
{
    class DBUtil
    {

        #region Declaration

        public const string FIELD_TABLE_NAME = "TABLE_NAME";
        public const string FIELD_UPDATE_KEY = "UPDATE_KEY";
        public const string FIELD_UPDATE_VALUE = "UPDATE_VALUE";
        private static String ConnString { get; set; }
        public static String TNS
        {
            get
            {
                var tns = string.Empty;
                if (string.IsNullOrEmpty(ConnString))
                    ConnString = GetConnectionString();

                var strConn = ConnString.Split(';');
                foreach (var s in strConn)
                {
                    if (!s.ToUpper().Trim().Contains("DATA SOURCE"))
                        continue;
                    tns = s.Substring(s.IndexOf('=') + 1);
                    break;
                }
                return tns;
            }
        }
        public static String UserID
        {
            get
            {
                var uID = string.Empty;
                if (string.IsNullOrEmpty(ConnString))
                    ConnString = GetConnectionString();

                var strConn = ConnString.Split(';');
                foreach (var s in strConn)
                {
                    if (!s.ToUpper().Trim().Contains("USER ID"))
                        continue;
                    uID = s.Substring(s.IndexOf('=') + 1);
                    break;
                }
                return uID;
            }
        }
        public static String Password
        {
            get
            {
                var pwd = string.Empty;
                if (string.IsNullOrEmpty(ConnString))
                    ConnString = GetConnectionString();

                var strConn = ConnString.Split(';');
                foreach (var s in strConn)
                {
                    if (!s.ToUpper().Trim().Contains("PASSWORD"))
                        continue;
                    pwd = s.Substring(s.IndexOf('=') + 1);
                    break;
                }
                return pwd;
            }
        }

        #endregion

        #region Get Statement

        public static string GetInsertStmt(Dictionary<string, string> inputs)
        {
            if (inputs == null || inputs.Count <= 1 || !inputs.ContainsKey(FIELD_TABLE_NAME))
                return null;

            // Basic Statement
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("INSERT INTO {0} (", inputs[FIELD_TABLE_NAME]));

            // Columns Name
            foreach (KeyValuePair<string, string> item in inputs)
            {
                if (item.Key == FIELD_TABLE_NAME)
                    continue;

                str.Append(string.Format("{0},", item.Key));
            }

            //Remove last "," and continue
            str.Remove(str.Length - 1, 1);
            str.Append(") VALUES (");

            // Columns Value
            foreach (KeyValuePair<string, string> item in inputs)
            {
                if (item.Key == FIELD_TABLE_NAME)
                    continue;

                str.Append(string.Format("{0},", item.Value));
            }

            //Remove last "," and complete
            str.Remove(str.Length - 1, 1);
            str.Append(")");

            // Return Final Statement
            return str.ToString();
        }

        public static string GetUpdateStmt(Dictionary<string, string> inputs)
        {
            if (inputs == null || inputs.Count <= 1 || !inputs.ContainsKey(FIELD_TABLE_NAME) || !inputs.ContainsKey(FIELD_UPDATE_KEY) || !inputs.ContainsKey(FIELD_UPDATE_VALUE))
                return null;

            // Basic Statement
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("UPDATE {0} SET ", inputs[FIELD_TABLE_NAME]));

            // Columns Name
            foreach (KeyValuePair<string, string> item in inputs)
            {
                if (item.Key == FIELD_TABLE_NAME || item.Key == FIELD_UPDATE_KEY || item.Key == FIELD_UPDATE_VALUE)
                    continue;

                str.Append(string.Format("{0}={1},", item.Key, item.Value));
            }

            //Remove last "," and continue
            str.Remove(str.Length - 1, 1);
            str.Append(string.Format(" WHERE {0}={1}", inputs[FIELD_UPDATE_KEY], inputs[FIELD_UPDATE_VALUE]));

            // Return Final Statement
            return str.ToString();
        }

        #endregion

        #region Execute Command

        public static int ExecuteNonQuery(string stmt, OleDbTransaction oTran)
        {
            OleDbCommand oCmd = oTran.Connection.CreateCommand();
            oCmd.CommandText = stmt;
            oCmd.Transaction = oTran;
            return oCmd.ExecuteNonQuery();
        }

        #endregion

        #region Function

        public static OleDbConnection OpenConnection()
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            conn.Open();
            return conn;
        }

        private static string GetConnectionString()
        {
            return string.Format("Provider=msdaora;{0}", EncryptionUtil.Encryption.Decrypt(ConfigurationManager.AppSettings["DBConn"].ToString()));
        }

        public static string ToSQLValue(object obj)
        {
            string SQL_NULL = "NULL";

            TypeCode objType = Type.GetTypeCode(obj.GetType());
            switch (objType)
            {
                case TypeCode.String:
                    string str = SafeConvert.ToString(obj);
                    if (str == string.Empty)
                        return SQL_NULL;
                    else
                        return String.Format("'{0}'", SafeConvert.ToString(obj).Replace("'", "''"));

                case TypeCode.DateTime:
                    DateTime dt = SafeConvert.ToDateTime(obj);
                    if (dt == DateTime.MinValue)
                        return SQL_NULL;
                    else
                        return String.Format("TO_DATE('{0}', 'yyyy-MM-dd')", dt.ToString("yyyy-MM-dd"));

                case TypeCode.Boolean:
                    bool b = SafeConvert.ToBoolean(obj);
                    if (b)
                        return "-1";
                    else
                        return "0";

                case TypeCode.Int16:
                    return SafeConvert.ToInt(obj).ToString("#0");
                case TypeCode.Int32:
                    return SafeConvert.ToInt(obj).ToString("#0");
                case TypeCode.Int64:
                    return SafeConvert.ToInt(obj).ToString("#0");

                case TypeCode.Double:
                case TypeCode.Decimal:
                    decimal dcm = SafeConvert.ToDecimal(obj);
                    return dcm.ToString("#0.00");

                default:
                    return SQL_NULL;
            }
        }

        #endregion
    }
}
