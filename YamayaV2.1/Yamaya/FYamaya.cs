using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.IO;
using System.Configuration;


using Janus.Windows.GridEX;
using EncryptionUtil;

namespace Yamaya
{
    public partial class FYamaya : Form
    {
        private TextBox txtCustom = new TextBox();

        public const string TAB_KEY_AREA          = "AREA";
        public const string TAB_KEY_STORE         = "STORE";
        public const string TAB_KEY_CATEGORY      = "CATEGORY";
        public const string TAB_KEY_ITEM          = "ITEM";
        public const string TAB_KEY_ITEM_DESC     = "ITEM_DESC";
        public const string TAB_KEY_STORE_HISTORY = "STORE_HISTORY";
        
        private DataTable dtArea     = null;
        private DataTable dtCategory = null;
        private DataTable dtStore    = null;
        private DataTable dtItem     = null;
        private DataTable dtItemDesc = null;
        private DataTable dtStoreHis = null;

        //private DataSet ds = new DataSet();

        private string mConnString = EncryptionUtil.Encryption.Decrypt(ConfigurationManager.AppSettings["DBConn"].ToString());

        public FYamaya()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            tsbtnSave.Enabled   = false;
            tsbtnCancel.Enabled = false;
        }



        #region GridEX Event
        private void gridEX_InitCustomEdit(object sender, InitCustomEditEventArgs e)
        {
            txtCustom.ReadOnly = false;

            string column = e.Column.Key;
            
            //When the user start edition by pressing a key, the EditChar
            //property holds the char that started the edition. If edition
            //was started because the user clicked in the cell the EditChar
            //returns (char)0
            if (e.EditChar != (char)0 && !txtCustom.ReadOnly)
            {
                txtCustom.Text = e.EditChar.ToString();
                txtCustom.SelectionStart = txtCustom.Text.Length;
            }
            else
            {
                if (e.Value == null)
                {
                    txtCustom.Text = "";
                }
                else
                {
                    txtCustom.Text = e.Value.ToString();
                }

                txtCustom.SelectionLength = txtCustom.Text.Length;
            }
            //Set the EditControl property to let the GridEX control
            //know which control to position in the cell.
            e.EditControl = txtCustom;
        }

        private void gridEX_EndCustomEdit(object sender, EndCustomEditEventArgs e)
        {
            //Compare the original value with the value in the control.
            if (e.Value == null || txtCustom.Text.CompareTo(e.Value.ToString()) != 0)
            {
                //If the value is different, set the DataChanged property to true
                //to indicate the control that it has to update the cell value.
                e.DataChanged = true;
                e.Value = txtCustom.Text;
            }
        }

        //private void gridEX_AddingRecord(object sender, CancelEventArgs e)
        //{

        //    tsbtnSave.Enabled    = true;
        //    tsbtnCancel.Enabled  = true;
        //    tsbtnUpload.Enabled  = false;
        //    tsbtnRefresh.Enabled = false;
        //}

        //private void gridEX_UpdatingRecord(object sender, CancelEventArgs e)
        //{
        //    tsbtnSave.Enabled = true;
        //    tsbtnCancel.Enabled = true;
        //    tsbtnUpload.Enabled = false;
        //    tsbtnRefresh.Enabled = false;
        //}

        #endregion




        #region Private
        private void refreshGrid(GridEX gridEx, DataTable dt)
        {
            gridEx.DataSource = dt;
        }

        private Dictionary<string, DataTable> setSaveDataTableValue()
        {
            Dictionary<string, DataTable> dic = new Dictionary<string, DataTable>();
            if (dtArea != null && dtArea.GetChanges() != null)
                dic.Add(TAB_KEY_AREA, dtArea);

            if (dtCategory != null && dtCategory.GetChanges() != null)
                dic.Add(TAB_KEY_CATEGORY, dtCategory);

            if (dtStore != null && dtStore.GetChanges() != null)
                dic.Add(TAB_KEY_STORE, dtStore);

            if (dtItem != null && dtItem.GetChanges() != null)
                dic.Add(TAB_KEY_ITEM, dtItem);

            if (dtItemDesc != null && dtItemDesc.GetChanges() != null)
                dic.Add(TAB_KEY_ITEM_DESC, dtItemDesc);

            if (dtStoreHis != null && dtStoreHis.GetChanges() != null)
                dic.Add(TAB_KEY_STORE_HISTORY, dtStoreHis);

            return dic;
        }

