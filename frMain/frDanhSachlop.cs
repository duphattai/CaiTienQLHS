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
    public partial class frDanhSachLop : DevExpress.XtraEditors.XtraForm
    {
        NamHoc_BUS _NHBus = new NamHoc_BUS();
        Khoi_BUS _KBUS = new Khoi_BUS();
        DanhSachLop_BUS _LopBus = new DanhSachLop_BUS();
        XepLop_BUS _XepBus = new XepLop_BUS();
        HoSoHocSinh_Bus _HSBUS = new HoSoHocSinh_Bus();

        List<usp_SelectHosohocsinhResult> _ListHS= new List<usp_SelectHosohocsinhResult>();

        Bitmap bitmap;
        public frDanhSachLop()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboNam_DropDown(object sender, EventArgs e)
        {
            //comboNam.Items.Clear();
            //LoadDanhSachNam();
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

            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                comboKhoi.Items.Add(khoi.KHOI.ToString());
               
            }
        }
        void LoadDanhSachLop()
        {
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoi.Tag.ToString(), comboNam.Tag.ToString()))
            {
                comboLop.Items.Add(lop.TENLOP.ToString());
            }

            //comboLop.SelectedIndex = 0;
        }
        void LoadDanhSachHocSinh()
        {
            if (comboKhoi.SelectedIndex != -1 && comboNam.SelectedIndex != -1 && comboLop.SelectedIndex != -1)
            {
                _ListHS.Clear();
                foreach (usp_SelectLopResult malop in _LopBus.LayDanhSachLop(int.Parse(comboLop.Tag.ToString())))
                {
                    {
                        foreach (usp_SelectXeplopsByMALOPResult maxeplop in _XepBus.TruyVanTheoMaLop(malop.MALOP))
                        {
                            foreach (usp_SelectHosohocsinhResult mahs in _HSBUS.TruyVanHocSinhTheoMaHocSinh(maxeplop.MAHOCSINH))
                            {
                                _ListHS.Add(mahs);
                            }
                        }
                    }
                }
                dataGridView.DataSource = _ListHS.ToArray();
                dataGridView.Columns["MAHOCSINH"].Visible = false;

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells["STT"].Value = i + 1;
                }
                labelSiSo.Text = dataGridView.Rows.Count.ToString();
            }
            else
            {
                dataGridView.DataSource = new List<usp_SelectHosohocsinhResult>().ToArray();
                labelSiSo.Text = null;
            }
        }
        private void frDanhSachLop_Load(object sender, EventArgs e)
        {

            comboNam.Items.Clear();
            
            LoadDanhSachNam();
            if (comboNam.Items.Count > 0)
                comboNam.SelectedIndex = 0;
            else
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        private void comboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            comboKhoi.Items.Clear();
            LoadDanhSachKhoi();

            foreach (NAMHOC nam in _NHBus.LayNamHoc())
            {
                if (index == comboNam.SelectedIndex)
                {
                    comboNam.Tag = nam.NAMHOC1;
                    break;
                }
                index++;
            }
            if (comboKhoi.Items.Count > 0)
                comboKhoi.SelectedIndex = 0;
            LoadDanhSachHocSinh();
        }

        private void comboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoi.Tag.ToString(), comboNam.Text))
            {
                if (index == comboLop.SelectedIndex)
                {
                    comboLop.Tag = lop.MALOP;
                    break;
                }

                index++;
            }
            LoadDanhSachHocSinh();
        }

        private void comboKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            comboLop.Items.Clear();

            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                if (index == comboKhoi.SelectedIndex)
                {
                    comboKhoi.Tag = khoi.MAKHOI;

                }
                index++;
            }

            LoadDanhSachLop();
            if(comboLop.Items.Count > 0)
                comboLop.SelectedIndex = 0;
            LoadDanhSachHocSinh();
            
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void printDanhSachLop_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridview();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("DANH SÁCH LỚP " + comboLop.Text.ToString().ToUpper()+ " NĂM HỌC " + comboNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 100, 50);
            e.Graphics.DrawImage(bitmap, new Point(50, 170));
        }

        void PrintDataGridview()
        {
            bitmap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitmap, this.dataGridView.ClientRectangle);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                printPreviewDanhSachLop.Document = printDanhSachLop;

                ((Form)printPreviewDanhSachLop).WindowState = FormWindowState.Maximized;
                printPreviewDanhSachLop.PrintPreviewControl.AutoZoom = false;
                printPreviewDanhSachLop.PrintPreviewControl.Zoom = 1.0;

                printPreviewDanhSachLop.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có dữ liệu nào trong danh sách", "Error");
            }
        }
    }
}