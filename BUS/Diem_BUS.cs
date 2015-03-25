using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{

    public class Diem_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        MonHoc_BUS _MHBUS = new MonHoc_BUS();
        DanhSachLop_BUS _LopBUS = new DanhSachLop_BUS();

        List<double> _ListDiem15 = new List<double>();
        List<double> _ListDiem1Tiet = new List<double>();
        List<double> _ListDiemHocKy = new List<double>();
        List<double> _ListDiemTBMon = new List<double>();
        List<int> _ListHeSo = new List<int>();

        public double LayDiemTrungBinhTheoTungMon(int _MaHS, String _NamHoc, int _MaHocKy, String _MaMon)
        {
            try
            {
                return (double)DB.usp_SelectBangdiem(_MaHS, _MaHocKy, _MaMon, _NamHoc).First().DIEMTRUNGBINH;
            }
            catch
            {
                return -1;
            }
        }

        public void LayHeSo()
        {
            foreach (LOAIDIEM heso in DB.LOAIDIEMs.ToList())
            {
                _ListHeSo.Add(heso.HESO);
            }

        }

        public double TinhDiemTrungBinhHocKy(int _MaHS, String _NamHoc, int _MaHocKy)
        {
            double sum = 0;
            int TongMon = 0;
            List<MONHOC> ListMH = _MHBUS.LayDanhSachMonHoc();
            foreach (MONHOC mh in ListMH)
            {
                try
                {
                    if (DB.usp_SelectBangdiem(_MaHS, _MaHocKy, mh.MAMONHOC, _NamHoc).First().DIEMTRUNGBINH != null)
                    {
                        TongMon++;
                        sum += (double)DB.usp_SelectBangdiem(_MaHS, _MaHocKy, mh.MAMONHOC, _NamHoc).First().DIEMTRUNGBINH;
                    }
                }
                catch { }
            }
            if (TongMon > 0)
                return Math.Round(sum / TongMon, 1);
            else
                return -1;
        }

        public List<DanhSachHS_BUS> LayBangDiemHocSinhTheoNamHoc(string _MaKhoi, string _NamHoc)
        {
            List<DanhSachHS_BUS> temp = new List<DanhSachHS_BUS>();
            double TongHK1;
            double TongHK2;
            int TongMonHk1;
            int TongMonHk2;
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBUS.LayDanhSachLopTheoKhoiMaNam(_MaKhoi, _NamHoc))
            {
                foreach (usp_SelectHocSinhTheoMALOPResult HSLop in _LopBUS.LayDanhSachHocSinhTheoMaLop(lop.MALOP))
                {
                    TongHK1 = 0;
                    TongHK2 = 0;
                    TongMonHk1 = 0;
                    TongMonHk2 = 0;
                    foreach (usp_SelectBangdiemNamHocByMaHocSinhResult BangDiem in DB.usp_SelectBangdiemNamHocByMaHocSinh(HSLop.MAHOCSINH, _NamHoc))
                    {
                        if (BangDiem.MAHOCKY == 1)
                        {
                            if (BangDiem.DIEMTRUNGBINH.HasValue)
                            {
                                TongHK1 += (double)BangDiem.DIEMTRUNGBINH;
                                TongMonHk1++;
                            }
                        }
                        else
                        {
                            if (BangDiem.DIEMTRUNGBINH.HasValue)
                            {
                                TongHK2 += (double)BangDiem.DIEMTRUNGBINH;
                                TongMonHk2++;
                            }
                        }
                    }
                    temp.Add(new DanhSachHS_BUS(HSLop.HOTEN, lop.TENLOP, Math.Round((TongHK1 / TongMonHk1), 1), Math.Round((TongHK2 / TongMonHk2), 1)));
                }
            }
            return temp;
        }

        public BangDiem_BUS LayBangDiem(int _MaHS, String _NamHoc, int _MaHocKy, String _MaMon)
        {
            double? _Diem15, _Diem1Tiet, _DiemHK;
            usp_SelectBangdiemResult _BangDiem;
            try
            {
                _BangDiem = DB.usp_SelectBangdiem(_MaHS, _MaHocKy, _MaMon, _NamHoc).First();
                string _TenHocSinh = DB.usp_SelectHosohocsinh(_MaHS).First().HOTEN;
                if (_BangDiem.MADIEM15 != null)
                    _Diem15 = DB.usp_SelectDiem(_BangDiem.MADIEM15).First().GIATRI;
                else
                    _Diem15 = null;

                if (_BangDiem.MADIEM1T != null)
                    _Diem1Tiet = DB.usp_SelectDiem(_BangDiem.MADIEM1T).First().GIATRI;
                else
                    _Diem1Tiet = null;

                if (_BangDiem.MADIEMHK != null)
                    _DiemHK = DB.usp_SelectDiem(_BangDiem.MADIEMHK).First().GIATRI;
                else
                    _DiemHK = null;
                return new BangDiem_BUS(_TenHocSinh, _MaHS, _BangDiem.MADIEM15, _Diem15, _BangDiem.MADIEM1T, _Diem1Tiet, _BangDiem.MADIEMHK, _DiemHK, _BangDiem.DIEMTRUNGBINH);
            }
            catch
            {
                DB.usp_InsertBangdiemNull(_MaHS, _MaMon, _MaHocKy, _NamHoc);
                _BangDiem = DB.usp_SelectBangdiem(_MaHS, _MaHocKy, _MaMon, _NamHoc).First();
                string _TenHocSinh = DB.usp_SelectHosohocsinh(_MaHS).First().HOTEN;
                if (_BangDiem.MADIEM15 != null)
                    _Diem15 = DB.usp_SelectDiem(_BangDiem.MADIEM15).First().GIATRI;
                else
                    _Diem15 = null;

                if (_BangDiem.MADIEM1T != null)
                    _Diem1Tiet = DB.usp_SelectDiem(_BangDiem.MADIEM1T).First().GIATRI;
                else
                    _Diem1Tiet = null;

                if (_BangDiem.MADIEMHK != null)
                    _DiemHK = DB.usp_SelectDiem(_BangDiem.MADIEMHK).First().GIATRI;
                else
                    _DiemHK = null;
                return new BangDiem_BUS(_TenHocSinh, _MaHS, _BangDiem.MADIEM15, _Diem15, _BangDiem.MADIEM1T, _Diem1Tiet, _BangDiem.MADIEMHK, _DiemHK, _BangDiem.DIEMTRUNGBINH);
            }
        }

        int LayMaDiemCuoi()
        {
            return (int)DB.usp_SelectLastMaDiem().First().MADIEM;
        }

        public void UpdateDiem(BangDiem_BUS _BangDiem, String _NamHoc, int _MaHocKy, String _MaMon)
        {
            int? _MaDiem15 = _BangDiem._MaDiem15;
            int? _MaDiem1T = _BangDiem._MaDiem1T;
            int? _MaDiemHK = _BangDiem._MaDiemHK;
            if (_BangDiem._MaDiem15 != null)
            {
                DB.usp_UpdateDiem(_BangDiem._MaDiem15, "D15", _BangDiem._Diem15);
            }
            else
            {
                if (_BangDiem._Diem15 != null)
                {
                    _MaDiem15 = LayMaDiemCuoi() + 1;
                    DB.usp_InsertDiem(_MaDiem15, "D15", _BangDiem._Diem15);
                }
            }

            if (_BangDiem._MaDiem1T != null)
            {
                DB.usp_UpdateDiem(_BangDiem._MaDiem1T, "D1T", _BangDiem._Diem1Tiet);
            }
            else
            {
                if (_BangDiem._Diem1Tiet != null)
                {
                    _MaDiem1T = LayMaDiemCuoi() + 1;
                    DB.usp_InsertDiem(_MaDiem1T, "D1T", _BangDiem._Diem1Tiet);
                }
            }

            if (_BangDiem._MaDiemHK != null)
            {
                DB.usp_UpdateDiem(_BangDiem._MaDiemHK, "DHK", _BangDiem._DiemHK);
            }
            else
            {
                if (_BangDiem._DiemHK != null)
                {
                    _MaDiemHK = LayMaDiemCuoi() + 1;
                    DB.usp_InsertDiem(_MaDiemHK, "DHK", _BangDiem._DiemHK);
                }
            }
            DB.usp_UpdateBangdiem(_BangDiem._MaHocSinh, _MaMon, _MaHocKy, _NamHoc, _MaDiem15, _MaDiem1T, _MaDiemHK);
        }
    }
}
