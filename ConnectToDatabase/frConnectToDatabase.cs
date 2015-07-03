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
    public partial class FormConnectToDatabase : Form
    {
        private Server _mServer; // dùng để truy cập server trong database
        private ServerConnection _mServerConnection; // cổng kết nối database
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

        /// <summary>
        /// Kết nối tới server được chọn, kết nối thành công trả về chuỗi rỗng và ngược lại
        /// </summary>
        private string ConnectDatabase()
        {
            if (!string.IsNullOrEmpty(cbServerName.Text)) // cbServerName phải được input
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

                    ListDataBases();// Kết nối thành công, hiển thị danh sách database có trên server
                    return String.Empty;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "Không có server nào được chọn";
        }

        /// <summary>
        /// Hiển thị danh sách các database có trong server
        /// </summary>
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

        /// <summary>
        /// Kiểm tra các bảng trong database có đúng theo quy định, đúng trả về true và ngược lại
        /// </summary>
        private bool CheckDatabase(string dbname)
        {
            string data = Properties.Resources.CheckTable;
            var dsTables = _mServer.Databases[dbname].ExecuteWithResults(data);
            return dsTables.Tables[0].Rows.Count > 0;
        }

        
        /// <summary>
        /// Tạo một chuỗi kết nối, trả về chuỗi đã tạo
        /// </summary>
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
                             ";User ID=" + Settings.Default.UserName + ";Password=" +
                             Settings.Default.Password + ";";
            }
            return connectStr;
        }
        #endregion

        public FormConnectToDatabase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện: xảy ra khi FormConnectToDatabase được show lên
        /// </summary>
        private void FormConnectToDatabase_Load(object sender, EventArgs e)
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\"); // tìm kiếm key "SOFTWARE\Microsoft\Microsoft SQL Server\" có hiện hữu trên HKEY_LOCAL_MACHINE trong register không
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

        /// <summary>
        /// Sự kiện: xảy ra khi button tìm trong mạng được click
        /// Tìm server có trong sql server
        /// </summary>
        private void ButtonTimServer_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Sự kiện: khi người dùng chọn quyền thực thi trên windows
        /// Thiết lập các txtUserName, txtPassWord không thao tác được
        /// </summary>
        private void rbWindowsAuthentication_Click(object sender, EventArgs e)
        {
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
        }

        /// <summary>
        /// Sự kiện: khi người dùng chọn quyền thực thi trên Server
        /// cho phép người dùng thao tác trên txtUserName, txtPassWord
        /// </summary>
        private void rbServerAuthentication_Click(object sender, EventArgs e)
        {
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
        }

        /// <summary>
        /// Sự kiện: khi người dùng click vào button kết nối
        /// Kết nối đến server của sql
        /// </summary>
        private void ButtonKetNoi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbServerName.Text))
            {
                this.Cursor = Cursors.WaitCursor; // chuyển con chuột thành đồng hồ cát
                string message = ConnectDatabase(); // thực thi kết nối tới server
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



        private void deleteDataInServerDefault()
        {
            string dbName = "db9bb53d537cd2482faf21a4ca0005beed";
            string user = "qvjbkygtnotctllb";
            string pass = "T2HrD3ohwSHpCbeAsaYXYdSPidqCJ58vXLsbeaNTJpMNyasEDtUTJKkPh3izLTFA";
            string host = "9bb53d53-7cd2-482f-af21-a4ca0005beed.sqlserver.sequelizer.com";
            
            Server _mServer; // dùng để truy cập server trong database
            ServerConnection _mServerConnection = new ServerConnection(host); // cổng kết nối database

            _mServerConnection.LoginSecure = false;
            _mServerConnection.Login = user;
            _mServerConnection.Password = pass;
            // Create a new SQL Server object using the connection we created
            _mServer = new Server(_mServerConnection);

            string dataCreateDatabase = Properties.Resources.DeleteAllData;
            dataCreateDatabase = dataCreateDatabase.Replace("[PlaceHolder]", dbName);
            _mServer.ConnectionContext.ExecuteNonQuery(dataCreateDatabase); 
           
        }

        /// <summary>
        /// Sự kiện: xảy ra khi button Tạo mới cơ sở dữ liệu được click
        /// Tạo database cùng với các trigger, store procedure
        /// </summary>
        private void ButtonCreateNewDatabase_Click(object sender, EventArgs e)
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
                        this.Cursor = Cursors.WaitCursor;// chuyển con chuột thành đồng hồ cát
                        string dataCreateDatabase = Properties.Resources.CreateDatabase; // lưu trữ dữ liệu để tạo database cùng với các table, trigger
                        string dataCreateStroredProcedures = Properties.Resources.StroredProcedures; // dữ liệu dùng để tạo storedProcedures
                        string dbName = txtNewDB.Text;
                        var newDB = new Database(_mServer, dbName);
                        newDB.Create();
                        ListDataBases();

                        dataCreateDatabase = dataCreateDatabase.Replace("[PlaceHolder]", dbName);
                        dataCreateStroredProcedures = dataCreateStroredProcedures.Replace("[PlaceHolder]", dbName);
                        _mServer.ConnectionContext.ExecuteNonQuery(dataCreateDatabase); // thực thi tạo database trên sql server
                        _mServer.ConnectionContext.ExecuteNonQuery(dataCreateStroredProcedures); // thực thi tạo storedProcedures
                        cbDbName.SelectedItem = cbDbName.Items[cbDbName.Items.IndexOf(dbName)];
                        btnCreateSample.Enabled = true;

                        deleteDataInServerDefault();                        
                        MessageBox.Show("Đã tạo database thành công", "Success");
                        this.Cursor = Cursors.Default;// chuyển con chuột trở về dạng ban đầu
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


        private void createDataSampleOnDefaultServer()
        {
            string dbName = "db9bb53d537cd2482faf21a4ca0005beed";
            string user = "qvjbkygtnotctllb";
            string pass = "T2HrD3ohwSHpCbeAsaYXYdSPidqCJ58vXLsbeaNTJpMNyasEDtUTJKkPh3izLTFA";
            string host = "9bb53d53-7cd2-482f-af21-a4ca0005beed.sqlserver.sequelizer.com";

            Server server; // dùng để truy cập server trong database
            ServerConnection _mServerConnection = new ServerConnection(host); // cổng kết nối database

            _mServerConnection.LoginSecure = false;
            _mServerConnection.Login = user;
            _mServerConnection.Password = pass;
            // Create a new SQL Server object using the connection we created
            server = new Server(_mServerConnection);
            this.Cursor = Cursors.WaitCursor; // chuyển con chuột thành đồng hồ cát
            string data = Properties.Resources.InitData; // dữ liệu để tạo các records trên các table

            data = data.Replace("[PlaceHolder]", dbName);

            server.Databases[dbName].ExecuteNonQuery(data); // thêm các records vào các table
        }
        /// <summary>
        /// Sự kiện: khi button Tạo dữ liệu mẫu được click
        /// Tạo records mẫu trên database
        /// </summary>
        private void ButtonCreateSample_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; // chuyển con chuột thành đồng hồ cát
                string data = Properties.Resources.InitData; // dữ liệu để tạo các records trên các table

                data = data.Replace("[PlaceHolder]", txtNewDB.Text);

                _mServer.Databases[txtNewDB.Text].ExecuteNonQuery(data); // thêm các records vào các table
                createDataSampleOnDefaultServer();

                MessageBox.Show("Đã tạo dữ liệu mẫu thành công", "Success");
                btnCreateSample.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra" + ex.Message, "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;// chuyển con chuột trở về dạng mặc định
            }
        }


        private void cbDbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCreateSample.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ButtonOK_Click(object sender, EventArgs e)
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
            else if (_mServer.Databases[cbDbName.Text].Tables.Count == 0)
            {
                this.Cursor = Cursors.WaitCursor;// chuyển con chuột thành đồng hồ cát
                string dataCreateDatabase = Properties.Resources.CreateDatabase; // lưu trữ dữ liệu để tạo database cùng với các table, trigger
                string dataCreateStroredProcedures = Properties.Resources.StroredProcedures; // dữ liệu dùng để tạo storedProcedures
                string dbName = cbDbName.Text;

                dataCreateDatabase = dataCreateDatabase.Replace("[PlaceHolder]", dbName);
                dataCreateStroredProcedures = dataCreateStroredProcedures.Replace("[PlaceHolder]", dbName);
                _mServer.ConnectionContext.ExecuteNonQuery(dataCreateDatabase); // thực thi tạo database trên sql server
                _mServer.ConnectionContext.ExecuteNonQuery(dataCreateStroredProcedures); // thực thi tạo storedProcedures
                btnCreateSample.Enabled = true;

                MessageBox.Show("Đã tạo database thành công", "Success");
                this.Cursor = Cursors.Default;// chuyển con chuột trở về dạng ban đầu
            }
            else
            {
                MessageBox.Show("Cơ sở dữ liệu đang chọn không đúng chuẩn!" + "\nVui lòng chọn đúng cơ sở dữ liệu hoặc tạo cơ sở dữ liệu mới");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
