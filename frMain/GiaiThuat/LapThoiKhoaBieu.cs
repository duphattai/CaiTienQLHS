using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessObject.DAO;

namespace frMain.GiaiThuat
{
    enum KHOI
    {
        KHOI_10 = 0,
        KHOI_11,
        KHOI_12
    }

    /// <summary>
    /// chương trình học từng khối
    /// </summary>
    class ChuongTrinhHoc
    {
        public String maKhoi; // khối học
        public List<MONHOC> chuongTrinhHoc; // danh sách môn học

        public ChuongTrinhHoc(List<MONHOC> ListTietGiangDay, String Khoi)
        {
            chuongTrinhHoc = ListTietGiangDay;
            maKhoi = Khoi;
        }
    }


    /// <summary>
    /// phân công giảng dạy cho từng giáo viên
    /// </summary>
    class GiangDay
    {
        public GIANGDAY giangDay;
        public GIAOVIEN giaoVien;
        public String maKhoi;
        public GiangDay(GiangDay temp)
        {
            giaoVien = temp.giaoVien;
            this.giangDay = temp.giangDay;
            maKhoi = temp.maKhoi;
        }

        public GiangDay(GIANGDAY giangDay, GIAOVIEN giaovien, String maKhoi)
        {
            this.giangDay = giangDay;
            this.giaoVien = giaovien;
            this.maKhoi = maKhoi;
        }
    }


    /// <summary>
    /// ý tưởng: 
    /// + tạo thời khóa biểu cho từng lớp ứng với từng chương trình học cụ thể -> TKB toàn trường
    /// ứng với các dòng tại từng cột kiểm tra xem giáo viên có bị trùng giờ dạy môn:
    ///     - nếu trùng giờ: 
    ///         . tìm trong khối của lớp đang xét các môn học không bị trùng tại thời điểm đó
    ///         . sau đó duyệt các môn học tại lớp đang xét rồi thay thế môn học bị trùng bằng môn học khác 
    /// </summary>
    class GiaiThuatLapThoiKhoaBieu
    {
        private const String KHOI10 = "K10";
        private const String KHOI11 = "K11";
        private const String KHOI12 = "K12";
        private const int _SOTIETHOCTRONGTUAN = 60;


        private List<GIAOVIEN> _ListGiaoVien; // danh sách giáo viên của trường
        private List<GiangDay> _listPhanCongGiangDay; // danh sách phân công giáo viên
        private List<MONHOC> _ListMonHoc; // danh sách môn học
        
        
        private List<LOP> _ListLop; // danh sách lớp lập lịch
        private List<ChuongTrinhHoc> _ListChuongTrinhHoc; // danh sách các tiết học từng khối trong 1 tuần

        private GiangDay[][] _QuanTheBanDau; // thời khóa biểu

        public GiaiThuatLapThoiKhoaBieu(List<GIAOVIEN> ListGiaoVien, List<MONHOC> ListMonHoc, List<LOP> ListLop, List<GIANGDAY> ListGiangDay)
        {
            this._ListGiaoVien = ListGiaoVien;
            this._ListLop = ListLop;
            this._ListMonHoc = ListMonHoc;

            _listPhanCongGiangDay = new List<GiangDay>();
            for (int i = 0; i < ListGiangDay.Count; i++)
            {
                for(int j = 0; j < ListGiaoVien.Count; j++)
                {
                    if(ListGiaoVien[j].MaGiaoVien.Equals(ListGiangDay[i].MaGiaoVien))
                    {
                        GiangDay temp = new GiangDay(ListGiangDay[i], ListGiaoVien[j], "");
                        _listPhanCongGiangDay.Add(temp);
                        break;
                    }
                }
            }

            // khoi tao ctr hoc cho khoi
            _ListChuongTrinhHoc = new List<ChuongTrinhHoc>();
            _ListChuongTrinhHoc.Add(TinhSoTietHocTrongTuan(KHOI.KHOI_10, _ListMonHoc));
            _ListChuongTrinhHoc.Add(TinhSoTietHocTrongTuan(KHOI.KHOI_11, _ListMonHoc));
            _ListChuongTrinhHoc.Add(TinhSoTietHocTrongTuan(KHOI.KHOI_12, _ListMonHoc));
        }