        private void focusTabUpdate()
        {
            switch (tabYamaya.SelectedTab.Key)
            {
                case TAB_KEY_AREA:
                    if (gridEXArea.Focused)
                    {
                        if (!gridEXArea.UpdateData())
                            return;
                    }
                    break;

                case TAB_KEY_CATEGORY:
                    if (gridEXCategory.Focused)
                    {
                        if (!gridEXCategory.UpdateData())
                            return;
                    }
                    break;

                case TAB_KEY_STORE:
                    if (gridEXStore.Focused)
                    {
                        if (!gridEXStore.UpdateData())
                            return;
                    }
                    break;

                case TAB_KEY_ITEM:
                    if (gridEXItem.Focused)
                    {
                        if (!gridEXItem.UpdateData())
                            return;
                    }
                    break;

                case TAB_KEY_ITEM_DESC:
                    if (gridEXItemDesc.Focused)
                    {
                        if (!gridEXItemDesc.UpdateData())
                            return;
                    }
                    break;

                case TAB_KEY_STORE_HISTORY:
                    if (gridEXStoreHistory.Focused)
                    {
                        if (!gridEXStoreHistory.UpdateData())
                            return;
                    }
                    break;

                default:
                    break;

            }
        }

        private void setToolBarButton()
        {
            tsbtnSave.Enabled    = true;
            tsbtnCancel.Enabled  = true;
            tsbtnUpload.Enabled  = false;
            tsbtnRefresh.Enabled = false;
        }

        private void deleteRecord(string module, string column, GridEXRow row, GridEX gridEX)
        {
            string value = row.Cells[column].Text;
            DataRow[] mDataRow = ((DataTable)gridEX.DataSource).Select(string.Format("{0} = '{1}'", column, value));
            if (mDataRow.Length > 0)
            {
                DataRow dr = mDataRow[0];
                if (dr.RowState == DataRowState.Added)
                {
                    switch (module)
                    {
                        case TAB_KEY_AREA:
                            dtArea.Rows.Remove(dr);
                            break;

                        case TAB_KEY_CATEGORY:
                            dtCategory.Rows.Remove(dr);
                            break;

                        case TAB_KEY_STORE:
                            dtStore.Rows.Remove(dr);
                            break;

                        case TAB_KEY_ITEM:
                            dtItem.Rows.Remove(dr);
                            break;

                        case TAB_KEY_ITEM_DESC:
                            dtItemDesc.Rows.Remove(dr);
                            break;

                        case TAB_KEY_STORE_HISTORY:
                            dtStoreHis.Rows.Remove(dr);
                            break;

                        default:
                            return;
                    }
                }
                else
                {
                    dr["REC_DELETED"] = 1;
                }

            }
        } 
        #endregion



        #region Button Strip Function
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                focusTabUpdate();

                BYamaya mBYamaya = new BYamaya();
                mBYamaya.saveRecords(setSaveDataTableValue(), mConnString);

                if (dtArea != null)
                {
                    dtArea.AcceptChanges();
                    gridEXArea.Refetch();
                }

                if (dtStore != null)
                {
                    dtStore.AcceptChanges();
                    gridEXStore.Refetch();
                }

                if (dtCategory != null)
                {
                    dtCategory.AcceptChanges();
                    gridEXCategory.Refetch();
                }

                if (dtItem != null)
                {
                    dtItem.AcceptChanges();
                    gridEXItem.Refetch();
                }

                if (dtItemDesc != null)
                {
                    dtItemDesc.AcceptChanges();
                    gridEXItemDesc.Refetch();
                }

                if (dtStoreHis != null)
                {
                    dtStoreHis.AcceptChanges();
                    gridEXStoreHistory.Refetch();
                }

                tsbtnSave.Enabled    = false;
                tsbtnCancel.Enabled  = false;
                tsbtnUpload.Enabled  = true;
                tsbtnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            if (dtArea != null)
            {
                dtArea.RejectChanges();
                gridEXArea.Refetch();
                gridEXArea.Refresh();
            }

            if (dtCategory != null)
            {
                dtCategory.RejectChanges();
                gridEXCategory.Refetch();
                gridEXCategory.Refresh();
            }

            if (dtStore != null)
            {
                dtStore.RejectChanges();
                gridEXStore.Refetch();
                gridEXStore.Refresh();
            }

            if (dtItem != null)
            {
                dtItem.RejectChanges();
                gridEXItem.Refetch();
                gridEXItem.Refresh();
            }

            if (dtItemDesc != null)
            {
                dtItemDesc.RejectChanges();
                gridEXItemDesc.Refetch();
                gridEXItemDesc.Refresh();
            }


