using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    /// <summary>
    /// Lớp trung gian, quản lý việc truy xuất đến table MONHOC (database) từ ứng dụng
    /// </summary>
    public class MonHoc_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        /// <summary>
        /// Trả về danh sách các môn học lấy được từ database
        /// </summary>
        public List<MONHOC> LayDanhSachMonHoc()
        {
            return DB.MONHOCs.ToList();
        }

        /// <summary>
        /// Kiểm tra môn học có nằm trong danh sách môn học không, nếu có trả về true hoặc ngược lại
        /// </summary>
        public bool KiemTraMonHoc(String _MonHoc, List<MONHOC> _ListMon)
        {
            foreach (MONHOC mh in _ListMon)
            {
                if (mh.TENMONHOC == _MonHoc)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// thêm môn học vào database
        /// </summary>
        public void Them(String _MaMon, String _TenMon)
        {
            DB.usp_InsertMonhoc(_MaMon, _TenMon);
        }

        /// <summary>
        /// Cập nhật lại môn học theo mã môn
        /// </summary>
        public void Update(String _MaMon, String _TenMon)
        {
            DB.usp_UpdateMonhoc(_MaMon, _TenMon);
        }

        /// <summary>
        /// Xóa môn học theo mã môn
        /// </summary>
        public void Delete(String _MaMon)
        {
            DB.usp_DeleteMonhoc(_MaMon);
        }
    }
}
