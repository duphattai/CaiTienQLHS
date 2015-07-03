using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DataAccessObject.DAO;
using System.Data.Linq;
namespace frMain
{
    public partial class frPhanCongGiangDay : DevExpress.XtraEditors.XtraForm
    {
        private MonHoc_BUS _monHocBus = new MonHoc_BUS();// truy xuất dữ liệu từ databse
        private GiaoVien_BUS _giaoVienBus = new GiaoVien_BUS();// truy xuất dữ liệu từ databse
        private GiangDay_BUS _giangDayBus = new GiangDay_BUS();// truy xuất dữ liệu từ databse
        private DanhSachLop_BUS _danhSachLopBus = new DanhSachLop_BUS();
        private NamHoc_BUS _namHocBus = new NamHoc_BUS();

        private List<MONHOC> _listMonHoc = new List<MONHOC>(); // chứa danh sách môn học lấy từ CSDL
        private List<GIAOVIEN> _listGiaoVien = new List<GIAOVIEN>(); // chứa danh sách giáo viên lấy từ CSDL
       
        private List<LOP> _listDanhSachLopChuaPhanCong = new List<LOP>(); // danh sách lớp để hiển thị dữ liệu lên datagridview
        private List<LOP> _listDanhSachLopPhanCong = new List<LOP>();// danh sách lớp để hiển thị dữ liệu lên datagridview
        public frPhanCongGiangDay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện: xảy ra khi người dùng click vào ô trên dataGridViewDanhSachGiaoVien
        /// </summary>
        private void dataGridViewDanhSachGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // nếu dòng dược click nằm trên header
            if(e.RowIndex <0)
                return;

            _listDanhSachLopChuaPhanCong.Clear();
            _listDanhSachLopPhanCong.Clear();

            // lấy danh sách lớp chưa phân công
            string maMonHoc = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["MaMonHoc"].Value.ToString();
            List<usp_SelectMonhocResult> monHoc = _monHocBus.LayMonHocTheoMaMonHoc(maMonHoc).ToList();
    
            List<usp_SelectDanhSachLopNotInGiangDayResult> danhSachLopChuaPhanCong = _danhSachLopBus.LayDanhSachLopGiangVienChuaPhanCong(maMonHoc, comboBoxNamHoc.SelectedItem.ToString()).ToList();

            foreach (usp_SelectDanhSachLopNotInGiangDayResult temp in danhSachLopChuaPhanCong)
            {
                LOP lop = new LOP();
                lop.MALOP = temp.MALOP;
                lop.MAKHOI = temp.MAKHOI;
                lop.NAMHOC = temp.NAMHOC;
                lop.TENLOP = temp.TENLOP;

                if (monHoc.ElementAt(0).SOTIETKHOI10 == 0 && lop.MAKHOI.Equals("K10")) continue;
                if (monHoc.ElementAt(0).SOTIETKHOI11 == 0 && lop.MAKHOI.Equals("K11")) continue;
                if (monHoc.ElementAt(0).SOTIETKHOI12 == 0 && lop.MAKHOI.Equals("K12")) continue;
                    
                _listDanhSachLopChuaPhanCong.Add(lop); // đối tượng chứa danh sách lớp
            }

            // lấy danh sách lớp đạ được phân công theo mã giáo viên, năm học
            string maGiaoVien = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["MaGiaoVien"].Value.ToString();
            List<usp_SelectGiangDayResult> danhSachLopPhanCong = _giangDayBus.LayGiangDayTheoMaGiaoVien(maGiaoVien, comboBoxNamHoc.SelectedItem.ToString()).ToList();
            foreach(usp_SelectGiangDayResult temp in danhSachLopPhanCong)
            {
                LOP lop = new LOP();
                lop.MALOP = temp.MaLop;
                lop.MAKHOI = temp.MAKHOI;
                lop.NAMHOC = temp.NAMHOC;
                lop.TENLOP = temp.TENLOP;

                _listDanhSachLopPhanCong.Add(lop);    // đối tượng chứa danh sách lớp       
            }