        /// <summary>
        /// tính số tiết học trong tuần của mỗi khối
        /// </summary>
        private ChuongTrinhHoc TinhSoTietHocTrongTuan(KHOI Khoi, List<MONHOC> ListGiangDay)
        {
            List<MONHOC> SoTietHocTrongTuan = new List<MONHOC>();
            for (int i = 0; i < _ListMonHoc.Count; i++) // duyệt danh sach môn học
            {
                // tạo các tiết học theo từng khối cụ thể
                if (Khoi == KHOI.KHOI_10)
                {
                    for (int k = 0; k < _ListMonHoc[i].SOTIETKHOI10; k++)
                    {
                        SoTietHocTrongTuan.Add(_ListMonHoc[i]);
                    }
                }
                else if (Khoi == KHOI.KHOI_11)
                {
                    for (int k = 0; k < _ListMonHoc[i].SOTIETKHOI11; k++)
                    {
                        SoTietHocTrongTuan.Add(_ListMonHoc[i]);
                    }
                }
                else if (Khoi == KHOI.KHOI_12)
                {
                    for (int k = 0; k < _ListMonHoc[i].SOTIETKHOI12; k++)
                    {
                        SoTietHocTrongTuan.Add(_ListMonHoc[i]);
                    }
                }
            }

            ChuongTrinhHoc CtrHoc = null;

            if(Khoi == KHOI.KHOI_10)
                CtrHoc = new ChuongTrinhHoc(SoTietHocTrongTuan, KHOI10);
            else if(Khoi == KHOI.KHOI_11)
                CtrHoc = new ChuongTrinhHoc(SoTietHocTrongTuan, KHOI11);
             else if(Khoi == KHOI.KHOI_12)
                CtrHoc = new ChuongTrinhHoc(SoTietHocTrongTuan, KHOI12);
            
            return CtrHoc;
        }

        public void CreateQuanTheBanDau()
        {
            _QuanTheBanDau = CreateTKB_ToanTruong();
        }


        /// <summary>
        /// Lập thời khóa biểu cho toàn trường
        /// </summary>
        /// <returns></returns>
        private GiangDay[][] CreateTKB_ToanTruong()
        {
            // Cấp phát vùng nhớ
            GiangDay[][] TKB_ToanTruong = new GiangDay[_ListLop.Count][];

            for (int i = 0; i < TKB_ToanTruong.Count(); i++)
            {
                TKB_ToanTruong[i] = CreateTKB_Lop(_ListLop[i]);
                Thread.Sleep(1000);
            }

            return TKB_ToanTruong;
        }


        /// <summary>
        /// lấy danh sách giáo viên dạy một lớp và cập nhất khối đang dạy cho giáo viên
        /// </summary>
        private List<GiangDay> layDanhSachGiaoVienDayLop(ChuongTrinhHoc chuongTrinhHocLop, LOP lop)
        {
            List<GiangDay> listDanhSachGiaoVien = new List<GiangDay>();

            for (int i = 0; i < chuongTrinhHocLop.chuongTrinhHoc.Count; i++)
            {
                for(int j = 0; j < _listPhanCongGiangDay.Count; j++)
                {
                    // tìm giáo viên được phân công dạy một môn tại một lớp
                    if(_listPhanCongGiangDay[j].giaoVien.MaMonHoc.Equals(chuongTrinhHocLop.chuongTrinhHoc[i].MAMONHOC) && _listPhanCongGiangDay[j].giangDay.MaLop.Equals(lop.MALOP))
                    {
                        GiangDay temp = new GiangDay(_listPhanCongGiangDay[j]);
                        temp.maKhoi = lop.MAKHOI;
                        listDanhSachGiaoVien.Add(temp);
                        break;
                    }
                }
            }

            return listDanhSachGiaoVien;
        }

