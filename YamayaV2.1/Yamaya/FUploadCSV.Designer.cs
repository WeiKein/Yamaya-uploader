namespace Yamaya
{
    partial class FUploadCSV
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbItemDesc = new System.Windows.Forms.RadioButton();
            this.rbItem = new System.Windows.Forms.RadioButton();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.rbArea = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel (CSV) File :";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(106, 69);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(401, 20);
            this.txtInputFile.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(513, 67);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(192, 95);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(273, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Done";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbItemDesc);
            this.groupBox1.Controls.Add(this.rbItem);
            this.groupBox1.Controls.Add(this.rbCategory);
            this.groupBox1.Controls.Add(this.rbArea);
            this.groupBox1.Location = new System.Drawing.Point(15, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 48);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // rbItemDesc
            // 
            this.rbItemDesc.AutoSize = true;
            this.rbItemDesc.Location = new System.Drawing.Point(260, 19);
            this.rbItemDesc.Name = "rbItemDesc";
            this.rbItemDesc.Size = new System.Drawing.Size(101, 17);
            this.rbItemDesc.TabIndex = 3;
            this.rbItemDesc.TabStop = true;
            this.rbItemDesc.Tag = "ITEM_DESC";
            this.rbItemDesc.Text = "Item Description";
            this.rbItemDesc.UseVisualStyleBackColor = true;
            this.rbItemDesc.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbItem
            // 
            this.rbItem.AutoSize = true;
            this.rbItem.Location = new System.Drawing.Point(179, 19);
            this.rbItem.Name = "rbItem";
            this.rbItem.Size = new System.Drawing.Size(56, 17);
            this.rbItem.TabIndex = 2;
            this.rbItem.TabStop = true;
            this.rbItem.Tag = "ITEM";
            this.rbItem.Text = "Item(s)";
            this.rbItem.UseVisualStyleBackColor = true;
            this.rbItem.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(93, 19);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(67, 17);
            this.rbCategory.TabIndex = 1;
            this.rbCategory.TabStop = true;
            this.rbCategory.Tag = "CATEGORY";
            this.rbCategory.Text = "Category";
            this.rbCategory.UseVisualStyleBackColor = true;
            this.rbCategory.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbArea
            // 
            this.rbArea.AutoSize = true;
            this.rbArea.Location = new System.Drawing.Point(17, 19);
            this.rbArea.Name = "rbArea";
            this.rbArea.Size = new System.Drawing.Size(47, 17);
            this.rbArea.TabIndex = 0;
            this.rbArea.TabStop = true;
            this.rbArea.Tag = "AREA";
            this.rbArea.Text = "Area";
            this.rbArea.UseVisualStyleBackColor = true;
            this.rbArea.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FUploadCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 131);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FUploadCSV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbItem;
        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.RadioButton rbArea;
        private System.Windows.Forms.RadioButton rbItemDesc;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}