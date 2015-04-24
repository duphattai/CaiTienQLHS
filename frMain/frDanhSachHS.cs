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
        private NamHoc_BUS _NamHoc_BUS = new NamHoc_BUS();// dùng để truy xuất dữ liệu từ bảng NAMHOC từ database
        private DanhSachLop_BUS _DanhSachLop_BUS = new DanhSachLop_BUS();// truy xuất đến bảng DANHSACHLOP
        private XepLop_BUS _XepLop_BUS = new XepLop_BUS();// truy xuất bảng XEPLOP
        private HoSoHocSinh_BUS _HoSoHocSinh_BUS = new HoSoHocSinh_BUS();// truy xuất bảng HOSOHOCSINH
        private Diem_BUS _Diem_BUS = new Diem_BUS();//truy xuất đến bảng DIEM
        private Khoi_BUS _Khoi_BUS = new Khoi_BUS();// truy xuất bảng KHOI
        private QLHSDataContext DB = new QLHSDataContext();

        //List<usp_SelectHosohocsinhsNotMaHocSinhResult> _ListHS = new List<usp_SelectHosohocsinhsNotMaHocSinhResult>();
        private List<ThongTinHocSinh> _ListHocSinh = new List<ThongTinHocSinh>();
        private List<int> _ListIndexKhoi = new List<int>();

        Bitmap bitmap;

        public FormDanhSachHocSinh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// load năm học từ database vào comboboxNam
        /// </summary>
        private void LoadDanhSachNam()
        {
            foreach (NAMHOC NH in _NamHoc_BUS.LayNamHoc())
            {
                comboboxNam.Items.Add(NH.NAMHOC1.ToString());
            }
        }

        /// <summary>
        /// lấy dữ liệu khối lớp từ database thêm vào comboboxKhoi
        /// </summary>
        private void LoadDanhSachKhoi()
        {
            int i = 0;
            foreach (usp_SelectKhoisAllResult khoi in _Khoi_BUS.LayDanhSachKhoi())
            {
                comboboxKhoi.Items.Add(khoi.KHOI.ToString());
                _ListIndexKhoi.Add(i);
                i++;
            }
        }

        /// <summary>
        /// Sự kiện: xảy ra khi form DanhSachHocSinh được load lên
        /// load danh sách năm học lên comboboxNam, nếu không tồn tại năm học nào thì đóng form lại
        /// </summary>
        private void FormDanhSachHocSinh_Load(object sender, EventArgs e)
        {
            LoadDanhSachNam();
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
        private void ComboboxNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachKhoi();
            comboboxKhoi.SelectedIndex = 0;
        }

        /// <summary>
        /// Trả về mã khối trong danh sách khối lấy từ database
        /// </summary>
        String LayMaKhoiTheoIndex()
        {
            int i = 0;
            foreach (usp_SelectKhoisAllResult khoi in _Khoi_BUS.LayDanhSachKhoi()) // duyệt khối trong danh sách khối
            {
                if (i == _ListIndexKhoi[comboboxKhoi.SelectedIndex]) return khoi.MAKHOI;

                i++;
            }
            return null;
        }

        /// <summary>
        /// Load danh sách học sinh theo khối và năm học tương ứng lên datagriview
        /// </summary>
        private void LoadDanhSachHocSinh()
        {
            _ListHocSinh.Clear();
            _ListHocSinh = _Diem_BUS.LayBangDiemHocSinhTheoNamHoc(LayMaKhoiTheoIndex(), comboboxNam.Text);
            dataGridView.DataSource = _ListHocSinh.ToArray();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        /// <summary>
        /// Sự kiện: xảy ra khi comboboxKhoi được chọn
        /// sẽ load danh sách học sinh tương ứng với khối lên datagridview
        /// </summary>
        private void ComboboxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachHocSinh();
        }

        /// <summary>
        /// Sự kiện: xảy ra khi buttonThoat được click
        /// đóng form đang thao tác
        /// </summary>
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }


        private void PrintDanhSachHocSinh_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridview();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("DANH SÁCH HỌC SINH " + comboboxKhoi.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 180, 50);
            e.Graphics.DrawString(" NĂM HỌC " + comboboxNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 250, 100);

            e.Graphics.DrawImage(bitmap, new Point(130, 170));
        }

        private void PrintDataGridview()
        {
            bitmap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitmap, this.dataGridView.ClientRectangle);
        }

        /// <summary>
        /// Sự kiện: xảy ra khi buttonIn được click
        /// In danh sách học sinh hiện có trên datagridview lên một của sổ mới
        /// </summary>
        private void ButtonIn_Click(object sender, EventArgs e)
        {
            printPreviewDanhSachHocSinh.Document = printDanhSachHocSinh;

            ((Form)printPreviewDanhSachHocSinh).WindowState = FormWindowState.Maximized;
            printPreviewDanhSachHocSinh.PrintPreviewControl.AutoZoom = false;
            printPreviewDanhSachHocSinh.PrintPreviewControl.Zoom = 1.0;

            printPreviewDanhSachHocSinh.ShowDialog();
        }
    }
}