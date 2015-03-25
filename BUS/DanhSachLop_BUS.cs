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

    public class DanhSachLop_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
        HoSoHocSinh_Bus _HSBUS = new HoSoHocSinh_Bus();
        XepLop_BUS _XLBUS = new XepLop_BUS();
        List<Lop_BUS> _ListLop = new List<Lop_BUS>();

        public List<LOP> LayDanhSachLop()
        {
            return DB.LOPs.ToList();
        }

        public ISingleResult<usp_SelectLopResult> LayDanhSachLop(int _Malop)
        {
            return DB.usp_SelectLop(_Malop);
        }

        public ISingleResult<usp_SelectHocSinhTheoMALOPResult> LayDanhSachHocSinhTheoMaLop(int _Malop)
        {
            return DB.usp_SelectHocSinhTheoMALOP(_Malop);
        }

        public ISingleResult<usp_SelectHocSinhChuaPhanLopResult> LayDanhSachHocSinhChuaPhanLop(string _Namhoc)
        {
            return DB.usp_SelectHocSinhChuaPhanLop(_Namhoc);
        }

        public ISingleResult<usp_SelectLopsByMAKHOI_NAMHOCResult> LayDanhSachLopTheoKhoiMaNam(String _Makhoi, String _NamHoc)
        {
            return DB.usp_SelectLopsByMAKHOI_NAMHOC(_Makhoi, _NamHoc);
        }

        public ISingleResult<usp_SelectLopByNamHocResult> LayDanhSachLopNamHoc(String _NamHoc)
        {
            return DB.usp_SelectLopByNamHoc(_NamHoc);
        }

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

        public List<Lop_BUS> TinhSiSoLop()
        {
            int _countSiSo = 0;
            foreach (XEPLOP xl in _XLBUS.LayTatCa())
            {
                foreach (LOP lop in LayDanhSachLop())
                {
                    foreach (HOSOHOCSINH hs in _HSBUS.LayTatCaHocSinh())
                    {
                        if (hs.MAHOCSINH == xl.MAHOCSINH && xl.MALOP == lop.MALOP)
                        {
                            _countSiSo++;
                        }
                    }
                    Lop_BUS _newlop = new Lop_BUS(lop.TENLOP, _countSiSo);
                    _ListLop.Add(_newlop);
                    _countSiSo = 0;
                }
            }

            return _ListLop;
        }

        public void Update(int _MaLop,String _TenLop,String _NamHoc,String _MaKhoi)
        {
            DB.usp_UpdateLop(_MaLop, _MaKhoi, _TenLop, _NamHoc, 0);
        }
        public void Insert(int _MaLop,String _TenLop,String _NamHoc,String _MaKhoi)
        {
            DB.usp_InsertLop(_MaLop, _MaKhoi, _TenLop, _NamHoc, 0);
        }
        public void Delete(int _MaLop)
        {
            DB.usp_DeleteLop(_MaLop);
        }
    }
}
