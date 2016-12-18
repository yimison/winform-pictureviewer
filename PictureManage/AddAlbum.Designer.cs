namespace PictureManage
{
    partial class AddAlbum
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
            this.txbAlbumName = new System.Windows.Forms.TextBox();
            this.btnAddAlbum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "相册名称:";
            // 
            // txbAlbumName
            // 
            this.txbAlbumName.Location = new System.Drawing.Point(52, 98);
            this.txbAlbumName.Name = "txbAlbumName";
            this.txbAlbumName.Size = new System.Drawing.Size(211, 21);
            this.txbAlbumName.TabIndex = 1;
            // 
            // btnAddAlbum
            // 
            this.btnAddAlbum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddAlbum.Location = new System.Drawing.Point(293, 98);
            this.btnAddAlbum.Name = "btnAddAlbum";
            this.btnAddAlbum.Size = new System.Drawing.Size(75, 23);
            this.btnAddAlbum.TabIndex = 2;
            this.btnAddAlbum.Text = "新增";
            this.btnAddAlbum.UseVisualStyleBackColor = true;
            this.btnAddAlbum.Click += new System.EventHandler(this.btnAddAlbum_Click);
            // 
            // AddAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 191);
            this.Controls.Add(this.btnAddAlbum);
            this.Controls.Add(this.txbAlbumName);
            this.Controls.Add(this.label1);
            this.Name = "AddAlbum";
            this.Text = "新建相册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAlbumName;
        private System.Windows.Forms.Button btnAddAlbum;
    }
}