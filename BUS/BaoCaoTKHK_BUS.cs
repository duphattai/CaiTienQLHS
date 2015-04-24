using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = ConnectToDatabase.Properties.Settings;
using DataAccessObject.DAO;

namespace BUS
{
    public class BaoCaoTKHK_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        HoSoHocSinh_BUS _HSBUS = new HoSoHocSinh_BUS();
        XepLop_BUS _XLBUS = new XepLop_BUS();
        DanhSachLop_BUS _DSLOPBUS = new DanhSachLop_BUS();
        Diem_BUS _DiemBUS = new Diem_BUS();
        QuiDinh_BUS _ThamSoBUS = new QuiDinh_BUS();

        int DiemDat = 0;

        List<ThongTinLop> _ListLop = new List<ThongTinLop>();
        List<BaoCaoTKHK> _ListBaoCaoTKHK = new List<BaoCaoTKHK>();

        public List<BaoCaoTKHK> LayDuLieu(int _MaHocKy, String _NamHoc)
        {
            DiemDat = _ThamSoBUS.LayDiemDatMon();
            try
            {
                int _countSoLuongDat = 0;

                _ListBaoCaoTKHK.Clear();
                foreach (usp_SelectLopByNamHocResult lop in _DSLOPBUS.LayDanhSachLopNamHoc(_NamHoc))
                {
                  
                    foreach(usp_SelectHocSinhTheoMALOPResult hs in _HSBUS.TruyVanHocSinhTheoMaLop(lop.MALOP))
                    {
                        double diem = _DiemBUS.TinhDiemTrungBinhHocKy(hs.MAHOCSINH, _NamHoc, _MaHocKy);
                        if (diem > DiemDat) _countSoLuongDat++;
                    }
                    if (lop.SISO > 0)
                    {
                        BaoCaoTKHK _newBaocao = new BaoCaoTKHK(lop.TENLOP, lop.SISO, _countSoLuongDat, 100 * (double)Math.Round(((double)_countSoLuongDat / lop.SISO), 2));
                        _ListBaoCaoTKHK.Add(_newBaocao);
                        _countSoLuongDat = 0;
                    }
                }
            }
            catch { }
            return _ListBaoCaoTKHK;

        }

    }
}
