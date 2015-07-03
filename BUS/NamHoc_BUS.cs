using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    /// <summary>
    /// Lớp trung gian, quản lý việc truy xuất đến table NAMHOC từ ứng dụng đến database
    /// </summary>
    public class NamHoc_BUS
    {

        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
        QLHSDataContext DBServer = new QLHSDataContext(ConnectionServer.connectionServer);
        /// <summary>
        /// Lấy danh sách các năm học từ database
        /// </summary>
        public List<NAMHOC> LayNamHoc()
        {
            return DB.NAMHOCs.ToList();
        }

        /// <summary>
        /// xóa một năm học khỏi database
        /// </summary>
        public void XoaNamHoc(NAMHOC namhoc)
        {
            DB.usp_DeleteNamhoc(namhoc.NAMHOC1);
            DBServer.usp_DeleteNamhoc(namhoc.NAMHOC1);
        }

        /// <summary>
        /// insert năm học vào database
        /// </summary>
        public void ThemNamHoc(NAMHOC namhoc)
        {
            DB.usp_InsertNamhoc(namhoc.NAMHOC1);
            DBServer.usp_InsertNamhoc(namhoc.NAMHOC1);
        } 
    }
}
