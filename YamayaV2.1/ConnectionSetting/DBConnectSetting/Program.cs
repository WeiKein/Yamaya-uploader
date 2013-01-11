using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBConnectSetting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MLogin mLogin = new MLogin();
            bool secPass  = mLogin.login();

            if (secPass)
            {
                Application.Run(new FDBConnectSetting());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
