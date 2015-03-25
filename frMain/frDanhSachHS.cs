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
    public partial class frDanhSachHS : DevExpress.XtraEditors.XtraForm
    {
        NamHoc_BUS _NHBus = new NamHoc_BUS();
        DanhSachLop_BUS _LopBus = new DanhSachLop_BUS();
        XepLop_BUS _XepBus = new XepLop_BUS();
        HoSoHocSinh_Bus _HSBUS = new HoSoHocSinh_Bus();
        Diem_BUS _DBUS = new Diem_BUS();
        Khoi_BUS _KBUS = new Khoi_BUS();
        QLHSDataContext DB = new QLHSDataContext();

        //List<usp_SelectHosohocsinhsNotMaHocSinhResult> _ListHS = new List<usp_SelectHosohocsinhsNotMaHocSinhResult>();
        List<DanhSachHS_BUS> _ListHS = new List<DanhSachHS_BUS>();
        List<int> _ListIndexKhoi = new List<int>();

        Bitmap bitmap;

        public frDanhSachHS()
        {
            InitializeComponent();
        }

        void LoadDanhSachNam()
        {
            foreach (NAMHOC NH in _NHBus.LayNamHoc())
            {
                comboNam.Items.Add(NH.NAMHOC1.ToString());
            }
        }
        void LoadDanhSachKhoi()
        {

            int i = 0;
            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                comboKhoi.Items.Add(khoi.KHOI.ToString());
                _ListIndexKhoi.Add(i);
                i++;

            }
        }
        private void frDanhSachHS_Load(object sender, EventArgs e)
        {
            LoadDanhSachNam();
            if (comboNam.Items.Count > 0)
            {
                comboNam.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }

        }

        private void comboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachKhoi();
            comboKhoi.SelectedIndex = 0;
        }

        String LayMaKhoiTheoIndex()
        {
            int i = 0;
            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                if (i == _ListIndexKhoi[comboKhoi.SelectedIndex]) return khoi.MAKHOI;

                i++;

            }
            return null;
        }
        void LoadDanhSachHocSinh()
        {
            _ListHS.Clear();
            _ListHS = _DBUS.LayBangDiemHocSinhTheoNamHoc(LayMaKhoiTheoIndex(), comboNam.Text);

            dataGridView.DataSource = _ListHS.ToArray();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["STT"].Value = i + 1;
            }

        }

        private void comboKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachHocSinh();


        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void printDanhSachHocSinh_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridview();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("DANH SÁCH HỌC SINH " + comboKhoi.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 180, 50);
            e.Graphics.DrawString(" NĂM HỌC " + comboNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 250, 100);

            e.Graphics.DrawImage(bitmap, new Point(130, 170));
        }
        void PrintDataGridview()
        {
            bitmap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitmap, this.dataGridView.ClientRectangle);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            printPreviewDanhSachHocSinh.Document = printDanhSachHocSinh;

            ((Form)printPreviewDanhSachHocSinh).WindowState = FormWindowState.Maximized;
            printPreviewDanhSachHocSinh.PrintPreviewControl.AutoZoom = false;
            printPreviewDanhSachHocSinh.PrintPreviewControl.Zoom = 1.0;

            printPreviewDanhSachHocSinh.ShowDialog();
        }
    }
}