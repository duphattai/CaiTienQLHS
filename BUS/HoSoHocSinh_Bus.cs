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
    /// Lớp trung gian, quản lý truy xuất dữ liệu trên bảng HOSOHOCSINH từ ứng dụng
    /// </summary>
   public class HoSoHocSinh_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
       /// <summary>
       /// lấy tất cả danh sách học sinh
       /// </summary>
       /// <returns>
       /// trả về một danh sách đối tượng (chứa các thông tin của học sinh)
       /// </returns>
       public List<HOSOHOCSINH> LayTatCaHocSinh()
        {
          return  DB.HOSOHOCSINHs.ToList();
        }

       /// <summary>
       /// thêm một học sinh vào bảng
       /// </summary>
       /// <param name="_HoTen"></param>
       /// <param name="_DiaChi"></param>
       /// <param name="_NgaySinh"></param>
       /// <param name="_Email"></param>
       /// <param name="_GioiTinh"></param>
       public void Them(String _HoTen,String _DiaChi, DateTime _NgaySinh, String _Email,String _GioiTinh)
        {
            DB.usp_InsertHosohocsinh(LayMaHocSinhCuoi() + 1, _HoTen, _DiaChi, _NgaySinh, _Email, _GioiTinh);
            DB.SubmitChanges();
        }

       /// <summary>
       /// cập nhật lại thông tin học sinh theo mã học sinh
       /// </summary>
       /// <param name="_MSSV"></param>
       /// <param name="_HoTen"></param>
       /// <param name="_DiaChi"></param>
       /// <param name="_NgaySinh"></param>
       /// <param name="_Email"></param>
       /// <param name="_GioiTinh"></param>
        public void Update( int _MSSV, String _HoTen,String _DiaChi, DateTime _NgaySinh, String _Email,String _GioiTinh)
       {
           DB.usp_UpdateHosohocsinh(_MSSV, _HoTen, _DiaChi, _NgaySinh, _Email, _GioiTinh);
       }

       /// <summary>
       /// xóa một học sinh theo mã học sinh
       /// </summary>
       /// <param name="_MSSV"></param>
        public void Delete(int _MAHS)
        {
            DB.usp_DeleteHosohocsinh(_MAHS);
            DB.SubmitChanges();
        }

       /// <summary>
       /// lấy thông tin học sinh theo mã học sinh
       /// </summary>
       /// <param name="_MAHS"></param>
       /// <returns>
       /// trả về danh sách các đối tượng (chứa thông tin học sinh)
       /// </returns>
        public List<usp_SelectHosohocsinhResult> TruyVanHocSinhTheoMaHocSinh(int? _MAHS)
         {
             return DB.usp_SelectHosohocsinh(_MAHS).ToList();
         }

       /// <summary>
       /// Hiển thị danh sách học sinh theo mã lớp
       /// </summary>
       /// <param name="_MaLop"></param>
       /// <returns>
       /// trả về danh sách các đối tượng (chứa thông tin học sinh)
       /// </returns>
        public List<usp_SelectHocSinhTheoMALOPResult> TruyVanHocSinhTheoMaLop(int _MaLop)
        {
            return DB.usp_SelectHocSinhTheoMALOP(_MaLop).ToList();
        }

       public int LayMaHocSinhCuoi()
       {
           try
           {
               return DB.usp_SelectLastMaHocSinh().First().MAHOCSINH;
           }
           catch
           {
               return -1;
           }
       }
    }
}
