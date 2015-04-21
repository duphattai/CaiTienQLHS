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
    /// Lớp trung gian, quản lý việc truy xuất đến table HOCKY (database) từ ứng dụng
    /// </summary>
    public class HocKy_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        /// <summary>
        /// Trả về danh sách học kỳ lấy từ atabase
        /// </summary>
        public List<HOCKY> LayDanhSachHocKy()
        {
            return DB.HOCKies.ToList();
        }
    }
}
