namespace Yamaya
{
    partial class FYamaya
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FYamaya));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout4 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout5 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout6 = new Janus.Windows.GridEX.GridEXLayout();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmniExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmniCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnUploadYamaya = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabYamaya = new Janus.Windows.UI.Tab.UITab();
            this.tabPageArea = new Janus.Windows.UI.Tab.UITabPage();
            this.gridEXArea = new Janus.Windows.GridEX.GridEX();
            this.tabPageStore = new Janus.Windows.UI.Tab.UITabPage();
            this.gridEXStore = new Janus.Windows.GridEX.GridEX();
            this.tabPageCategory = new Janus.Windows.UI.Tab.UITabPage();
            this.gridEXCategory = new Janus.Windows.GridEX.GridEX();
            this.tabPageItem = new Janus.Windows.UI.Tab.UITabPage();
            this.gridEXItem = new Janus.Windows.GridEX.GridEX();
            this.tabPageItemDesc = new Janus.Windows.UI.Tab.UITabPage();
            this.gridEXItemDesc = new Janus.Windows.GridEX.GridEX();
            this.tabPageStoreHistory = new Janus.Windows.UI.Tab.UITabPage();
            this.gridEXStoreHistory = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabYamaya)).BeginInit();
            this.tabYamaya.SuspendLayout();
            this.tabPageArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXArea)).BeginInit();
            this.tabPageStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXStore)).BeginInit();
            this.tabPageCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXCategory)).BeginInit();
            this.tabPageItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXItem)).BeginInit();
            this.tabPageItemDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXItemDesc)).BeginInit();
            this.tabPageStoreHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXStoreHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmniExpand,
            this.tsmniCollapse,
            this.toolStripSeparator1,
            this.tsmniDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 76);
            // 
            // tsmniExpand
            // 
            this.tsmniExpand.Name = "tsmniExpand";
            this.tsmniExpand.Size = new System.Drawing.Size(119, 22);
            this.tsmniExpand.Text = "Expand";
            this.tsmniExpand.Click += new System.EventHandler(this.tsmniExpand_Click);
            // 
            // tsmniCollapse
            // 
            this.tsmniCollapse.Name = "tsmniCollapse";
            this.tsmniCollapse.Size = new System.Drawing.Size(119, 22);
            this.tsmniCollapse.Text = "Collapse";
            this.tsmniCollapse.Click += new System.EventHandler(this.tsmniCollapse_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // tsmniDelete
            // 
            this.tsmniDelete.Name = "tsmniDelete";
            this.tsmniDelete.Size = new System.Drawing.Size(119, 22);
            this.tsmniDelete.Text = "Delete";
            this.tsmniDelete.Click += new System.EventHandler(this.tsmniDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(799, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(3);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSave,
            this.tsbtnCancel,
            this.tsbtnRefresh,
            this.tsbtnUpload,
            this.toolStripSeparator2,
            this.tsbtnUploadYamaya});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(799, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Enabled = false;
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(51, 22);
            this.tsbtnSave.Text = "Save";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnCancel
            // 
            this.tsbtnCancel.Enabled = false;
            this.tsbtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCancel.Image")));
            this.tsbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCancel.Name = "tsbtnCancel";
            this.tsbtnCancel.Size = new System.Drawing.Size(63, 22);
            this.tsbtnCancel.Text = "Cancel";
            this.tsbtnCancel.Click += new System.EventHandler(this.tsbtnCancel_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnUpload
            // 
            this.tsbtnUpload.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUpload.Image")));
            this.tsbtnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUpload.Name = "tsbtnUpload";
            this.tsbtnUpload.Size = new System.Drawing.Size(110, 22);
            this.tsbtnUpload.Text = "Upload CSV File";
            this.tsbtnUpload.Click += new System.EventHandler(this.tsbtnUpload_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnUploadYamaya
            // 
            this.tsbtnUploadYamaya.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUploadYamaya.Image")));
            this.tsbtnUploadYamaya.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUploadYamaya.Name = "tsbtnUploadYamaya";
            this.tsbtnUploadYamaya.Size = new System.Drawing.Size(136, 22);
            this.tsbtnUploadYamaya.Text = "Upload Yamaya Files";
            this.tsbtnUploadYamaya.Click += new System.EventHandler(this.tsbtnUploadYamaya_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabYamaya);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(799, 520);
            this.splitContainer1.SplitterDistance = 449;
            this.splitContainer1.TabIndex = 4;
            // 
            // tabYamaya
            // 
            this.tabYamaya.Controls.Add(this.tabPageArea);
            this.tabYamaya.Controls.Add(this.tabPageStore);
            this.tabYamaya.Controls.Add(this.tabPageCategory);
            this.tabYamaya.Controls.Add(this.tabPageItem);
            this.tabYamaya.Controls.Add(this.tabPageItemDesc);
            this.tabYamaya.Controls.Add(this.tabPageStoreHistory);
            this.tabYamaya.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabYamaya.Location = new System.Drawing.Point(0, 0);
            this.tabYamaya.Name = "tabYamaya";
            this.tabYamaya.Size = new System.Drawing.Size(799, 520);
            this.tabYamaya.TabIndex = 1;
            this.tabYamaya.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabPageArea,
            this.tabPageStore,
            this.tabPageCategory,
            this.tabPageItem,
            this.tabPageItemDesc,
            this.tabPageStoreHistory});
            this.tabYamaya.TabStripOffset = 3;
            this.tabYamaya.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            this.tabYamaya.SelectedTabChanged += new Janus.Windows.UI.Tab.TabEventHandler(this.uiTab1_SelectedTabChanged);
            // 
            // tabPageArea
            // 
            this.tabPageArea.Controls.Add(this.gridEXArea);
            this.tabPageArea.Key = "AREA";
            this.tabPageArea.Location = new System.Drawing.Point(1, 22);
            this.tabPageArea.Name = "tabPageArea";
            this.tabPageArea.Size = new System.Drawing.Size(797, 497);
            this.tabPageArea.TabIndex = 0;
            this.tabPageArea.Text = "Area";
            // 
            // gridEXArea
            // 
            this.gridEXArea.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXArea.AlternatingColors = true;
            this.gridEXArea.ColumnAutoResize = true;
            this.gridEXArea.ContextMenuStrip = this.contextMenuStrip1;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridEXArea.DesignTimeLayout = gridEXLayout1;
            this.gridEXArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEXArea.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular;
            this.gridEXArea.EmptyRows = true;
            this.gridEXArea.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEXArea.Location = new System.Drawing.Point(0, 0);
            this.gridEXArea.Name = "gridEXArea";
            this.gridEXArea.RecordNavigator = true;
            this.gridEXArea.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXArea.Size = new System.Drawing.Size(797, 497);
            this.gridEXArea.TabIndex = 1;
            this.gridEXArea.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gridEXArea_UpdatingCell);
            this.gridEXArea.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXArea_UpdatingRecord);
            this.gridEXArea.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXArea_AddingRecord);
            // 
            // tabPageStore
            // 
            this.tabPageStore.Controls.Add(this.gridEXStore);
            this.tabPageStore.Key = "STORE";
            this.tabPageStore.Location = new System.Drawing.Point(1, 22);
            this.tabPageStore.Name = "tabPageStore";
            this.tabPageStore.Size = new System.Drawing.Size(797, 497);
            this.tabPageStore.TabIndex = 1;
            this.tabPageStore.Text = "Store Size";
            // 
            // gridEXStore
            // 
            this.gridEXStore.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXStore.AlternatingColors = true;
            this.gridEXStore.ColumnAutoResize = true;
            this.gridEXStore.ContextMenuStrip = this.contextMenuStrip1;
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridEXStore.DesignTimeLayout = gridEXLayout2;
            this.gridEXStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEXStore.EmptyRows = true;
            this.gridEXStore.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEXStore.Location = new System.Drawing.Point(0, 0);
            this.gridEXStore.Name = "gridEXStore";
            this.gridEXStore.RecordNavigator = true;
            this.gridEXStore.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXStore.Size = new System.Drawing.Size(797, 497);
            this.gridEXStore.TabIndex = 0;
            this.gridEXStore.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gridEXStore_UpdatingCell);
            this.gridEXStore.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXStore_UpdatingRecord);
            this.gridEXStore.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXStore_AddingRecord);
            // 
            // tabPageCategory
            // 
            this.tabPageCategory.Controls.Add(this.gridEXCategory);
            this.tabPageCategory.Key = "CATEGORY";
            this.tabPageCategory.Location = new System.Drawing.Point(1, 22);
            this.tabPageCategory.Name = "tabPageCategory";
            this.tabPageCategory.Size = new System.Drawing.Size(797, 497);
            this.tabPageCategory.TabIndex = 2;
            this.tabPageCategory.Text = "Catecory Code";
            // 
            // gridEXCategory
            // 
            this.gridEXCategory.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXCategory.AlternatingColors = true;
            this.gridEXCategory.ColumnAutoResize = true;
            this.gridEXCategory.ContextMenuStrip = this.contextMenuStrip1;
            gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
            this.gridEXCategory.DesignTimeLayout = gridEXLayout3;
            this.gridEXCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEXCategory.EmptyRows = true;
            this.gridEXCategory.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEXCategory.Location = new System.Drawing.Point(0, 0);
            this.gridEXCategory.Name = "gridEXCategory";
            this.gridEXCategory.RecordNavigator = true;
            this.gridEXCategory.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXCategory.Size = new System.Drawing.Size(797, 497);
            this.gridEXCategory.TabIndex = 1;
            this.gridEXCategory.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gridEXCategory_UpdatingCell);
            this.gridEXCategory.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXCategory_UpdatingRecord);
            this.gridEXCategory.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXCategory_AddingRecord);
            // 
            // tabPageItem
            // 
            this.tabPageItem.Controls.Add(this.gridEXItem);
            this.tabPageItem.Key = "ITEM";
            this.tabPageItem.Location = new System.Drawing.Point(1, 22);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Size = new System.Drawing.Size(797, 497);
            this.tabPageItem.TabIndex = 3;
            this.tabPageItem.Text = "Item";
            // 
            // gridEXItem
            // 
            this.gridEXItem.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXItem.AlternatingColors = true;
            this.gridEXItem.ColumnAutoResize = true;
            this.gridEXItem.ContextMenuStrip = this.contextMenuStrip1;
            gridEXLayout4.LayoutString = resources.GetString("gridEXLayout4.LayoutString");
            this.gridEXItem.DesignTimeLayout = gridEXLayout4;
            this.gridEXItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEXItem.EmptyRows = true;
            this.gridEXItem.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEXItem.Location = new System.Drawing.Point(0, 0);
            this.gridEXItem.Name = "gridEXItem";
            this.gridEXItem.RecordNavigator = true;
            this.gridEXItem.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXItem.Size = new System.Drawing.Size(797, 497);
            this.gridEXItem.TabIndex = 1;
            this.gridEXItem.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gridEXItem_UpdatingCell);
            this.gridEXItem.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXItem_UpdatingRecord);
            this.gridEXItem.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXItem_AddingRecord);
            // 
            // tabPageItemDesc
            // 
            this.tabPageItemDesc.Controls.Add(this.gridEXItemDesc);
            this.tabPageItemDesc.Key = "ITEM_DESC";
            this.tabPageItemDesc.Location = new System.Drawing.Point(1, 22);
            this.tabPageItemDesc.Name = "tabPageItemDesc";
            this.tabPageItemDesc.Size = new System.Drawing.Size(797, 497);
            this.tabPageItemDesc.TabIndex = 4;
            this.tabPageItemDesc.Text = "Item Description";
            // 
            // gridEXItemDesc
            // 
            this.gridEXItemDesc.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXItemDesc.AlternatingColors = true;
            this.gridEXItemDesc.ColumnAutoResize = true;
            this.gridEXItemDesc.ContextMenuStrip = this.contextMenuStrip1;
            gridEXLayout5.LayoutString = resources.GetString("gridEXLayout5.LayoutString");
            this.gridEXItemDesc.DesignTimeLayout = gridEXLayout5;
            this.gridEXItemDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEXItemDesc.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular;
            this.gridEXItemDesc.EmptyRows = true;
            this.gridEXItemDesc.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEXItemDesc.Location = new System.Drawing.Point(0, 0);
            this.gridEXItemDesc.Name = "gridEXItemDesc";
            this.gridEXItemDesc.RecordNavigator = true;
            this.gridEXItemDesc.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXItemDesc.Size = new System.Drawing.Size(797, 497);
            this.gridEXItemDesc.TabIndex = 1;
            this.gridEXItemDesc.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gridEXItemDesc_UpdatingCell);
            this.gridEXItemDesc.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXItemDesc_UpdatingRecord);
            this.gridEXItemDesc.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXItemDesc_AddingRecord);
            // 
            // tabPageStoreHistory
            // 
            this.tabPageStoreHistory.Controls.Add(this.gridEXStoreHistory);
            this.tabPageStoreHistory.Key = "STORE_HISTORY";
            this.tabPageStoreHistory.Location = new System.Drawing.Point(1, 22);
            this.tabPageStoreHistory.Name = "tabPageStoreHistory";
            this.tabPageStoreHistory.Size = new System.Drawing.Size(797, 497);
            this.tabPageStoreHistory.TabIndex = 5;
            this.tabPageStoreHistory.Text = "Store History";
            // 
            // gridEXStoreHistory
            // 
            this.gridEXStoreHistory.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXStoreHistory.AlternatingColors = true;
            this.gridEXStoreHistory.ContextMenuStrip = this.contextMenuStrip1;
            gridEXLayout6.LayoutString = resources.GetString("gridEXLayout6.LayoutString");
            this.gridEXStoreHistory.DesignTimeLayout = gridEXLayout6;
            this.gridEXStoreHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEXStoreHistory.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular;
            this.gridEXStoreHistory.EmptyRows = true;
            this.gridEXStoreHistory.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEXStoreHistory.Location = new System.Drawing.Point(0, 0);
            this.gridEXStoreHistory.Name = "gridEXStoreHistory";
            this.gridEXStoreHistory.RecordNavigator = true;
            this.gridEXStoreHistory.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEXStoreHistory.Size = new System.Drawing.Size(797, 497);
            this.gridEXStoreHistory.TabIndex = 2;
            this.gridEXStoreHistory.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gridEXStoreHistory_UpdatingCell);
            this.gridEXStoreHistory.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXStoreHistory_UpdatingRecord);
            this.gridEXStoreHistory.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gridEXStoreHistory_AddingRecord);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 46);
            this.panel1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FYamaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 567);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FYamaya";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yamaya";
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabYamaya)).EndInit();
            this.tabYamaya.ResumeLayout(false);
            this.tabPageArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEXArea)).EndInit();
            this.tabPageStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEXStore)).EndInit();
            this.tabPageCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEXCategory)).EndInit();
            this.tabPageItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEXItem)).EndInit();
            this.tabPageItemDesc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEXItemDesc)).EndInit();
            this.tabPageStoreHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEXStoreHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnUpload;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnCancel;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmniDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmniExpand;
        private System.Windows.Forms.ToolStripMenuItem tsmniCollapse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Janus.Windows.UI.Tab.UITab tabYamaya;
        private Janus.Windows.UI.Tab.UITabPage tabPageArea;
        private Janus.Windows.GridEX.GridEX gridEXArea;
        private Janus.Windows.UI.Tab.UITabPage tabPageStore;
        private Janus.Windows.GridEX.GridEX gridEXStore;
        private Janus.Windows.UI.Tab.UITabPage tabPageCategory;
        private Janus.Windows.GridEX.GridEX gridEXCategory;
        private Janus.Windows.UI.Tab.UITabPage tabPageItem;
        private Janus.Windows.GridEX.GridEX gridEXItem;
        private Janus.Windows.UI.Tab.UITabPage tabPageItemDesc;
        private Janus.Windows.GridEX.GridEX gridEXItemDesc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnUploadYamaya;
        private Janus.Windows.UI.Tab.UITabPage tabPageStoreHistory;
        private Janus.Windows.GridEX.GridEX gridEXStoreHistory;


    }
}

