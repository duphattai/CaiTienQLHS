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
        private QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

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
            //DB.SubmitChanges();

            return result;
        }
        //public int Them(GIAOVIEN gv)
        //{
        //    try
        //    {
        //        DB.GIAOVIENs.InsertOnSubmit(gv);
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //}


        /// <summary>
        /// Cập nhật record vào table GIAOVIEN
        /// Cập nhật thành công trả về 1 và ngược lại
        /// </summary>
        public int Update(String MaGiaoVien, String TenGiaoVien, String DiaChi, DateTime NgaySinh, String Email, String GioiTinh, String MaMonHoc)
        {
            int result = DB.usp_UpdateGiaoVien(MaGiaoVien, TenGiaoVien, DiaChi, NgaySinh, Email, GioiTinh, MaMonHoc);
            //DB.SubmitChanges();

            return result;
        }
        //public int Update(String MaGiaoVien, String TenGiaoVien, String DiaChi, DateTime NgaySinh, String Email, String GioiTinh, String MaMonHoc)
        //{
        //    GIAOVIEN gv = DB.GIAOVIENs.Where(g => g.MaGiaoVien == MaGiaoVien).SingleOrDefault<GIAOVIEN>();
        //    if(gv != null)
        //    {
        //        gv.HoTen = TenGiaoVien;
        //        gv.DiaChi = DiaChi;
        //        gv.NgaySinh = NgaySinh;
        //        gv.Email = Email;
        //        gv.GioiTinh = GioiTinh;
        //        gv.MaMonHoc = MaMonHoc;

        //        return 1;
        //    }
        //    return -1;
        //}


        public void Delete(String MaGiaoVien)
        {
            DB.usp_DeleteGiaoVien(MaGiaoVien);
            //DB.SubmitChanges();
        }
        //public void Delete(String MaGiaoVien)
        //{
        //    GIAOVIEN gv = DB.GIAOVIENs.Where(g => g.MaGiaoVien == MaGiaoVien).SingleOrDefault<GIAOVIEN>();
        //    if (gv != null)
        //    {
        //        DB.GIAOVIENs.DeleteOnSubmit(gv);
        //    }
        //}

        public int LaySTTMaGiaoVienCuoiCung()
        {
            return (int)DB.usp_SelectLastSTTMaGiaoVien();   
        }

        public List<usp_SelectAllGiaoVienResult> LayDanhSachGiaoVien()
        {
            return DB.usp_SelectAllGiaoVien().ToList();
        }

        public void setSubmitChanged()
        {
            DB.SubmitChanges();
        }
    }
}
