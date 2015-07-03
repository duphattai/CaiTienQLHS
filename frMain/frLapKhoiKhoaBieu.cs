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
using System.IO;

namespace frMain
{
    public partial class frLapKhoiKhoaBieu : DevExpress.XtraEditors.XtraForm
    {
        private NamHoc_BUS _namHocBus = new NamHoc_BUS();
        private DanhSachLop_BUS _danhSachLopBus = new DanhSachLop_BUS();
        private MonHoc_BUS _monHocBus = new MonHoc_BUS();
        private GiangDay_BUS _giangDayBus = new GiangDay_BUS();
        private ThoiKhoaBieu_BUS _thoiKhoaBieuBus = new ThoiKhoaBieu_BUS();

        private GiaiThuat.GiaiThuatLapThoiKhoaBieu giaithuat;
        private List<usp_SelectLopByNamHocResult> _listDanhSachLop = new List<usp_SelectLopByNamHocResult>(); // danh sách lớp để hiển thị dữ liệu lên datagridview
        private List<MONHOC> _danhSachMonHoc = new List<MONHOC>();

        private List<LOP> _listLopLapLich = new List<LOP>(); // danh sách lớp sẽ lập thời khóa biểu
        public frLapKhoiKhoaBieu()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Sự kiện: khi form được hiển thị lên screen
        /// hiển thị thông tin cần thiết
        /// </summary>
        private void frLapKhoiKhoaBieu_Load(object sender, EventArgs e)
        {
            try
            {
                _danhSachMonHoc = _monHocBus.LayDanhSachMonHoc();

                foreach (NAMHOC namHoc in _namHocBus.LayNamHoc())
                {
                    comBoBoxNamHoc.Items.Add(namHoc.NAMHOC1);
                }
                comBoBoxNamHoc.SelectedIndex = 0;

                _listDanhSachLop = _danhSachLopBus.LayDanhSachLopNamHoc(comBoBoxNamHoc.SelectedItem.ToString()).ToList();
                dataGridViewDanhSachLop.DataSource = _listDanhSachLop.ToList();
            }catch(Exception ex)
            {
                MessageBox.Show("Không có dữ liệu để lập thời khóa biểu", "Thông báo");
                Application.Exit();
            }
        }

        /// <summary>
        /// Kiểm tra xem lớp có được phân công giáo viên dạy đầy đủ, nếu phân công đầy đủ trả về true và ngược lại
        /// </summary>
        private Boolean kiemTraPhanCongGiangDayLop(List<usp_SelectMonHocBy_MaLopResult> danhSachPhanCongGiangDay, string Khoi, List<MONHOC> danhSachMon)
        {
            int count = 0;
            for (int i = 0; i < danhSachMon.Count; i++)
            {
                if (Khoi.Equals("K10") && danhSachMon[i].SOTIETKHOI10 != 0)
                    count++;
                else if (Khoi.Equals("K11") && danhSachMon[i].SOTIETKHOI11 != 0)
                    count++;
                else if (Khoi.Equals("K12") && danhSachMon[i].SOTIETKHOI12 != 0)
                    count++;
            }

            if (danhSachPhanCongGiangDay.Count() == count) return true;

            return false;
        }

