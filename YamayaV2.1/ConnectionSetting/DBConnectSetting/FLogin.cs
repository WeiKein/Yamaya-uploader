using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace DBConnectSetting
{
    public partial class FLogin : Form
    {
        #region Contants

        private const int MAX_RETRY = 3;

        #endregion

        #region Local Declaration

        private int mRetryCounter;
        private bool mSecurityPass;

        #endregion

        public bool SecurityPass
        {
            get { return mSecurityPass; }
        }

        #region Public
        public FLogin()
        {
            InitializeComponent();
            mRetryCounter = MAX_RETRY;
        } 
        #endregion

        #region Private
        private void login()
        {
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Please enter password to login.", "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            string mPassword = ConfigurationManager.AppSettings[MLogin.KEY_PASSWORD].ToString();

            if (string.IsNullOrEmpty(mPassword))
            {
                mPassword = string.Empty;
            }
            else
            {
                mPassword = EncryptionUtil.Encryption.Decrypt(mPassword);
            }

            Cursor = Cursors.WaitCursor;

            mSecurityPass = (txtPassword.Text == mPassword);

            if (!mSecurityPass)
            {
                if (--mRetryCounter == 0)
                {
                    MessageBox.Show(string.Format("Invalid Password.  You have exceeded {0} login retry privilege.\r\n\r\nThe program will terminate now.", MAX_RETRY - 1), "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                MessageBox.Show(string.Format("Invalid Password, Please try to login again.\r\n\r\nYou have only {0} more retry left.", mRetryCounter), "DBConnection Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            this.Close();
        } 
        #endregion

        #region Events
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FChangePassword mFChangePassword = new FChangePassword();
            mFChangePassword.ShowDialog();            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                login();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
        
    }
}
