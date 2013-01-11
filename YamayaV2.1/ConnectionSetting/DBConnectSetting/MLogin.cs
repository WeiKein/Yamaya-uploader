using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DBConnectSetting
{
    class MLogin
    {
        public const string KEY_PASSWORD = "Password";

        private FLogin mFLogin;

        public bool login()
        {
            try
            {
                mFLogin = new FLogin();
                mFLogin.ShowDialog();
                return mFLogin.SecurityPass;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
