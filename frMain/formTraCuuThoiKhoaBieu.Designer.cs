namespace frMain
{
    partial class formTraCuuThoiKhoaBieu
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewThoiKhoaBieu = new System.Windows.Forms.DataGridView();
            this.BuoiHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxLop = new System.Windows.Forms.ComboBox();
            this.comboBoxNamHocTabLop = new System.Windows.Forms.ComboBox();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxTenGiaoVien = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxNamHocTabGiaoVien = new System.Windows.Forms.ComboBox();
            this.buttonTim = new DevExpress.XtraEditors.SimpleButton();
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.buttonExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThoiKhoaBieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(301, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "THỜI KHÓA BIỂU";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dataGridViewThoiKhoaBieu);
            this.groupControl1.Location = new System.Drawing.Point(39, 219);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(663, 161);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thời khóa biểu";
            // 
            // dataGridViewThoiKhoaBieu
            // 
            this.dataGridViewThoiKhoaBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewThoiKhoaBieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuoiHoc,
            this.Tiet,
            this.Thu2,
            this.Thu3,
            this.Thu4,
            this.Thu5,
            this.Thu6,
            this.Thu7});
            this.dataGridViewThoiKhoaBieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewThoiKhoaBieu.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewThoiKhoaBieu.Name = "dataGridViewThoiKhoaBieu";
            this.dataGridViewThoiKhoaBieu.Size = new System.Drawing.Size(659, 138);
            this.dataGridViewThoiKhoaBieu.TabIndex = 0;
            // 
            // BuoiHoc
            // 
            this.BuoiHoc.HeaderText = "Buổi học";
            this.BuoiHoc.Name = "BuoiHoc";
            this.BuoiHoc.ReadOnly = true;
            this.BuoiHoc.Width = 80;
            // 
            // Tiet
            // 
            this.Tiet.HeaderText = "Tiết";
            this.Tiet.Name = "Tiet";
            this.Tiet.ReadOnly = true;
            this.Tiet.Width = 55;
            // 
            // Thu2
            // 
            this.Thu2.HeaderText = "Thứ 2";
            this.Thu2.Name = "Thu2";
            this.Thu2.ReadOnly = true;
            this.Thu2.Width = 80;
            // 
            // Thu3
            // 
            this.Thu3.HeaderText = "Thứ 3";
            this.Thu3.Name = "Thu3";
            this.Thu3.ReadOnly = true;
            this.Thu3.Width = 80;
            // 
            // Thu4
            // 
            this.Thu4.HeaderText = "Thứ 4";
            this.Thu4.Name = "Thu4";
            this.Thu4.ReadOnly = true;
            this.Thu4.Width = 80;
            // 
            // Thu5
            // 
            this.Thu5.HeaderText = "Thứ 5";
            this.Thu5.Name = "Thu5";
            this.Thu5.ReadOnly = true;
            this.Thu5.Width = 80;
            // 
            // Thu6
            // 
            this.Thu6.HeaderText = "Thứ 6";
            this.Thu6.Name = "Thu6";
            this.Thu6.ReadOnly = true;
            this.Thu6.Width = 80;
            // 
            // Thu7
            // 
            this.Thu7.HeaderText = "Thứ 7";
            this.Thu7.Name = "Thu7";
            this.Thu7.ReadOnly = true;
            this.Thu7.Width = 80;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(108, 54);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(242, 142);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.comboBoxLop);
            this.xtraTabPage1.Controls.Add(this.comboBoxNamHocTabLop);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(237, 117);
            this.xtraTabPage1.Text = "Tìm kiếm theo lớp";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(21, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Lớp:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Năm học:";
            // 
            // comboBoxLop
            // 
            this.comboBoxLop.FormattingEnabled = true;
            this.comboBoxLop.Location = new System.Drawing.Point(104, 65);
            this.comboBoxLop.Name = "comboBoxLop";
            this.comboBoxLop.Size = new System.Drawing.Size(111, 21);
            this.comboBoxLop.TabIndex = 1;
            // 
            // comboBoxNamHocTabLop
            // 
            this.comboBoxNamHocTabLop.FormattingEnabled = true;
            this.comboBoxNamHocTabLop.Location = new System.Drawing.Point(104, 21);
            this.comboBoxNamHocTabLop.Name = "comboBoxNamHocTabLop";
            this.comboBoxNamHocTabLop.Size = new System.Drawing.Size(111, 21);
            this.comboBoxNamHocTabLop.TabIndex = 0;
            this.comboBoxNamHocTabLop.SelectedIndexChanged += new System.EventHandler(this.comboBoxNamHocTabLop_SelectedIndexChanged);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.labelControl5);
            this.xtraTabPage2.Controls.Add(this.comboBoxTenGiaoVien);
            this.xtraTabPage2.Controls.Add(this.labelControl4);
            this.xtraTabPage2.Controls.Add(this.comboBoxNamHocTabGiaoVien);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(237, 117);
            this.xtraTabPage2.Text = "Tìm kiếm theo giáo viên";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(25, 68);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(68, 13);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "Tên giáo viên:";
            // 
            // comboBoxTenGiaoVien
            // 
            this.comboBoxTenGiaoVien.FormattingEnabled = true;
            this.comboBoxTenGiaoVien.Location = new System.Drawing.Point(111, 65);
            this.comboBoxTenGiaoVien.Name = "comboBoxTenGiaoVien";
            this.comboBoxTenGiaoVien.Size = new System.Drawing.Size(109, 21);
            this.comboBoxTenGiaoVien.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(25, 25);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Năm học:";
            // 
            // comboBoxNamHocTabGiaoVien
            // 
            this.comboBoxNamHocTabGiaoVien.FormattingEnabled = true;
            this.comboBoxNamHocTabGiaoVien.Location = new System.Drawing.Point(111, 22);
            this.comboBoxNamHocTabGiaoVien.Name = "comboBoxNamHocTabGiaoVien";
            this.comboBoxNamHocTabGiaoVien.Size = new System.Drawing.Size(109, 21);
            this.comboBoxNamHocTabGiaoVien.TabIndex = 4;
            // 
            // buttonTim
            // 
            this.buttonTim.Location = new System.Drawing.Point(425, 74);
            this.buttonTim.Name = "buttonTim";
            this.buttonTim.Size = new System.Drawing.Size(75, 23);
            this.buttonTim.TabIndex = 3;
            this.buttonTim.Text = "Tìm";
            this.buttonTim.Click += new System.EventHandler(this.buttonTim_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Location = new System.Drawing.Point(525, 73);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(75, 23);
            this.buttonThoat.TabIndex = 4;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(425, 120);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonExcel.TabIndex = 5;
            this.buttonExcel.Text = "Xuất Excel";
            this.buttonExcel.Visible = false;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // formTraCuuThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 392);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonTim);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "formTraCuuThoiKhoaBieu";
            this.Text = "formTraCuuThoiKhoaBieu";
            this.Load += new System.EventHandler(this.formTraCuuThoiKhoaBieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThoiKhoaBieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dataGridViewThoiKhoaBieu;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox comboBoxLop;
        private System.Windows.Forms.ComboBox comboBoxNamHocTabLop;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ComboBox comboBoxTenGiaoVien;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox comboBoxNamHocTabGiaoVien;
        private DevExpress.XtraEditors.SimpleButton buttonTim;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private DevExpress.XtraEditors.SimpleButton buttonExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuoiHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu7;
    }
}