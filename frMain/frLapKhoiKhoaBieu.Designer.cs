﻿namespace frMain
{
    partial class frLapKhoiKhoaBieu
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewDanhSachLop = new System.Windows.Forms.DataGridView();
            this.buttonKiemTra = new DevExpress.XtraEditors.SimpleButton();
            this.buttonTuDong = new DevExpress.XtraEditors.SimpleButton();
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.comBoBoxNamHoc = new System.Windows.Forms.ComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewThoiKhoaBieu = new System.Windows.Forms.DataGridView();
            this.buttonLuu = new DevExpress.XtraEditors.SimpleButton();
            this.buttonXuatExcel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChonLop = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThoiKhoaBieu)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 95);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Năm học:";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl3.Controls.Add(this.dataGridViewDanhSachLop);
            this.groupControl3.Location = new System.Drawing.Point(29, 130);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(347, 196);
            this.groupControl3.TabIndex = 12;
            this.groupControl3.Text = "Danh sách lớp";
            // 
            // dataGridViewDanhSachLop
            // 
            this.dataGridViewDanhSachLop.AllowUserToAddRows = false;
            this.dataGridViewDanhSachLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSachLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.MaLop,
            this.TenLop,
            this.ChonLop,
            this.MaKhoi,
            this.NamHoc,
            this.SiSo});
            this.dataGridViewDanhSachLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDanhSachLop.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewDanhSachLop.MultiSelect = false;
            this.dataGridViewDanhSachLop.Name = "dataGridViewDanhSachLop";
            this.dataGridViewDanhSachLop.Size = new System.Drawing.Size(343, 173);
            this.dataGridViewDanhSachLop.TabIndex = 0;
            this.dataGridViewDanhSachLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDanhSachLop_CellClick);
            this.dataGridViewDanhSachLop.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewDanhSachLop_DataError);
            // 
            // buttonKiemTra
            // 
            this.buttonKiemTra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonKiemTra.Location = new System.Drawing.Point(425, 154);
            this.buttonKiemTra.Name = "buttonKiemTra";
            this.buttonKiemTra.Size = new System.Drawing.Size(71, 23);
            this.buttonKiemTra.TabIndex = 13;
            this.buttonKiemTra.Text = "Kiểm tra";
            this.buttonKiemTra.Click += new System.EventHandler(this.buttonKiemTra_Click);
            // 
            // buttonTuDong
            // 
            this.buttonTuDong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTuDong.Location = new System.Drawing.Point(516, 154);
            this.buttonTuDong.Name = "buttonTuDong";
            this.buttonTuDong.Size = new System.Drawing.Size(71, 23);
            this.buttonTuDong.TabIndex = 15;
            this.buttonTuDong.Text = "Tự động";
            this.buttonTuDong.Visible = false;
            this.buttonTuDong.Click += new System.EventHandler(this.buttonTuDong_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonThoat.Location = new System.Drawing.Point(425, 258);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(71, 23);
            this.buttonThoat.TabIndex = 16;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // comBoBoxNamHoc
            // 
            this.comBoBoxNamHoc.FormattingEnabled = true;
            this.comBoBoxNamHoc.Location = new System.Drawing.Point(98, 92);
            this.comBoBoxNamHoc.Name = "comBoBoxNamHoc";
            this.comBoBoxNamHoc.Size = new System.Drawing.Size(104, 21);
            this.comBoBoxNamHoc.TabIndex = 17;
            this.comBoBoxNamHoc.SelectedIndexChanged += new System.EventHandler(this.comBoBoxNamHoc_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dataGridViewThoiKhoaBieu);
            this.groupControl1.Location = new System.Drawing.Point(27, 345);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(580, 159);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "Thoi khoa bieu";
            // 
            // dataGridViewThoiKhoaBieu
            // 
            this.dataGridViewThoiKhoaBieu.AllowUserToAddRows = false;
            this.dataGridViewThoiKhoaBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewThoiKhoaBieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewThoiKhoaBieu.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewThoiKhoaBieu.MultiSelect = false;
            this.dataGridViewThoiKhoaBieu.Name = "dataGridViewThoiKhoaBieu";
            this.dataGridViewThoiKhoaBieu.Size = new System.Drawing.Size(576, 136);
            this.dataGridViewThoiKhoaBieu.TabIndex = 0;
            // 
            // buttonLuu
            // 
            this.buttonLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLuu.Location = new System.Drawing.Point(425, 207);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(71, 23);
            this.buttonLuu.TabIndex = 19;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.Visible = false;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonXuatExcel
            // 
            this.buttonXuatExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonXuatExcel.Location = new System.Drawing.Point(516, 207);
            this.buttonXuatExcel.Name = "buttonXuatExcel";
            this.buttonXuatExcel.Size = new System.Drawing.Size(71, 23);
            this.buttonXuatExcel.TabIndex = 20;
            this.buttonXuatExcel.Text = "Xuất excel";
            this.buttonXuatExcel.Click += new System.EventHandler(this.buttonXuatExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(191, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "LẬP THỜI KHÓA BIỂU";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 20F;
            this.dataGridViewTextBoxColumn2.HeaderText = "STT";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MALOP";
            this.MaLop.HeaderText = "Mã lớp";
            this.MaLop.Name = "MaLop";
            this.MaLop.ReadOnly = true;
            this.MaLop.Visible = false;
            // 
            // TenLop
            // 
            this.TenLop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenLop.DataPropertyName = "TENLOP";
            this.TenLop.HeaderText = "Lớp";
            this.TenLop.Name = "TenLop";
            this.TenLop.ReadOnly = true;
            // 
            // ChonLop
            // 
            this.ChonLop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChonLop.HeaderText = "Chọn lớp";
            this.ChonLop.Name = "ChonLop";
            // 
            // MaKhoi
            // 
            this.MaKhoi.DataPropertyName = "MAKHOI";
            this.MaKhoi.HeaderText = "Mã khối";
            this.MaKhoi.Name = "MaKhoi";
            this.MaKhoi.ReadOnly = true;
            this.MaKhoi.Visible = false;
            // 
            // NamHoc
            // 
            this.NamHoc.DataPropertyName = "NAMHOC";
            this.NamHoc.HeaderText = "Năm học";
            this.NamHoc.Name = "NamHoc";
            this.NamHoc.ReadOnly = true;
            this.NamHoc.Visible = false;
            // 
            // SiSo
            // 
            this.SiSo.DataPropertyName = "SISO";
            this.SiSo.HeaderText = "Sỉ số";
            this.SiSo.Name = "SiSo";
            this.SiSo.ReadOnly = true;
            this.SiSo.Visible = false;
            // 
            // frLapKhoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonXuatExcel);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.comBoBoxNamHoc);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonTuDong);
            this.Controls.Add(this.buttonKiemTra);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.Name = "frLapKhoiKhoaBieu";
            this.Text = "LapKhoiKhoaBieu";
            this.Load += new System.EventHandler(this.frLapKhoiKhoaBieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThoiKhoaBieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachLop;
        private DevExpress.XtraEditors.SimpleButton buttonKiemTra;
        private DevExpress.XtraEditors.SimpleButton buttonTuDong;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private System.Windows.Forms.ComboBox comBoBoxNamHoc;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dataGridViewThoiKhoaBieu;
        private DevExpress.XtraEditors.SimpleButton buttonLuu;
        private DevExpress.XtraEditors.SimpleButton buttonXuatExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChonLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiSo;
        private System.Windows.Forms.Label label1;
    }
}