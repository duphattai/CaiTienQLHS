namespace frMain
{
    partial class frQuanLyNamHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frQuanLyNamHoc));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMHOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btthoat = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btluu = new DevExpress.XtraEditors.SimpleButton();
            this.btxoa = new DevExpress.XtraEditors.SimpleButton();
            this.btthem = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamBatDau = new System.Windows.Forms.TextBox();
            this.lbMonHoc = new System.Windows.Forms.Label();
            this.txtNamKetThuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.NAMHOC});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 202);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(531, 181);
            this.dataGridView.TabIndex = 22;
            this.dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // NAMHOC
            // 
            this.NAMHOC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NAMHOC.DataPropertyName = "NAMHOC1";
            this.NAMHOC.HeaderText = "Năm học";
            this.NAMHOC.Name = "NAMHOC";
            this.NAMHOC.ReadOnly = true;
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
            this.btthoat.Location = new System.Drawing.Point(394, 113);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(109, 28);
            this.btthoat.TabIndex = 30;
            this.btthoat.Text = "THOÁT";
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
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
            // btluu
            // 
            this.btluu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btluu.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btluu.Appearance.Options.UseFont = true;
            this.btluu.Appearance.Options.UseForeColor = true;
            this.btluu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btluu.ImageIndex = 3;
            this.btluu.ImageList = this.imageList1;
            this.btluu.Location = new System.Drawing.Point(394, 73);
            this.btluu.Name = "btluu";
            this.btluu.Size = new System.Drawing.Size(109, 28);
            this.btluu.TabIndex = 29;
            this.btluu.Text = "LƯU";
            this.btluu.Click += new System.EventHandler(this.btluu_Click);
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
            this.btxoa.Location = new System.Drawing.Point(237, 153);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(109, 28);
            this.btxoa.TabIndex = 28;
            this.btxoa.Text = "XÓA";
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
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
            this.btthem.Location = new System.Drawing.Point(93, 153);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(109, 28);
            this.btthem.TabIndex = 26;
            this.btthem.Text = "THÊM";
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "QUẢN LÝ NĂM HỌC";
            // 
            // txtNamBatDau
            // 
            this.txtNamBatDau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamBatDau.Location = new System.Drawing.Point(136, 77);
            this.txtNamBatDau.Name = "txtNamBatDau";
            this.txtNamBatDau.Size = new System.Drawing.Size(176, 26);
            this.txtNamBatDau.TabIndex = 24;
            this.txtNamBatDau.TextChanged += new System.EventHandler(this.txtNamBatDau_TextChanged);
            this.txtNamBatDau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamBatDau_KeyPress);
            // 
            // lbMonHoc
            // 
            this.lbMonHoc.AutoSize = true;
            this.lbMonHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonHoc.Location = new System.Drawing.Point(40, 84);
            this.lbMonHoc.Name = "lbMonHoc";
            this.lbMonHoc.Size = new System.Drawing.Size(91, 19);
            this.lbMonHoc.TabIndex = 23;
            this.lbMonHoc.Text = "Năm bắt đầu:";
            // 
            // txtNamKetThuc
            // 
            this.txtNamKetThuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamKetThuc.Location = new System.Drawing.Point(136, 109);
            this.txtNamKetThuc.Name = "txtNamKetThuc";
            this.txtNamKetThuc.Size = new System.Drawing.Size(176, 26);
            this.txtNamKetThuc.TabIndex = 31;
            this.txtNamKetThuc.TextChanged += new System.EventHandler(this.txtNamKetThuc_TextChanged);
            this.txtNamKetThuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamKetThuc_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Năm kết thúc:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(318, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(318, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "*";
            // 
            // frQuanLyNamHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 383);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNamKetThuc);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btthoat);
            this.Controls.Add(this.btluu);
            this.Controls.Add(this.btxoa);
            this.Controls.Add(this.btthem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNamBatDau);
            this.Controls.Add(this.lbMonHoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frQuanLyNamHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NĂM HỌC";
            this.Load += new System.EventHandler(this.frQuanLyNamHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private DevExpress.XtraEditors.SimpleButton btthoat;
        private DevExpress.XtraEditors.SimpleButton btluu;
        private DevExpress.XtraEditors.SimpleButton btxoa;
        private DevExpress.XtraEditors.SimpleButton btthem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamBatDau;
        private System.Windows.Forms.Label lbMonHoc;
        private System.Windows.Forms.TextBox txtNamKetThuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMHOC;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}