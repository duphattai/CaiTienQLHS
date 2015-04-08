using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using System.Data.Linq;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    /// <summary>
    /// Lớp trung gian, quản lý việc truy xuất đến table KHOI (database) từ ứng dụng
    /// </summary>
    public class Khoi_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        /// <summary>
        /// lấy danh sách khối lớp từ bảng KHOI
        /// </summary>
        public ISingleResult<usp_SelectKhoisAllResult> LayDanhSachKhoi()
        {
            return DB.usp_SelectKhoisAll();
        }        
    }
}
