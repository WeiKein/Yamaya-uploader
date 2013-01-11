using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Configuration;
using System.IO;


namespace DBConnectSetting
{
    public partial class FChangePassword : Form
    {
        #region Constants
        private const int MAX_RETRY = 3;

        public const string BASSNETCONFIG_CONFIG_FILE = "DBConnectSetting.exe.config";
        private const string XPATH_FMT = "/configuration/appSettings/add[attribute::key='{0}']";
        private const string TAG_VALUE = "value";

        #endregion

        #region Declaration
        private int mChangePasswordRetryCounter;
        private string mFileLoc;
        #endregion

        #region Constructor
        public FChangePassword()
        {
            InitializeComponent();
            init();
        } 
        #endregion

        #region Private

        private void init()
        {
            mChangePasswordRetryCounter = MAX_RETRY;

            string path = Application.StartupPath;
            DirectoryInfo di      = new DirectoryInfo(path);
            FileSystemInfo[] dirs = di.GetFileSystemInfos(BASSNETCONFIG_CONFIG_FILE);

            if (dirs.Length > 0)
            {
                mFileLoc = dirs[0].FullName;
            }
        }

        private bool isValid()
        {
            if ((txtNewPassword.Text.Length > 0 || txtConfirmPassword.Text.Length > 0) && txtOldPassword.Text.Length == 0)
            {
                MessageBox.Show("You have to enter the OLD PASSWORD before you can change it to the new one.", "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text.Length == 0)
            {
                MessageBox.Show("You have to enter an valid new password. Please try again.", "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text == txtOldPassword.Text)
            {
                MessageBox.Show("New password is identical to old password.  Please enter password that is vary from the old password.", "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("The CONFIRM PASSWORD you have enter is not matching with the NEW PASSWORD.  Please try again.", "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;

        }

        private void change()
        {
            try
            {
                if (isValid() == false)
                    return;

                string mPassword = Properties.Settings.Default.Password;

                if (string.IsNullOrEmpty(mPassword))
                {
                    mPassword = string.Empty;
                }
                else
                {
                    mPassword = ConfigurationManager.AppSettings[MLogin.KEY_PASSWORD].ToString();
                }

                Cursor = Cursors.WaitCursor;

                bool mSecurityPass = (txtOldPassword.Text == mPassword);

                if (!mSecurityPass)
                {
                    if (--mChangePasswordRetryCounter == 0)
                    {
                        MessageBox.Show(string.Format("Invalid Old Password.  You have exceeded {0} change retry privilege.\r\n\r\nThe program will terminate now.", MAX_RETRY - 1), "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                    MessageBox.Show(string.Format("Invalid Old Password, Please try to change again.\r\n\r\nYou have only {0} more retry left.", mChangePasswordRetryCounter), "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOldPassword.Focus();
                    return;
                }

                XmlDocument mXml = new XmlDocument();
                XmlNode mNode = null;

                mXml.Load(mFileLoc);
                mNode = mXml.SelectSingleNode(string.Format(XPATH_FMT, MLogin.KEY_PASSWORD));
                mNode.Attributes[TAG_VALUE].Value = EncryptionUtil.Encryption.Encrypt(txtNewPassword.Text);
                mXml.Save(mFileLoc);
                ConfigurationManager.AppSettings[MLogin.KEY_PASSWORD] = EncryptionUtil.Encryption.Encrypt(txtNewPassword.Text);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            
        }
        #endregion

        private void btnChange_Click(object sender, EventArgs e)
        {
            change();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
