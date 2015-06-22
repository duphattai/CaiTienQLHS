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
using Excel;
using System.IO;
namespace frMain
{
    public partial class frHoSoGiaoVien : DevExpress.XtraEditors.XtraForm
    {
        private const int START_POSITION_AT_ROW_READ_FROM_EXCEL = 2;

        private MonHoc_BUS _monHocBus = new MonHoc_BUS();// truy xuất dữ liệu từ databse
        private GiaoVien_BUS _giaoVienBus = new GiaoVien_BUS();// truy xuất dữ liệu từ databse
        private GiangDay_BUS _giangDayBus = new GiangDay_BUS();// truy xuất dữ liệu từ databse

        private List<MONHOC> _listMonHoc = new List<MONHOC>(); // chứa danh sách môn học lấy từ CSDL
        private List<GIAOVIEN> _listGiaoVien = new List<GIAOVIEN>(); // chứa danh sách giáo viên lấy từ CSDL
        private GIAOVIEN _currentSelected = null; // chứa thông tin giáo viên được chọn trên gridview

        private bool _isChanged = false;
        public frHoSoGiaoVien()
        {
            InitializeComponent();
        }

        private void frHoSoGiaoVien_Load(object sender, EventArgs e)
        {
            _listMonHoc = _monHocBus.LayDanhSachMonHoc(); // lấy danh sách môn học
            _listGiaoVien = _giaoVienBus.LayTatCaDanhSachGiaoVien();

            // thêm danh sách vào combobox
            for (int i = 0; i < _listMonHoc.Count; i++)
                comboBoxDayMon.Items.Add(_listMonHoc[i].TENMONHOC);
            comboBoxDayMon.SelectedIndex = 0;


            // thêm giới tính vào combobox và thiết lập item selected có index = 0
            comboBoxGioiTinh.Items.Add("Nam");
            comboBoxGioiTinh.Items.Add("Nữ");
            comboBoxGioiTinh.SelectedIndex = 0;

            hienThiDanhSachGiaoVienTrenGridView();
            dateNgaySinh.DateTime = DateTime.Now;
        }


        /// <summary>
        /// Lấy dữ liệu từ danh sách giáo từ đối tượng _listGiaoVien rồi hiển thị lên gridview
        /// </summary>
        private void hienThiDanhSachGiaoVienTrenGridView()
        {
            dataGridViewDanhSachGiaoVien.RowCount = _listGiaoVien.Count;
            for(int i = 0; i < _listGiaoVien.Count; i++) // duyệt từng giáo viên thiết lập dữ liệu tương ứng với từng cột
            {
                // thiết lập dữ liệu cho cột trên dòng
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["HoTen"].Value = _listGiaoVien[i].HoTen;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["MaGiaoVien"].Value = _listGiaoVien[i].MaGiaoVien;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["NgaySinh"].Value = _listGiaoVien[i].NgaySinh;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["DiaChi"].Value = _listGiaoVien[i].DiaChi;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["GioiTinh"].Value = _listGiaoVien[i].GioiTinh;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["Email"].Value = _listGiaoVien[i].Email;
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["MaMonHoc"].Value = _listGiaoVien[i].MaMonHoc;
                for(int j = 0; j < _listMonHoc.Count; j++)
                {
                    if(_listMonHoc[j].MAMONHOC.Equals(_listGiaoVien[i].MaMonHoc))
                    {
                        dataGridViewDanhSachGiaoVien.Rows[i].Cells["DayMon"].Value = _listMonHoc[j].TENMONHOC;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Sự kiện: xảy ra khi người dùng click vào button Thêm
        /// thêm một giáo viên vào table
        /// </summary>
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên!", "Lỗi");
                return;
            }


            _isChanged = true;
            // lấy STT để phát sinh mã giáo viên
            int STT = _giaoVienBus.LaySTTMaGiaoVienCuoiCung();
            // thiết lập thuộc tính
            GIAOVIEN temp = new GIAOVIEN();
            temp.MaGiaoVien = "GV" + Convert.ToInt32(STT + 1);
            temp.HoTen = textHoTen.Text;
            temp.DiaChi = textDiaChi.Text;
            temp.NgaySinh = dateNgaySinh.DateTime;
            temp.Email = textEmail.Text;
            temp.GioiTinh = comboBoxGioiTinh.Items[comboBoxGioiTinh.SelectedIndex].ToString();
            temp.MaMonHoc = _listMonHoc[comboBoxDayMon.SelectedIndex].MAMONHOC;
           

            //Thêm giáo viên vào CSDL, thêm giảng dạy vào CSDL
            //if (_giaoVienBus.Them("GV" + Convert.ToInt32(STT + 1), textHoTen.Text, textDiaChi.Text, dateNgaySinh.DateTime, textEmail.Text, comboBoxGioiTinh.SelectedText, _listMonHoc[comboBoxDayMon.SelectedIndex].MAMONHOC) == 1)
            //{
            //    MessageBox.Show("Thêm thành công!", "Thông báo");
            //}
            //else
            //{
            //    MessageBox.Show("Thêm thất bại! Môn học bạn chọn không tồn tại trong danh sách môn học", "Thông báo");
            //    return;
            //}

            if (_giaoVienBus.Them(temp) == 1)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Môn học bạn chọn không tồn tại trong danh sách môn học", "Thông báo");
                return;
            }
           
            _listGiaoVien.Add(temp);
            hienThiDanhSachGiaoVienTrenGridView();
        }

        private void dataGridViewDanhSachGiaoVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridViewDanhSachGiaoVien.Rows.Count; i++)
            {
                dataGridViewDanhSachGiaoVien.Rows[i].Cells["STT"].Value = i + 1;
            }
        }