        /// <summary>
        /// Sự kiện: khi click vào button Kiểm tra
        /// kiểm tra xem dữ liệu đã đầy đủ chưa, nếu đủ thì cho phép người dùng lập lịch
        /// </summary>
        private void buttonKiemTra_Click(object sender, EventArgs e)
        {
            List<usp_SelectLopByNamHocResult> danhSachLopLapLich = new List<usp_SelectLopByNamHocResult>(); // danh sách lớp lập lịch
            List<string> listLop = new List<string>(); // chứa danh sách lớp không thể lập lịch

            for(int i = 0; i < dataGridViewDanhSachLop.RowCount; i++)
            {
                if(Convert.ToBoolean(dataGridViewDanhSachLop.Rows[i].Cells["ChonLop"].Value) == true) // lấy những lớp được selected
                {
                    danhSachLopLapLich.Add(_listDanhSachLop[i]);
                    List<usp_SelectMonHocBy_MaLopResult> temp = _giangDayBus.LayMonHocTheoMaLop(_listDanhSachLop[i].MALOP);
                    if (!kiemTraPhanCongGiangDayLop(temp, _listDanhSachLop[i].MAKHOI, _danhSachMonHoc))
                        listLop.Add(_listDanhSachLop[i].TENLOP);
                }
            }

            if(listLop.Count == 0) // có thể lập lịch
            {
                MessageBox.Show("Có thể lập thời khóa biểu.", "Thông báo");
                buttonTuDong.Visible = true;
               
                // lấy danh sách lớp được chọn lập thời khóa biểu
                for(int i = 0; i < danhSachLopLapLich.Count; i++)
                {
                    LOP temp = new LOP();
                    temp.MALOP = danhSachLopLapLich[i].MALOP;
                    temp.MAKHOI = danhSachLopLapLich[i].MAKHOI;
                    temp.TENLOP = danhSachLopLapLich[i].TENLOP;

                    _listLopLapLich.Add(temp);
                }
            }
            else
            {
                string message = "";
                for(int i = 0; i < listLop.Count; i++)
                {
                    message += listLop[i] + ", ";
                }

                MessageBox.Show("Các lớp chưa thể lập lịch: " + message, "Thông báo");
                return;
            }
        }


        private void dataGridViewDanhSachLop_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridViewDanhSachLop.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Sự kiện: khi người dùng click vào cell lần đầu
        /// Drop down item in combobox lam
        /// </summary>
        private void dataGridViewDanhSachLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validRow = (e.RowIndex != -1); //Make sure the clicked row isn't the header.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validRow)
            {
                datagridview.BeginEdit(true);
                ((System.Windows.Forms.ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }


        /// <summary>
        /// Đóng form đang thao tác
        /// </summary>
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Sự kiện: khi button Tự động được click
        /// tự động lập lịch cho năm học
        /// </summary>
        private void buttonTuDong_Click(object sender, EventArgs e)
        {
            GiaoVien_BUS giaoVienBus = new GiaoVien_BUS();
            List<GIAOVIEN> listGiaoVien = giaoVienBus.LayTatCaDanhSachGiaoVien();

            List<GIANGDAY> listGiangDay = new List<GIANGDAY>();
            for(int i = 0; i < _listLopLapLich.Count; i++) // duyệt từng lớp 
            {
                foreach(usp_SelectGiangDayBy_MaLopResult temp in _giangDayBus.LayGiangDayTheoMaLop(_listLopLapLich[i].MALOP)) // lấy giảng dạy theo lớp
                {
                    GIANGDAY giangDay = new GIANGDAY();
                    giangDay.MaGiaoVien = temp.MaGiaoVien;
                    giangDay.MaLop = temp.MaLop;

                    listGiangDay.Add(giangDay);
                }
            }


            giaithuat = new GiaiThuat.GiaiThuatLapThoiKhoaBieu(listGiaoVien, _danhSachMonHoc, _listLopLapLich, listGiangDay);
            giaithuat.CreateQuanTheBanDau(); // khởi tạo thời khóa biểu random
            if (giaithuat.CapNhatMonHocBiTrungTKB()) // cập nhật lai thời khóa biểu sao cho không có tiết học bi trùng
            {
                giaithuat.ShowTKBToGridView(dataGridViewThoiKhoaBieu);
                buttonLuu.Visible = true;
            }
            else 
            {
                MessageBox.Show("Không thể lập lịch. số giảng viên không hợp lệ", "Thông báo");
            }
        }

        /// <summary>
        /// Sự kiện: khi buttonLuu được click
        /// lưu thời khóa biểu xuống csdl
        /// </summary>
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                GiaiThuat.GiangDay[][] thoiKhoaBieu = giaithuat.layThoiKhoaBieu();
                List<int> listLopDaLapLich = new List<int>(); // chưa danh sách lớp có thời khóa biểu
                for(int i = 0; i < _listLopLapLich.Count; i++)
                {
                    if(_thoiKhoaBieuBus.CheckExistsThoiKhoaBieuByMaLop(_listLopLapLich[i].MALOP)) // kiểm tra lớp lập lịch đã tồn tại thời khóa biểu trước hay không
                    {
                        
                        listLopDaLapLich.Add(_listLopLapLich[i].MALOP);
                    }
                }
                

                DialogResult result;
                if(listLopDaLapLich.Count != 0) // tồn tại lớp đã có lịch từ trước
                {
                    result = MessageBox.Show("Thời khóa biểu của năm học hiện tại đã lập lịch, bạn có muốn ghi đè lên?", "Thông báo", MessageBoxButtons.OKCancel);

                    if(result == DialogResult.OK)
                    {
                        // xóa lịch lớp đã có từ trước
                        for (int k = 0; k < listLopDaLapLich.Count; k++)
                        {
                            _thoiKhoaBieuBus.Delete(listLopDaLapLich[k]);
                        }

                        // thêm thời khóa biểu xuống CSDL
                        for (int i = 0; i < thoiKhoaBieu.Count(); i++)
                        {
                            for (int j = 0; j < thoiKhoaBieu[i].Count(); j++)
                            {
                                if (thoiKhoaBieu[i][j] == null) continue;

                                int maLop = thoiKhoaBieu[i][j].giangDay.MaLop;
                                string maGiaoVien = thoiKhoaBieu[i][j].giaoVien.MaGiaoVien;
                                int tiet = j;

                                 _thoiKhoaBieuBus.Them(maLop, maGiaoVien, tiet);
                            }
                        }
                    }
                }
                else // không tồn tại lớp lập lịch từ trước
                {
                    for (int i = 0; i < thoiKhoaBieu.Count(); i++)
                    {
                        for (int j = 0; j < thoiKhoaBieu[i].Count(); j++)
                        {
                            if (thoiKhoaBieu[i][j] == null) continue;

                            int maLop = thoiKhoaBieu[i][j].giangDay.MaLop;
                            string maGiaoVien = thoiKhoaBieu[i][j].giaoVien.MaGiaoVien;
                            int tiet = j;

                            _thoiKhoaBieuBus.Them(maLop, maGiaoVien, tiet);
                        }
                    }
                }

                MessageBox.Show("Lưu thành công!", "Thông báo");
            }catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi");

                MessageBox.Show("Không thể lưu", "Lỗi");
            } 
        }

