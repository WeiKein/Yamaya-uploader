using System;
using System.Data;
using System.Data.OracleClient;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Yamaya
{
    public partial class ProgessStatus : Form
    {
        #region Declaration
        DataTable mDataTable;
        string mModule;
        string mDBConnection;

        int mRowCount = 0;

        IDbConnection iConn = null;
        IDbTransaction iTran = null;

        #endregion



        #region Constructor
        public ProgessStatus()
        {
            InitializeComponent();
        } 
        #endregion




        #region BackGroudWorker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string stmtUpdate = string.Empty;
            string stmtInsert = string.Empty;
            BYamaya mBYamaya = new BYamaya();

            switch (mModule)
            {
                case BYamaya.TAB_KEY_AREA:
                    stmtUpdate = YamayaStmt.UPD_AREA_DATA;
                    stmtInsert = YamayaStmt.INS_AREA_DATA;
                    break;

                case BYamaya.TAB_KEY_CATEGORY:
                    stmtUpdate = YamayaStmt.UPD_CATEGROY_DATA;
                    stmtInsert = YamayaStmt.INS_CATEGORY_DATA;
                    break;

                case BYamaya.TAB_KEY_ITEM:
                    stmtUpdate = YamayaStmt.UPD_ITEM_DATA;
                    stmtInsert = YamayaStmt.INS_ITEM_DATA;
                    break;

                case BYamaya.TAB_KEY_ITEM_DESC:
                    stmtUpdate = YamayaStmt.UPD_ITEMDESC_DATA;
                    stmtInsert = YamayaStmt.INS_ITEMDESC_DATA;
                    break;

            }

            iConn = new OracleConnection(mDBConnection);
            iConn.Open();
            iTran = iConn.BeginTransaction();


            int columnLength = mDataTable.Columns.Count;
            string stmt      = string.Empty;

            mRowCount = mDataTable.Rows.Count;
            if (mRowCount == 0)
                return;

            string[] value = new string[columnLength];

            for (int a = 1; a < mRowCount; a++)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                DataRow row = mDataTable.Rows[a];
                for (int b = 0; b < value.Length; b++)
                {
                    string temp   = string.Empty;
                    string actual = string.Empty;

                    if (b == 0)
                    {
                        temp = row[b].ToString();
                        //if (temp.Length == 1)
                        //    actual = string.Empty;
                        //else
                        //    actual = temp.Substring(1, (temp.Length - 1));
                        if (temp.Length == 0)
                            actual = string.Empty;
                        else
                            actual = temp;
                    }
                    else if (b == (value.Length - 1))
                    {
                        temp = row[b].ToString();
                        //if (temp.Length == 1)
                        //    actual = string.Empty;
                        //else
                        //    actual = temp.Substring(0, (temp.Length - 1));
                        if (temp.Length == 0)
                            actual = string.Empty;
                        else
                            actual = temp;
                    }
                    else
                    {
                        actual = row[b].ToString();
                    }

                    value[b] = actual.Trim().Replace("'", "''"); ;
                }

                stmt = string.Format(stmtUpdate, value);
                int i = mBYamaya.executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                if (i == 0)
                {
                    stmt = string.Format(stmtInsert, value);
                    mBYamaya.executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                }

                //System.Threading.Thread.Sleep(100);
                backgroundWorker1.ReportProgress(a);
            }

            switch (mModule)
            {
                case BYamaya.TAB_KEY_AREA:
                    mBYamaya.UpdateAreaMapping(iTran);
                    break;

                case BYamaya.TAB_KEY_CATEGORY:
                    mBYamaya.UpdateCategoryMapping(iTran);
                    break;

                case BYamaya.TAB_KEY_ITEM:
                    mBYamaya.UpdateItemMapping(iTran);
                    break;

                case BYamaya.TAB_KEY_ITEM_DESC:
                    mBYamaya.UpdateItemDescMapping(iTran);
                    break;

            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled == true)
            {
                if (iTran != null)
                    iTran.Rollback();
            }
            else if (e.Error != null)
            {
                if (iTran != null)
                    iTran.Rollback();

                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
            else
            {
                if (iTran != null)
                    iTran.Commit();
            }


            if (iConn != null)
                iConn.Close();

            if (e.Cancelled == false && e.Error == null)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { SuccessCloseFrom(); }));
                }
                else
                {
                    SuccessCloseFrom();
                }
            }


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Min((((100 * e.ProgressPercentage) / (mRowCount - 1))), 100);
            lblRecordStatus.Text = string.Format("({0}/{1})", e.ProgressPercentage.ToString(), (mRowCount - 1).ToString());
        }

        private void ProgessStatus_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ProgessStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        #endregion



        #region Upload From CSV

        public void uploadAreaCSV(DataTable dt, string module, string DBConnection)
        {
            mDataTable    = dt;
            mModule       = module;
            mDBConnection = DBConnection;
        }

        private void SuccessCloseFrom()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void FailCloseFrom()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Close();
        }

        #endregion

   

    }
}