            hienThiDanhLopChuaPhanCongTrenGridView(); // hiển thị dữ liệu lên datagridview
            hienThiDanhLopPhanCongTrenGridView(); // hiển thị dữ liệu lên datagridview
        }

        /// <summary>
        /// Sự kiện: khi form được show lên
        /// lấy danh sách giáo viên, danh sách môn học, danh sách năm học từ database
        /// </summary>
        private void frPhanCongGiangDay_Load(object sender, EventArgs e)
        {
            try
            {
                _listGiaoVien = _giaoVienBus.LayTatCaDanhSachGiaoVien();
                _listMonHoc = _monHocBus.LayDanhSachMonHoc();

                foreach (NAMHOC namHoc in _namHocBus.LayNamHoc())
                {
                    comboBoxNamHoc.Items.Add(namHoc.NAMHOC1);
                }
                comboBoxNamHoc.SelectedIndex = 0;
                hienThiDanhSachGiaoVienTrenGridView();// hiển thị danh sách giao viên lên datagridview
            }catch(Exception ex)
            { }
        }

        /// <summary>
        /// Hiển thị danh sách giáo viên lên dataGridViewDanhSachGiaoVien
        /// </summary>
        private void hienThiDanhSachGiaoVienTrenGridView()
        {
            dataGridViewDanhSachGiaoVien.RowCount = _listGiaoVien.Count;
            for (int i = 0; i < _listGiaoVien.Count; i++) // duyệt từng giáo viên thiết lập dữ liệu tương ứng với từng cột
            {
                // thiết lập dữ liệu cho cột trên dòng
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["HoTen"].Value = _listGiaoVien[i].HoTen;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["MaGiaoVien"].Value = _listGiaoVien[i].MaGiaoVien;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["NgaySinh"].Value = _listGiaoVien[i].NgaySinh;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["DiaChi"].Value = _listGiaoVien[i].DiaChi;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["GioiTinh"].Value = _listGiaoVien[i].GioiTinh;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["Email"].Value = _listGiaoVien[i].Email;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["MaMonHoc"].Value = _listGiaoVien[i].MaMonHoc;
                for (int j = 0; j < _listMonHoc.Count; j++)
                {
                    if (_listMonHoc[j].MAMONHOC.Equals(_listGiaoVien[i].MaMonHoc))
                    {
                        dataGridViewDanhSachGiaoVien.Rows[i].Cells["DayMon"].Value = _listMonHoc[j].TENMONHOC;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Hiển thị danh sách giáo viên lên dataGridViewDanhSachLopChuaPhanCong
        /// </summary>
        private void hienThiDanhLopChuaPhanCongTrenGridView()
        {
            dataGridViewDanhSachLopChuaPhanCong.Rows.Clear();
            dataGridViewDanhSachLopChuaPhanCong.RowCount = _listDanhSachLopChuaPhanCong.Count;

            for(int i = 0; i < _listDanhSachLopChuaPhanCong.Count;  i++)
            {
                dataGridViewDanhSachLopChuaPhanCong.Rows[i].Cells["MaLop1"].Value = _listDanhSachLopChuaPhanCong[i].MALOP;
                dataGridViewDanhSachLopChuaPhanCong.Rows[i].Cells["TenLop1"].Value = _listDanhSachLopChuaPhanCong[i].TENLOP;
            }
        }

        /// <summary>
        /// Hiển thị danh sách giáo viên lên dataGridViewDanhSachLopPhanCong
        /// </summary>
        private void hienThiDanhLopPhanCongTrenGridView()
        {
            dataGridViewDanhSachLopPhanCong.Rows.Clear();
            dataGridViewDanhSachLopPhanCong.RowCount = _listDanhSachLopPhanCong.Count;

            for (int i = 0; i < _listDanhSachLopPhanCong.Count; i++)
            {
                dataGridViewDanhSachLopPhanCong.Rows[i].Cells["MaLop2"].Value = _listDanhSachLopPhanCong[i].MALOP;
                dataGridViewDanhSachLopPhanCong.Rows[i].Cells["TenLop2"].Value = _listDanhSachLopPhanCong[i].TENLOP;
            }
        }

        /// <summary>
        /// Sự kiện: khi người dùng click button Thoát
        /// đóng form đang thao tác
        /// </summary>
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Sự kiện: khi người dùng click vào button Thêm
        /// Thêm lớp đã chọn vào giảng dạy
        /// </summary>
        private void buttonThem_Click(object sender, EventArgs e)
        {
            int rowSelectedDanhSachLop = -1;
            int rowSelectedGiaoVien = -1;

            if (dataGridViewDanhSachLopChuaPhanCong.CurrentCell != null) // kiểm tra còn dòng hiển thị dữ liệu (không phải header)
                rowSelectedDanhSachLop = dataGridViewDanhSachLopChuaPhanCong.CurrentCell.RowIndex;
            if (dataGridViewDanhSachGiaoVien.CurrentCell != null)// kiểm tra còn dòng hiển thị dữ liệu (không phải header)
                rowSelectedGiaoVien = dataGridViewDanhSachGiaoVien.CurrentCell.RowIndex;

            if( rowSelectedDanhSachLop >= 0 &&  rowSelectedGiaoVien >= 0)
            {
                try
                {
                    string maGiaoVien = dataGridViewDanhSachGiaoVien.Rows[rowSelectedGiaoVien].Cells["MaGiaoVien"].Value.ToString();
                    int maLop = Convert.ToInt32(dataGridViewDanhSachLopChuaPhanCong.Rows[rowSelectedDanhSachLop].Cells["MaLop1"].Value);

                    _giangDayBus.Them(maGiaoVien, maLop);

                    _listDanhSachLopPhanCong.Add(_listDanhSachLopChuaPhanCong[rowSelectedDanhSachLop]);
                    _listDanhSachLopChuaPhanCong.RemoveAt(rowSelectedDanhSachLop);

                    hienThiDanhLopChuaPhanCongTrenGridView();
                    hienThiDanhLopPhanCongTrenGridView();
                }catch(Exception ex)
                {
                    MessageBox.Show("Không thể têem vào!", "Thông báo");
                }
            }
        }


        /// <summary>
        /// Sự kiện: khi người dùng click vào button Xóa
        /// Xóa phân công giảng dạy theo mã giáo viên, mã lớp
        /// </summary>
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int rowSelectedGiaoVien = -1;
            int rowSelectedLopPhanCong = -1;

            if (dataGridViewDanhSachLopPhanCong.CurrentCell != null) // kiểm tra còn dòng hiển thị dữ liệu (không phải header)
                rowSelectedLopPhanCong = dataGridViewDanhSachLopPhanCong.CurrentCell.RowIndex;
            if (dataGridViewDanhSachGiaoVien.CurrentCell != null)// kiểm tra còn dòng hiển thị dữ liệu (không phải header)
                rowSelectedGiaoVien = dataGridViewDanhSachGiaoVien.CurrentCell.RowIndex;

            if (rowSelectedGiaoVien >= 0 && rowSelectedLopPhanCong >= 0)
            {
                try
                {
                    string maGiaoVien = dataGridViewDanhSachGiaoVien.Rows[rowSelectedGiaoVien].Cells["MaGiaoVien"].Value.ToString();
                    int maLop = Convert.ToInt32(dataGridViewDanhSachLopPhanCong.Rows[rowSelectedLopPhanCong].Cells["MaLop2"].Value);

                    _giangDayBus.Delete(maGiaoVien, maLop);

                    _listDanhSachLopChuaPhanCong.Add(_listDanhSachLopPhanCong[rowSelectedLopPhanCong]);
                    _listDanhSachLopPhanCong.RemoveAt(rowSelectedLopPhanCong);

                    hienThiDanhLopChuaPhanCongTrenGridView();
                    hienThiDanhLopPhanCongTrenGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm vào!", "Thong bao");
                }
            }
        }
    }
}