using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Yamaya
{
    public partial class FUploadYamaya : Form
    {
        public FUploadYamaya()
        {
            InitializeComponent();
        }

        private void FUploadYamaya_Load(object sender, EventArgs e)
        {
            cboTarget.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtPath.Text = string.Join("|", openFileDialog1.FileNames);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Please select at least one file", "Yamaya FTP Files Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (var filePath in openFileDialog1.FileNames)
            {
                if (getBatchDate(filePath) == DateTime.MinValue)
                {
                    MessageBox.Show("File Name must contains YYYMMDD numeric", "Yamaya FTP Files Upload",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Initializing UI
            Enabled = false;

            // Loop each file and upload
            var conn = new Connector();
            var i = 0;
            foreach (var filePath in openFileDialog1.FileNames)
            {
                // Get Date
                conn.BatchDate = getBatchDate(filePath);

                // Update Hearder
                i++;
                Text = string.Format("Yamaya Files Upload - Uploading File {0}/{1}", i, openFileDialog1.FileNames.Length);
                Application.DoEvents();

                // Upload
                switch (cboTarget.SelectedIndex)
                {
                    case 0:
                        conn.Run(Connector.FileType.Transaction, filePath);
                        break;
                    case 1:
                        conn.Run(Connector.FileType.Store, filePath);
                        break;
                    case 2:
                        conn.Run(Connector.FileType.Item, filePath);
                        break;
                }
            }

            // Complete Upload
            Text = string.Format("Yamaya Files Upload - Upload Completed {0}/{1}", i, openFileDialog1.FileNames.Length);
            Application.DoEvents();
            Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DateTime getBatchDate(string filePath)
        {
            // Contains YYYYMMDD?
            string strYMD = Regex.Match(Connector.GetFileName(filePath), @"\d+").Value;
            if (string.IsNullOrEmpty(strYMD))
                return DateTime.MinValue;

            // Is correct YYYYMMDD?
            DateTime dtBatch;
            try
            {
                dtBatch = DateTime.ParseExact(strYMD, "yyyyMMdd",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None);
            }
            catch
            {
                return DateTime.MinValue;
            }

            // Return value
            return dtBatch;
        }

    }
}