        /// <summary>
        /// Sự kiện: khi button Xuất được click
        /// xuất thời khóa biểu ra excel
        /// </summary>
        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            xuatFileExcel();
        }

        private void xuatFileExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "xls files (*.xls)|*.xls";
            saveFile.FileName = "Thời khóa biểu năm học" + comBoBoxNamHoc.SelectedItem;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter wr = new StreamWriter(saveFile.FileName, false, Encoding.Unicode);
                try
                {
                    for (int i = 0; i < dataGridViewThoiKhoaBieu.ColumnCount; i++)
                    {
                        if(dataGridViewThoiKhoaBieu.Columns[i].Name != null)
                            wr.Write(Convert.ToString(dataGridViewThoiKhoaBieu.Columns[i].Name) + "\t");
                    }
                    wr.WriteLine();

                    for (int i = 0; i < dataGridViewThoiKhoaBieu.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridViewThoiKhoaBieu.Rows[i].Cells.Count; j++)
                        {
                            if (dataGridViewThoiKhoaBieu.Rows[i].Cells[j] != null)
                                wr.Write(Convert.ToString(dataGridViewThoiKhoaBieu.Rows[i].Cells[j].Value) + "\t");
                            else
                                wr.Write("\t");
                        }
                        wr.WriteLine();
                    }
                    wr.Close();

                    MessageBox.Show("Xuất tập tin excel thành công!", "Thông báo");

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("Không thể xuất tập tin file excel", "Lỗi");
                }
            }
        }


        /// <summary>
        /// Sự kiện: khi comBoBoxNamHoc thay đổi giá trị
        /// load lại danh sách lớp theo năm học
        /// </summary>
        private void comBoBoxNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                _listDanhSachLop = _danhSachLopBus.LayDanhSachLopNamHoc(comBoBoxNamHoc.SelectedItem.ToString());
                dataGridViewDanhSachLop.DataSource = _listDanhSachLop.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không tìm thấy", "Thông báo");
            }
        }
    }
}