            tsbtnSave.Enabled    = false;
            tsbtnCancel.Enabled  = false;
            tsbtnUpload.Enabled  = true;
            tsbtnRefresh.Enabled = true;
            focusTabUpdate();

        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            focusTabUpdate();
            refreshScreen(tabYamaya.SelectedTab.Key);
        }

        private void tsbtnUpload_Click(object sender, EventArgs e)
        {
            focusTabUpdate();

            if (tsbtnSave.Enabled == true)
                return;

            FUploadCSV mForm = new FUploadCSV();
            try
            {                
                mForm.init(tabYamaya.SelectedTab.Key, mConnString);
                mForm.onSuccessUpload += new FUploadCSV.onSuccessUploadEvent(onSuccessUpload);
                mForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                if(mForm.onSuccessUpload != null)
                    mForm.onSuccessUpload -= new FUploadCSV.onSuccessUploadEvent(onSuccessUpload);
            }
            
        }

        private void onSuccessUpload(string Module)
        {
            refreshScreen(Module);
        }

        private void refreshScreen(string module)
        {
            BYamaya mBYamaya = new BYamaya();
            switch (module)
            {
                case TAB_KEY_AREA:
                    if (dtArea == null || dtArea.GetChanges() == null)
                    {
                        refreshGrid(gridEXArea, dtArea = mBYamaya.getAreaDT(mConnString));

                        //if (!ds.Tables.Contains(TAB_KEY_AREA))
                        //    ds.Tables.Add(dtArea);
                    }
                    break;

                case TAB_KEY_CATEGORY:
                    if (dtCategory == null || dtCategory.GetChanges() == null)
                    {
                        refreshGrid(gridEXCategory, dtCategory = mBYamaya.getCategoryDT(mConnString));

                        //if (!ds.Tables.Contains(TAB_KEY_CATEGORY))
                        //    ds.Tables.Add(dtCategory);
                    }
                    break;

                case TAB_KEY_STORE:
                    if (dtStore == null || dtStore.GetChanges() == null)
                    {
                        refreshGrid(gridEXStore, dtStore = mBYamaya.getStoreDT(mConnString));

                        //if (!ds.Tables.Contains(TAB_KEY_STORE))
                        //    ds.Tables.Add(dtStore);
                    }
                    break;

                case TAB_KEY_ITEM:
                    if (dtItem == null || dtItem.GetChanges() == null)
                    {
                        refreshGrid(gridEXItem, dtItem = mBYamaya.getItemDT(mConnString));

                        //if (!ds.Tables.Contains(TAB_KEY_ITEM))
                        //    ds.Tables.Add(dtItem);
                    }
                    break;

                case TAB_KEY_ITEM_DESC:
                    if (dtItemDesc == null || dtItemDesc.GetChanges() == null)
                    {
                        refreshGrid(gridEXItemDesc, dtItemDesc = mBYamaya.getItemDescDT(mConnString));

                        //if (!ds.Tables.Contains(TAB_KEY_ITEM_DESC))
                        //    ds.Tables.Add(dtItemDesc);
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion



        #region Events
        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            try
            {
                if (tsbtnSave.Enabled == false)
                {
                    if (e.Page.Key == TAB_KEY_STORE || e.Page.Key == TAB_KEY_STORE_HISTORY)
                    {
                        tsbtnUpload.Enabled = false;
                    }
                    else
                    {
                        tsbtnUpload.Enabled = true;
                    }
                }

                BYamaya mBYamaya = new BYamaya();
                switch (e.Page.Key)
                {
                    case TAB_KEY_AREA:
                        if (dtArea == null || dtArea.GetChanges() == null)
                        {
                            refreshGrid(gridEXArea, dtArea = mBYamaya.getAreaDT(mConnString));
                        }
                        break;

                    case TAB_KEY_CATEGORY:
                        if (dtCategory == null || dtCategory.GetChanges() == null)
                        {
                            refreshGrid(gridEXCategory, dtCategory = mBYamaya.getCategoryDT(mConnString));
                        }
                        break;

                    case TAB_KEY_STORE:
                        if (dtStore == null || dtStore.GetChanges() == null)
                        {
                            refreshGrid(gridEXStore, dtStore = mBYamaya.getStoreDT(mConnString));
                        }
                        break;

                    case TAB_KEY_ITEM:
                        if (dtItem == null || dtItem.GetChanges() == null)
                        {
                            refreshGrid(gridEXItem, dtItem = mBYamaya.getItemDT(mConnString));
                        }
                        break;

                    case TAB_KEY_ITEM_DESC:
                        if (dtItemDesc == null || dtItemDesc.GetChanges() == null)
                        {
                            refreshGrid(gridEXItemDesc, dtItemDesc = mBYamaya.getItemDescDT(mConnString));
                        }
                        break;

                    case TAB_KEY_STORE_HISTORY:
                        if (dtStoreHis == null || dtStoreHis.GetChanges() == null)
                        {
                            refreshGrid(gridEXStoreHistory, dtStoreHis = mBYamaya.getStoreHistoryDT(mConnString));
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                tsbtnUpload.Enabled = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void tsmniDelete_Click(object sender, EventArgs e)
        {
            GridEX mGridEX = null;
            string mColumn = string.Empty;
            string mModule = tabYamaya.SelectedTab.Key;

            switch (mModule)
            {
                case TAB_KEY_AREA:
                    mGridEX = gridEXArea;
                    mColumn = "AREACODE";
                    break;

                case TAB_KEY_CATEGORY:
                    mGridEX = gridEXCategory;
                    mColumn = "CATEGORYCODE";
                    break;

                case TAB_KEY_STORE:
                    mGridEX = gridEXStore;
                    mColumn = "STORESIZE";
                    break;

                case TAB_KEY_ITEM:
                    mGridEX = gridEXItem;
                    mColumn = "ITEMCODE";
                    break;

                case TAB_KEY_ITEM_DESC:
                    mGridEX = gridEXItemDesc;
                    mColumn = "ITEMCATEGORY";
                    break;

                case TAB_KEY_STORE_HISTORY:
                    mGridEX = gridEXStoreHistory;
                    mColumn = "CHAINID";
                    break;

                default:
                    return;
            }


            GridEXRow row = mGridEX.GetRow();
            deleteRecord(mModule, mColumn, row, mGridEX);
            mGridEX.Update();
            mGridEX.Refresh();

            tsbtnSave.Enabled = true;
            tsbtnCancel.Enabled = true;
            tsbtnUpload.Enabled = false;
            tsbtnRefresh.Enabled = false;
        }

        private void tsmniCollapse_Click(object sender, EventArgs e)
        {
            GridEX mGridEX = null;
            switch (tabYamaya.SelectedTab.Key)
            {
                case TAB_KEY_AREA:
                    mGridEX = gridEXArea;
                    break;

                case TAB_KEY_CATEGORY:
                    mGridEX = gridEXCategory;
                    break;

                case TAB_KEY_STORE:
                    mGridEX = gridEXStore;
                    break;

                case TAB_KEY_ITEM:
                    mGridEX = gridEXItem;
                    break;

                case TAB_KEY_ITEM_DESC:
                    mGridEX = gridEXItemDesc;
                    break;

                case TAB_KEY_STORE_HISTORY:
                    mGridEX = gridEXStoreHistory;
                    break;

                default:
                    return;
            }

            if (mGridEX.RootTable.Groups.Count > 0)
                mGridEX.CollapseGroups();
        }

        private void tsmniExpand_Click(object sender, EventArgs e)
        {
            GridEX mGridEX = null;
            switch (tabYamaya.SelectedTab.Key)
            {
                case TAB_KEY_AREA:
                    mGridEX = gridEXArea;
                    break;

                case TAB_KEY_CATEGORY:
                    mGridEX = gridEXCategory;
                    break;

                case TAB_KEY_STORE:
                    mGridEX = gridEXStore;
                    break;

                case TAB_KEY_ITEM:
                    mGridEX = gridEXItem;
                    break;

                case TAB_KEY_ITEM_DESC:
                    mGridEX = gridEXItemDesc;
                    break;

                case TAB_KEY_STORE_HISTORY:
                    mGridEX = gridEXStoreHistory;
                    break;

                default:
                    return;
            }

            if (mGridEX.RootTable.Groups.Count > 0)
                mGridEX.ExpandGroups();
        }

        private void tsbtnUploadYamaya_Click(object sender, EventArgs e)
        {
            var f = new FUploadYamaya();
            f.ShowDialog();
        } 
        #endregion

        

        #region GridEX Event

        private void gridEXArea_AddingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXArea.GetRow();
            if (row.RowType != RowType.NewRecord)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["AREACODE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Area Code]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtArea.Select(string.Format("AREACODE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                DataRow dr = result[0];
                dr["AREACODE"]           = row.Cells["AREACODE"].Value;
                dr["PREFECTUREJAPANESE"] = row.Cells["PREFECTUREJAPANESE"].Value;
                dr["PREFECTUREENGLISH"]  = row.Cells["PREFECTUREENGLISH"].Value;
                dr["AREAJAPANESE"]       = row.Cells["AREAJAPANESE"].Value;
                dr["AREAENGLISH"]        = row.Cells["AREAENGLISH"].Value;
                dr["DISTRICTJAPANESE"]   = row.Cells["DISTRICTJAPANESE"].Value;
                dr["DISTRICTENGLISH"]    = row.Cells["DISTRICTENGLISH"].Value;
                dr["REC_DELETED"]        = 0;

                gridEXArea.CancelCurrentEdit();
            }

            setToolBarButton();
        }

        private void gridEXArea_UpdatingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXArea.GetRow();
            if (row.RowType != RowType.Record)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["AREACODE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Area Code]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtArea.Select(string.Format("AREACODE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                //Update the record to deleted code
                DataRow dr               = result[0];
                //dr["AREACODE"]           = row.Cells["AREACODE"].Value;
                dr["PREFECTUREJAPANESE"] = row.Cells["PREFECTUREJAPANESE"].Value;
                dr["PREFECTUREENGLISH"]  = row.Cells["PREFECTUREENGLISH"].Value;
                dr["AREAJAPANESE"]       = row.Cells["AREAJAPANESE"].Value;
                dr["AREAENGLISH"]        = row.Cells["AREAENGLISH"].Value;
                dr["DISTRICTJAPANESE"]   = row.Cells["DISTRICTJAPANESE"].Value;
                dr["DISTRICTENGLISH"]    = row.Cells["DISTRICTENGLISH"].Value;
                dr["REC_DELETED"]        = 0;
                gridEXArea.CancelCurrentEdit();

                //Mark the current record as deleted.
                row.Cells["REC_DELETED"].Value = 1;
                
            }

            setToolBarButton();
        }

        private void gridEXArea_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key != "AREACODE")
                return;

            string value = e.Value.ToString();
            DataRow[] result = dtArea.Select(string.Format("AREACODE = '{0}' AND (REC_DELETED <> 1 OR REC_DELETED IS NULL)", value));
            if (result.Length > 0)
            {
                MessageBox.Show("Duplicated [Area Code].\r\nPlease try another value.", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }
        }



        private void gridEXStore_AddingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXStore.GetRow();
            if (row.RowType != RowType.NewRecord)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["STORESIZE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Store Size]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtStore.Select(string.Format("STORESIZE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                DataRow dr = result[0];
                dr["STORESIZE"]             = row.Cells["STORESIZE"].Value;
                dr["STORESIZEDESCJAPANESE"] = row.Cells["STORESIZEDESCJAPANESE"].Value;
                dr["STORESIZEDESCENGLISH"]  = row.Cells["STORESIZEDESCENGLISH"].Value;
                dr["REC_DELETED"]           = 0;

                gridEXStore.CancelCurrentEdit();
            }

            setToolBarButton();
        }

        private void gridEXStore_UpdatingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXStore.GetRow();
            if (row.RowType != RowType.Record)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["STORESIZE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Store Size]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtStore.Select(string.Format("STORESIZE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                //Update the record to deleted code
                DataRow dr = result[0];
                dr["STORESIZE"]             = row.Cells["STORESIZE"].Value;
                dr["STORESIZEDESCJAPANESE"] = row.Cells["STORESIZEDESCJAPANESE"].Value;
                dr["STORESIZEDESCENGLISH"]  = row.Cells["STORESIZEDESCENGLISH"].Value;
                dr["REC_DELETED"]           = 0;
                gridEXStore.CancelCurrentEdit();

                //Mark the current record as deleted.
                row.Cells["REC_DELETED"].Value = 1;
            }

            setToolBarButton();
        }

        private void gridEXStore_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key != "STORESIZE")
                return;

            string value = e.Value.ToString();
            DataRow[] result = dtStore.Select(string.Format("STORESIZE = '{0}' AND (REC_DELETED <> 1 OR REC_DELETED IS NULL)", value));
            if (result.Length > 0)
            {
                MessageBox.Show("Duplicated [Store Size].\r\nPlease try another value.", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }
        }



        private void gridEXCategory_AddingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXCategory.GetRow();
            if (row.RowType != RowType.NewRecord)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["CATEGORYCODE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Category Code]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtCategory.Select(string.Format("CATEGORYCODE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                DataRow dr = result[0];
                dr["CATEGORYCODE"]        = row.Cells["CATEGORYCODE"].Value;
                dr["DESCRIPTIONENGLISH"]  = row.Cells["DESCRIPTIONENGLISH"].Value;
                dr["DESCRIPTIONJAPANESE"] = row.Cells["DESCRIPTIONJAPANESE"].Value;
                dr["REC_DELETED"] = 0;

                gridEXCategory.CancelCurrentEdit();
            }

            setToolBarButton();
        }

        private void gridEXCategory_UpdatingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXCategory.GetRow();
            if (row.RowType != RowType.Record)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["CATEGORYCODE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Category Code]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtCategory.Select(string.Format("CATEGORYCODE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                //Update the record to deleted code
                DataRow dr = result[0];
                dr["CATEGORYCODE"]        = row.Cells["CATEGORYCODE"].Value;
                dr["DESCRIPTIONENGLISH"]  = row.Cells["DESCRIPTIONENGLISH"].Value;
                dr["DESCRIPTIONJAPANESE"] = row.Cells["DESCRIPTIONJAPANESE"].Value;
                dr["REC_DELETED"]         = 0;
                gridEXCategory.CancelCurrentEdit();

                //Mark the current record as deleted.
                row.Cells["REC_DELETED"].Value = 1;
            }

            setToolBarButton();
        }

        private void gridEXCategory_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key != "CATEGORYCODE")
                return;

            string value = e.Value.ToString();
            DataRow[] result = dtCategory.Select(string.Format("CATEGORYCODE = '{0}' AND (REC_DELETED <> 1 OR REC_DELETED IS NULL)", value));
            if (result.Length > 0)
            {
                MessageBox.Show("Duplicated [Category Code].\r\nPlease try another value.", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

        }



        private void gridEXItem_AddingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXItem.GetRow();
            if (row.RowType != RowType.NewRecord)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["ITEMCODE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Item Code]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtItem.Select(string.Format("ITEMCODE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                DataRow dr = result[0];
                dr["ITEMCODE"]         = row.Cells["ITEMCODE"].Value;
                dr["ITEMBRAND"]        = row.Cells["ITEMBRAND"].Value;
                dr["ITEMSUBBRAND"]     = row.Cells["ITEMSUBBRAND"].Value;
                //dr["ITEMWINETYPE"]     = row.Cells["ITEMWINETYPE"].Value;
                //dr["ITEMWINECOLOR"]    = row.Cells["ITEMWINECOLOR"].Value;
                dr["COUNTRYOFORIGIN"]  = row.Cells["COUNTRYOFORIGIN"].Value;
                dr["ITEMCATEGORY"]     = row.Cells["ITEMCATEGORY"].Value;
                dr["ITEMAUTHENTICITY"] = row.Cells["ITEMAUTHENTICITY"].Value;
                dr["REC_DELETED"] = 0;

                gridEXItem.CancelCurrentEdit();
            }

            setToolBarButton();
        }

        private void gridEXItem_UpdatingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXItem.GetRow();
            if (row.RowType != RowType.Record)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["ITEMCODE"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Item Code]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtItem.Select(string.Format("ITEMCODE = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                //Update the record to deleted code
                DataRow dr = result[0];
                dr["ITEMCODE"]         = row.Cells["ITEMCODE"].Value;
                dr["ITEMBRAND"]        = row.Cells["ITEMBRAND"].Value;
                dr["ITEMSUBBRAND"]     = row.Cells["ITEMSUBBRAND"].Value;
                //dr["ITEMWINETYPE"]     = row.Cells["ITEMWINETYPE"].Value;
                //dr["ITEMWINECOLOR"]    = row.Cells["ITEMWINECOLOR"].Value;
                dr["COUNTRYOFORIGIN"]  = row.Cells["COUNTRYOFORIGIN"].Value;
                dr["ITEMCATEGORY"]     = row.Cells["ITEMCATEGORY"].Value;
                dr["ITEMAUTHENTICITY"] = row.Cells["ITEMAUTHENTICITY"].Value;
                dr["REC_DELETED"] = 0;
                gridEXItem.CancelCurrentEdit();

                //Mark the current record as deleted.
                row.Cells["REC_DELETED"].Value = 1;
            }

            setToolBarButton();
        }

        private void gridEXItem_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key != "ITEMCODE")
                return;

            string value = e.Value.ToString();
            DataRow[] result = dtItem.Select(string.Format("ITEMCODE = '{0}' AND (REC_DELETED <> 1 OR REC_DELETED IS NULL)", value));
            if (result.Length > 0)
            {
                MessageBox.Show("Duplicated [Item Code].\r\nPlease try another value.", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

        }



        private void gridEXItemDesc_AddingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXItemDesc.GetRow();
            if (row.RowType != RowType.NewRecord)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["ITEMCATEGORY"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Item Brand Category]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtItemDesc.Select(string.Format("ITEMCATEGORY = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                DataRow dr = result[0];
                dr["ITEMCATEGORY"]             = row.Cells["ITEMCATEGORY"].Value;
                dr["ITEMSEQUENCE"]             = row.Cells["ITEMSEQUENCE"].Value;
                dr["ITEMCATEGORYDESCJAPANESE"] = row.Cells["ITEMCATEGORYDESCJAPANESE"].Value;
                dr["ITEMCATEGORYDESCENGLISH"]  = row.Cells["ITEMCATEGORYDESCENGLISH"].Value;
                dr["REC_DELETED"] = 0;

                gridEXItemDesc.CancelCurrentEdit();
            }

            setToolBarButton();
        }

        private void gridEXItemDesc_UpdatingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXItemDesc.GetRow();
            if (row.RowType != RowType.Record)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["ITEMCATEGORY"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Item Brand Category]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtItemDesc.Select(string.Format("ITEMCATEGORY = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                //Update the record to deleted code
                DataRow dr = result[0];
                dr["ITEMCATEGORY"] = row.Cells["ITEMCATEGORY"].Value;
                dr["ITEMSEQUENCE"] = row.Cells["ITEMSEQUENCE"].Value;
                dr["ITEMCATEGORYDESCJAPANESE"] = row.Cells["ITEMCATEGORYDESCJAPANESE"].Value;
                dr["ITEMCATEGORYDESCENGLISH"]  = row.Cells["ITEMCATEGORYDESCENGLISH"].Value;
                dr["REC_DELETED"]              = 0;
                gridEXItemDesc.CancelCurrentEdit();

                //Mark the current record as deleted.
                row.Cells["REC_DELETED"].Value = 1;
            }

            setToolBarButton();
        }      

        private void gridEXItemDesc_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key != "ITEMCATEGORY")
                return;

            string value = e.Value.ToString();
            DataRow[] result = dtItemDesc.Select(string.Format("ITEMCATEGORY = '{0}' AND (REC_DELETED <> 1 OR REC_DELETED IS NULL)", value));
            if (result.Length > 0)
            {
                MessageBox.Show("Duplicated [Item Brand Category].\r\nPlease try another value.", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

        }

        
        private void gridEXStoreHistory_AddingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXStoreHistory.GetRow();
            if (row.RowType != RowType.NewRecord)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["CHAINID"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Chain ID]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtStoreHis.Select(string.Format("CHAINID = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                DataRow dr = result[0];
                dr["CHAINID"] = row.Cells["CHAINID"].Value;
                dr["CHAINDESCRIPTION1"] = row.Cells["CHAINDESCRIPTION1"].Value;
                dr["CHAINDESCRIPTION2"] = row.Cells["CHAINDESCRIPTION2"].Value;
                dr["STORECODE"] = row.Cells["STORECODE"].Value;
                dr["STOREDESCRIPTION1"] = row.Cells["STOREDESCRIPTION1"].Value;
                dr["STOREDESCRIPTION2"] = row.Cells["STOREDESCRIPTION2"].Value;
                dr["STOREDESCRIPTION3"] = row.Cells["STOREDESCRIPTION3"].Value;
                dr["POSTALCODE"] = row.Cells["POSTALCODE"].Value;
                dr["ADDRESS1"] = row.Cells["ADDRESS1"].Value;
                dr["ADDRESS2"] = row.Cells["ADDRESS2"].Value;
                dr["TELEPHONE"] = row.Cells["TELEPHONE"].Value;
                dr["FAX"] = row.Cells["FAX"].Value;
                dr["STORESIZE"] = row.Cells["STORESIZE"].Value;
                dr["STORESIZEDESCRIPTION1"] = row.Cells["STORESIZEDESCRIPTION1"].Value;
                dr["STORESIZEDESCRIPTION2"] = row.Cells["STORESIZEDESCRIPTION2"].Value;
                dr["STOREFLOORSPACE"] = row.Cells["STOREFLOORSPACE"].Value;
                dr["PREFECTURECODE"] = row.Cells["PREFECTURECODE"].Value;
                dr["PREFECTUREDESCRIPTION1"] = row.Cells["PREFECTUREDESCRIPTION1"].Value;
                dr["PREFECTUREDESCRIPTION2"] = row.Cells["PREFECTUREDESCRIPTION2"].Value;
                dr["AREADESCRIPTION1"] = row.Cells["AREADESCRIPTION1"].Value;
                dr["AREADESCRIPTION2"] = row.Cells["AREADESCRIPTION2"].Value;
                dr["DISTRICTDESCRIPTION1"] = row.Cells["DISTRICTDESCRIPTION1"].Value;
                dr["DISTRICTDESCRIPTION2"] = row.Cells["DISTRICTDESCRIPTION2"].Value;
                dr["ANALYSIS1"] = row.Cells["ANALYSIS1"].Value;
                dr["ANALYSIS2"] = row.Cells["ANALYSIS2"].Value;
                dr["DATEOPEN"]    = row.Cells["DATEOPEN"].Value;
                dr["DATEUPDATED"] = row.Cells["DATEUPDATED"].Value;
                dr["REC_DELETED"] = 0;

                gridEXStoreHistory.CancelCurrentEdit();
            }

            setToolBarButton();
        }

        private void gridEXStoreHistory_UpdatingRecord(object sender, CancelEventArgs e)
        {
            GridEXRow row = gridEXStoreHistory.GetRow();
            if (row.RowType != RowType.Record)
            {
                e.Cancel = true;
                return;
            }

            string value = row.Cells["CHAINID"].Text;
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please insert value for [Chain ID]", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            DataRow[] result = dtStoreHis.Select(string.Format("CHAINID = '{0}' AND REC_DELETED = 1", value));
            if (result.Length > 0)
            {
                //Update the record to deleted code
                DataRow dr = result[0];
                dr["CHAINID"] = row.Cells["CHAINID"].Value;
                dr["CHAINDESCRIPTION1"] = row.Cells["CHAINDESCRIPTION1"].Value;
                dr["CHAINDESCRIPTION2"] = row.Cells["CHAINDESCRIPTION2"].Value;
                dr["STORECODE"] = row.Cells["STORECODE"].Value;
                dr["STOREDESCRIPTION1"] = row.Cells["STOREDESCRIPTION1"].Value;
                dr["STOREDESCRIPTION2"] = row.Cells["STOREDESCRIPTION2"].Value;
                dr["STOREDESCRIPTION3"] = row.Cells["STOREDESCRIPTION3"].Value;
                dr["POSTALCODE"] = row.Cells["POSTALCODE"].Value;
                dr["ADDRESS1"] = row.Cells["ADDRESS1"].Value;
                dr["ADDRESS2"] = row.Cells["ADDRESS2"].Value;
                dr["TELEPHONE"] = row.Cells["TELEPHONE"].Value;
                dr["FAX"] = row.Cells["FAX"].Value;
                dr["STORESIZE"] = row.Cells["STORESIZE"].Value;
                dr["STORESIZEDESCRIPTION1"] = row.Cells["STORESIZEDESCRIPTION1"].Value;
                dr["STORESIZEDESCRIPTION2"] = row.Cells["STORESIZEDESCRIPTION2"].Value;
                dr["STOREFLOORSPACE"] = row.Cells["STOREFLOORSPACE"].Value;
                dr["PREFECTURECODE"] = row.Cells["PREFECTURECODE"].Value;
                dr["PREFECTUREDESCRIPTION1"] = row.Cells["PREFECTUREDESCRIPTION1"].Value;
                dr["PREFECTUREDESCRIPTION2"] = row.Cells["PREFECTUREDESCRIPTION2"].Value;
                dr["AREADESCRIPTION1"] = row.Cells["AREADESCRIPTION1"].Value;
                dr["AREADESCRIPTION2"] = row.Cells["AREADESCRIPTION2"].Value;
                dr["DISTRICTDESCRIPTION1"] = row.Cells["DISTRICTDESCRIPTION1"].Value;
                dr["DISTRICTDESCRIPTION2"] = row.Cells["DISTRICTDESCRIPTION2"].Value;
                dr["ANALYSIS1"] = row.Cells["ANALYSIS1"].Value;
                dr["ANALYSIS2"] = row.Cells["ANALYSIS2"].Value;
                dr["DATEOPEN"] = row.Cells["DATEOPEN"].Value;
                dr["DATEUPDATED"] = row.Cells["DATEUPDATED"].Value;
                dr["REC_DELETED"] = 0;
                gridEXStoreHistory.CancelCurrentEdit();

                //Mark the current record as deleted.
                row.Cells["REC_DELETED"].Value = 1;
            }

            setToolBarButton();
        }

        private void gridEXStoreHistory_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key != "CHAINID")
                return;

            string value = e.Value.ToString();
            DataRow[] result = dtStoreHis.Select(string.Format("CHAINID = '{0}' AND (REC_DELETED <> 1 OR REC_DELETED IS NULL)", value));
            if (result.Length > 0)
            {
                MessageBox.Show("Duplicated [Chain ID].\r\nPlease try another value.", "Validation", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

        }

        #endregion

    }
}
