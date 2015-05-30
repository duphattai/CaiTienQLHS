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
    public partial class formDanhSachLop : DevExpress.XtraEditors.XtraForm
    {
        private NamHoc_BUS _namHocBus = new NamHoc_BUS();
        private Khoi_BUS _khoiBus = new Khoi_BUS();
        private DanhSachLop_BUS _danhSachLopBus = new DanhSachLop_BUS();
        private XepLop_BUS _xepLopBus = new XepLop_BUS();
        private HoSoHocSinh_BUS _hoSoHocSinhBus = new HoSoHocSinh_BUS();

        private List<usp_SelectHosohocsinhResult> _listHoSoHocSinh = new List<usp_SelectHosohocsinhResult>();

        private Bitmap bitmap;
        public formDanhSachLop()
        {
            InitializeComponent();
        }

        private void loadDanhSachNam()
        {
            foreach (NAMHOC NH in _namHocBus.LayNamHoc())
            {
                comboBoxNam.Items.Add(NH.NAMHOC1.ToString());
            }
        }
        private void loadDanhSachKhoi()
        {
            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                comboBoxKhoi.Items.Add(khoi.KHOI.ToString()); 
            }
        }
        private void loadDanhSachLop()
        {
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comboBoxKhoi.Tag.ToString(), comboBoxNam.Tag.ToString()))
            {
                comboBoxLop.Items.Add(lop.TENLOP.ToString());
            }
        }

        private void loadDanhSachHocSinh()
        {
            if (comboBoxKhoi.SelectedIndex != -1 && comboBoxNam.SelectedIndex != -1 && comboBoxLop.SelectedIndex != -1)
            {
                _listHoSoHocSinh.Clear();
                foreach (usp_SelectLopResult malop in _danhSachLopBus.LayDanhSachLop(int.Parse(comboBoxLop.Tag.ToString())))
                {
                    {
                        foreach (usp_SelectXeplopsByMALOPResult maxeplop in _xepLopBus.TruyVanTheoMaLop(malop.MALOP))
                        {
                            foreach (usp_SelectHosohocsinhResult mahs in _hoSoHocSinhBus.TruyVanHocSinhTheoMaHocSinh(maxeplop.MAHOCSINH))
                            {
                                _listHoSoHocSinh.Add(mahs);
                            }
                        }
                    }
                }
                dataGridView.DataSource = _listHoSoHocSinh.ToArray();
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

        private void formDanhSachLop_Load(object sender, EventArgs e)
        {

            comboBoxNam.Items.Clear();
            
            loadDanhSachNam();
            if (comboBoxNam.Items.Count > 0)
                comboBoxNam.SelectedIndex = 0;
            else
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        private void comboBoxNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            comboBoxKhoi.Items.Clear();
            loadDanhSachKhoi();

            foreach (NAMHOC nam in _namHocBus.LayNamHoc())
            {
                if (index == comboBoxNam.SelectedIndex)
                {
                    comboBoxNam.Tag = nam.NAMHOC1;
                    break;
                }
                index++;
            }
            if (comboBoxKhoi.Items.Count > 0)
                comboBoxKhoi.SelectedIndex = 0;
            loadDanhSachHocSinh();
        }

        private void comboBoxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comboBoxKhoi.Tag.ToString(), comboBoxNam.Text))
            {
                if (index == comboBoxLop.SelectedIndex)
                {
                    comboBoxLop.Tag = lop.MALOP;
                    break;
                }

                index++;
            }
            loadDanhSachHocSinh();
        }

        private void comboBoxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            comboBoxLop.Items.Clear();

            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                if (index == comboBoxKhoi.SelectedIndex)
                {
                    comboBoxKhoi.Tag = khoi.MAKHOI;

                }
                index++;
            }

            loadDanhSachLop();
            if(comboBoxLop.Items.Count > 0)
                comboBoxLop.SelectedIndex = 0;
            loadDanhSachHocSinh();
            
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void printDanhSachLop_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDataGridview();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("DANH SÁCH LỚP " + comboBoxLop.Text.ToString().ToUpper()+ " NĂM HỌC " + comboBoxNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 100, 50);
            e.Graphics.DrawImage(bitmap, new Point(50, 170));
        }

        void printDataGridview()
        {
            bitmap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitmap, this.dataGridView.ClientRectangle);
        }
        private void buttonIn_Click(object sender, EventArgs e)
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


        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            xuatFileExcel(); 
        }
    
        private void xuatFileExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "xls files (*.xls)|*.xls";
            saveFile.FileName = "Danh sách học sinh lớp " + comboBoxLop.SelectedItem;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter wr = new StreamWriter(saveFile.FileName, false, Encoding.Unicode);

                DataTable table = new DataTable();

                string header1 = "Id";
                string header2 = "Họ và tên";
                string header3 = "Điểm 15p";
                string header4 = "Điểm 1T";
                string header5 = "Điểm thi";
                table.Columns.Add(header1, typeof(string));
                table.Columns.Add(header2, typeof(string));
                table.Columns.Add(header3, typeof(string));
                table.Columns.Add(header4, typeof(string));
                table.Columns.Add(header5, typeof(string));


                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    DataRow row = table.NewRow();

                    row[header1] = dataGridView.Rows[i].Cells["MAHOCSINH"].Value.ToString();
                    row[header2] = dataGridView.Rows[i].Cells["HoTen"].Value.ToString();
                    row[header3] = "";
                    row[header4] = "";
                    row[header5] = "";

                    table.Rows.Add(row);
                }


                try
                {
                    wr.Write("Lớp: " + comboBoxLop.SelectedItem.ToString());
                    wr.WriteLine();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        wr.Write(table.Columns[i].ToString() + "\t");
                    }

                    wr.WriteLine();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            if (table.Rows[i][j] != null)
                                wr.Write(Convert.ToString(table.Rows[i][j]) + "\t");
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
    }
}