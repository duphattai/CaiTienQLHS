namespace frMain
{
    partial class frBaoCaoTKHK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frBaoCaoTKHK));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtIn = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.comboNam = new System.Windows.Forms.ComboBox();
            this.comboHocKy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printBaoCaoHocKy = new System.Drawing.Printing.PrintDocument();
            this.printPreviewBaoCaoHocKy = new System.Windows.Forms.PrintPreviewDialog();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 142);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(705, 194);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // STT
            // 
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
            this.SiSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SiSo.DataPropertyName = "_SiSo";
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
            this.TiLe.DataPropertyName = "_TiLe";
            this.TiLe.HeaderText = "Tỉ Lệ";
            this.TiLe.Name = "TiLe";
            this.TiLe.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtIn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboNam);
            this.panel1.Controls.Add(this.comboHocKy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 142);
            this.panel1.TabIndex = 3;
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
            this.BtIn.Location = new System.Drawing.Point(540, 46);
            this.BtIn.Name = "BtIn";
            this.BtIn.Size = new System.Drawing.Size(133, 34);
            this.BtIn.TabIndex = 8;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(205, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "TỔNG KẾT HỌC KỲ";
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
            this.btThoat.Location = new System.Drawing.Point(540, 95);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(133, 34);
            this.btThoat.TabIndex = 6;
            this.btThoat.Text = "THOÁT";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(21, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Năm Học:";
            // 
            // comboNam
            // 
            this.comboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNam.FormattingEnabled = true;
            this.comboNam.Location = new System.Drawing.Point(104, 95);
            this.comboNam.Name = "comboNam";
            this.comboNam.Size = new System.Drawing.Size(158, 27);
            this.comboNam.TabIndex = 4;
            this.comboNam.SelectedIndexChanged += new System.EventHandler(this.comboNam_SelectedIndexChanged);
            // 
            // comboHocKy
            // 
            this.comboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHocKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboHocKy.FormattingEnabled = true;
            this.comboHocKy.Location = new System.Drawing.Point(355, 95);
            this.comboHocKy.Name = "comboHocKy";
            this.comboHocKy.Size = new System.Drawing.Size(158, 27);
            this.comboHocKy.TabIndex = 2;
            this.comboHocKy.SelectedIndexChanged += new System.EventHandler(this.comboHocKy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(287, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Học kỳ:";
            // 
            // printBaoCaoHocKy
            // 
            this.printBaoCaoHocKy.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printBaoCaoHocKy_PrintPage);
            // 
            // printPreviewBaoCaoHocKy
            // 
            this.printPreviewBaoCaoHocKy.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewBaoCaoHocKy.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewBaoCaoHocKy.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewBaoCaoHocKy.Enabled = true;
            this.printPreviewBaoCaoHocKy.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewBaoCaoHocKy.Icon")));
            this.printPreviewBaoCaoHocKy.Name = "printPreviewBaoCaoHocKy";
            this.printPreviewBaoCaoHocKy.Visible = false;
            // 
            // frBaoCaoTKHK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 336);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frBaoCaoTKHK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO TỔNG KẾT HỌC KỲ";
            this.Load += new System.EventHandler(this.frBaoCaoTKHK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboNam;
        private System.Windows.Forms.ComboBox comboHocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiLe;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton BtIn;
        private System.Drawing.Printing.PrintDocument printBaoCaoHocKy;
        private System.Windows.Forms.PrintPreviewDialog printPreviewBaoCaoHocKy;

    }
}