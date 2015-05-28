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
    // truy xuất dữ liệu database APPDATA
    public class TaiKhoan_BUS
    {
        AppDataContext HS = new AppDataContext();
        
        // Trả về danh sách các tài khoản lấy từ bảng TAIKHOAN
        public List<TAIKHOAN> LayTatCaTaiKhoan()
        {
            return HS.TAIKHOANs.ToList();
        }

        // Coder: Tài
        // Trả về danh sách các kết quả khi thực thi câu truy vấn
        public List<usp_SelectLastMaTKResult> LayMaTKCuoiCung()
        {
            return HS.usp_SelectLastMaTK().ToList();
        }

        // Thêm tài khoản vào bảng TAIKHOAN
        public void Them(int imatk, String itentk, String imatKhau, int iloai)
        {
            HS.usp_InsertTaiKhoan(imatk, itentk, imatKhau, iloai);
            HS.SubmitChanges();
        }

        // cập nhật dữ liệu tại một mã tài khoản
        public void Sua(int imatk, String itentk, String imatKhau, int iloai)
        {
            HS.usp_UpdateTaiKhoan(imatk, itentk, imatKhau, iloai);
            HS.SubmitChanges();
        }

        // xóa một tài khoản
        public void Xoa(int _MSSV)
        {
            HS.usp_DeleteTaiKhoan(_MSSV);
            HS.SubmitChanges();
        }


        // trả về danh sách tài khoản theo mã tài khoản
        public List<usp_SelectTaikhoanResult> TruyVanTaiKhoanTheoMaTK(int _MATK)
        {
            return HS.usp_SelectTaikhoan(_MATK).ToList();
        }
    }
}
