﻿namespace frMain
{
    partial class FormDanhSachHocSinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDanhSachHocSinh));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboboxKhoi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboboxNam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonIn = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBHK1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBHK2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDanhSachHocSinh = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDanhSachHocSinh = new System.Windows.Forms.PrintPreviewDialog();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 300);
            this.panel2.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.comboboxKhoi);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.comboboxNam);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(275, 83);
            this.panel6.TabIndex = 3;
            // 
            // comboboxKhoi
            // 
            this.comboboxKhoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxKhoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxKhoi.FormattingEnabled = true;
            this.comboboxKhoi.Location = new System.Drawing.Point(89, 45);
            this.comboboxKhoi.Name = "comboboxKhoi";
            this.comboboxKhoi.Size = new System.Drawing.Size(172, 27);
            this.comboboxKhoi.TabIndex = 3;
            this.comboboxKhoi.SelectedIndexChanged += new System.EventHandler(this.comBoBoxKhoi_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(14, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Khối:";
            // 
            // comboboxNam
            // 
            this.comboboxNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxNam.FormattingEnabled = true;
            this.comboboxNam.Location = new System.Drawing.Point(89, 12);
            this.comboboxNam.Name = "comboboxNam";
            this.comboboxNam.Size = new System.Drawing.Size(172, 27);
            this.comboboxNam.TabIndex = 1;
            this.comboboxNam.SelectedIndexChanged += new System.EventHandler(this.comBoBoxNam_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Năm học:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonIn);
            this.panel1.Controls.Add(this.buttonThoat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 101);
            this.panel1.TabIndex = 5;
            // 
            // buttonIn
            // 
            this.buttonIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIn.Appearance.ForeColor = System.Drawing.Color.Green;
            this.buttonIn.Appearance.Options.UseFont = true;
            this.buttonIn.Appearance.Options.UseForeColor = true;
            this.buttonIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIn.ImageIndex = 1;
            this.buttonIn.ImageList = this.imageList1;
            this.buttonIn.Location = new System.Drawing.Point(486, 59);
            this.buttonIn.Name = "buttonIn";
            this.buttonIn.Size = new System.Drawing.Size(116, 36);
            this.buttonIn.TabIndex = 3;
            this.buttonIn.Text = "IN";
            this.buttonIn.Click += new System.EventHandler(this.buttonIn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1417949388_bullet_deny.png");
            this.imageList1.Images.SetKeyName(1, "1420271317_printer.png");
            // 
            // buttonThoat
            // 
            this.buttonThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.Appearance.ForeColor = System.Drawing.Color.Green;
            this.buttonThoat.Appearance.Options.UseFont = true;
            this.buttonThoat.Appearance.Options.UseForeColor = true;
            this.buttonThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThoat.ImageIndex = 0;
            this.buttonThoat.ImageList = this.imageList1;
            this.buttonThoat.Location = new System.Drawing.Point(620, 59);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(153, 36);
            this.buttonThoat.TabIndex = 2;
            this.buttonThoat.Text = "THOÁT";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(253, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH HỌC SINH";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.HOTEN,
            this.Lop,
            this.TBHK1,
            this.TBHK2});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(275, 101);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(510, 300);
            this.dataGridView.TabIndex = 8;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // HOTEN
            // 
            this.HOTEN.DataPropertyName = "_HoTen";
            this.HOTEN.HeaderText = "Họ Tên";
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.ReadOnly = true;
            // 
            // Lop
            // 
            this.Lop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lop.DataPropertyName = "_Lop";
            this.Lop.HeaderText = "Lớp";
            this.Lop.Name = "Lop";
            this.Lop.ReadOnly = true;
            // 
            // TBHK1
            // 
            this.TBHK1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TBHK1.DataPropertyName = "_TBHK1";
            this.TBHK1.HeaderText = "TB Học Kỳ I";
            this.TBHK1.Name = "TBHK1";
            this.TBHK1.ReadOnly = true;
            // 
            // TBHK2
            // 
            this.TBHK2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TBHK2.DataPropertyName = "_TBHK2";
            this.TBHK2.HeaderText = "TB Học Kỳ II";
            this.TBHK2.Name = "TBHK2";
            this.TBHK2.ReadOnly = true;
            // 
            // printDanhSachHocSinh
            // 
            this.printDanhSachHocSinh.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDanhSachHocSinh_PrintPage);
            // 
            // printPreviewDanhSachHocSinh
            // 
            this.printPreviewDanhSachHocSinh.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDanhSachHocSinh.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDanhSachHocSinh.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDanhSachHocSinh.Enabled = true;
            this.printPreviewDanhSachHocSinh.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDanhSachHocSinh.Icon")));
            this.printPreviewDanhSachHocSinh.Name = "printPreviewDanhSachHocSinh";
            this.printPreviewDanhSachHocSinh.Visible = false;
            // 
            // FormDanhSachHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 401);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDanhSachHocSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH HỌC SINH";
            this.Load += new System.EventHandler(this.formDanhSachHocSinh_Load);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox comboboxKhoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboboxNam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBHK1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBHK2;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton buttonIn;
        private System.Drawing.Printing.PrintDocument printDanhSachHocSinh;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDanhSachHocSinh;
    }
}