        private GiangDay[] CreateTKB_Lop(LOP lop)
        {
            GiangDay[] TKB_Khoi = new GiangDay[_SOTIETHOCTRONGTUAN]; // khởi tạo số tiết tối đa trong tuần là 70 tiết
            List<int> SoTietHocTrongTuan = new List<int>();
            for (int i = 0; i < _SOTIETHOCTRONGTUAN; i++)
                SoTietHocTrongTuan.Add(i);

            Random rand = new Random();
            int index = 0;
            for (int i = 0; i < _ListChuongTrinhHoc.Count; i++)
            {
                if (_ListChuongTrinhHoc[i].maKhoi.Equals(lop.MAKHOI))// lấy chương trình học đúng với lớp 
                {
                    List<GiangDay> ListSoTietMonHocTrongTuan = layDanhSachGiaoVienDayLop(_ListChuongTrinhHoc[i], lop); // copy tạo list mới

                    for (int j = 0; j < ListSoTietMonHocTrongTuan.Count; j++)
                    {
                        if (SoTietHocTrongTuan.Count > 0)
                        {
                            index = rand.Next(0, SoTietHocTrongTuan.Count);
                            TKB_Khoi[SoTietHocTrongTuan[index]] = ListSoTietMonHocTrongTuan[j];
                            SoTietHocTrongTuan.RemoveAt(index);
                        }
                    }

                    break;
                }
            }

            return TKB_Khoi;
        }

        private Boolean KiemTraTietDayCoBiTrung(GiangDay[][] TKB_Truong, int column)
        {
            int tietTrung = 0;

            for (int row = 0; row < TKB_Truong.Count(); row++)
            {
                if (TKB_Truong[row][column] == null) continue;

                for (int j = 0; j < TKB_Truong.Count(); j++)
                {
                    if (row == j || TKB_Truong[j][column] == null) continue;

                    if (TKB_Truong[row][column].giaoVien.MaMonHoc.Equals(TKB_Truong[j][column].giaoVien.MaMonHoc) && TKB_Truong[row][column].giangDay.MaGiaoVien.Equals(TKB_Truong[j][column].giangDay.MaGiaoVien))
                    {
                        tietTrung++;
                    }
                }
            }

            if (tietTrung != 0) return true;

            return false;
        }

        private int KiemTraMonHocCoBiTrung(GiangDay MonHoc, GiangDay[][] TKB, int column)
        {
            int rows = TKB.Count();
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                if (TKB[i][column] != null && MonHoc.giangDay.MaGiaoVien == TKB[i][column].giangDay.MaGiaoVien)
                {
                    count++;
                }
            }

            return count;
        }

        private List<MONHOC> DanhSachMonHocKhongDayTaiThoiDiemHienTai(GiangDay[][] TKB, String maKhoi, int Column)
        {
            List<MONHOC> listMonHoc = new List<MONHOC>(_ListMonHoc);

            for (int row = 0; row < TKB.Count(); row++)
            {
                for (int i = 0; i < listMonHoc.Count; i++)
                {
                    if (TKB[row][Column] != null && TKB[row][Column].maKhoi == maKhoi && TKB[row][Column].giaoVien.MaMonHoc.Equals(listMonHoc[i].MAMONHOC))
                    {
                        listMonHoc.RemoveAt(i);
                        break;
                    }
                }
            }

            if (listMonHoc.Count == 0) return null;

            return listMonHoc;
        }

        public Boolean CapNhatMonHocBiTrungTKB()
        {
            int rows = _QuanTheBanDau.Count();
            int columns = _QuanTheBanDau[0].Count();

            for (int i = 0; i < columns; i++)
            {
                if (!KiemTraTietDayCoBiTrung(_QuanTheBanDau, i)) // khong bi trung tiet day
                    continue;

                for (int j = 0; j < rows; j++)
                {
                    if (_QuanTheBanDau[j][i] != null && KiemTraMonHocCoBiTrung(_QuanTheBanDau[j][i], _QuanTheBanDau, i) > 1)
                    {
                        List<MONHOC> list = null;

                        // lấy danh sách môn học không có dạy tại thời điểm đang xét, tại một khối đang xét
                        if (_ListLop[j].MAKHOI.IndexOf("K10") >= 0)
                        {
                            list = DanhSachMonHocKhongDayTaiThoiDiemHienTai(_QuanTheBanDau, _ListLop[j].MAKHOI, i);
                        }
                        else if (_ListLop[j].MAKHOI.IndexOf("K11") >= 0)
                        {
                            list = DanhSachMonHocKhongDayTaiThoiDiemHienTai(_QuanTheBanDau, _ListLop[j].MAKHOI, i);
                        }
                        else if (_ListLop[j].MAKHOI.IndexOf("K12") >= 0)
                        {
                            list = DanhSachMonHocKhongDayTaiThoiDiemHienTai(_QuanTheBanDau, _ListLop[j].MAKHOI, i);
                        }

                        if (list == null) return false;

                        CapNhatTKB(j, i, _QuanTheBanDau[j][i], list);
                    }
                }
            }

            return true;
        }

