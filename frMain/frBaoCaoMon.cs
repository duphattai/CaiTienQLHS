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
    public partial class frBaoCaoMon : DevExpress.XtraEditors.XtraForm
    {

        NamHoc_BUS _NHBUS = new NamHoc_BUS();
        Khoi_BUS _KBUS = new Khoi_BUS();
        HocKy_BUS _HKBUS = new HocKy_BUS();
        MonHoc_BUS _MHBUS = new MonHoc_BUS();
        Diem_BUS _DBUS = new Diem_BUS();
        XepLop_BUS _XepBus = new XepLop_BUS();
        BaoCaoMonHoc_BUS _BaoCaoBUS = new BaoCaoMonHoc_BUS();
        HoSoHocSinh_Bus _HSBUS = new HoSoHocSinh_Bus();

        List<BaoCaoMonHoc> _ListBaoCaoMon = new List<BaoCaoMonHoc>();

        Bitmap bitmap;
        public frBaoCaoMon()
        {
            InitializeComponent();
        }

        private void frBaoCaoMon_Load(object sender, EventArgs e)
        {
            comboHocKy.Items.Clear();
            comboMon.Items.Clear();
            comboNam.Items.Clear();

            LoadDanhSachHocKy();
            LoadDanhSachMonHoc();
            LoadDanhSachNam();
            if (comboNam.Items.Count > 0)
            {
                comboNam.SelectedIndex = 0;
                if (comboHocKy.Items.Count > 0)
                    comboHocKy.SelectedIndex = 0;
                if (comboMon.Items.Count > 0)
                    comboMon.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Bạn không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        void LoadDanhSachMonHoc()
        {
            foreach (MONHOC mh in _MHBUS.LayDanhSachMonHoc())
            {
                comboMon.Items.Add(mh.TENMONHOC);
            }
            //comboMon.SelectedIndex = 0;
        }

        void LoadDanhSachHocKy()
        {
            foreach (HOCKY hk in _HKBUS.LayDanhSachHocKy())
            {
                comboHocKy.Items.Add(hk.TENHOCKY);
            }
            //comboHocKy.SelectedIndex = 0;

        }

        void LoadDanhSachNam()
        {
            foreach (NAMHOC nam in _NHBUS.LayNamHoc())
            {
                comboNam.Items.Add(nam.NAMHOC1);
            }
            //comboNam.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (MONHOC mh in _MHBUS.LayDanhSachMonHoc())
            {
                if (index == comboMon.SelectedIndex)
                {
                    comboMon.Tag = mh.MAMONHOC;
                    break;
                }
                index++;
            }
            LoadDatagridview();
        }

        private void comboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
           
            foreach (HOCKY hk in _HKBUS.LayDanhSachHocKy())
            {

                if (index == comboHocKy.SelectedIndex)
                {
                    comboHocKy.Tag = hk.MAHOCKY;
                    break;
                }
                index++;
            }
            LoadDatagridview();
        }

        private void comboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (NAMHOC nam in _NHBUS.LayNamHoc())
            {
                if (index == comboNam.SelectedIndex)
                {
                    comboNam.Tag = nam.NAMHOC1;
                    break;
                }
                index++;
            }
            LoadDatagridview();
        }

        void LoadDatagridview()
        {
            if (comboHocKy.SelectedIndex != -1 && comboNam.SelectedIndex != -1 && comboMon.SelectedIndex != -1)
            {
                _ListBaoCaoMon.Clear();

                 _ListBaoCaoMon = _BaoCaoBUS.LayDuLieu(comboMon.Tag.ToString(), int.Parse(comboHocKy.Tag.ToString()), comboNam.Text);

                dataGridView.DataSource = _ListBaoCaoMon.ToArray();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells["STT"].Value = i + 1;
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void printBaoCaoMon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridview();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("BÁO CÁO TỔNG KẾT MÔN " + comboMon.Text.ToString().ToUpper() +" "+ comboHocKy.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 140, 50);

            e.Graphics.DrawString("NĂM HỌC " + comboNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 250, 100);

            //e.Graphics.DrawString("Môn : " + comboMon.Text.ToString() + "Năm :" + comboNam.Text.ToString() + "Học Kỳ :" + comboHocKy.Text.ToString(), font, System.Drawing.Brushes.Black,0,0);
            e.Graphics.DrawImage(bitmap, new Point(0, 170));
        }
        void PrintDataGridview()
        {

            bitmap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitmap, dataGridView.ClientRectangle);

        }

        private void BtIn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                printPreviewBaoCaoMon.Document = printBaoCaoMon;

                ((Form)printPreviewBaoCaoMon).WindowState = FormWindowState.Maximized;
                printPreviewBaoCaoMon.PrintPreviewControl.AutoZoom = false;
                printPreviewBaoCaoMon.PrintPreviewControl.Zoom = 1.0;

                printPreviewBaoCaoMon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có dữ liệu nào trong danh sách", "Error");
            }
        }

        
    }
}