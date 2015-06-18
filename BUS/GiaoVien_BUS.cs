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
    public class GiaoVien_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        public List<GIAOVIEN> LayTatCaDanhSachGiaoVien()
        {
            return DB.GIAOVIENs.ToList();
        }

        /// <summary>
        /// Thêm một record vào table GIAOVIEN
        /// thêm thành công trả về 1 và ngược lại
        /// </summary>
        public int Them(String MaGiaoVien, String TenGiaoVien, String DiaChi, DateTime NgaySinh, String Email, String GioiTinh, String MaMonHoc)
        {
            int result =  DB.usp_InsertGiaoVien(MaGiaoVien, TenGiaoVien, DiaChi, NgaySinh, Email, GioiTinh, MaMonHoc);
            DB.SubmitChanges();

            return result;
        }

        /// <summary>
        /// Cập nhật record vào table GIAOVIEN
        /// Cập nhật thành công trả về 1 và ngược lại
        /// </summary>
        public int Update(String MaGiaoVien, String TenGiaoVien, String DiaChi, DateTime NgaySinh, String Email, String GioiTinh, String MaMonHoc)
        {
            int result = DB.usp_UpdateGiaoVien(MaGiaoVien, TenGiaoVien, DiaChi, NgaySinh, Email, GioiTinh, MaMonHoc);
            DB.SubmitChanges();

            return result;
        }

        public void Delete(String MaGiaoVien)
        {
            DB.usp_DeleteGiaoVien(MaGiaoVien);
            DB.SubmitChanges();
        }

        public int LaySTTMaGiaoVienCuoiCung()
        {
            return (int)DB.usp_SelectLastSTTMaGiaoVien();   
        }

        public List<usp_SelectAllGiaoVienResult> LayDanhSachGiaoVien()
        {
            return DB.usp_SelectAllGiaoVien().ToList();
        }
    }
}
