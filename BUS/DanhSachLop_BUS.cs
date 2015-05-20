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
    ///  Đối tượng dùng để chứa danh sách học sinh trong lớp
    /// </summary>
    public class DanhSachLop_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
        HoSoHocSinh_BUS _HSBUS = new HoSoHocSinh_BUS();
        XepLop_BUS _XLBUS = new XepLop_BUS();
        List<ThongTinLop> _ListLop = new List<ThongTinLop>();

        /// <summary>
        /// Trả về danh sách lớp trong table LOP
        /// </summary>
        public List<LOP> LayDanhSachLop()
        {
            return DB.LOPs.ToList();
        }

        /// <summary>
        /// Trả về một lớp được lọc theo mã lớp cụ thể trong danh sách lớp
        /// </summary>
        public ISingleResult<usp_SelectLopResult> LayDanhSachLop(int _Malop)
        {
            return DB.usp_SelectLop(_Malop);
        }

        /// <summary>
        /// Trả về danh sách học sinh trong một lớp
        /// </summary>
        public ISingleResult<usp_SelectHocSinhTheoMALOPResult> LayDanhSachHocSinhTheoMaLop(int _Malop)
        {
            return DB.usp_SelectHocSinhTheoMALOP(_Malop);
        }

        /// <summary>
        /// Trả về danh sách học sinh chưa phân lớp theo năm học
        /// </summary>
        public ISingleResult<usp_SelectHocSinhChuaPhanLopResult> LayDanhSachHocSinhChuaPhanLop(string _Namhoc)
        {
            return DB.usp_SelectHocSinhChuaPhanLop(_Namhoc);
        }

        /// <summary>
        /// Trả về danh sách lớp theo khối trong một năm học
        /// </summary>
        public ISingleResult<usp_SelectLopsByMAKHOI_NAMHOCResult> LayDanhSachLopTheoKhoiMaNam(String _Makhoi, String _NamHoc)
        {
            return DB.usp_SelectLopsByMAKHOI_NAMHOC(_Makhoi, _NamHoc);
        }

        /// <summary>
        /// Trả về danh sách các lớp trong một năm học
        /// </summary>
        public ISingleResult<usp_SelectLopByNamHocResult> LayDanhSachLopNamHoc(String _NamHoc)
        {
            return DB.usp_SelectLopByNamHoc(_NamHoc);
        }

        /// <summary>
        /// Trả về mã lớp cuối trong  table LOP
        /// </summary>
        public int LayMaLopCuoi()
        {
            try
            {
                return DB.usp_SelectLastMaLop().First().MALOP;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Trả về năm học theo mã lớp nào đó
        /// </summary>
        public string LayNamHocTheoMaLop(int _MaLop)
        {
            try
            {
                return DB.usp_SelectLop(_MaLop).First().NAMHOC;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Tính sỉ số từng lớp, trả về danh sách lớp cùng với sỉ số tương ứng
        /// </summary>
        public List<ThongTinLop> TinhSiSoLop()
        {
            int _countSiSo = 0;
            foreach (XEPLOP xl in _XLBUS.LayTatCa()) // duyệt danh sách lớp được xếp lớp
            {
                foreach (LOP lop in LayDanhSachLop()) // duyệt tất cả danh sách lớp
                {
                    foreach (HOSOHOCSINH hs in _HSBUS.LayTatCaHocSinh()) // duyệt từng HS
                    {
                        if (hs.MAHOCSINH == xl.MAHOCSINH && xl.MALOP == lop.MALOP)
                        {
                            _countSiSo++;
                        }
                    }

                    ThongTinLop _newlop = new ThongTinLop(lop.TENLOP, _countSiSo); // tạo một đối tượng chứa lớp và sỉ số
                    _ListLop.Add(_newlop); // thêm vào danh sách lớp
                    _countSiSo = 0;
                }
            }

            return _ListLop;
        }

        /// <summary>
        /// Cập nhật lại dữ liệu trong table LOP theo mã lớp
        /// </summary>
        public void Update(int _MaLop,String _TenLop,String _NamHoc,String _MaKhoi)
        {
            DB.usp_UpdateLop(_MaLop, _MaKhoi, _TenLop, _NamHoc, 0);
        }

        /// <summary>
        /// thêm dữ liệu trong table LOP
        /// </summary>
        public void Insert(int _MaLop,String _TenLop,String _NamHoc,String _MaKhoi)
        {
            DB.usp_InsertLop(_MaLop, _MaKhoi, _TenLop, _NamHoc, 0);
        }

        /// <summary>
        /// Xóa một lớp
        /// </summary>
        public void Delete(int _MaLop)
        {
            DB.usp_DeleteLop(_MaLop);
        }

       public ISingleResult<usp_SelectDanhSachLopNotInGiangDayResult> LayDanhSachLopGiangVienChuaPhanCong(String MaMonHoc, String NamHoc)
       {
           return DB.usp_SelectDanhSachLopNotInGiangDay(MaMonHoc, NamHoc);
       }
    }
}
