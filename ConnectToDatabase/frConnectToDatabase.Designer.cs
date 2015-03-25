namespace ConnectToDatabase
{
    partial class frConnectToDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frConnectToDatabase));
            this.cbServerName = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblServerName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.grbLogOn = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.rbServerAuthentication = new System.Windows.Forms.RadioButton();
            this.rbWindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.btnCreateNewDatabase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewDB = new System.Windows.Forms.TextBox();
            this.cbDbName = new System.Windows.Forms.ComboBox();
            this.lblSelectDbName = new System.Windows.Forms.Label();
            this.pnlConnectionInfo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateSample = new System.Windows.Forms.Button();
            this.grbDatabaseConnection = new System.Windows.Forms.GroupBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.grbLogOn.SuspendLayout();
            this.pnlConnectionInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbDatabaseConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbServerName
            // 
            this.cbServerName.FormattingEnabled = true;
            this.cbServerName.Location = new System.Drawing.Point(18, 108);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.Size = new System.Drawing.Size(236, 21);
            this.cbServerName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(29, 50);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(75, 13);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "Server Name :";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(163, 436);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 30);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Lưu cấu hình";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(278, 102);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(108, 30);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Tìm trong mạng";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // grbLogOn
            // 
            this.grbLogOn.Controls.Add(this.txtPassword);
            this.grbLogOn.Controls.Add(this.btnConnect);
            this.grbLogOn.Controls.Add(this.txtUserName);
            this.grbLogOn.Controls.Add(this.lblPassword);
            this.grbLogOn.Controls.Add(this.lblUserName);
            this.grbLogOn.Controls.Add(this.rbServerAuthentication);
            this.grbLogOn.Controls.Add(this.rbWindowsAuthentication);
            this.grbLogOn.Location = new System.Drawing.Point(8, 136);
            this.grbLogOn.Name = "grbLogOn";
            this.grbLogOn.Size = new System.Drawing.Size(378, 153);
            this.grbLogOn.TabIndex = 4;
            this.grbLogOn.TabStop = false;
            this.grbLogOn.Text = "Đăng nhập vào Server";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(100, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(268, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(282, 118);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 30);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(100, 69);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(268, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(36, 95);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(52, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(36, 72);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Tài khoản";
            // 
            // rbServerAuthentication
            // 
            this.rbServerAuthentication.AutoSize = true;
            this.rbServerAuthentication.Location = new System.Drawing.Point(24, 41);
            this.rbServerAuthentication.Name = "rbServerAuthentication";
            this.rbServerAuthentication.Size = new System.Drawing.Size(188, 17);
            this.rbServerAuthentication.TabIndex = 1;
            this.rbServerAuthentication.Text = "Sử dụng chứng thực quyền Server";
            this.rbServerAuthentication.UseVisualStyleBackColor = true;
            this.rbServerAuthentication.Click += new System.EventHandler(this.rbServerAuthentication_Click);
            // 
            // rbWindowsAuthentication
            // 
            this.rbWindowsAuthentication.AutoSize = true;
            this.rbWindowsAuthentication.Checked = true;
            this.rbWindowsAuthentication.Location = new System.Drawing.Point(24, 18);
            this.rbWindowsAuthentication.Name = "rbWindowsAuthentication";
            this.rbWindowsAuthentication.Size = new System.Drawing.Size(196, 17);
            this.rbWindowsAuthentication.TabIndex = 0;
            this.rbWindowsAuthentication.TabStop = true;
            this.rbWindowsAuthentication.Text = "Sử dụng chứng thực quyền Window";
            this.rbWindowsAuthentication.UseVisualStyleBackColor = true;
            this.rbWindowsAuthentication.Click += new System.EventHandler(this.rbWindowsAuthentication_Click);
            // 
            // btnCreateNewDatabase
            // 
            this.btnCreateNewDatabase.Enabled = false;
            this.btnCreateNewDatabase.Location = new System.Drawing.Point(299, 32);
            this.btnCreateNewDatabase.Name = "btnCreateNewDatabase";
            this.btnCreateNewDatabase.Size = new System.Drawing.Size(69, 30);
            this.btnCreateNewDatabase.TabIndex = 8;
            this.btnCreateNewDatabase.Text = "Tạo mới";
            this.btnCreateNewDatabase.UseVisualStyleBackColor = true;
            this.btnCreateNewDatabase.Click += new System.EventHandler(this.btnCreateNewDatabase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tạo mới cơ sở dữ liệu:";
            // 
            // txtNewDB
            // 
            this.txtNewDB.Enabled = false;
            this.txtNewDB.Location = new System.Drawing.Point(180, 38);
            this.txtNewDB.Name = "txtNewDB";
            this.txtNewDB.Size = new System.Drawing.Size(115, 20);
            this.txtNewDB.TabIndex = 9;
            // 
            // cbDbName
            // 
            this.cbDbName.AllowDrop = true;
            this.cbDbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDbName.Enabled = false;
            this.cbDbName.FormattingEnabled = true;
            this.cbDbName.Location = new System.Drawing.Point(10, 37);
            this.cbDbName.Name = "cbDbName";
            this.cbDbName.Size = new System.Drawing.Size(149, 21);
            this.cbDbName.TabIndex = 1;
            this.cbDbName.SelectedIndexChanged += new System.EventHandler(this.cbDbName_SelectedIndexChanged);
            // 
            // lblSelectDbName
            // 
            this.lblSelectDbName.AutoSize = true;
            this.lblSelectDbName.Location = new System.Drawing.Point(7, 21);
            this.lblSelectDbName.Name = "lblSelectDbName";
            this.lblSelectDbName.Size = new System.Drawing.Size(133, 13);
            this.lblSelectDbName.TabIndex = 0;
            this.lblSelectDbName.Text = "Chọn cơ sở dữ liệu có sẵn:";
            // 
            // pnlConnectionInfo
            // 
            this.pnlConnectionInfo.Controls.Add(this.groupBox1);
            this.pnlConnectionInfo.Controls.Add(this.grbDatabaseConnection);
            this.pnlConnectionInfo.Controls.Add(this.lblDataSource);
            this.pnlConnectionInfo.Controls.Add(this.cbServerName);
            this.pnlConnectionInfo.Controls.Add(this.btnCancel);
            this.pnlConnectionInfo.Controls.Add(this.lblServerName);
            this.pnlConnectionInfo.Controls.Add(this.btnOK);
            this.pnlConnectionInfo.Controls.Add(this.btnFind);
            this.pnlConnectionInfo.Controls.Add(this.grbLogOn);
            this.pnlConnectionInfo.Location = new System.Drawing.Point(15, 13);
            this.pnlConnectionInfo.Name = "pnlConnectionInfo";
            this.pnlConnectionInfo.Size = new System.Drawing.Size(406, 471);
            this.pnlConnectionInfo.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateSample);
            this.groupBox1.Location = new System.Drawing.Point(8, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 51);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu mẫu";
            // 
            // btnCreateSample
            // 
            this.btnCreateSample.Enabled = false;
            this.btnCreateSample.Location = new System.Drawing.Point(10, 16);
            this.btnCreateSample.Name = "btnCreateSample";
            this.btnCreateSample.Size = new System.Drawing.Size(358, 23);
            this.btnCreateSample.TabIndex = 10;
            this.btnCreateSample.Text = "Tạo dữ liệu mẫu cho ứng dụng";
            this.btnCreateSample.UseVisualStyleBackColor = true;
            this.btnCreateSample.Click += new System.EventHandler(this.btnCreateSample_Click);
            // 
            // grbDatabaseConnection
            // 
            this.grbDatabaseConnection.Controls.Add(this.btnCreateNewDatabase);
            this.grbDatabaseConnection.Controls.Add(this.label1);
            this.grbDatabaseConnection.Controls.Add(this.txtNewDB);
            this.grbDatabaseConnection.Controls.Add(this.cbDbName);
            this.grbDatabaseConnection.Controls.Add(this.lblSelectDbName);
            this.grbDatabaseConnection.Location = new System.Drawing.Point(8, 295);
            this.grbDatabaseConnection.Name = "grbDatabaseConnection";
            this.grbDatabaseConnection.Size = new System.Drawing.Size(378, 78);
            this.grbDatabaseConnection.TabIndex = 5;
            this.grbDatabaseConnection.TabStop = false;
            this.grbDatabaseConnection.Text = "Chọn database làm việc";
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(15, 8);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(341, 91);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = resources.GetString("lblDataSource.Text");
            // 
            // frConnectToDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 497);
            this.Controls.Add(this.pnlConnectionInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frConnectToDatabase";
            this.Text = "Kết nối cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbLogOn.ResumeLayout(false);
            this.grbLogOn.PerformLayout();
            this.pnlConnectionInfo.ResumeLayout(false);
            this.pnlConnectionInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grbDatabaseConnection.ResumeLayout(false);
            this.grbDatabaseConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbServerName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox grbLogOn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.RadioButton rbServerAuthentication;
        private System.Windows.Forms.RadioButton rbWindowsAuthentication;
        private System.Windows.Forms.Button btnCreateNewDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewDB;
        private System.Windows.Forms.ComboBox cbDbName;
        private System.Windows.Forms.Label lblSelectDbName;
        private System.Windows.Forms.Panel pnlConnectionInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreateSample;
        private System.Windows.Forms.GroupBox grbDatabaseConnection;
        private System.Windows.Forms.Label lblDataSource;
    }
}