using DataAccessObject.DAO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = ConnectToDatabase.Properties.Settings;
using System.Threading;

namespace BUS
{
    public class GiaoVien_BUS
    {
        private QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
        private QLHSDataContext DBServer = new QLHSDataContext(ConnectionServer.connectionServer);
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
            int result = DB.usp_InsertGiaoVien(MaGiaoVien, TenGiaoVien, DiaChi, NgaySinh, Email, GioiTinh, MaMonHoc);
            DB.SubmitChanges();

            DBServer.usp_InsertGiaoVien(MaGiaoVien, TenGiaoVien, DiaChi, NgaySinh, Email, GioiTinh, MaMonHoc);
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
            DBServer.usp_UpdateGiaoVien(MaGiaoVien, TenGiaoVien, DiaChi, NgaySinh, Email, GioiTinh, MaMonHoc);
            return result;
        }



        public void Delete(String MaGiaoVien)
        {
            DB.usp_DeleteGiaoVien(MaGiaoVien);
            DB.SubmitChanges();

            DBServer.usp_DeleteGiaoVien(MaGiaoVien);
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
