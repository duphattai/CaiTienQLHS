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
    /// Lớp trung gian, quản lý việc truy xuất đến table XEPLOP từ ứng dụng
    /// </summary>
    public class XepLop_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        /// <summary>
        /// Lấy tất cả dữ liệu từ table XEPLOP 
        /// </summary>
        /// <returns></returns>
        public List<XEPLOP> LayTatCa()
        {
            return DB.XEPLOPs.ToList();
        }

        /// <summary>
        /// lấy lớp học theo mã học sinh trong table XEPLOP
        /// </summary>
        /// <param name="_MAHS"></param>
        /// <returns></returns>
        public ISingleResult<usp_SelectXeplopsByMAHOCSINHResult> TruyVanTheoMaHocSinh(int _MAHS)
        {
            return DB.usp_SelectXeplopsByMAHOCSINH(_MAHS);
        }

        /// <summary>
        /// lấy danh sách mã học sinh theo mã lớp trên table XEPLOP
        /// </summary>
        /// <param name="_MALOP"></param>
        /// <returns></returns>
        public ISingleResult<usp_SelectXeplopsByMALOPResult> TruyVanTheoMaLop(int _MALOP)
        {
            return DB.usp_SelectXeplopsByMALOP(_MALOP);

        }

        /// <summary>
        /// Kiểm tra học sinh có thuộc lớp nào đó không
        /// </summary>
        /// <param name="_MaHS"></param>
        /// <param name="_MaLop"></param>
        /// <returns></returns>
        public bool CheckExist(int _MaHS, int _MaLop)
        {
            try
            {
                if (DB.usp_SelectXeplop(_MaHS, _MaLop).Count() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// cập nhật lại dữ liệu trên bảng XEPLOP
        /// </summary>
        /// <param name="_MaHS"></param>
        /// <param name="_MaLop"></param>
        /// <param name="_NewMaHS"></param>
        /// <param name="_NewMaLop"></param>
        public void Update(int? _MaHS, int? _MaLop, int? _NewMaHS, int? _NewMaLop)
        {
            DB.usp_UpdateXeplop(_MaHS, _MaLop, _NewMaHS, _NewMaLop);
        }

        /// <summary>
        /// xóa mã học khỏi table
        /// </summary>
        /// <param name="_MaHS"></param>
        /// <param name="_MaLop"></param>
        public void Delete(int _MaHS, int _MaLop)
        {
            DB.usp_DeleteXeplop(_MaLop, _MaHS);
        }

        /// <summary>
        /// insert một học sinh vào lớp
        /// </summary>
        /// <param name="_MaHS"></param>
        /// <param name="_MaLop"></param>
        public void Insert(int _MaHS, int _MaLop)
        {
            DB.usp_InsertXeplop(_MaHS, _MaLop);
        }

        /// <summary>
        /// tìm mã lớp theo mã học sinh và năm học 
        /// </summary>
        /// <param name="_MaHocSinh"></param>
        /// <param name="_NamHoc"></param>
        /// <returns>
        /// nếu tìm được trả về vị trí, không thì trả về -1
        /// </returns>
        public int TimMaLopTheoMaHS_NamHoc(int _MaHocSinh, string _NamHoc)
        {
            try
            {
                return DB.usp_SelectMALOPByMAHOCSINH_NAMHOC(_MaHocSinh, _NamHoc).First().MALOP;
            }
            catch
            {
                return -1;
            }
        }
    }
}
