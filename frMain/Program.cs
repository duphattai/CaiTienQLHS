using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Settings = ConnectToDatabase.Properties.Settings;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace frMain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            if (String.IsNullOrEmpty(Settings.Default.ConnectString))
            {
                Application.Run(new ConnectToDatabase.FormConnectToDatabase());
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectString))
                    {
                        connection.Open();
                    }
                }
                catch
                {
                    Settings.Default.ConnectString = null;
                    MessageBox.Show("Cơ sở dữ liệu của bạn đã bị lỗi, vui lòng tạo cơ sở dữ liệu mới", "Error");
                    Application.Run(new ConnectToDatabase.FormConnectToDatabase());
                }
            }
           
            if (!String.IsNullOrEmpty(Settings.Default.ConnectString))
            {
                //Application.Run(new fmQuanLyHocSinh());
                Application.Run(new frDangNhap());
            }
        }
    }
}
