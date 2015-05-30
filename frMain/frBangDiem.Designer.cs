namespace frMain
{
    partial class formBangDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBangDiem));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonExcel = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelHocKy = new System.Windows.Forms.Label();
            this.labelMon = new System.Windows.Forms.Label();
            this.labelLop = new System.Windows.Forms.Label();
            this.BtIn = new DevExpress.XtraEditors.SimpleButton();
            this.buttonLuu = new DevExpress.XtraEditors.SimpleButton();
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboboxHocKy = new System.Windows.Forms.ComboBox();
            this.comboboxMon = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboboxLop = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboboxNam = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboboxKhoi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.printBangDiem = new System.Drawing.Printing.PrintDocument();
            this.printPreviewBangDiem = new System.Windows.Forms.PrintPreviewDialog();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem1Tiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemHK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHocSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDiem15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDiem1Tiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDiemHK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(286, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 52);
            this.panel2.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(114, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(229, 31);
            this.label9.TabIndex = 1;
            this.label9.Text = "ĐIỂM MÔN HỌC";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(286, 52);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(740, 338);
            this.panel4.TabIndex = 11;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.HoTen,
            this.Diem15,
            this.Diem1Tiet,
            this.DiemHK,
            this.DiemTB,
            this.MaHocSinh,
            this.MaDiem15,
            this.MaDiem1Tiet,
            this.MaDiemHK});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 94);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(740, 244);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonExcel);
            this.panel1.Controls.Add(this.labelHocKy);
            this.panel1.Controls.Add(this.labelMon);
            this.panel1.Controls.Add(this.labelLop);
            this.panel1.Controls.Add(this.BtIn);
            this.panel1.Controls.Add(this.buttonLuu);
            this.panel1.Controls.Add(this.buttonThoat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 94);
            this.panel1.TabIndex = 0;
            // 
            // ButtonExcel
            // 
            this.ButtonExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExcel.Appearance.ForeColor = System.Drawing.Color.Green;
            this.ButtonExcel.Appearance.Options.UseFont = true;
            this.ButtonExcel.Appearance.Options.UseForeColor = true;
            this.ButtonExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExcel.ImageIndex = 5;
            this.ButtonExcel.ImageList = this.imageList1;
            this.ButtonExcel.Location = new System.Drawing.Point(481, 11);
            this.ButtonExcel.Name = "ButtonExcel";
            this.ButtonExcel.Size = new System.Drawing.Size(113, 33);
            this.ButtonExcel.TabIndex = 10;
            this.ButtonExcel.Text = "EXCEL";
            this.ButtonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
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
            this.imageList1.Images.SetKeyName(5, "1420271317_printer.png");
            // 
            // labelHocKy
            // 
            this.labelHocKy.AutoSize = true;
            this.labelHocKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHocKy.ForeColor = System.Drawing.Color.Blue;
            this.labelHocKy.Location = new System.Drawing.Point(287, 15);
            this.labelHocKy.Name = "labelHocKy";
            this.labelHocKy.Size = new System.Drawing.Size(0, 19);
            this.labelHocKy.TabIndex = 9;
            // 
            // labelMon
            // 
            this.labelMon.AutoSize = true;
            this.labelMon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMon.ForeColor = System.Drawing.Color.Blue;
            this.labelMon.Location = new System.Drawing.Point(57, 59);
            this.labelMon.Name = "labelMon";
            this.labelMon.Size = new System.Drawing.Size(0, 19);
            this.labelMon.TabIndex = 8;
            // 
            // labelLop
            // 
            this.labelLop.AutoSize = true;
            this.labelLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLop.ForeColor = System.Drawing.Color.Blue;
            this.labelLop.Location = new System.Drawing.Point(53, 15);
            this.labelLop.Name = "labelLop";
            this.labelLop.Size = new System.Drawing.Size(0, 19);
            this.labelLop.TabIndex = 7;
            // 
            // BtIn
            // 
            this.BtIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtIn.Appearance.ForeColor = System.Drawing.Color.Green;
            this.BtIn.Appearance.Options.UseFont = true;
            this.BtIn.Appearance.Options.UseForeColor = true;
            this.BtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtIn.ImageIndex = 5;
            this.BtIn.ImageList = this.imageList1;
            this.BtIn.Location = new System.Drawing.Point(481, 55);
            this.BtIn.Name = "BtIn";
            this.BtIn.Size = new System.Drawing.Size(113, 33);
            this.BtIn.TabIndex = 6;
            this.BtIn.Text = "IN";
            this.BtIn.Click += new System.EventHandler(this.buttonIn_Click);
            // 
            // buttonLuu
            // 
            this.buttonLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLuu.Appearance.ForeColor = System.Drawing.Color.Green;
            this.buttonLuu.Appearance.Options.UseFont = true;
            this.buttonLuu.Appearance.Options.UseForeColor = true;
            this.buttonLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLuu.ImageIndex = 3;
            this.buttonLuu.ImageList = this.imageList1;
            this.buttonLuu.Location = new System.Drawing.Point(600, 11);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(128, 33);
            this.buttonLuu.TabIndex = 5;
            this.buttonLuu.Text = "LƯU";
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.Appearance.ForeColor = System.Drawing.Color.Green;
            this.buttonThoat.Appearance.Options.UseFont = true;
            this.buttonThoat.Appearance.Options.UseForeColor = true;
            this.buttonThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThoat.ImageIndex = 4;
            this.buttonThoat.ImageList = this.imageList1;
            this.buttonThoat.Location = new System.Drawing.Point(600, 55);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(128, 33);
            this.buttonThoat.TabIndex = 4;
            this.buttonThoat.Text = "THOÁT";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(216, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Học kỳ : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Môn : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lớp : ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.comboboxHocKy);
            this.panel5.Controls.Add(this.comboboxMon);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.comboboxLop);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.comboboxNam);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.comboboxKhoi);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(286, 387);
            this.panel5.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(9, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Môn:";
            // 
            // comboboxHocKy
            // 
            this.comboboxHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxHocKy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxHocKy.FormattingEnabled = true;
            this.comboboxHocKy.Location = new System.Drawing.Point(92, 136);
            this.comboboxHocKy.Name = "comboboxHocKy";
            this.comboboxHocKy.Size = new System.Drawing.Size(167, 27);
            this.comboboxHocKy.TabIndex = 3;
            this.comboboxHocKy.SelectedIndexChanged += new System.EventHandler(this.comboboxHocKy_SelectedIndexChanged);
            // 
            // comboboxMon
            // 
            this.comboboxMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxMon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxMon.FormattingEnabled = true;
            this.comboboxMon.Location = new System.Drawing.Point(92, 252);
            this.comboboxMon.Name = "comboboxMon";
            this.comboboxMon.Size = new System.Drawing.Size(167, 27);
            this.comboboxMon.TabIndex = 5;
            this.comboboxMon.SelectedIndexChanged += new System.EventHandler(this.comboboxMon_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(9, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Học kỳ:";
            // 
            // comboboxLop
            // 
            this.comboboxLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxLop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxLop.FormattingEnabled = true;
            this.comboboxLop.Location = new System.Drawing.Point(92, 211);
            this.comboboxLop.Name = "comboboxLop";
            this.comboboxLop.Size = new System.Drawing.Size(167, 27);
            this.comboboxLop.TabIndex = 7;
            this.comboboxLop.SelectedIndexChanged += new System.EventHandler(this.comboBoxLop_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(9, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Lớp :";
            // 
            // comboboxNam
            // 
            this.comboboxNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxNam.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxNam.FormattingEnabled = true;
            this.comboboxNam.Location = new System.Drawing.Point(92, 99);
            this.comboboxNam.Name = "comboboxNam";
            this.comboboxNam.Size = new System.Drawing.Size(167, 27);
            this.comboboxNam.TabIndex = 1;
            this.comboboxNam.SelectedIndexChanged += new System.EventHandler(this.comboboxNam_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(9, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Khối :";
            // 
            // comboboxKhoi
            // 
            this.comboboxKhoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxKhoi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxKhoi.FormattingEnabled = true;
            this.comboboxKhoi.Location = new System.Drawing.Point(92, 172);
            this.comboboxKhoi.Name = "comboboxKhoi";
            this.comboboxKhoi.Size = new System.Drawing.Size(167, 27);
            this.comboboxKhoi.TabIndex = 6;
            this.comboboxKhoi.SelectedIndexChanged += new System.EventHandler(this.comboboxKhoi_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(9, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Năm học:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 390);
            this.panel3.TabIndex = 9;
            // 
            // printBangDiem
            // 
            this.printBangDiem.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printBangDiem_PrintPage);
            // 
            // printPreviewBangDiem
            // 
            this.printPreviewBangDiem.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewBangDiem.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewBangDiem.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewBangDiem.Enabled = true;
            this.printPreviewBangDiem.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewBangDiem.Icon")));
            this.printPreviewBangDiem.Name = "printPreviewBangDiem";
            this.printPreviewBangDiem.Visible = false;
            // 
            // STT
            // 
            this.STT.FillWeight = 50F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoTen.DataPropertyName = "_HoTen";
            this.HoTen.FillWeight = 37.23404F;
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // Diem15
            // 
            this.Diem15.DataPropertyName = "_Diem15";
            this.Diem15.FillWeight = 110F;
            this.Diem15.HeaderText = "Điểm 15\'";
            this.Diem15.Name = "Diem15";
            this.Diem15.Width = 110;
            // 
            // Diem1Tiet
            // 
            this.Diem1Tiet.DataPropertyName = "_Diem1Tiet";
            this.Diem1Tiet.FillWeight = 110F;
            this.Diem1Tiet.HeaderText = "Điểm 1 Tiết";
            this.Diem1Tiet.Name = "Diem1Tiet";
            this.Diem1Tiet.Width = 110;
            // 
            // DiemHK
            // 
            this.DiemHK.DataPropertyName = "_DiemHK";
            this.DiemHK.FillWeight = 110F;
            this.DiemHK.HeaderText = "Điểm Học Kỳ";
            this.DiemHK.Name = "DiemHK";
            this.DiemHK.Width = 110;
            // 
            // DiemTB
            // 
            this.DiemTB.DataPropertyName = "_DiemTB";
            this.DiemTB.FillWeight = 110F;
            this.DiemTB.HeaderText = "Điểm Trung Bình";
            this.DiemTB.Name = "DiemTB";
            this.DiemTB.ReadOnly = true;
            this.DiemTB.Width = 110;
            // 
            // MaHocSinh
            // 
            this.MaHocSinh.DataPropertyName = "_MaHocSinh";
            this.MaHocSinh.HeaderText = "Mã Học Sinh";
            this.MaHocSinh.Name = "MaHocSinh";
            this.MaHocSinh.ReadOnly = true;
            this.MaHocSinh.Visible = false;
            // 
            // MaDiem15
            // 
            this.MaDiem15.DataPropertyName = "_MaDiem15";
            this.MaDiem15.HeaderText = "Mã Điểm 15";
            this.MaDiem15.Name = "MaDiem15";
            this.MaDiem15.ReadOnly = true;
            this.MaDiem15.Visible = false;
            // 
            // MaDiem1Tiet
            // 
            this.MaDiem1Tiet.DataPropertyName = "_MaDiem1T";
            this.MaDiem1Tiet.HeaderText = "Mã Điểm 1 Tiết";
            this.MaDiem1Tiet.Name = "MaDiem1Tiet";
            this.MaDiem1Tiet.ReadOnly = true;
            this.MaDiem1Tiet.Visible = false;
            // 
            // MaDiemHK
            // 
            this.MaDiemHK.DataPropertyName = "_MaDiemHK";
            this.MaDiemHK.HeaderText = "Mã Điểm Học Kỳ";
            this.MaDiemHK.Name = "MaDiemHK";
            this.MaDiemHK.ReadOnly = true;
            this.MaDiemHK.Visible = false;
            // 
            // formBangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 390);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formBangDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BẢNG ĐIỂM";
            this.Load += new System.EventHandler(this.formBangDiem_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboboxHocKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboboxNam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboboxMon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboboxLop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboboxKhoi;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private DevExpress.XtraEditors.SimpleButton buttonLuu;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton BtIn;
        private System.Drawing.Printing.PrintDocument printBangDiem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewBangDiem;
        private System.Windows.Forms.Label labelHocKy;
        private System.Windows.Forms.Label labelMon;
        private System.Windows.Forms.Label labelLop;
        private DevExpress.XtraEditors.SimpleButton ButtonExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem1Tiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDiem15;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDiem1Tiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDiemHK;
    }
}