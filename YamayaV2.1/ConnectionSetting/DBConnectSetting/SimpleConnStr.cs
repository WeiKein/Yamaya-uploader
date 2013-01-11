using System;
using System.Collections.Generic;
using System.Text;
using EncryptionUtil;
using System.Data.OracleClient;

namespace DBConnectSetting
{
    public class SimpleConnStr
    {
        public const string USERID     = "User ID";
        public const string PASSWORD   = "Password";
        public const string DATASOURCE = "Data Source";
        public const string DELIMIT    = ";";
        public const string EQUAL      = "=";

        protected string mUserID     = "";
        protected string mPwd        = "";
        protected string mDataSource = "";
        protected string mServer     = "";
        protected string mConnStr    = "";

        private const string CONNSTR = "User ID={0};Password={1};Data Source={2};Unicode=true";

        public SimpleConnStr()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string UserID
        {
            get
            {
                return mUserID;
            }
            set
            {
                mUserID = value;
            }
        }

        public string Password
        {
            get
            {
                return mPwd;
            }
            set
            {
                mPwd = value;
            }
        }

        public string DataSource
        {
            get
            {
                return mDataSource;
            }
            set
            {
                mDataSource = value;
            }
        }

        public string ConnStr
        {
            get
            {
                return mConnStr;
            }
            set
            {
                mConnStr = value;
                if (mConnStr.IndexOf(PASSWORD) == -1)
                {
                    if (!string.IsNullOrEmpty(mConnStr))
                    {
                        mConnStr = EncryptionUtil.Encryption.Decrypt(mConnStr);
                        decode();
                    }
                }
                else
                {
                    decode();
                }
            }
        }

        public string ConnStrCypher
        {
            get
            {
                return EncryptionUtil.Encryption.Encrypt(mConnStr);
            }
        }


        public void decode()
        {

            string[] conn = ConnStr.Split(DELIMIT.ToCharArray());

            foreach (string str in conn)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    string key = str.Split(EQUAL.ToCharArray())[0];
                    string val = str.Split(EQUAL.ToCharArray())[1];

                    if (key.ToUpper() == DATASOURCE.ToUpper())
                        DataSource = val;
                    else if (key.ToUpper() == PASSWORD.ToUpper())
                        Password = val;
                    else if (key.ToUpper() == USERID.ToUpper())
                        UserID = val;
                }
            }
        }

        public string encode()
        {
            return mConnStr = string.Format(CONNSTR, UserID, Password, DataSource);
        }

        public void test()
        {
            OracleConnection conn = new OracleConnection(ConnStr);
            conn.Open();
            conn.Close();

        }

        public override string ToString()
        {
            return mConnStr;
        }
    }
}
