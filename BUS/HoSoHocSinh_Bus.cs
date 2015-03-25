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
   public class HoSoHocSinh_Bus
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
        public List<HOSOHOCSINH> LayTatCaHocSinh()
        {
          return  DB.HOSOHOCSINHs.ToList();
        }

       public void Them(String _HoTen,String _DiaChi, DateTime _NgaySinh, String _Email,String _GioiTinh)
        {
            DB.usp_InsertHosohocsinh(LayMaHocSinhCuoi() + 1, _HoTen, _DiaChi, _NgaySinh, _Email, _GioiTinh);
            DB.SubmitChanges();
        }
        public void Update( int _MSSV, String _HoTen,String _DiaChi, DateTime _NgaySinh, String _Email,String _GioiTinh)
       {
           DB.usp_UpdateHosohocsinh(_MSSV, _HoTen, _DiaChi, _NgaySinh, _Email, _GioiTinh);
       }

        public void Delete(int _MSSV)
        {
            DB.usp_DeleteHosohocsinh(_MSSV);
            DB.SubmitChanges();
        }

     //public ISingleResult<usp_SelectHosohocsinhsNotMaHocSinhResult> TruyVanHocSinhKhongLayMaHocSinh(int? _MAHS)
     //   {
     //       return DB.usp_SelectHosohocsinhsNotMaHocSinh(_MAHS);
     //   }
           public ISingleResult<usp_SelectHosohocsinhResult>  TruyVanHocSinhTheoMaHocSinh(int? _MAHS)
         {
             return DB.usp_SelectHosohocsinh(_MAHS);
         }

        public ISingleResult<usp_SelectHocSinhTheoMALOPResult> TruyVanHocSinhTheoMaLop(int _MaLop)
        {
            return DB.usp_SelectHocSinhTheoMALOP(_MaLop);
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
