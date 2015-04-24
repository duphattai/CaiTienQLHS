using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
   public class BaoCaoMonHoc_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        HoSoHocSinh_BUS _HSBUS = new HoSoHocSinh_BUS();
        XepLop_BUS _XLBUS = new XepLop_BUS();
        DanhSachLop_BUS _DSLOPBUS = new DanhSachLop_BUS();
        Diem_BUS _DiemBUS = new Diem_BUS();
        QuiDinh_BUS _ThamSoBUS = new QuiDinh_BUS();

        List<ThongTinLop> _ListLop = new List<ThongTinLop>();
        

        public List<BaoCaoMonHoc> LayDuLieu(String _MaMon,int _MaHocKy,String _NamHoc)
        {
            List<BaoCaoMonHoc> _ListBaoCaoMon = new List<BaoCaoMonHoc>();
            int DiemDat = _ThamSoBUS.LayDiemDatMon();
            try
            {
                int _countSoLuongDat = 0;
                _ListBaoCaoMon.Clear();
                foreach (usp_SelectLopByNamHocResult lop in _DSLOPBUS.LayDanhSachLopNamHoc(_NamHoc))
                {
                    foreach (usp_SelectHocSinhTheoMALOPResult hs in _HSBUS.TruyVanHocSinhTheoMaLop(lop.MALOP))
                    {
                        double diem = _DiemBUS.LayDiemTrungBinhTheoTungMon(hs.MAHOCSINH, _NamHoc, _MaHocKy, _MaMon);
                        if (diem > DiemDat)
                            _countSoLuongDat++;
                    }
                    if (lop.SISO > 0)
                    {
                        BaoCaoMonHoc _newBaocao = new BaoCaoMonHoc(lop.TENLOP, lop.SISO, _countSoLuongDat, 100 * (double)Math.Round(((double)_countSoLuongDat / lop.SISO), 2));
                        _ListBaoCaoMon.Add(_newBaocao);
                        _countSoLuongDat = 0;
                    }
                }
            }
            catch { }
            return _ListBaoCaoMon;
          
        }

    }
}
