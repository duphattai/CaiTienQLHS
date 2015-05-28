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
using System.Data.Linq;
using DataAccessObject.DAO;

namespace frMain
{
    public partial class formBangDiem : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Đối tượng dùng để lưu danh sách bảng điểm bị thay đổi nhưng chưa lưu xuống database theo năm học
        /// </summary>
        public class CBangDiemChanged
        {
            public string namHoc; // lưu năm học
            public int maHocKy; // lưu học kỳ 
            public string maKhoi; // lưu khối lớp
            public int maLop; // lưu mã lớp trong khối
            public string maMon; // lưu mã môn học
            public List<BangDiemHocSinh> listDiem = new List<BangDiemHocSinh>(); // danh sách bảng điểm bị thay đổi trong năm học đó

            /// <summary>
            /// Construtor để khởi tạo giá trị các thuộc tính
            /// </summary>
            public CBangDiemChanged(string _NamHoc, int _MaHocKy, string _MaKhoi, int _MaLop, string _MaMon, List<BangDiemHocSinh> _ListDiem)
            {
                namHoc = _NamHoc;
                maHocKy = _MaHocKy;
                maKhoi = _MaKhoi;
                maLop = _MaLop;
                maMon = _MaMon;
                listDiem = _ListDiem;
            }
        }

        private NamHoc_BUS _namHocBus = new NamHoc_BUS(); // dùng để truy xuất dữ liệu từ bảng NAMHOC từ database
        private Khoi_BUS _khoiBus = new Khoi_BUS(); // truy xuất bảng KHOI
        private HocKy_BUS _hocKyBus = new HocKy_BUS(); // truy xuất đến bảng HOCKY
        private MonHoc_BUS _monHocBus = new MonHoc_BUS(); // truy xuất đến bảng MONHOC
        private Diem_BUS _diemBus = new Diem_BUS(); // truy xuất đến bảng DIEM
        private XepLop_BUS _xepLopBus = new XepLop_BUS(); // truy xuất bảng XEPLOP
        private HoSoHocSinh_BUS _hoSoHocSinhBus = new HoSoHocSinh_BUS(); // truy xuất bảng HOSOHOCSINH
        private QuiDinh_BUS _quiDinhBus = new QuiDinh_BUS(); // truy xuất bảng QUIDINH
        private DanhSachLop_BUS _danhSachLopBus = new DanhSachLop_BUS(); // truy xuất đến bảng DANHSACHLOP

        private Bitmap _bitMap;
        private bool _isSelectedBefore = false;
        private int _namHocIndex, _khoiIndex, _lopIndex, _maHocSinh;


        private List<BangDiemHocSinh> _listBangDiem = new List<BangDiemHocSinh>(); // chưa danh sách bảng điểm lấy từ database
        private List<CBangDiemChanged> _listBangDiemChanged = new List<CBangDiemChanged>(); // danh sách bảng điểm bị thay đổi nhưng chua cập nhật torng database

        private double? _previousValue = 0;   // lưu điểm cũ trước khi thay đổi, để gắn lại nếu người dùng nhập sai quy định

        

        /// <summary>
        /// Constructor dùng để khởi tạo hiển thị của Form và thiết lập chức năng cột DIEM15, DIEM1Tiet, DIEMHK chỉ đọc
        /// </summary>
        public formBangDiem(bool _IsAllowToUpdate)
        {
            InitializeComponent();
            if (!_IsAllowToUpdate)
            {
                dataGridView.Columns["DIEM15"].ReadOnly = true;
                dataGridView.Columns["DIEM1Tiet"].ReadOnly = true;
                dataGridView.Columns["DIEMHK"].ReadOnly = true;
            }
        }

        public formBangDiem(bool _IsAllowToUpdate, int NamHocIndex, int KhoiIndex, int LopIndex, int MaHocSinh)
        {
            InitializeComponent();
            if (!_IsAllowToUpdate)
            {
                dataGridView.Columns["DIEM15"].ReadOnly = true;
                dataGridView.Columns["DIEM1Tiet"].ReadOnly = true;
                dataGridView.Columns["DIEMHK"].ReadOnly = true;
            }
            _isSelectedBefore = true;
            _namHocIndex = NamHocIndex;
            _khoiIndex = KhoiIndex;
            _lopIndex = LopIndex;
            _maHocSinh = MaHocSinh;
        }

