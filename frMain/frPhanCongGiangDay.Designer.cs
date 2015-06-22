namespace frMain
{
    partial class frPhanCongGiangDay
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewDanhSachGiaoVien = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewDanhSachLopPhanCong = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxNamHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewDanhSachLopChuaPhanCong = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonThem = new DevExpress.XtraEditors.SimpleButton();
            this.buttonXoa = new DevExpress.XtraEditors.SimpleButton();
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopPhanCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopChuaPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl2.Controls.Add(this.dataGridViewDanhSachGiaoVien);
            this.groupControl2.Location = new System.Drawing.Point(25, 78);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(756, 159);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Danh sách giáo viên";
            // 
            // dataGridViewDanhSachGiaoVien
            // 
            this.dataGridViewDanhSachGiaoVien.AllowUserToAddRows = false;
            this.dataGridViewDanhSachGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSachGiaoVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaGiaoVien,
            this.HoTen,
            this.NgaySinh,
            this.GioiTinh,
            this.DiaChi,
            this.Email,
            this.MaMonHoc,
            this.DayMon});
            this.dataGridViewDanhSachGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDanhSachGiaoVien.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewDanhSachGiaoVien.MultiSelect = false;
            this.dataGridViewDanhSachGiaoVien.Name = "dataGridViewDanhSachGiaoVien";
            this.dataGridViewDanhSachGiaoVien.Size = new System.Drawing.Size(752, 136);
            this.dataGridViewDanhSachGiaoVien.TabIndex = 0;
            this.dataGridViewDanhSachGiaoVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDanhSachGiaoVien_CellClick);
            // 
            // STT
            // 
            this.STT.FillWeight = 20F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 30;
            // 
            // MaGiaoVien
            // 
            this.MaGiaoVien.DataPropertyName = "MaGiaoVien";
            this.MaGiaoVien.HeaderText = "MaGiaoVien";
            this.MaGiaoVien.Name = "MaGiaoVien";
            this.MaGiaoVien.ReadOnly = true;
            this.MaGiaoVien.Visible = false;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            this.GioiTinh.Width = 70;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // MaMonHoc
            // 
            this.MaMonHoc.DataPropertyName = "MaMonHoc";
            this.MaMonHoc.HeaderText = "Mã môn dạy";
            this.MaMonHoc.Name = "MaMonHoc";
            this.MaMonHoc.ReadOnly = true;
            this.MaMonHoc.Visible = false;
            // 
            // DayMon
            // 
            this.DayMon.HeaderText = "Dạy môn";
            this.DayMon.Name = "DayMon";
            this.DayMon.ReadOnly = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.dataGridViewDanhSachLopPhanCong);
            this.groupControl1.Location = new System.Drawing.Point(455, 260);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(279, 161);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Danh sách lớp đã phân công";
            // 
            // dataGridViewDanhSachLopPhanCong
            // 
            this.dataGridViewDanhSachLopPhanCong.AllowUserToAddRows = false;
            this.dataGridViewDanhSachLopPhanCong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewDanhSachLopPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSachLopPhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.MaLop2,
            this.TenLop2});
            this.dataGridViewDanhSachLopPhanCong.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewDanhSachLopPhanCong.MultiSelect = false;
            this.dataGridViewDanhSachLopPhanCong.Name = "dataGridViewDanhSachLopPhanCong";
            this.dataGridViewDanhSachLopPhanCong.Size = new System.Drawing.Size(274, 138);
            this.dataGridViewDanhSachLopPhanCong.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 20F;
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // MaLop2
            // 
            this.MaLop2.HeaderText = "Mã lớp";
            this.MaLop2.Name = "MaLop2";
            this.MaLop2.ReadOnly = true;
            // 
            // TenLop2
            // 
            this.TenLop2.HeaderText = "Lớp";
            this.TenLop2.Name = "TenLop2";
            this.TenLop2.ReadOnly = true;
            // 
            // comboBoxNamHoc
            // 
            this.comboBoxNamHoc.FormattingEnabled = true;
            this.comboBoxNamHoc.Location = new System.Drawing.Point(159, 41);
            this.comboBoxNamHoc.Name = "comboBoxNamHoc";
            this.comboBoxNamHoc.Size = new System.Drawing.Size(104, 21);
            this.comboBoxNamHoc.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Phân Công Giảng Dạy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Năm học:";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl3.Controls.Add(this.dataGridViewDanhSachLopChuaPhanCong);
            this.groupControl3.Location = new System.Drawing.Point(23, 260);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(278, 161);
            this.groupControl3.TabIndex = 11;
            this.groupControl3.Text = "Danh sách lớp chưa phân công";
            // 
            // dataGridViewDanhSachLopChuaPhanCong
            // 
            this.dataGridViewDanhSachLopChuaPhanCong.AllowUserToAddRows = false;
            this.dataGridViewDanhSachLopChuaPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSachLopChuaPhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.MaLop1,
            this.TenLop1});
            this.dataGridViewDanhSachLopChuaPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDanhSachLopChuaPhanCong.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewDanhSachLopChuaPhanCong.MultiSelect = false;
            this.dataGridViewDanhSachLopChuaPhanCong.Name = "dataGridViewDanhSachLopChuaPhanCong";
            this.dataGridViewDanhSachLopChuaPhanCong.Size = new System.Drawing.Size(274, 138);
            this.dataGridViewDanhSachLopChuaPhanCong.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 20F;
            this.dataGridViewTextBoxColumn2.HeaderText = "STT";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 30;
            // 
            // MaLop1
            // 
            this.MaLop1.HeaderText = "Mã lớp";
            this.MaLop1.Name = "MaLop1";
            this.MaLop1.ReadOnly = true;
            // 
            // TenLop1
            // 
            this.TenLop1.HeaderText = "Lớp";
            this.TenLop1.Name = "TenLop1";
            this.TenLop1.ReadOnly = true;
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(342, 301);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(75, 23);
            this.buttonThem.TabIndex = 12;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Location = new System.Drawing.Point(342, 347);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(75, 23);
            this.buttonXoa.TabIndex = 13;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Location = new System.Drawing.Point(342, 392);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(75, 23);
            this.buttonThoat.TabIndex = 15;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // frPhanCongGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 433);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxNamHoc);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "frPhanCongGiangDay";
            this.Text = "frPhanCongGiangDay";
            this.Load += new System.EventHandler(this.frPhanCongGiangDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopPhanCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopChuaPhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachGiaoVien;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachLopPhanCong;
        private System.Windows.Forms.ComboBox comboBoxNamHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachLopChuaPhanCong;
        private DevExpress.XtraEditors.SimpleButton buttonThem;
        private DevExpress.XtraEditors.SimpleButton buttonXoa;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop1;
    }
}