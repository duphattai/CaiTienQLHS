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
    public partial class formTraCuuThoiKhoaBieu : DevExpress.XtraEditors.XtraForm
    {
        private NamHoc_BUS _namHocBus = new NamHoc_BUS();
        private ThoiKhoaBieu_BUS _thoiKhoaBieuBus = new ThoiKhoaBieu_BUS();
        private GiaoVien_BUS _giaoVienBus = new GiaoVien_BUS();
        private DanhSachLop_BUS _danhSachLopBus = new DanhSachLop_BUS();

        private List<usp_SelectLopByNamHocResult> danhSachLop; // chưa danh sách lớp lấy từ CSDL theo năm học
        private List<GIAOVIEN> danhSachGiaoVien; // danh sách giáo viên toàn trường
        private List<NAMHOC> danhSachNamHoc; // danh sách năm học


        private String fileName;
        public formTraCuuThoiKhoaBieu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện: trước khi form được hiển thị
        /// load các thông tin cần thiết cho form
        /// </summary>
        private void formTraCuuThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            danhSachNamHoc = _namHocBus.LayNamHoc(); // lấy danh sách năm học
            
            // thêm năm học vào combobox các page
            for(int i = 0; i < danhSachNamHoc.Count; i++)
            {
                comboBoxNamHocTabLop.Items.Add(danhSachNamHoc[i].NAMHOC1);
                comboBoxNamHocTabGiaoVien.Items.Add(danhSachNamHoc[i].NAMHOC1);
            }
            comboBoxNamHocTabLop.SelectedIndex = 0;
            comboBoxNamHocTabGiaoVien.SelectedIndex = 0;

            // lấy danh sách giáo viên của trường
            danhSachGiaoVien = _giaoVienBus.LayTatCaDanhSachGiaoVien();
            // thêm vào combobox
            for(int i = 0; i < danhSachGiaoVien.Count; i++)
            {
                comboBoxTenGiaoVien.Items.Add(danhSachGiaoVien[i].HoTen);
            }
            comboBoxTenGiaoVien.SelectedIndex = 0;
        }

        /// <summary>
        /// Sự kiện: khi comboBoxNamHocTabLop được thay đổi giá trị
        /// ứng với từng năm học được chọn, hiển thị lai danh sách lớp tương ứng
        /// </summary>
        private void comboBoxNamHocTabLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            danhSachLop = _danhSachLopBus.LayDanhSachLopNamHoc(comboBoxNamHocTabLop.SelectedItem.ToString()); // lấy danh sách lớp theo năm học
            comboBoxLop.Items.Clear();

            for(int i = 0; i < danhSachLop.Count; i++)
            {
                comboBoxLop.Items.Add(danhSachLop[i].TENLOP);
            }
            comboBoxLop.SelectedIndex = 0;
        }

        /// <summary>
        /// Sự kiện: khi buttonTim được click
        /// Tìm thời khóa biểu cho lớp hoặc giáo viên đã chọn
        /// </summary>
        private void buttonTim_Click(object sender, EventArgs e)
        {
            if(xtraTabControl1.SelectedTabPageIndex == 0) // nếu tab lớp được chọn
            {
                if(comboBoxNamHocTabLop.SelectedIndex >= 0 && comboBoxLop.SelectedIndex >= 0)
                {
                    int maLop = danhSachLop[comboBoxLop.SelectedIndex].MALOP;
                    List<usp_SelectThoiKhoaBieuBy_MaLopResult> thoiKhoaBieu = null;
                    try
                    {
                        thoiKhoaBieu = _thoiKhoaBieuBus.LayThoiKhoaBieu(maLop); // lấy thời khóa biểu từ CSDL
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không tìm thấy!", "Thông báo");
                        return;
                    }
                    dataGridViewThoiKhoaBieu.Rows.Clear();
                    dataGridViewThoiKhoaBieu.RowCount = 10;
                    dataGridViewThoiKhoaBieu.Rows[0].Cells["BuoiHoc"].Value = "Sáng";
                    dataGridViewThoiKhoaBieu.Rows[5].Cells["BuoiHoc"].Value = "Chiều";

                    for(int i = 0; i < thoiKhoaBieu.Count; i++)
                    {
                        dataGridViewThoiKhoaBieu.Rows[thoiKhoaBieu[i].TIET % 10].Cells[thoiKhoaBieu[i].TIET / 10 + 2].Value = thoiKhoaBieu[i].TENMONHOC;

                        dataGridViewThoiKhoaBieu.Rows[thoiKhoaBieu[i].TIET % 10].Cells["Tiet"].Value = Convert.ToInt32(thoiKhoaBieu[i].TIET % 10 + 1);
                    }

                    buttonExcel.Visible = true;
                    fileName = "Thời khóa biểu năm học " + comboBoxNamHocTabLop.SelectedItem + " lớp " + comboBoxLop.SelectedItem; 
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1) // nếu tab giáo viên được chọn
            {
                String maGiaoVien = danhSachGiaoVien[comboBoxTenGiaoVien.SelectedIndex].MaGiaoVien;
                List<usp_SelectThoiKhoaBieuBy_MaGiaoVienResult> thoiKhoaBieu = null;
                try
                {
                    thoiKhoaBieu = _thoiKhoaBieuBus.LayThoiKhoaBieu(maGiaoVien);
                }catch(Exception ex)
                {
                    MessageBox.Show("Không tìm thấy!", "Thông báo");
                    return;
                }
                
                dataGridViewThoiKhoaBieu.Rows.Clear();
                dataGridViewThoiKhoaBieu.RowCount = 10;
                dataGridViewThoiKhoaBieu.Rows[0].Cells["BuoiHoc"].Value = "Sáng";
                dataGridViewThoiKhoaBieu.Rows[5].Cells["BuoiHoc"].Value = "Chiều";

                for (int i = 0; i < thoiKhoaBieu.Count; i++)
                {
                    dataGridViewThoiKhoaBieu.Rows[thoiKhoaBieu[i].TIET % 10].Cells[thoiKhoaBieu[i].TIET / 10 + 2].Value = thoiKhoaBieu[i].TENLOP + "  "+thoiKhoaBieu[i].TENMONHOC;

                    dataGridViewThoiKhoaBieu.Rows[thoiKhoaBieu[i].TIET % 10].Cells["Tiet"].Value = Convert.ToInt32(thoiKhoaBieu[i].TIET % 10 + 1);
                }

                buttonExcel.Visible = true;
                fileName = "Thời khóa biểu năm học " + comboBoxNamHocTabGiaoVien.SelectedItem + " giáo viên " + comboBoxTenGiaoVien.SelectedItem; 
            }
        }


        /// <summary>
        /// Sự kiện: khi buttonThoat được click
        /// đóng form đang thao tác
        /// </summary>
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            xuatFileExcel();
        }

        private void xuatFileExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "xls files (*.xls)|*.xls";
            saveFile.FileName = fileName;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter wr = new StreamWriter(saveFile.FileName, false, Encoding.Unicode);
                try
                {
                    for (int i = 0; i < dataGridViewThoiKhoaBieu.ColumnCount; i++)
                    {
                        if (dataGridViewThoiKhoaBieu.Columns[i].Name != null)
                            wr.Write(dataGridViewThoiKhoaBieu.Columns[i].Name + "\t");
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
    }
}