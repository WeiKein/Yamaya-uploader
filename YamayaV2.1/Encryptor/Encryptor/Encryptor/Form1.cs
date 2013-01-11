using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Encryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = txtValue.Text;
            string output = Security.Encrypt(input);

            txtValue.Text = output;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string input = txtValue.Text;
            string output = Security.Decrypt(input);

            txtValue.Text = output;
        }
    }
}
