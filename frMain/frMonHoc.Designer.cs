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
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENMONHOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TENMONHOC});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 213);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(512, 236);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TENMONHOC
            // 
            this.TENMONHOC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TENMONHOC.DataPropertyName = "TENMONHOC";
            this.TENMONHOC.HeaderText = "Môn Học";
            this.TENMONHOC.Name = "TENMONHOC";
            this.TENMONHOC.ReadOnly = true;
            // 
            // txtmonhoc
            // 
            this.txtmonhoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmonhoc.Location = new System.Drawing.Point(126, 91);
            this.txtmonhoc.Name = "txtmonhoc";
            this.txtmonhoc.Size = new System.Drawing.Size(176, 26);
            this.txtmonhoc.TabIndex = 15;
            // 
            // lbMonHoc
            // 
            this.lbMonHoc.AutoSize = true;
            this.lbMonHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonHoc.Location = new System.Drawing.Point(29, 98);
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
            this.btthem.Location = new System.Drawing.Point(11, 144);
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
            this.btsua.Location = new System.Drawing.Point(126, 144);
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
            this.btxoa.Location = new System.Drawing.Point(241, 144);
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
            this.label5.Location = new System.Drawing.Point(308, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "*";
            // 
            // frMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 449);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENMONHOC;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
    }
}