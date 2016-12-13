namespace PictureViewer
{
    partial class Frm_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Setting));
            this.chkPNG = new System.Windows.Forms.CheckBox();
            this.chkGIF = new System.Windows.Forms.CheckBox();
            this.chkJPG = new System.Windows.Forms.CheckBox();
            this.chkBMP = new System.Windows.Forms.CheckBox();
            this.btnAssociatedFileType = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAutoClearTemp = new System.Windows.Forms.CheckBox();
            this.btnSetTempPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.dgvSkin = new System.Windows.Forms.DataGridView();
            this.DGV_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSettingSkin = new System.Windows.Forms.Button();
            this.btnClearSkin = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkin)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkPNG
            // 
            this.chkPNG.AutoSize = true;
            this.chkPNG.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPNG.Location = new System.Drawing.Point(15, 24);
            this.chkPNG.Name = "chkPNG";
            this.chkPNG.Size = new System.Drawing.Size(42, 16);
            this.chkPNG.TabIndex = 0;
            this.chkPNG.Text = "PNG";
            this.chkPNG.UseVisualStyleBackColor = true;
            // 
            // chkGIF
            // 
            this.chkGIF.AutoSize = true;
            this.chkGIF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGIF.Location = new System.Drawing.Point(175, 24);
            this.chkGIF.Name = "chkGIF";
            this.chkGIF.Size = new System.Drawing.Size(42, 16);
            this.chkGIF.TabIndex = 1;
            this.chkGIF.Text = "GIF";
            this.chkGIF.UseVisualStyleBackColor = true;
            // 
            // chkJPG
            // 
            this.chkJPG.AutoSize = true;
            this.chkJPG.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkJPG.Location = new System.Drawing.Point(253, 24);
            this.chkJPG.Name = "chkJPG";
            this.chkJPG.Size = new System.Drawing.Size(42, 16);
            this.chkJPG.TabIndex = 2;
            this.chkJPG.Text = "JPG";
            this.chkJPG.UseVisualStyleBackColor = true;
            // 
            // chkBMP
            // 
            this.chkBMP.AutoSize = true;
            this.chkBMP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBMP.Location = new System.Drawing.Point(95, 24);
            this.chkBMP.Name = "chkBMP";
            this.chkBMP.Size = new System.Drawing.Size(42, 16);
            this.chkBMP.TabIndex = 3;
            this.chkBMP.Text = "BMP";
            this.chkBMP.UseVisualStyleBackColor = true;
            // 
            // btnAssociatedFileType
            // 
            this.btnAssociatedFileType.Location = new System.Drawing.Point(314, 20);
            this.btnAssociatedFileType.Name = "btnAssociatedFileType";
            this.btnAssociatedFileType.Size = new System.Drawing.Size(40, 23);
            this.btnAssociatedFileType.TabIndex = 4;
            this.btnAssociatedFileType.Text = "设置";
            this.btnAssociatedFileType.UseVisualStyleBackColor = true;
            this.btnAssociatedFileType.Click += new System.EventHandler(this.btnAssociatedFileType_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.chkPNG);
            this.groupBox1.Controls.Add(this.btnAssociatedFileType);
            this.groupBox1.Controls.Add(this.chkGIF);
            this.groupBox1.Controls.Add(this.chkBMP);
            this.groupBox1.Controls.Add(this.chkJPG);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 56);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件关联";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.ForeColor = System.Drawing.Color.Blue;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(359, 25);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 12);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "可能需要管理员权限";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAutoClearTemp);
            this.groupBox2.Controls.Add(this.btnSetTempPath);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 76);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "缓存设置(GIF转成单张PNG)";
            // 
            // chkAutoClearTemp
            // 
            this.chkAutoClearTemp.AutoSize = true;
            this.chkAutoClearTemp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoClearTemp.Location = new System.Drawing.Point(15, 47);
            this.chkAutoClearTemp.Name = "chkAutoClearTemp";
            this.chkAutoClearTemp.Size = new System.Drawing.Size(132, 16);
            this.chkAutoClearTemp.TabIndex = 5;
            this.chkAutoClearTemp.Text = "退出时自动清除缓存";
            this.chkAutoClearTemp.UseVisualStyleBackColor = true;
            this.chkAutoClearTemp.Click += new System.EventHandler(this.chkAutoClearTemp_Click);
            // 
            // btnSetTempPath
            // 
            this.btnSetTempPath.Location = new System.Drawing.Point(432, 18);
            this.btnSetTempPath.Name = "btnSetTempPath";
            this.btnSetTempPath.Size = new System.Drawing.Size(40, 23);
            this.btnSetTempPath.TabIndex = 5;
            this.btnSetTempPath.Text = "设置";
            this.btnSetTempPath.UseVisualStyleBackColor = true;
            this.btnSetTempPath.Click += new System.EventHandler(this.btnSetTempPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(50, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(376, 21);
            this.txtPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "位置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picBox);
            this.groupBox3.Controls.Add(this.dgvSkin);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(484, 230);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "皮肤设置";
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(98, 17);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(328, 210);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 3;
            this.picBox.TabStop = false;
            // 
            // dgvSkin
            // 
            this.dgvSkin.AllowUserToAddRows = false;
            this.dgvSkin.AllowUserToDeleteRows = false;
            this.dgvSkin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSkin.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSkin.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSkin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGV_Name,
            this.DGV_Path});
            this.dgvSkin.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvSkin.Location = new System.Drawing.Point(3, 17);
            this.dgvSkin.MultiSelect = false;
            this.dgvSkin.Name = "dgvSkin";
            this.dgvSkin.ReadOnly = true;
            this.dgvSkin.RowHeadersVisible = false;
            this.dgvSkin.RowTemplate.Height = 23;
            this.dgvSkin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSkin.Size = new System.Drawing.Size(95, 210);
            this.dgvSkin.TabIndex = 2;
            this.dgvSkin.TabStop = false;
            this.dgvSkin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSkin_CellClick);
            // 
            // DGV_Name
            // 
            this.DGV_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGV_Name.HeaderText = "皮肤名称";
            this.DGV_Name.Name = "DGV_Name";
            this.DGV_Name.ReadOnly = true;
            this.DGV_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DGV_Path
            // 
            this.DGV_Path.HeaderText = "皮肤路径";
            this.DGV_Path.Name = "DGV_Path";
            this.DGV_Path.ReadOnly = true;
            this.DGV_Path.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSettingSkin);
            this.panel1.Controls.Add(this.btnClearSkin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(426, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 210);
            this.panel1.TabIndex = 1;
            // 
            // btnSettingSkin
            // 
            this.btnSettingSkin.Location = new System.Drawing.Point(6, 178);
            this.btnSettingSkin.Name = "btnSettingSkin";
            this.btnSettingSkin.Size = new System.Drawing.Size(40, 23);
            this.btnSettingSkin.TabIndex = 7;
            this.btnSettingSkin.Text = "设置";
            this.btnSettingSkin.UseVisualStyleBackColor = true;
            this.btnSettingSkin.Click += new System.EventHandler(this.btnSettingSkin_Click);
            // 
            // btnClearSkin
            // 
            this.btnClearSkin.Location = new System.Drawing.Point(6, 149);
            this.btnClearSkin.Name = "btnClearSkin";
            this.btnClearSkin.Size = new System.Drawing.Size(40, 23);
            this.btnClearSkin.TabIndex = 6;
            this.btnClearSkin.Text = "清除";
            this.btnClearSkin.UseVisualStyleBackColor = true;
            this.btnClearSkin.Click += new System.EventHandler(this.btnClearSkin_Click);
            // 
            // Frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Frm_Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPNG;
        private System.Windows.Forms.CheckBox chkGIF;
        private System.Windows.Forms.CheckBox chkJPG;
        private System.Windows.Forms.CheckBox chkBMP;
        private System.Windows.Forms.Button btnAssociatedFileType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAutoClearTemp;
        private System.Windows.Forms.Button btnSetTempPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSettingSkin;
        private System.Windows.Forms.Button btnClearSkin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.DataGridView dgvSkin;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_Path;
    }
}