        /// <summary>
        /// Sự kiện: xảy ra khi người dùng click vào button Sửa
        /// cập nhật lại thông tin giáo viên
        /// </summary>
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên!", "Lỗi");
                return;
            }

            _isChanged = true;
            if(_currentSelected != null) // nếu tồn tại thông tin giáo viên được chọn
            {
                if(_giaoVienBus.Update(_currentSelected.MaGiaoVien, _currentSelected.HoTen, _currentSelected.DiaChi, _currentSelected.NgaySinh, _currentSelected.Email, _currentSelected.GioiTinh, _currentSelected.MaMonHoc) == 0)
                {
                    MessageBox.Show("Cập nhật thất bại! Môn học bạn chọn không tồn tại trong danh sách môn học", "Thông báo");
                    return;
                }


                // cập nhật lại dữ liệu hiển thị trên gridview
                for (int i = 0; i < _listGiaoVien.Count; i++)
                {
                    if(_listGiaoVien[i].MaGiaoVien.Equals(_currentSelected.MaGiaoVien))
                    {
                        _listGiaoVien[i].HoTen = textHoTen.Text;
                        _listGiaoVien[i].DiaChi = textDiaChi.Text;
                        _listGiaoVien[i].NgaySinh = dateNgaySinh.DateTime;
                        _listGiaoVien[i].Email = textEmail.Text;
                        _listGiaoVien[i].GioiTinh = comboBoxGioiTinh.Items[comboBoxGioiTinh.SelectedIndex].ToString();
                        _listGiaoVien[i].MaMonHoc = _listMonHoc[comboBoxDayMon.SelectedIndex].MAMONHOC;
                    }
                }

                hienThiDanhSachGiaoVienTrenGridView();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
        }

        /// <summary>
        /// Sự kiện: khi người dùng click button Thoát
        /// Đóng form đang thao tác
        /// </summary>
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            if(_isChanged && MessageBox.Show("Dữ liệu đã thay đổi, bạn có muốn lưu sự thay đổi?","Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _giaoVienBus.setSubmitChanged();
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            this.Close();
        }


        /// <summary>
        /// Sự kiện: khi người dùng click vào button Xóa
        /// Xóa một giáo viên được chọn trên gridview
        /// </summary>
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (_currentSelected == null) return;


            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                try 
                {
                    _isChanged = true;
                    // xóa khóa ngoại trong bảng GIANGDAY
                    //_giangDayBus.Delete(_currentSelected.MaGiaoVien);
                    List<GIANGDAY> temp =  _giangDayBus.DB.GIANGDAYs.Where(gd => gd.MaGiaoVien == _currentSelected.MaGiaoVien).ToList<GIANGDAY>();
                    if( temp.Count != 0)
                    {
                        MessageBox.Show("Không thể xóa giáo viên đã phân công giảng dạy!", "Thông báo");
                        return;
                    }


                    //xóa giáo viên trong bảng GIAOVIEN, xảy ra ngoại lệ khi có khóa ngoại
                    _giaoVienBus.Delete(_currentSelected.MaGiaoVien);

                    MessageBox.Show("Xóa thành công!", "Thông báo");

                    for (int i = 0; i < _listGiaoVien.Count; i++)
                    {
                        if (_listGiaoVien[i].MaGiaoVien.Equals(_currentSelected.MaGiaoVien))
                        {
                            _listGiaoVien.RemoveAt(i);
                            break;
                        }
                    }

                    _currentSelected = null;
                    hienThiDanhSachGiaoVienTrenGridView();
                }catch(Exception ex)
                {
                    MessageBox.Show("Không thể xóa!", "Thông báo");
                }              
            }
        }


        /// <summary>
        /// Sự kiện: khi người dùng double click vào dòng trên datagridview
        /// lấy thông tin trên dòng được chọn
        /// </summary>
        private void dataGridViewDanhSachGiaoVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_currentSelected != null)
            {
                // thiết lập hiển thị dữ liệu trên giao diện
                textHoTen.Text = _currentSelected.HoTen;
                textEmail.Text = _currentSelected.Email;
                textDiaChi.Text = _currentSelected.DiaChi;
                dateNgaySinh.EditValue = (DateTime)_currentSelected.NgaySinh;
                comboBoxDayMon.SelectedItem = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["DayMon"].Value.ToString();

                for (int i = 0; i < comboBoxGioiTinh.Items.Count; i++)
                {
                    if(comboBoxGioiTinh.Items[i].Equals(_listGiaoVien[e.RowIndex].GioiTinh))
                    {
                        comboBoxGioiTinh.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Sự kiện: khi người dùng click vào cell trên gridview
        /// Lưu thông tin giáo viên tại dòng được click
        /// </summary>
        private void dataGridViewDanhSachGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra nếu chọn trên dòng dữ liệu, không phải trên header
            {
                // thiết lập thuộc tính dữ liệu vào biến _currentSelected
                _currentSelected = new GIAOVIEN();
                _currentSelected.MaGiaoVien = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["MaGiaoVien"].Value.ToString();
                _currentSelected.HoTen = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                _currentSelected.GioiTinh = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                _currentSelected.MaMonHoc = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["MaMonHoc"].Value.ToString();
                _currentSelected.NgaySinh = (DateTime)dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["NgaySinh"].Value;
                _currentSelected.MaMonHoc = _listMonHoc[comboBoxDayMon.SelectedIndex].MAMONHOC;
                _currentSelected.DiaChi = dataGridViewDanhSachGiaoVien.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            }
            else
                _currentSelected = null;
        }

        private void buttonOpenDataFromExcell_Click(object sender, EventArgs e)
        {
            moFileExcell();
        }

        private void moFileExcell()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel Files|*.xls;*.xlsx";
            openFile.Title = "Chọn tập tin excel";
            openFile.InitialDirectory = @"C:\\";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;
                DocFileExcel(path);
            }
        }

        private void DocFileExcel(string ipath)
        {
            IExcelDataReader FileExcel;
            FileStream stream = File.Open(ipath, FileMode.Open, FileAccess.Read);   //Đọc file vào
            try
            {
                //1. Câu lệnh sau dùng cho Excel 2007 trở lên
                FileExcel = ExcelReaderFactory.CreateOpenXmlReader(stream);      //1.
            }
            catch
            {
                //2. Nếu bạn dùng Excel 2003 trở xuống vui lòng dùng câu lệnh 2. thay cho 1.
                FileExcel = ExcelReaderFactory.CreateBinaryReader(stream);    //2.
            }

            DataSet result = FileExcel.AsDataSet();
            FileExcel.IsFirstRowAsColumnNames = true;
            //listtemp = new List<string>();
            foreach (System.Data.DataTable table in result.Tables)
            {
                for (int i = START_POSITION_AT_ROW_READ_FROM_EXCEL; i < table.Rows.Count; i++)
                {
                    GIAOVIEN temp = new GIAOVIEN();
                    temp.HoTen = table.Rows[i].ItemArray[0].ToString();
                    temp.NgaySinh = (DateTime)table.Rows[i].ItemArray[1];
                    temp.GioiTinh = table.Rows[i].ItemArray[2].ToString();
                    temp.DiaChi = table.Rows[i].ItemArray[3].ToString();
                    temp.Email = table.Rows[i].ItemArray[4].ToString();
                    
                    for(int j = 0; j < _listMonHoc.Count; j++)
                    {
                        if(_listMonHoc[j].TENMONHOC.Equals(table.Rows[i].ItemArray[5].ToString()))
                        {
                            temp.MaMonHoc = _listMonHoc[j].MAMONHOC;
                            break;
                        }
                    }

                    temp.MaGiaoVien = "GV" + Convert.ToInt64(_giaoVienBus.LaySTTMaGiaoVienCuoiCung() + 1);

                    //if (_giaoVienBus.Them(temp.MaGiaoVien, temp.HoTen, temp.DiaChi, temp.NgaySinh, temp.Email, temp.GioiTinh, temp.MaMonHoc) == 0)
                    //    MessageBox.Show("Giáo viên: " + temp.HoTen + " dạy môn không nằm trong danh sách quy định!", "Lỗi");
                    //else
                    //    _listGiaoVien.Add(temp);

                    if (_giaoVienBus.Them(temp) == 0)
                        MessageBox.Show("Giáo viên: " + temp.HoTen + " dạy môn không nằm trong danh sách quy định!", "Lỗi");
                    else
                        _listGiaoVien.Add(temp);
                }
            }
            FileExcel.Close();

            hienThiDanhSachGiaoVienTrenGridView();
            _isChanged = true;
            MessageBox.Show("Mở tập tin excel thành công!", "Thông báo");
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn lưu những thay đổi dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _giaoVienBus.setSubmitChanged();
                MessageBox.Show("Lưu thành công", "Thông báo");
                _isChanged = false;
            }
        }
    }
}