namespace frMain
{
    partial class frMonHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMonHoc));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtmonhoc = new System.Windows.Forms.TextBox();
            this.lbMonHoc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btthem = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btsua = new DevExpress.XtraEditors.SimpleButton();
            this.btxoa = new DevExpress.XtraEditors.SimpleButton();
            this.btluu = new DevExpress.XtraEditors.SimpleButton();
            this.btthoat = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textSoTietKhoi10 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textSoTietKhoi11 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textSoTietKhoi12 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENMONHOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTietKhoi10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTietKhoi11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTietKhoi12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.TENMONHOC,
            this.SoTietKhoi10,
            this.SoTietKhoi11,
            this.SoTietKhoi12});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 264);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(512, 185);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // txtmonhoc
            // 
            this.txtmonhoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmonhoc.Location = new System.Drawing.Point(143, 58);
            this.txtmonhoc.Name = "txtmonhoc";
            this.txtmonhoc.Size = new System.Drawing.Size(159, 26);
            this.txtmonhoc.TabIndex = 15;
            // 
            // lbMonHoc
            // 
            this.lbMonHoc.AutoSize = true;
            this.lbMonHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonHoc.Location = new System.Drawing.Point(29, 62);
            this.lbMonHoc.Name = "lbMonHoc";
            this.lbMonHoc.Size = new System.Drawing.Size(91, 19);
            this.lbMonHoc.TabIndex = 14;
            this.lbMonHoc.Text = "Tên môn học:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(126, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "QUẢN LÝ MÔN HỌC";
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
            this.btthem.Location = new System.Drawing.Point(11, 218);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(109, 28);
            this.btthem.TabIndex = 17;
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
            this.btsua.Location = new System.Drawing.Point(126, 218);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(109, 28);
            this.btsua.TabIndex = 18;
            this.btsua.Text = "SỬA";
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
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
            this.btxoa.Location = new System.Drawing.Point(241, 218);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(109, 28);
            this.btxoa.TabIndex = 19;
            this.btxoa.Text = "XÓA";
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // btluu
            // 
            this.btluu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btluu.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btluu.Appearance.Options.UseFont = true;
            this.btluu.Appearance.Options.UseForeColor = true;
            this.btluu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btluu.ImageIndex = 3;
            this.btluu.ImageList = this.imageList1;
            this.btluu.Location = new System.Drawing.Point(384, 89);
            this.btluu.Name = "btluu";
            this.btluu.Size = new System.Drawing.Size(109, 28);
            this.btluu.TabIndex = 20;
            this.btluu.Text = "LƯU";
            this.btluu.Click += new System.EventHandler(this.btLuu_Click);
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
            this.btthoat.Location = new System.Drawing.Point(384, 129);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(109, 28);
            this.btthoat.TabIndex = 21;
            this.btthoat.Text = "THOÁT";
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(308, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "*";
            // 
            // textSoTietKhoi10
            // 
            this.textSoTietKhoi10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSoTietKhoi10.Location = new System.Drawing.Point(143, 94);
            this.textSoTietKhoi10.Name = "textSoTietKhoi10";
            this.textSoTietKhoi10.Size = new System.Drawing.Size(159, 26);
            this.textSoTietKhoi10.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Số tiết khối 10";
            // 
            // textSoTietKhoi11
            // 
            this.textSoTietKhoi11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSoTietKhoi11.Location = new System.Drawing.Point(143, 133);
            this.textSoTietKhoi11.Name = "textSoTietKhoi11";
            this.textSoTietKhoi11.Size = new System.Drawing.Size(159, 26);
            this.textSoTietKhoi11.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Số tiết khối 11";
            // 
            // textSoTietKhoi12
            // 
            this.textSoTietKhoi12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSoTietKhoi12.Location = new System.Drawing.Point(143, 174);
            this.textSoTietKhoi12.Name = "textSoTietKhoi12";
            this.textSoTietKhoi12.Size = new System.Drawing.Size(159, 26);
            this.textSoTietKhoi12.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "Số tiết khối 12";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(308, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(308, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(308, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "*";
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 30;
            // 
            // TENMONHOC
            // 
            this.TENMONHOC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TENMONHOC.DataPropertyName = "TENMONHOC";
            this.TENMONHOC.HeaderText = "Môn Học";
            this.TENMONHOC.Name = "TENMONHOC";
            this.TENMONHOC.ReadOnly = true;
            // 
            // SoTietKhoi10
            // 
            this.SoTietKhoi10.DataPropertyName = "SOTIETKHOI10";
            this.SoTietKhoi10.HeaderText = "Số tiết khối 10";
            this.SoTietKhoi10.Name = "SoTietKhoi10";
            this.SoTietKhoi10.ReadOnly = true;
            // 
            // SoTietKhoi11
            // 
            this.SoTietKhoi11.DataPropertyName = "SOTIETKHOI11";
            this.SoTietKhoi11.HeaderText = "Số tiết khối 11";
            this.SoTietKhoi11.Name = "SoTietKhoi11";
            this.SoTietKhoi11.ReadOnly = true;
            // 
            // SoTietKhoi12
            // 
            this.SoTietKhoi12.DataPropertyName = "SOTIETKHOI12";
            this.SoTietKhoi12.HeaderText = "Số tiết khối 12";
            this.SoTietKhoi12.Name = "SoTietKhoi12";
            this.SoTietKhoi12.ReadOnly = true;
            // 
            // frMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 449);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textSoTietKhoi12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textSoTietKhoi11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textSoTietKhoi10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btthoat);
            this.Controls.Add(this.btluu);
            this.Controls.Add(this.btxoa);
            this.Controls.Add(this.btsua);
            this.Controls.Add(this.btthem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtmonhoc);
            this.Controls.Add(this.lbMonHoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MÔN HỌC";
            this.Load += new System.EventHandler(this.frMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtmonhoc;
        private System.Windows.Forms.Label lbMonHoc;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btthem;
        private DevExpress.XtraEditors.SimpleButton btsua;
        private DevExpress.XtraEditors.SimpleButton btxoa;
        private DevExpress.XtraEditors.SimpleButton btluu;
        private DevExpress.XtraEditors.SimpleButton btthoat;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textSoTietKhoi10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSoTietKhoi11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSoTietKhoi12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENMONHOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTietKhoi10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTietKhoi11;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTietKhoi12;
    }
}