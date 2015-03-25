namespace frMain
{
    partial class frQuanLyLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frQuanLyLop));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboKhoi = new System.Windows.Forms.ComboBox();
            this.comboNam = new System.Windows.Forms.ComboBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btthem = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btsua = new DevExpress.XtraEditors.SimpleButton();
            this.btthoat = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Luu = new DevExpress.XtraEditors.SimpleButton();
            this.btxoa = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.TenLop});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 237);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(440, 206);
            this.dataGridView.TabIndex = 15;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenLop
            // 
            this.TenLop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenLop.DataPropertyName = "TENLOP";
            this.TenLop.HeaderText = "Tên Lớp";
            this.TenLop.Name = "TenLop";
            this.TenLop.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(22, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Khối  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(22, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Năm Học :";
            // 
            // comboKhoi
            // 
            this.comboKhoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKhoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboKhoi.FormattingEnabled = true;
            this.comboKhoi.Location = new System.Drawing.Point(106, 160);
            this.comboKhoi.Name = "comboKhoi";
            this.comboKhoi.Size = new System.Drawing.Size(158, 27);
            this.comboKhoi.TabIndex = 12;
            this.comboKhoi.SelectedIndexChanged += new System.EventHandler(this.comboKhoi_SelectedIndexChanged);
            // 
            // comboNam
            // 
            this.comboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNam.FormattingEnabled = true;
            this.comboNam.Location = new System.Drawing.Point(106, 122);
            this.comboNam.Name = "comboNam";
            this.comboNam.Size = new System.Drawing.Size(158, 27);
            this.comboNam.TabIndex = 11;
            this.comboNam.SelectedIndexChanged += new System.EventHandler(this.comboNam_SelectedIndexChanged);
            // 
            // txtTenLop
            // 
            this.txtTenLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Location = new System.Drawing.Point(106, 195);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(158, 26);
            this.txtTenLop.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(22, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tên Lớp :";
            // 
            // btthem
            // 
            this.btthem.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthem.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btthem.Appearance.Options.UseFont = true;
            this.btthem.Appearance.Options.UseForeColor = true;
            this.btthem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btthem.ImageIndex = 0;
            this.btthem.ImageList = this.imageList1;
            this.btthem.Location = new System.Drawing.Point(307, 44);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(111, 31);
            this.btthem.TabIndex = 21;
            this.btthem.Text = "THÊM";
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1417949391_bullet_add.png");
            this.imageList1.Images.SetKeyName(1, "1420364165_66728.ico");
            this.imageList1.Images.SetKeyName(2, "1417949402_bullet_delete.png");
            this.imageList1.Images.SetKeyName(3, "1420299204_photo.png");
            this.imageList1.Images.SetKeyName(4, "1417949388_bullet_deny.png");
            // 
            // btsua
            // 
            this.btsua.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsua.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btsua.Appearance.Options.UseFont = true;
            this.btsua.Appearance.Options.UseForeColor = true;
            this.btsua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btsua.ImageIndex = 1;
            this.btsua.ImageList = this.imageList1;
            this.btsua.Location = new System.Drawing.Point(307, 81);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(111, 31);
            this.btsua.TabIndex = 22;
            this.btsua.Text = "SỬA";
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // btthoat
            // 
            this.btthoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthoat.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btthoat.Appearance.Options.UseFont = true;
            this.btthoat.Appearance.Options.UseForeColor = true;
            this.btthoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btthoat.ImageIndex = 4;
            this.btthoat.ImageList = this.imageList1;
            this.btthoat.Location = new System.Drawing.Point(307, 193);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(111, 31);
            this.btthoat.TabIndex = 23;
            this.btthoat.Text = "THOÁT";
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(129, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 26);
            this.label4.TabIndex = 24;
            this.label4.Text = "QUẢN LÝ LỚP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(146, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // Luu
            // 
            this.Luu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Luu.Appearance.ForeColor = System.Drawing.Color.Green;
            this.Luu.Appearance.Options.UseFont = true;
            this.Luu.Appearance.Options.UseForeColor = true;
            this.Luu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Luu.ImageIndex = 3;
            this.Luu.ImageList = this.imageList1;
            this.Luu.Location = new System.Drawing.Point(307, 156);
            this.Luu.Name = "Luu";
            this.Luu.Size = new System.Drawing.Size(111, 31);
            this.Luu.TabIndex = 26;
            this.Luu.Text = "LƯU";
            this.Luu.Click += new System.EventHandler(this.Luu_Click);
            // 
            // btxoa
            // 
            this.btxoa.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoa.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btxoa.Appearance.Options.UseFont = true;
            this.btxoa.Appearance.Options.UseForeColor = true;
            this.btxoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btxoa.ImageIndex = 2;
            this.btxoa.ImageList = this.imageList1;
            this.btxoa.Location = new System.Drawing.Point(307, 118);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(111, 31);
            this.btxoa.TabIndex = 27;
            this.btxoa.Text = "XÓA";
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(270, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "*";
            // 
            // frQuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 443);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btxoa);
            this.Controls.Add(this.Luu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btthoat);
            this.Controls.Add(this.btsua);
            this.Controls.Add(this.btthem);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboKhoi);
            this.Controls.Add(this.comboNam);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frQuanLyLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ LỚP";
            this.Load += new System.EventHandler(this.frQuanLyLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboKhoi;
        private System.Windows.Forms.ComboBox comboNam;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btthem;
        private DevExpress.XtraEditors.SimpleButton btsua;
        private DevExpress.XtraEditors.SimpleButton btthoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton Luu;
        private DevExpress.XtraEditors.SimpleButton btxoa;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
    }
}