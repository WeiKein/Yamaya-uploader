using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FileHelpers;
using FileHelpers.DataLink;

namespace Yamaya
{
    public partial class FUploadCSV : Form
    {
        public delegate void onSuccessUploadEvent(string Module);
        public onSuccessUploadEvent onSuccessUpload;

        private const string FILE_TYPE = "Microsoft Excel CSV (*.csv)|*.csv";
        private string mSelectedTable  = string.Empty;
        private string mSelectedModule = string.Empty;
        private string mDBConn         = string.Empty;

        public FUploadCSV()
        {
            InitializeComponent();
        }

        public void init(string input, string DBConn)
        {
            mDBConn = DBConn;

            switch (input)
            {
                case FYamaya.TAB_KEY_AREA:
                    rbArea.Checked = true;
                    break;

                case FYamaya.TAB_KEY_CATEGORY:
                    rbCategory.Checked = true;
                    break;

                case FYamaya.TAB_KEY_ITEM:
                    rbItem.Checked = true;
                    break;

                case FYamaya.TAB_KEY_ITEM_DESC:
                    rbItemDesc.Checked = true;
                    break;

                default:
                    rbArea.Checked = true;
                    break;
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInputFile.Text))
                {
                    return;
                }

                string message = string.Format("Do you want to upload {0} from file: \r\n{1}", mSelectedTable, txtInputFile.Text);

                DialogResult result = MessageBox.Show(message, "Information", MessageBoxButtons.OKCancel);

                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;

                this.Cursor       = Cursors.WaitCursor;
                List<string> rows = new List<string>();
 
                //StreamReader reader = new StreamReader(txtInputFile.Text, Encoding.GetEncoding("Shift-JIS"));

                FileHelperEngine engine = null;
                switch (mSelectedModule)
                {
                    case FYamaya.TAB_KEY_AREA:
                        engine = new FileHelperEngine(typeof(AreaMapping), Encoding.GetEncoding("Shift-JIS"));
                        break;

                    case FYamaya.TAB_KEY_CATEGORY:
                        engine = new FileHelperEngine(typeof(CategoryMapping), Encoding.GetEncoding("Shift-JIS"));
                        break;

                    case FYamaya.TAB_KEY_ITEM:
                        engine = new FileHelperEngine(typeof(ItemMapping), Encoding.GetEncoding("Shift-JIS"));
                        break;

                    case FYamaya.TAB_KEY_ITEM_DESC:
                        engine = new FileHelperEngine(typeof(ItemDescMapping), Encoding.GetEncoding("Shift-JIS"));
                        break;

                    default:
                        break;
                }

                // to Read use:
                DataTable dt = engine.ReadFileAsDT(txtInputFile.Text);

                ProgessStatus mFProgessStatus = new ProgessStatus();
                mFProgessStatus.uploadAreaCSV(dt, mSelectedModule, mDBConn);
                DialogResult dresult = mFProgessStatus.ShowDialog();

                if (dresult == System.Windows.Forms.DialogResult.Yes)
                {
                    MessageBox.Show("Successfully upload record to database!", "Upload CSV File", MessageBoxButtons.OK);
                    onSuccessUpload(mSelectedModule);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter   = FILE_TYPE;
            openFileDialog1.FileName = txtInputFile.Text;

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtInputFile.Text = openFileDialog1.FileName;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked) return;

            switch (rb.Tag.ToString())
            {
                case FYamaya.TAB_KEY_AREA:
                    rbArea.Checked  = true;
                    mSelectedModule = FYamaya.TAB_KEY_AREA;
                    mSelectedTable  = "[Area]";
                    break;

                case FYamaya.TAB_KEY_CATEGORY:
                    rbCategory.Checked = true;
                    mSelectedModule = FYamaya.TAB_KEY_CATEGORY;
                    mSelectedTable = "[Category]";
                    break;

                case FYamaya.TAB_KEY_ITEM:
                    rbItem.Checked = true;
                    mSelectedModule = FYamaya.TAB_KEY_ITEM;
                    mSelectedTable = "[Item]";
                    break;

                case FYamaya.TAB_KEY_ITEM_DESC:
                    rbItemDesc.Checked = true;
                    mSelectedModule = FYamaya.TAB_KEY_ITEM_DESC;
                    mSelectedTable = "[Item Description]";
                    break;

                default:
                    rbArea.Checked  = true;
                    mSelectedModule = FYamaya.TAB_KEY_AREA;
                    mSelectedTable  = "[Area]";
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DelimitedRecord(",")]
        public class AreaMapping
        {
            public string AreaCode;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string PEnglish;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string PJapanese;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string AEnglish;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string AJapanese;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string DEnglish;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string DJapanese;
        }

        [DelimitedRecord(",")]
        public class CategoryMapping
        {
            public string CategoryCode;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string DEnglish;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string DJapanese;
        }

        [DelimitedRecord(",")]
        public class ItemMapping
        {
            public string ItemCode;

            public string Brand;

            public string SubBrand;

            public string ItemClass;

            public string WineColor;

            public string CountryOriginal;

            public string ItemCategory;

            public string ItemAuthentiCity;

            public string ItemSubClass;
        }

        [DelimitedRecord(",")]
        public class ItemDescMapping
        {
            public string ItemCategory;

            public string Sequence;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string ICDJapanese;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string ICDEnglish;
        }

        [DelimitedRecord(",")]
        public class StoreMapping
        {
            public string StoreSize;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string SSDJapanese;

            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            [FieldOptional]
            public string SSDEnglish;
        }

    }
}
