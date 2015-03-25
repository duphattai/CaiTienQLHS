namespace frMain
{
    partial class frBaoCaoMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frBaoCaoMon));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtIn = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboMon = new System.Windows.Forms.ComboBox();
            this.comboHocKy = new System.Windows.Forms.ComboBox();
            this.comboNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.printBaoCaoMon = new System.Drawing.Printing.PrintDocument();
            this.printPreviewBaoCaoMon = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Lop,
            this.SiSo,
            this.SoLuongDat,
            this.TiLe});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 149);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(901, 296);
            this.dataGridView.TabIndex = 5;
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // Lop
            // 
            this.Lop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lop.DataPropertyName = "_Lop";
            this.Lop.HeaderText = "Lớp";
            this.Lop.Name = "Lop";
            this.Lop.ReadOnly = true;
            // 
            // SiSo
            // 
            this.SiSo.DataPropertyName = "_Siso";
            this.SiSo.HeaderText = "Sĩ Số";
            this.SiSo.Name = "SiSo";
            this.SiSo.ReadOnly = true;
            // 
            // SoLuongDat
            // 
            this.SoLuongDat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuongDat.DataPropertyName = "_SoLuongDat";
            this.SoLuongDat.HeaderText = "Số Lượng Đạt";
            this.SoLuongDat.Name = "SoLuongDat";
            this.SoLuongDat.ReadOnly = true;
            // 
            // TiLe
            // 
            this.TiLe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TiLe.DataPropertyName = "_Tile";
            this.TiLe.HeaderText = "Tỉ Lệ";
            this.TiLe.Name = "TiLe";
            this.TiLe.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtIn);
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboMon);
            this.panel1.Controls.Add(this.comboHocKy);
            this.panel1.Controls.Add(this.comboNam);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 149);
            this.panel1.TabIndex = 4;
            // 
            // BtIn
            // 
            this.BtIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtIn.Appearance.ForeColor = System.Drawing.Color.Green;
            this.BtIn.Appearance.Options.UseFont = true;
            this.BtIn.Appearance.Options.UseForeColor = true;
            this.BtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtIn.ImageIndex = 1;
            this.BtIn.ImageList = this.imageList1;
            this.BtIn.Location = new System.Drawing.Point(752, 58);
            this.BtIn.Name = "BtIn";
            this.BtIn.Size = new System.Drawing.Size(132, 33);
            this.BtIn.TabIndex = 10;
            this.BtIn.Text = "IN";
            this.BtIn.Click += new System.EventHandler(this.BtIn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1417949388_bullet_deny.png");
            this.imageList1.Images.SetKeyName(1, "1420271317_printer.png");
            // 
            // btThoat
            // 
            this.btThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btThoat.Appearance.Options.UseFont = true;
            this.btThoat.Appearance.Options.UseForeColor = true;
            this.btThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThoat.ImageIndex = 0;
            this.btThoat.ImageList = this.imageList1;
            this.btThoat.Location = new System.Drawing.Point(752, 97);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(132, 33);
            this.btThoat.TabIndex = 9;
            this.btThoat.Text = "THOÁT";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(343, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "BÁO CÁO MÔN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(23, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Năm Học:";
            // 
            // comboMon
            // 
            this.comboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMon.FormattingEnabled = true;
            this.comboMon.Location = new System.Drawing.Point(555, 97);
            this.comboMon.Name = "comboMon";
            this.comboMon.Size = new System.Drawing.Size(155, 27);
            this.comboMon.TabIndex = 6;
            this.comboMon.SelectedIndexChanged += new System.EventHandler(this.comboMon_SelectedIndexChanged);
            // 
            // comboHocKy
            // 
            this.comboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHocKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboHocKy.FormattingEnabled = true;
            this.comboHocKy.Location = new System.Drawing.Point(342, 97);
            this.comboHocKy.Name = "comboHocKy";
            this.comboHocKy.Size = new System.Drawing.Size(155, 27);
            this.comboHocKy.TabIndex = 5;
            this.comboHocKy.SelectedIndexChanged += new System.EventHandler(this.comboHocKy_SelectedIndexChanged);
            // 
            // comboNam
            // 
            this.comboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNam.FormattingEnabled = true;
            this.comboNam.Location = new System.Drawing.Point(101, 97);
            this.comboNam.Name = "comboNam";
            this.comboNam.Size = new System.Drawing.Size(155, 27);
            this.comboNam.TabIndex = 4;
            this.comboNam.SelectedIndexChanged += new System.EventHandler(this.comboNam_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(271, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Học kỳ:  ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(504, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Môn: ";
            // 
            // printBaoCaoMon
            // 
            this.printBaoCaoMon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printBaoCaoMon_PrintPage);
            // 
            // printPreviewBaoCaoMon
            // 
            this.printPreviewBaoCaoMon.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewBaoCaoMon.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewBaoCaoMon.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewBaoCaoMon.Enabled = true;
            this.printPreviewBaoCaoMon.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewBaoCaoMon.Icon")));
            this.printPreviewBaoCaoMon.Name = "printPreviewBaoCaoMon";
            this.printPreviewBaoCaoMon.Visible = false;
            // 
            // frBaoCaoMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 445);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frBaoCaoMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO MÔN HỌC";
            this.Load += new System.EventHandler(this.frBaoCaoMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMon;
        private System.Windows.Forms.ComboBox comboHocKy;
        private System.Windows.Forms.ComboBox comboNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiLe;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton BtIn;
        private System.Drawing.Printing.PrintDocument printBaoCaoMon;
        private System.Windows.Forms.PrintPreviewDialog printPreviewBaoCaoMon;
    }
}