        private void CapNhatTKB(int row, int column, GiangDay monhoc, List<MONHOC> listMon)
        {
            for (int k = 0; k < listMon.Count; k++)
            {
                for (int i = 0; i < _QuanTheBanDau[row].Count(); i++)
                {
                    if (_QuanTheBanDau[row][i] != null && _QuanTheBanDau[row][i].giaoVien.MaMonHoc.Equals(listMon[k].MAMONHOC))
                    {
                        if (KiemTraMonHocCoBiTrung(monhoc, _QuanTheBanDau, i) == 0 && KiemTraMonHocCoBiTrung(_QuanTheBanDau[row][i], _QuanTheBanDau, column) == 0)
                        {
                            GiangDay temp = monhoc;
                            _QuanTheBanDau[row][column] = _QuanTheBanDau[row][i];
                            _QuanTheBanDau[row][i] = temp;
                            return;
                        }
                    }
                    else if (_QuanTheBanDau[row][i] == null && KiemTraMonHocCoBiTrung(monhoc, _QuanTheBanDau, i) == 0)
                    {
                        _QuanTheBanDau[row][i] = monhoc;
                        _QuanTheBanDau[row][column] = null;
                        return;
                    }
                }
            }
        }

        private String layTenMonHoc(String maMonHoc)
        {
            String tenMonHoc = "";
            for(int i = 0; i < _ListMonHoc.Count; i++)
            {
                if(_ListMonHoc[i].MAMONHOC.Equals(maMonHoc))
                {
                    tenMonHoc = _ListMonHoc[i].TENMONHOC;
                    break;
                }
            }

            return tenMonHoc;
        }

        public void ShowTKBToGridView(DataGridView GridView)
        {
            GridView.Rows.Clear();
            GridView.ColumnCount = _SOTIETHOCTRONGTUAN + 1;
            GridView.ColumnHeadersVisible = true;

            GridView.Columns[0].Name = "";
            for (int i = 1; i <= _SOTIETHOCTRONGTUAN; i++)
            {
                if(i % 10 == 1)
                {
                    switch(i / 10)
                    {
                        case 0:
                            GridView.Columns[i].Name = "Thứ hai";
                            break;
                        case 1:
                            GridView.Columns[i].Name = "Thứ ba";
                            break;
                        case 2:
                            GridView.Columns[i].Name = "Thứ tư";
                            break;
                        case 3:
                            GridView.Columns[i].Name = "Thứ năm";
                            break;
                        case 4:
                            GridView.Columns[i].Name = "Thứ sáu";
                            break;
                        case 5:
                            GridView.Columns[i].Name = "Thứ bảy";
                            break;
                    }
                }   
            }

            List<String> dataSource = new List<string>();
            dataSource.Add("Lớp '\' Tiết");
            for (int i = 1; i < GridView.ColumnCount; i++)
            {
                if(i % 10 == 0)
                    dataSource.Add(Convert.ToString(10));
                else
                    dataSource.Add(Convert.ToString(i % 10));
            }
            GridView.Rows.Add(dataSource.ToArray());

            for (int i = 0; i < _QuanTheBanDau.Count(); i++)
            {
                List<String> dataRow = new List<string>();
                dataRow.Add(_ListLop[i].TENLOP);
                for (int j = 0; j < _QuanTheBanDau[i].Count(); j++)
                {
                    if (_QuanTheBanDau[i][j] == null)
                        dataRow.Add("");
                    else
                        dataRow.Add(_QuanTheBanDau[i][j].giaoVien.HoTen + " - " + layTenMonHoc(_QuanTheBanDau[i][j].giaoVien.MaMonHoc));
                }
                GridView.Rows.Add(dataRow.ToArray());
            }
        }

        public List<int> TinhSoTietBiTrung()
        {
            List<int> count = new List<int>();

            for (int i = 0; i < _SOTIETHOCTRONGTUAN; i++)
            {
                if (KiemTraTietDayCoBiTrung(_QuanTheBanDau, i))
                {
                    count.Add(i + 1);
                }
            }

            return count;
        }

        public GiangDay[][] layThoiKhoaBieu()
        {
            return _QuanTheBanDau;
        }
    }
}
