using DataAccessObject.DAO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    public class ThoiKhoaBieu_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        /// <summary>
        /// Thêm một record vào table THOIKHOABIEU
        /// thêm thành công trả về 1 và ngược lại
        /// </summary>
        public int Them(int MaLop, String MaGiaoVien, int Tiet)
        {
            int result = DB.usp_InsertThoiKhoaBieu(MaLop, MaGiaoVien, Tiet);
            DB.SubmitChanges();

            return result;
        }

        /// <summary>
        /// Cập nhật record vào table THOIKHOABIEU
        /// Cập nhật thành công trả về 1 và ngược lại
        /// </summary>
        public int Update(int MaLop, String MaGiaoVien, int Tiet)
        {
            int result = DB.usp_UpdateThoiKhoaBieu(MaLop, MaGiaoVien, Tiet);
            DB.SubmitChanges();

            return result;
        }

        public List<usp_SelectThoiKhoaBieuBy_MaGiaoVienResult> LayThoiKhoaBieu(string MaGiaoVien)
        {
            return DB.usp_SelectThoiKhoaBieuBy_MaGiaoVien(MaGiaoVien).ToList();
        }

        public List<usp_SelectThoiKhoaBieuBy_MaLopResult> LayThoiKhoaBieu(int MaLop)
        {
            return DB.usp_SelectThoiKhoaBieuBy_MaLop(MaLop).ToList();
        }

        public Boolean CheckExistsThoiKhoaBieuByMaLop(int MaLop)
        {
            return Convert.ToBoolean(DB.usp_CheckExistsThoiKhoaBieuBy_MaLop(MaLop));
        }

        public void Delete(int MaLop)
        {
            DB.usp_DeleteThoiKhoaBieuBy_MaLop(MaLop);
        }
    }
}
