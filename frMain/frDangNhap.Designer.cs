namespace frMain
{
    partial class frDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textTen = new System.Windows.Forms.TextBox();
            this.textMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dangnhap = new DevExpress.XtraEditors.SimpleButton();
            this.thoat = new DevExpress.XtraEditors.SimpleButton();
            this.checkMK = new System.Windows.Forms.CheckBox();
            this.thongtin = new DevExpress.XtraEditors.SimpleButton();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(186, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageList = this.imageList1;
            this.label2.Location = new System.Drawing.Point(40, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1417949406_lock_locked.png");
            this.imageList1.Images.SetKeyName(1, "1417949388_bullet_deny.png");
            this.imageList1.Images.SetKeyName(2, "1419506144_lock_unlocked.png");
            this.imageList1.Images.SetKeyName(3, "1417955342_user_info.png");
            this.imageList1.Images.SetKeyName(4, "1417949526_key.png");
            this.imageList1.Images.SetKeyName(5, "1417949358_user_edit.png");
            // 
            // textTen
            // 
            this.textTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTen.Location = new System.Drawing.Point(139, 84);
            this.textTen.Name = "textTen";
            this.textTen.Size = new System.Drawing.Size(194, 26);
            this.textTen.TabIndex = 2;
            // 
            // textMatKhau
            // 
            this.textMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMatKhau.Location = new System.Drawing.Point(139, 133);
            this.textMatKhau.Name = "textMatKhau";
            this.textMatKhau.Size = new System.Drawing.Size(194, 26);
            this.textMatKhau.TabIndex = 3;
            this.textMatKhau.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(42, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu:";
            // 
            // dangnhap
            // 
            this.dangnhap.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangnhap.Appearance.ForeColor = System.Drawing.Color.Green;
            this.dangnhap.Appearance.Options.UseFont = true;
            this.dangnhap.Appearance.Options.UseForeColor = true;
            this.dangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dangnhap.ImageIndex = 2;
            this.dangnhap.ImageList = this.imageList1;
            this.dangnhap.Location = new System.Drawing.Point(10, 227);
            this.dangnhap.Name = "dangnhap";
            this.dangnhap.Size = new System.Drawing.Size(199, 36);
            this.dangnhap.TabIndex = 5;
            this.dangnhap.Text = "ĐĂNG NHẬP(ENTER)";
            this.dangnhap.Click += new System.EventHandler(this.ButtonDangNhap_Click);
            // 
            // thoat
            // 
            this.thoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoat.Appearance.ForeColor = System.Drawing.Color.Green;
            this.thoat.Appearance.Options.UseFont = true;
            this.thoat.Appearance.Options.UseForeColor = true;
            this.thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thoat.ImageIndex = 1;
            this.thoat.ImageList = this.imageList1;
            this.thoat.Location = new System.Drawing.Point(392, 227);
            this.thoat.Name = "thoat";
            this.thoat.Size = new System.Drawing.Size(170, 36);
            this.thoat.TabIndex = 7;
            this.thoat.Text = "THOÁT(ESC)";
            this.thoat.Click += new System.EventHandler(this.ButtonThoat_Click);
            // 
            // checkMK
            // 
            this.checkMK.AutoSize = true;
            this.checkMK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkMK.Location = new System.Drawing.Point(139, 174);
            this.checkMK.Name = "checkMK";
            this.checkMK.Size = new System.Drawing.Size(139, 23);
            this.checkMK.TabIndex = 4;
            this.checkMK.Text = "     Hiện mật khẩu.";
            this.checkMK.UseVisualStyleBackColor = true;
            this.checkMK.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // thongtin
            // 
            this.thongtin.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongtin.Appearance.ForeColor = System.Drawing.Color.Green;
            this.thongtin.Appearance.Options.UseFont = true;
            this.thongtin.Appearance.Options.UseForeColor = true;
            this.thongtin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thongtin.ImageIndex = 3;
            this.thongtin.ImageList = this.imageList1;
            this.thongtin.Location = new System.Drawing.Point(215, 227);
            this.thongtin.Name = "thongtin";
            this.thongtin.Size = new System.Drawing.Size(171, 36);
            this.thongtin.TabIndex = 6;
            this.thongtin.Text = "XEM THÔNG TIN";
            this.thongtin.Click += new System.EventHandler(this.thongtin_Click);
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(80, 294);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(404, 12);
            this.marqueeProgressBarControl1.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(58, 275);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Bắt đầu...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(394, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 141);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(339, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(339, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "*";
            // 
            // frDangNhap
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 315);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.thongtin);
            this.Controls.Add(this.checkMK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.thoat);
            this.Controls.Add(this.dangnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textMatKhau);
            this.Controls.Add(this.textTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Office 2013";
            this.MaximizeBox = false;
            this.Name = "frDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BẢO MẬT";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frDangNhap_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTen;
        private System.Windows.Forms.TextBox textMatKhau;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton dangnhap;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton thoat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkMK;
        private DevExpress.XtraEditors.SimpleButton thongtin;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}