        /// <summary>
        /// Sự kiện: xảy ra khi form bảng điểm được load lên
        /// </summary>
        private void formBangDiem_Load(object sender, EventArgs e)
        {
            loadDanhSachNam();
            if (comboboxNam.Items.Count > 0)
            {
                if (!_isSelectedBefore)
                {
                    loadDanhSachHocKy();
                    comboboxHocKy.SelectedIndex = 0;
                    comboboxNam.SelectedIndex = 0;
                }
                else
                {
                    loadDanhSachHocKy();
                    loadDanhSachMonHoc();
                    comboboxNam.SelectedIndex = _namHocIndex;
                    comboboxKhoi.SelectedIndex = _khoiIndex;
                    comboboxLop.SelectedIndex = _lopIndex;
                    comboboxHocKy.SelectedIndex = 0;
                    comboboxMon.SelectedIndex = 0;
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells["MaHocSinh"].Value.ToString() == _maHocSinh.ToString())
                            dataGridView.CurrentCell = row.Cells[0];
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        /// <summary>
        /// load năm học từ database vào comboboxNam
        /// </summary>
        private void loadDanhSachNam()
        {
            comboboxNam.Items.Clear();// xóa các danh sách năm học hiện có
            foreach (NAMHOC nam in _namHocBus.LayNamHoc())
            {
                comboboxNam.Items.Add(nam.NAMHOC1);// thêm năm học vào combobox
            }
        }

        /// <summary>
        /// lấy dữ liệu học kỳ từ database thêm vào comboboxHocky
        /// </summary>
        void loadDanhSachHocKy()
        {
            comboboxHocKy.Items.Clear();// xóa các danh sách học kỳ hiện có
            foreach (HOCKY hk in _hocKyBus.LayDanhSachHocKy()) // duyệt danh sách học kỳ lấy từ database
            {
                comboboxHocKy.Items.Add(hk.TENHOCKY); // thêm học kỳ năm học
            }
        }

        /// <summary>
        /// lấy dữ liệu tất cả môn học từ database thêm vào comboboxMon
        /// </summary>
        void loadDanhSachMonHoc()
        {
            comboboxMon.Items.Clear();
            foreach (MONHOC mh in _monHocBus.LayDanhSachMonHoc())
            {
                comboboxMon.Items.Add(mh.TENMONHOC);
            }
        }

        /// <summary>
        /// lấy dữ liệu khối lớp từ database thêm vào comboboxKhoi
        /// </summary>
        void loadDanhSachKhoi()
        {
            comboboxKhoi.Items.Clear();
            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                comboboxKhoi.Items.Add(khoi.KHOI.ToString());
            }
        }

        /// <summary>
        /// lấy dữ liệu lớp học từ database thêm vào comboboxLop theo năm học và khối lớp
        /// </summary>
        void loadDanhSachLop()
        {
            comboboxLop.Items.Clear();
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comboboxKhoi.Tag.ToString(), comboboxNam.Text))
            {
                comboboxLop.Items.Add(lop.TENLOP.ToString());
            }
        }


        /// <summary>
        /// Kiểm tra xem trong năm học, trong một học kỳ, trong một lớp, trong một môn có điểm học sinh bị thay đổi ma chưa lưu lại hay chưa
        /// nếu có trả về vị trí trong danh sách đó, không trả về -1
        /// </summary> 
        int checkExistedInListBangDiemChanged(string _NamHoc, int _MaHocKy, string _MaKhoi, int _MaLop, string _MaMon)
        {
            for (int i = 0; i < _listBangDiemChanged.Count; i++)
            {
                if (_listBangDiemChanged[i].namHoc == _NamHoc && _listBangDiemChanged[i].maHocKy == _MaHocKy 
                    && _listBangDiemChanged[i].maKhoi == _MaKhoi && _listBangDiemChanged[i].maLop == _MaLop 
                    && _listBangDiemChanged[i].maMon == _MaMon)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Tìm vị trí của học sinh trong danh sách bảng điểm
        /// </summary>
        /// <returns>
        /// không tìm thấy trả về -1, ngược lại là vị trí của học sinh
        /// </returns>
        int findIndexInListBangDiem(int _MaHocSinh, List<BangDiemHocSinh> _BangDiem)
        {
            for (int i = 0; i < _BangDiem.Count; i++)
            {
                if (_MaHocSinh == _BangDiem[i]._MaHocSinh)
                    return i;
            }
            return -1;
        }

        void LoadBangDiem()
        {

        }

        /// <summary>
        /// Sự kiện: khi comboxboxNam được click vào
        /// load dữ liệu năm học vào combobox và thiết lập thuộc tính
        /// </summary>
        private void comboboxNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDanhSachKhoi();
            if (comboboxKhoi.Items.Count > 0)
                comboboxKhoi.SelectedIndex = 0; // mặc định chọn item đầu tiên
        }


        /// <summary>
        /// Sự kiện: khi comboboxHocKy được click vào
        /// thiết lập thuộc tính Tag của combobox = mã học kỳ tương ứng được selected, hiển thị lại dữ liệu trên datagridview
        /// </summary>
        private void comboboxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (HOCKY hk in _hocKyBus.LayDanhSachHocKy())
            {
                if (index == comboboxHocKy.SelectedIndex)
                {
                    comboboxHocKy.Tag = hk.MAHOCKY;
                    break;
                }
                index++;
            }
            loadDataGridView();
        }


        /// <summary>
        /// Sự kiện: xảy ra khi comboboxMon được chọn
        /// thiết lập thuộc tính Tag = mã môn học tương ứng với tên môn học được chọn
        /// </summary>
        private void comboboxMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (MONHOC mh in _monHocBus.LayDanhSachMonHoc())
            {
                if (index == comboboxMon.SelectedIndex)
                {
                    comboboxMon.Tag = mh.MAMONHOC;
                    break;
                }
                index++;
            }
            loadDataGridView();
        }

        /// <summary>
        /// Sự kiện: xảy ra khi comboboxKhoi được chọn
        /// thiết lập Tag = mã khối tương ứng với tên khối được chọn và load lại danh sách lớp 
        /// </summary>
        private void comboboxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                if (index == comboboxKhoi.SelectedIndex)
                {
                    comboboxKhoi.Tag = khoi.MAKHOI;

                }
                index++;
            }

            loadDanhSachLop();
            if (comboboxLop.Items.Count > 0)
                comboboxLop.SelectedIndex = 0;
        }


        /// <summary>
        /// Sự kiện: xảy ra khi comboboxLop đựơc chọn
        /// hiển thị lại danh sách môn học theo lớp và thiết lập Tag = mã lớp tương ứng với tên lớp được chọn
        /// </summary>
        private void comboBoxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            loadDanhSachMonHoc();

            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comboboxKhoi.Tag.ToString(), comboboxNam.Text))
            {
                if (index == comboboxLop.SelectedIndex)
                {
                    comboboxLop.Tag = lop.MALOP;
                    break;
                }
                index++;
            }
            if (comboboxMon.Items.Count > 0)
                comboboxMon.SelectedIndex = 0;
        }


        /// <summary>
        /// lấy danh sách học sinh và bảng điểm với các điều kiện tương ứng hiển thị lên datagridview
        /// </summary>
        void loadDataGridView()
        {
            // Đảm bảo các combobox đều có dữ liệu được chọn
            if (comboboxLop.SelectedIndex != -1 && comboboxMon.SelectedIndex != -1 && comboboxNam.SelectedIndex != -1 && comboboxHocKy.SelectedIndex != -1 && comboboxKhoi.SelectedIndex != -1)
            {
                labelHocKy.Text = comboboxHocKy.Text;
                labelMon.Text = comboboxMon.Text;
                labelLop.Text = comboboxLop.Text;


                _listBangDiem.Clear();
                int i = checkExistedInListBangDiemChanged(comboboxNam.Text, int.Parse(comboboxHocKy.Tag.ToString()), comboboxKhoi.Tag.ToString(), int.Parse(comboboxLop.Tag.ToString()), comboboxMon.Tag.ToString());
                if (i == -1)// không tìm thấy
                {
                    // duyệt danh sách học sinh trong một lớp
                    foreach (usp_SelectXeplopsByMALOPResult hs in _xepLopBus.TruyVanTheoMaLop(int.Parse(comboboxLop.Tag.ToString())))
                    {
                        // Lấy bảng điểm học sinh đang duyệt từ database
                        BangDiemHocSinh diem = _diemBus.LayBangDiem((int)hs.MAHOCSINH, comboboxNam.Text, int.Parse(comboboxHocKy.Tag.ToString()), comboboxMon.Tag.ToString());
                        _listBangDiem.Add(diem); // thêm học sinh cùng bảng điểm vào danh sách
                    }
                    dataGridView.DataSource = _listBangDiem.ToArray(); // thiết lập dữ liệu cho datagridview
                }
                else // tìm thấy
                {
                    dataGridView.DataSource = _listBangDiemChanged[i].listDiem.ToArray();// thiết lập dữ liệu cho datagridview
                }
            }
            else
            {
                labelHocKy.Text = null;
                labelMon.Text = null;
                labelLop.Text = null;
            }

            // thiết lập số thứ tự trên datagridview
            for (int j = 0; j < dataGridView.Rows.Count; j++)
            {
                dataGridView.Rows[j].Cells["STT"].Value = j + 1;
            }

        }

        /// <summary>
        /// Sự kiện: xảy ra sau khi thay đổi dữ liệu trên datagridview
        /// kiểm tra điểm vừa thay đổi có hợp lệ không, nếu hợp lệ và điểm nhập đầy đủ sẽ tính điểm trung bình
        /// </summary>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double Diem = -1;
            double? DiemTB = null;

            try
            {
                double.TryParse(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out Diem); // convert string to double tại giá trị vừa thay đổi
            }
            catch
            {
                Diem = -1;
            }
            finally
            {
                int DiemToiDa = _quiDinhBus.LayDiemToiDa();
                int DiemToiThieu = _quiDinhBus.LayDiemToiThieu();
                if (Diem > DiemToiDa || Diem < DiemToiThieu) // điểm thay đổi không hợp lệ
                {
                    MessageBox.Show("Điểm không được vượt quá " + DiemToiDa.ToString() + " hay nhỏ hơn " + DiemToiThieu.ToString(), "Error");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _previousValue; // nếu không hợp lệ sẽ lấy lại điểm cũ
                    dataGridView.CancelEdit();
                }
                else // hợp lệ
                {
                    // đảm bảo các điểm được nhập đầy đủ
                    if (dataGridView.Rows[e.RowIndex].Cells["Diem15"].Value != null && dataGridView.Rows[e.RowIndex].Cells["Diem1Tiet"].Value != null && dataGridView.Rows[e.RowIndex].Cells["DiemHK"].Value != null)
                    {
                        double _Diem15 = double.Parse(dataGridView.Rows[e.RowIndex].Cells["Diem15"].Value.ToString());
                        double _Diem1Tiet = double.Parse(dataGridView.Rows[e.RowIndex].Cells["Diem1Tiet"].Value.ToString());
                        double _DiemHK = double.Parse(dataGridView.Rows[e.RowIndex].Cells["DiemHK"].Value.ToString());
                        DiemTB = Math.Round((_Diem15 + _Diem1Tiet * 2 + _DiemHK * 3) / 6, 1); // tính điểm trung bình

                        dataGridView.Rows[e.RowIndex].Cells["DiemTB"].Value = DiemTB;
                    }

                    int i = checkExistedInListBangDiemChanged(comboboxNam.Text, int.Parse(comboboxHocKy.Tag.ToString()), comboboxKhoi.Tag.ToString(), int.Parse(comboboxLop.Tag.ToString()), comboboxMon.Tag.ToString());
                    if (i == -1)// không tìm thấy
                    {
                        // thêm bảng điểm vừa thay đổi vào ListBangDiemChanged
                        _listBangDiemChanged.Add(new CBangDiemChanged(comboboxNam.Text, int.Parse(comboboxHocKy.Tag.ToString()), comboboxKhoi.Tag.ToString(), int.Parse(comboboxLop.Tag.ToString()), comboboxMon.Tag.ToString(), new List<BangDiemHocSinh>(_listBangDiem)));
                        
                        int index = _listBangDiemChanged.Count - 1;
                        int j = findIndexInListBangDiem(int.Parse(dataGridView.Rows[e.RowIndex].Cells["MaHocSinh"].Value.ToString()), _listBangDiemChanged[index].listDiem);
                        switch (e.ColumnIndex)// vị trí cột có điểm vừa thay đổi
                        {
                            case 3:
                                _listBangDiemChanged[index].listDiem[j]._Diem15 = Diem;
                                break;
                            case 4:
                                _listBangDiemChanged[index].listDiem[j]._Diem1Tiet = Diem;
                                break;
                            case 5:
                                _listBangDiemChanged[index].listDiem[j]._DiemHK = Diem;
                                break;
                            default:
                                break;
                        }
                        _listBangDiemChanged[index].listDiem[j]._DiemTB = DiemTB;
                    }
                    else // tìm thấy
                    {
                        int j = findIndexInListBangDiem(int.Parse(dataGridView.Rows[e.RowIndex].Cells["MaHocSinh"].Value.ToString()), _listBangDiemChanged[i].listDiem);
                        switch (e.ColumnIndex)// vị trí cột có điểm vừa thay đổi
                        {
                            case 3:
                                _listBangDiemChanged[i].listDiem[j]._Diem15 = Diem;
                                break;
                            case 4:
                                _listBangDiemChanged[i].listDiem[j]._Diem1Tiet = Diem;
                                break;
                            case 5:
                                _listBangDiemChanged[i].listDiem[j]._DiemHK = Diem;
                                break;
                            default:
                                break;
                        }
                        _listBangDiemChanged[i].listDiem[j]._DiemTB = DiemTB;
                    }
                }
            }

        }

        /// <summary>
        /// Sự kiện: xảy ra khi nhập sai dữ liệu vào cột điểm
        /// </summary>
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Vui lòng chỉ nhập số", "Error");
            dataGridView.CancelEdit();
        }

        /// <summary>
        /// Sự kiện: khi thay đổi dữ liệu trên ô trong datagridview
        /// convert dữ liệu từ ô đã thay đổi thành double
        /// </summary>
        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                _previousValue = double.Parse(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()); // convert string to double
            }
            catch
            {
                _previousValue = null;
            }
        }

        /// <summary>
        /// Sự kiện: khi buttonLuu được click
        /// lưu dữ liệu điểm của học sinh đã bị thay đổi vào databse
        /// </summary>
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _listBangDiemChanged.Count; i++)
            {
                for (int j = 0; j < _listBangDiemChanged[i].listDiem.Count; j++)
                    _diemBus.UpdateDiem(_listBangDiemChanged[i].listDiem[j], _listBangDiemChanged[i].namHoc, _listBangDiemChanged[i].maHocKy, _listBangDiemChanged[i].maMon);
            }
            MessageBox.Show("Lưu thành công", "Success");
            _listBangDiemChanged.Clear();
        }

        /// <summary>
        /// Sự kiện: khi buttonThoat được click
        /// nếu dữ liệu bị thay đổi nhưng chưa lưu sẽ nhắc người dùng lưu lại, đóng form đang thao tác
        /// </summary>
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            if (_listBangDiemChanged.Count > 0) // dữ liệu thay đổi nhưng chưa lưu
            {
                DialogResult dr = MessageBox.Show("Dữ liệu có thay đổi, bạn có muốn lưu lại ko?", "THOÁT ỨNG DỤNG", MessageBoxButtons.YesNoCancel);
                if (dr != DialogResult.Cancel) // button trên Yes trên DialogResult được chọn
                {
                    if (DialogResult.Yes == dr)
                    {
                        buttonLuu_Click(sender, e); // lưu dữ liệu vào database
                    }
                    this.Close();
                }
            }
            else // không có dữ liệu bị thay đổi
            {
                if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Sự kiện: khi buttonIn được click
        /// in bảng điểm 
        /// </summary>
        private void buttonIn_Click(object sender, EventArgs e)
        {
            printPreviewBangDiem.Document = printBangDiem; // thiết lập dữ liệu sẽ in lên

            ((Form)printPreviewBangDiem).WindowState = FormWindowState.Maximized; // thiết lập cửa số mới full màn hình
            printPreviewBangDiem.PrintPreviewControl.AutoZoom = false;
            printPreviewBangDiem.PrintPreviewControl.Zoom = 1.0; 

            printPreviewBangDiem.ShowDialog();
        }

        /// <summary>
        /// vẽ table của datagridview 
        /// </summary>
        private void printDataGridView()
        {
            _bitMap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(_bitMap, this.dataGridView.ClientRectangle);
        }


        private void printBangDiem_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDataGridView();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("BẢNG ĐIỂM MÔN " + comboboxMon.Text.ToString().ToUpper() +" LỚP "+comboboxLop.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 180, 50);
            e.Graphics.DrawString(comboboxHocKy.Text.ToString().ToUpper()+ ", NĂM HỌC " + comboboxNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 200, 100);

            e.Graphics.DrawImage(_bitMap, new Point(40, 170));
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {

        }
    }
}