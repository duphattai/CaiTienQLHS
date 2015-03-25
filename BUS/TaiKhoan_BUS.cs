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
    public class TaiKhoan_BUS
    {
        AppDataContext HS = new AppDataContext();
        public List<TAIKHOAN> LayTatCaTaiKhoan()
        {
            return HS.TAIKHOANs.ToList();
        }
        public void Them(int imatk, String itentk, String imatKhau, int iloai)
        {
            HS.usp_InsertTaiKhoan(imatk, itentk, imatKhau, iloai);
            HS.SubmitChanges();

        }
        public void Sua(int imatk, String itentk, String imatKhau, int iloai)
        {
            HS.usp_UpdateTaiKhoan(imatk, itentk, imatKhau, iloai);
            HS.SubmitChanges();
        }
        public void Xoa(int _MSSV)
        {
            HS.usp_DeleteTaiKhoan(_MSSV);
            HS.SubmitChanges();
        }

        public ISingleResult<usp_SelectTaikhoanResult> TruyVanTaiKhoanTheoMaTK(int _MATK)
        {
            return HS.usp_SelectTaikhoan(_MATK);
        }
    }
}
