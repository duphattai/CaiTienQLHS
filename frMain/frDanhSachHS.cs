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

namespace frMain
{
    public partial class FormDanhSachHocSinh : DevExpress.XtraEditors.XtraForm
    {
        private NamHoc_BUS _namHocBus = new NamHoc_BUS();// dùng để truy xuất dữ liệu từ bảng NAMHOC từ database
        private DanhSachLop_BUS _danhSachLopBus = new DanhSachLop_BUS();// truy xuất đến bảng DANHSACHLOP
        private XepLop_BUS _xepLopBus = new XepLop_BUS();// truy xuất bảng XEPLOP
        private HoSoHocSinh_BUS _hoSoHocSinhBus = new HoSoHocSinh_BUS();// truy xuất bảng HOSOHOCSINH
        private Diem_BUS _diemBus = new Diem_BUS();//truy xuất đến bảng DIEM
        private Khoi_BUS _khoiBus = new Khoi_BUS();// truy xuất bảng KHOI
        private QLHSDataContext DB = new QLHSDataContext();

        //List<usp_SelectHosohocsinhsNotMaHocSinhResult> _ListHS = new List<usp_SelectHosohocsinhsNotMaHocSinhResult>();
        private List<ThongTinHocSinh> _listHocSinh = new List<ThongTinHocSinh>();
        private List<int> _listIndexKhoi = new List<int>();

        Bitmap bitMap;

        public FormDanhSachHocSinh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// load năm học từ database vào comboboxNam
        /// </summary>
        private void loadDanhSachNam()
        {
            foreach (NAMHOC NH in _namHocBus.LayNamHoc())
            {
                comboboxNam.Items.Add(NH.NAMHOC1.ToString());
            }
        }

        /// <summary>
        /// lấy dữ liệu khối lớp từ database thêm vào comboboxKhoi
        /// </summary>
        private void loadDanhSachKhoi()
        {
            int i = 0;
            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                comboboxKhoi.Items.Add(khoi.KHOI.ToString());
                _listIndexKhoi.Add(i);
                i++;
            }
        }

        /// <summary>
        /// Sự kiện: xảy ra khi form DanhSachHocSinh được load lên
        /// load danh sách năm học lên comboboxNam, nếu không tồn tại năm học nào thì đóng form lại
        /// </summary>
        private void formDanhSachHocSinh_Load(object sender, EventArgs e)
        {
            loadDanhSachNam();
            if (comboboxNam.Items.Count > 0) // tồn tại năm học
            {
                comboboxNam.SelectedIndex = 0;
            }
            else // không tồn tại năm học, đóng form đang mở
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        /// <summary>
        /// Sự kiện: xảy ra khi comboboxNam được chọn item
        /// sẽ load danh sách khối tương ứng với năm học được chọn
        /// </summary>
        private void comBoBoxNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDanhSachKhoi();
            comboboxKhoi.SelectedIndex = 0;
        }

        /// <summary>
        /// Trả về mã khối trong danh sách khối lấy từ database
        /// </summary>
        String layMaKhoiTheoIndex()
        {
            int i = 0;
            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi()) // duyệt khối trong danh sách khối
            {
                if (i == _listIndexKhoi[comboboxKhoi.SelectedIndex]) return khoi.MAKHOI;

                i++;
            }
            return null;
        }

        /// <summary>
        /// Load danh sách học sinh theo khối và năm học tương ứng lên datagriview
        /// </summary>
        private void loadDanhSachHocSinh()
        {
            _listHocSinh.Clear();
            _listHocSinh = _diemBus.LayBangDiemHocSinhTheoNamHoc(layMaKhoiTheoIndex(), comboboxNam.Text);
            dataGridView.DataSource = _listHocSinh.ToArray();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        /// <summary>
        /// Sự kiện: xảy ra khi comboboxKhoi được chọn
        /// sẽ load danh sách học sinh tương ứng với khối lên datagridview
        /// </summary>
        private void comBoBoxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDanhSachHocSinh();
        }

        /// <summary>
        /// Sự kiện: xảy ra khi buttonThoat được click
        /// đóng form đang thao tác
        /// </summary>
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }


        private void printDanhSachHocSinh_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDataGridView();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("DANH SÁCH HỌC SINH " + comboboxKhoi.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 180, 50);
            e.Graphics.DrawString(" NĂM HỌC " + comboboxNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 250, 100);

            e.Graphics.DrawImage(bitMap, new Point(130, 170));
        }

        private void printDataGridView()
        {
            bitMap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitMap, this.dataGridView.ClientRectangle);
        }

        /// <summary>
        /// Sự kiện: xảy ra khi buttonIn được click
        /// In danh sách học sinh hiện có trên datagridview lên một của sổ mới
        /// </summary>
        private void buttonIn_Click(object sender, EventArgs e)
        {
            printPreviewDanhSachHocSinh.Document = printDanhSachHocSinh;

            ((Form)printPreviewDanhSachHocSinh).WindowState = FormWindowState.Maximized;
            printPreviewDanhSachHocSinh.PrintPreviewControl.AutoZoom = false;
            printPreviewDanhSachHocSinh.PrintPreviewControl.Zoom = 1.0;

            printPreviewDanhSachHocSinh.ShowDialog();
        }
    }
}