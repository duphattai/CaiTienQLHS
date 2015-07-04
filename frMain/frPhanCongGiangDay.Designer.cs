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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewDanhSachLopPhanCong = new System.Windows.Forms.DataGridView();
            this.comboBoxNamHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewDanhSachLopChuaPhanCong = new System.Windows.Forms.DataGridView();
            this.buttonThem = new DevExpress.XtraEditors.SimpleButton();
            this.buttonXoa = new DevExpress.XtraEditors.SimpleButton();
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewDanhSachGiaoVien = new System.Windows.Forms.DataGridView();
            this.DayMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopPhanCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopChuaPhanCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.dataGridViewDanhSachLopPhanCong);
            this.groupControl1.Location = new System.Drawing.Point(520, 345);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(347, 161);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Danh sách lớp đã phân công";
            // 
            // dataGridViewDanhSachLopPhanCong
            // 
            this.dataGridViewDanhSachLopPhanCong.AllowUserToAddRows = false;
            this.dataGridViewDanhSachLopPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSachLopPhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.MaLop2,
            this.TenLop2});
            this.dataGridViewDanhSachLopPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDanhSachLopPhanCong.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewDanhSachLopPhanCong.MultiSelect = false;
            this.dataGridViewDanhSachLopPhanCong.Name = "dataGridViewDanhSachLopPhanCong";
            this.dataGridViewDanhSachLopPhanCong.Size = new System.Drawing.Size(343, 138);
            this.dataGridViewDanhSachLopPhanCong.TabIndex = 0;
            // 
            // comboBoxNamHoc
            // 
            this.comboBoxNamHoc.FormattingEnabled = true;
            this.comboBoxNamHoc.Location = new System.Drawing.Point(86, 41);
            this.comboBoxNamHoc.Name = "comboBoxNamHoc";
            this.comboBoxNamHoc.Size = new System.Drawing.Size(104, 21);
            this.comboBoxNamHoc.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Năm học:";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl3.Controls.Add(this.dataGridViewDanhSachLopChuaPhanCong);
            this.groupControl3.Location = new System.Drawing.Point(27, 345);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(337, 161);
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
            this.dataGridViewDanhSachLopChuaPhanCong.Size = new System.Drawing.Size(333, 138);
            this.dataGridViewDanhSachLopChuaPhanCong.TabIndex = 0;
            // 
            // buttonThem
            // 
            this.buttonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThem.Location = new System.Drawing.Point(403, 379);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(75, 23);
            this.buttonThem.TabIndex = 12;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXoa.Location = new System.Drawing.Point(403, 425);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(75, 23);
            this.buttonXoa.TabIndex = 13;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThoat.Location = new System.Drawing.Point(403, 470);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(75, 23);
            this.buttonThoat.TabIndex = 15;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
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
            this.MaLop2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaLop2.HeaderText = "Mã lớp";
            this.MaLop2.Name = "MaLop2";
            this.MaLop2.ReadOnly = true;
            // 
            // TenLop2
            // 
            this.TenLop2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenLop2.HeaderText = "Lớp";
            this.TenLop2.Name = "TenLop2";
            this.TenLop2.ReadOnly = true;
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
            this.MaLop1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaLop1.HeaderText = "Mã lớp";
            this.MaLop1.Name = "MaLop1";
            this.MaLop1.ReadOnly = true;
            // 
            // TenLop1
            // 
            this.TenLop1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenLop1.HeaderText = "Lớp";
            this.TenLop1.Name = "TenLop1";
            this.TenLop1.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(320, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "PHÂN CÔNG GIẢNG DẠY";
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
            this.dataGridViewDanhSachGiaoVien.Size = new System.Drawing.Size(840, 222);
            this.dataGridViewDanhSachGiaoVien.TabIndex = 0;
            this.dataGridViewDanhSachGiaoVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDanhSachGiaoVien_CellClick);
            // 
            // DayMon
            // 
            this.DayMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DayMon.HeaderText = "Dạy môn";
            this.DayMon.Name = "DayMon";
            this.DayMon.ReadOnly = true;
            // 
            // MaMonHoc
            // 
            this.MaMonHoc.DataPropertyName = "MaMonHoc";
            this.MaMonHoc.HeaderText = "Mã môn dạy";
            this.MaMonHoc.Name = "MaMonHoc";
            this.MaMonHoc.ReadOnly = true;
            this.MaMonHoc.Visible = false;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // MaGiaoVien
            // 
            this.MaGiaoVien.DataPropertyName = "MaGiaoVien";
            this.MaGiaoVien.HeaderText = "MaGiaoVien";
            this.MaGiaoVien.Name = "MaGiaoVien";
            this.MaGiaoVien.ReadOnly = true;
            this.MaGiaoVien.Visible = false;
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STT.FillWeight = 20F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.dataGridViewDanhSachGiaoVien);
            this.groupControl2.Location = new System.Drawing.Point(25, 78);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(844, 245);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Danh sách giáo viên";
            // 
            // frPhanCongGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 519);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxNamHoc);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.MaximizeBox = false;
            this.Name = "frPhanCongGiangDay";
            this.Text = "frPhanCongGiangDay";
            this.Load += new System.EventHandler(this.frPhanCongGiangDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopPhanCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachLopChuaPhanCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSachGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachLopPhanCong;
        private System.Windows.Forms.ComboBox comboBoxNamHoc;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachLopChuaPhanCong;
        private DevExpress.XtraEditors.SimpleButton buttonThem;
        private DevExpress.XtraEditors.SimpleButton buttonXoa;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewDanhSachGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayMon;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}