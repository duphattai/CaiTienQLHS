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
    public partial class frBaoCaoTKHK : DevExpress.XtraEditors.XtraForm
    {
        NamHoc_BUS _NHBUS = new NamHoc_BUS();
        Khoi_BUS _KBUS = new Khoi_BUS();
        DanhSachLop_BUS _LopBus = new DanhSachLop_BUS();
        XepLop_BUS _XepBus = new XepLop_BUS();
        HoSoHocSinh_Bus _HSBUS = new HoSoHocSinh_Bus();
        HocKy_BUS _HKBUS = new HocKy_BUS();
        BaoCaoTKHK_BUS _TKHKBUS = new BaoCaoTKHK_BUS();

        List<BaoCaoTKHK> _ListBaoCaoTKHK = new List<BaoCaoTKHK>();

        Bitmap bitmap;
        public frBaoCaoTKHK()
        {
            InitializeComponent();

        }

        void LoadDanhSachNam()
        {
            comboNam.Items.Clear();
            foreach (NAMHOC NH in _NHBUS.LayNamHoc())
            {
                comboNam.Items.Add(NH.NAMHOC1.ToString());
            }
        }
        void LoadDanhSachHocKy()
        {
            comboHocKy.Items.Clear();
            foreach (HOCKY hk in _HKBUS.LayDanhSachHocKy())
            {
                comboHocKy.Items.Add(hk.TENHOCKY);
            }
        }

        private void frBaoCaoTKHK_Load(object sender, EventArgs e)
        {
            LoadDanhSachNam();
            LoadDanhSachHocKy();
            if (comboNam.Items.Count > 0)
            {
                comboNam.SelectedIndex = 0;
                if (comboHocKy.Items.Count > 0)
                    comboHocKy.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Bạn không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        void LoadDatagridview()
        {
            _ListBaoCaoTKHK.Clear();
            if(comboHocKy.SelectedIndex != -1 && comboNam.SelectedIndex != -1)
                _ListBaoCaoTKHK = _TKHKBUS.LayDuLieu(int.Parse(comboHocKy.Tag.ToString()), comboNam.Text);

            dataGridView.DataSource = _ListBaoCaoTKHK.ToArray();

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

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["STT"].Value = i + 1;
            }

        }
        #region Thoát
        private void btThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }
        #endregion

     
        void PrintDataGridview()
        {
            bitmap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitmap, this.dataGridView.ClientRectangle);
        }

     
        private void BtIn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                printPreviewBaoCaoHocKy.Document = printBaoCaoHocKy;

                ((Form)printPreviewBaoCaoHocKy).WindowState = FormWindowState.Maximized;
                printPreviewBaoCaoHocKy.PrintPreviewControl.AutoZoom = false;
                printPreviewBaoCaoHocKy.PrintPreviewControl.Zoom = 1.0;

                printPreviewBaoCaoHocKy.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có dữ liệu nào trong danh sách","Error");
            }
        }

        private void printBaoCaoHocKy_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridview();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("BÁO CÁO TỔNG KẾT " + comboHocKy.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 200, 50);

            e.Graphics.DrawString(" NĂM HỌC " + comboNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 270, 100);

            //e.Graphics.DrawString("Môn : " + comboMon.Text.ToString() + "Năm :" + comboNam.Text.ToString() + "Học Kỳ :" + comboHocKy.Text.ToString(), font, System.Drawing.Brushes.Black,0,0);
            e.Graphics.DrawImage(bitmap, new Point(50, 170));
        }
    }
}