using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using Settings = ConnectToDatabase.Properties.Settings;

namespace ConnectToDatabase
{
    public partial class frConnectToDatabase : Form
    {
        private Server _mServer;
        private ServerConnection _mServerConnection;
        public bool _IsOKClicked = false;

        #region Hàm chức năng
        //Find server in computer
        private void FindServer()
        {
            this.Cursor = Cursors.WaitCursor;
            cbServerName.Items.Clear();

            DataTable table = SmoApplication.EnumAvailableSqlServers(false);

            foreach (DataRow item in table.Rows)
            {
                cbServerName.Items.Add(item["Name"]);
            }
            if (cbServerName.Items.Count > 0)
                cbServerName.SelectedIndex = 0;

            this.Cursor = Cursors.Default;
        }

        //Connect to selected database
        private string ConnectDatabase()
        {
            if (!string.IsNullOrEmpty(cbServerName.Text))
            {
                try
                {
                    _mServerConnection = new ServerConnection(cbServerName.Text);
                    //Check type of Authentication
                    if (rbWindowsAuthentication.Checked)
                    {
                        _mServerConnection.LoginSecure = true;
                        _mServer = new Server(_mServerConnection);
                    }
                    else
                    {
                        // Create a new connection to the selected server name
                        _mServerConnection.LoginSecure = false;
                        _mServerConnection.Login = txtUserName.Text;
                        _mServerConnection.Password = txtPassword.Text;
                        // Create a new SQL Server object using the connection we created
                        _mServer = new Server(_mServerConnection);
                    }
                    ListDataBases();
                    return String.Empty;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "Không có server nào được chọn";
        }

        //List all database in server
        private void ListDataBases()
        {
            cbDbName.Items.Clear();
            foreach (Database db in _mServer.Databases)
            {
                //Check if database is not a system database
                if (!db.IsSystemObject)
                {
                    cbDbName.Items.Add(db.Name);
                }
            }

            if (cbDbName.Items.Count > 0)
            {
                cbDbName.SelectedIndex = 0;
            }
        }

        //Check if enought table in database
        private bool CheckDatabase(string dbname)
        {
            string data = Properties.Resources.CheckTable;
            var dsTables = _mServer.Databases[dbname].ExecuteWithResults(data);
            return dsTables.Tables[0].Rows.Count > 0;
        }

        //Create a connection string
        private string CreateConnectionString()
        {
            string connectStr;
            if (!Settings.Default.SQLAuthenticationMode)
            {
                connectStr = @"Server=" + Settings.Default.Server + ";Database=" + Settings.Default.DatabaseName +
                             ";Trusted_Connection=True;";
            }
            else
            {
                connectStr = @"Server=" + Settings.Default.Server + ";Database=" + Settings.Default.DatabaseName +
                             ";Integrated Security=SSPI;User ID=" + Settings.Default.UserName + ";Password=" +
                             Settings.Default.Password + ";";
            }
            return connectStr;
        }
        #endregion

        public frConnectToDatabase()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\");
            }
            catch (Exception)
            {
                rk = Registry.LocalMachine.OpenSubKey(@"\SOFTWARE\Microsoft\Microsoft SQL Server\");
            }

            if (rk != null)
            {
                IEnumerable<string> instances = (String[])rk.GetValue("InstalledInstances");
                if (instances != null)
                {
                    foreach (string instance in instances)
                    {
                        cbServerName.Items.Add(@"localhost\" + instances);
                    }
                }
            }

            if (cbServerName.Items.Count > 0)
                cbServerName.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tìm kiếm các máy chủ có thể mất nhiều thời gian."
                                + "\nBạn có thể gõ Tên máy chủ hoặc IP của máy chủ."
                                + "\nBạn có chắc chắn muốn tìm các máy chủ hoạt động trong mạng LAN?",
                                "Network finding...",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                FindServer();
            }
        }

        private void rbWindowsAuthentication_Click(object sender, EventArgs e)
        {
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void rbServerAuthentication_Click(object sender, EventArgs e)
        {
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbServerName.Text))
            {
                this.Cursor = Cursors.WaitCursor;
                string message = ConnectDatabase();
                this.Cursor = Cursors.Default;

                if (string.IsNullOrEmpty(message))
                {
                    cbDbName.Enabled = true;
                    btnCreateNewDatabase.Enabled = true;
                    txtNewDB.Enabled = true;
                }
                else
                {
                    MessageBox.Show(message, "SQL Authetication", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                // A server was not selected, show an error message
                MessageBox.Show("Bạn hãy chọn hoặc gõ Tên máy chủ để thực hiện!", "Server not selected",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnCreateNewDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNewDB.Text))
                {
                    if (cbDbName.Items.Contains(txtNewDB.Text))
                    {
                        MessageBox.Show("Database đã tồn tại");
                        return;
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        string data = Properties.Resources.CreateDatabase;
                        string data2 = Properties.Resources.StroredProcedures;
                        string dbName = txtNewDB.Text;
                        var newDB = new Database(_mServer, dbName);
                        newDB.Create();
                        ListDataBases();

                        data = data.Replace("[PlaceHolder]", dbName);
                        data2 = data2.Replace("[PlaceHolder]", dbName);
                        _mServer.ConnectionContext.ExecuteNonQuery(data);
                        _mServer.ConnectionContext.ExecuteNonQuery(data2);
                        cbDbName.SelectedItem = cbDbName.Items[cbDbName.Items.IndexOf(dbName)];
                        btnCreateSample.Enabled = true;

                        MessageBox.Show("Đã tạo database thành công", "Success");
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên database");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra" + ex.Message, "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCreateSample_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string data = Properties.Resources.InitData;
                

                data = data.Replace("[PlaceHolder]", txtNewDB.Text);

                _mServer.Databases[txtNewDB.Text].ExecuteNonQuery(data);
                MessageBox.Show("Đã tạo dữ liệu mẫu thành công", "Success");
                btnCreateSample.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra" + ex.Message, "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cbDbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCreateSample.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckDatabase(cbDbName.Text))
            {
                Settings.Default.Server = cbServerName.Text;
                Settings.Default.SQLAuthenticationMode = rbServerAuthentication.Checked;
                Settings.Default.DatabaseName = cbDbName.SelectedItem.ToString();
                if (rbServerAuthentication.Checked)
                {
                    Settings.Default.UserName = txtUserName.Text;
                    Settings.Default.Password = txtPassword.Text;
                    Settings.Default.SavePassword = true;
                }
                else
                {
                    Settings.Default.UserName = string.Empty;
                    Settings.Default.Password = string.Empty;
                    Settings.Default.SavePassword = false;
                }

                Settings.Default.ConnectString = CreateConnectionString();
                Settings.Default.Save();

                DialogResult = DialogResult.OK;
                _IsOKClicked = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cơ sở dữ liệu đang chọn không đúng chuẩn!" + "\nVui lòng chọn đúng cơ sở dữ liệu hoặc tạo cơ sở dữ liệu mới");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
