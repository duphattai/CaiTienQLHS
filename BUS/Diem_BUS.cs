using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    /// <summary>
    /// Lớp trung gian, quản lý việc truy xuất đến table DIEM (database) từ ứng dụng
    /// </summary>
    public class Diem_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        MonHoc_BUS _MHBUS = new MonHoc_BUS(); // đối tượng truy xuất dữ liệu table MONHOC
        DanhSachLop_BUS _LopBUS = new DanhSachLop_BUS(); // truy xuất dữ liệu table DANHSACHLOP

        List<double> _ListDiem15 = new List<double>(); // danh sách điểm 15'
        List<double> _ListDiem1Tiet = new List<double>(); // danh sách điểm 1 tiết
        List<double> _ListDiemHocKy = new List<double>(); // danh sách điểm học kỳ
        List<double> _ListDiemTBMon = new List<double>(); // danh sách điểm trung bình môn
        List<int> _ListHeSo = new List<int>(); // hệ số của từng loại điểm

        /// <summary>
        /// Lấy điểm trung bình của một môn cụ thể trong một học kỳ năm học của 1 học sinh
        /// </summary>
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

        /// <summary>
        /// cập nhật hệ số điểm(từ database) vào thuộc tính danh sách hệ số
        /// </summary>
        public void LayHeSo()
        {
            foreach (LOAIDIEM heso in DB.LOAIDIEMs.ToList())
            {
                _ListHeSo.Add(heso.HESO);
            }
        }

        /// <summary>
        /// Tính điểm trung bình học kỳ của một học sinh, trả về số điểm tinh được hoặc không tính được (-1)
        /// </summary>
        public double TinhDiemTrungBinhHocKy(int _MaHS, String _NamHoc, int _MaHocKy)
        {
            double sum = 0; // tổng số điểm tương ứng với hệ số
            int TongMon = 0; // số môn học của HS 
            List<MONHOC> ListMH = _MHBUS.LayDanhSachMonHoc(); // chứa danh sách môn học
            foreach (MONHOC mh in ListMH) // duyệt từng môn học
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

        /// <summary>
        /// trả về danh sách điểm của tất cả học sinh trong một khối trong một năm học
        /// </summary>
        public List<ThongTinHocSinh> LayBangDiemHocSinhTheoNamHoc(string _MaKhoi, string _NamHoc)
        {
            List<ThongTinHocSinh> temp = new List<ThongTinHocSinh>(); // chứa danh sách bảng điểm học sinh theo khối
            double TongHK1; // tổng điểm của tất cả các môn học kỳ 1
            double TongHK2; // tổng điểm của tất cả các môn học kỳ 2
            int TongMonHk1; // số môn học kỳ 1
            int TongMonHk2; // số môn học kỳ 2


            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBUS.LayDanhSachLopTheoKhoiMaNam(_MaKhoi, _NamHoc)) // duyệt các lớp trong một khối
            {
                foreach (usp_SelectHocSinhTheoMALOPResult HSLop in _LopBUS.LayDanhSachHocSinhTheoMaLop(lop.MALOP)) // duyệt HS trong một lớp
                {
                    TongHK1 = 0;
                    TongHK2 = 0;
                    TongMonHk1 = 0;
                    TongMonHk2 = 0;
                    foreach (usp_SelectBangdiemNamHocByMaHocSinhResult BangDiem in DB.usp_SelectBangdiemNamHocByMaHocSinh(HSLop.MAHOCSINH, _NamHoc)) // duyệt bảng điểm của HS, tính tổng số điểm của tất cả môn và số môn học trong 2 học kỳ
                    {
                        if (BangDiem.MAHOCKY == 1) // điểm học kỳ 1
                        {
                            if (BangDiem.DIEMTRUNGBINH.HasValue)
                            {
                                TongHK1 += (double)BangDiem.DIEMTRUNGBINH;
                                TongMonHk1++;
                            }
                        }
                        else // điểm học kỳ 2
                        {
                            if (BangDiem.DIEMTRUNGBINH.HasValue)
                            {
                                TongHK2 += (double)BangDiem.DIEMTRUNGBINH;
                                TongMonHk2++;
                            }
                        }
                    }

                    // thêm học sinh với điểm hk1 và hk2 vào danh sách
                    temp.Add(new ThongTinHocSinh(HSLop.HOTEN, lop.TENLOP, Math.Round((TongHK1 / TongMonHk1), 1), Math.Round((TongHK2 / TongMonHk2), 1)));
                }
            }


            return temp;
        }

        /// <summary>
        /// Trả về bảng điểm của một học sinh theo một môn trong một học kỳ năm học
        /// </summary>
        public BangDiemHocSinh LayBangDiem(int _MaHS, String _NamHoc, int _MaHocKy, String _MaMon)
        {
            double? _Diem15, _Diem1Tiet, _DiemHK; // lưu điểm của một HS
            usp_SelectBangdiemResult _BangDiem; // truy xuất bảng điểm từ database 


            try
            {
                _BangDiem = DB.usp_SelectBangdiem(_MaHS, _MaHocKy, _MaMon, _NamHoc).First(); // truy xuất bảng điểm một HS cụ thể theo một môn
                string _TenHocSinh = DB.usp_SelectHosohocsinh(_MaHS).First().HOTEN; // lấy tên học sinh theo mã học sinh

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


                return new BangDiemHocSinh(_TenHocSinh, _MaHS, _BangDiem.MADIEM15, _Diem15, _BangDiem.MADIEM1T, _Diem1Tiet, _BangDiem.MADIEMHK, _DiemHK, _BangDiem.DIEMTRUNGBINH);
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
                return new BangDiemHocSinh(_TenHocSinh, _MaHS, _BangDiem.MADIEM15, _Diem15, _BangDiem.MADIEM1T, _Diem1Tiet, _BangDiem.MADIEMHK, _DiemHK, _BangDiem.DIEMTRUNGBINH);
            }
        }

        /// <summary>
        /// trả về mã điểm cuối trong table DIEM
        /// </summary>
        int LayMaDiemCuoi()
        {
            try
            {
                return (int)DB.usp_SelectLastMaDiem().First().MADIEM;
            }
            catch // bắt ngoại lệ khi thực thi câu lệnh select trong store procedure trả về NULL
            {
                return 0;
            }  
        }

        /// <summary>
        /// Cập nhật lại table DIEM và BANGDIEM trong database
        /// </summary>
        public void UpdateDiem(BangDiemHocSinh _BangDiem, String _NamHoc, int _MaHocKy, String _MaMon)
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
