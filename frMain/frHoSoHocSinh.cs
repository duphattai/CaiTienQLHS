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
using DataAccessObject.DAO;
using BUS;
using Excel;
using System.IO;

namespace frMain
{
    public partial class frHoSoHocSinh : DevExpress.XtraEditors.XtraForm
    {
        private HoSoHocSinh_BUS hoSoHocSinhBus = new HoSoHocSinh_BUS();
        private DataTable table = new DataTable();
        private List<HOSOHOCSINH> listHoSoHocSinh;
        private List<HOSOHOCSINH> ListHoSoHocSinhADD = new List<HOSOHOCSINH>();
        private List<HOSOHOCSINH> ListHoSoHocSinhDelete = new List<HOSOHOCSINH>();
        private List<HOSOHOCSINH> ListHoSoHocSinhUpdate = new List<HOSOHOCSINH>();
        private List<string> listtemp;
        int NewHSCounter = 0;
        bool _IsSelectedBefore = false;
        int _SelectedMaHocSinh;

        public frHoSoHocSinh()
        {
            InitializeComponent();
        }

        public frHoSoHocSinh(int MaHocSinh)
        {
            InitializeComponent();
            _IsSelectedBefore = true;
            _SelectedMaHocSinh = MaHocSinh;
        }
   
        #region Thêm

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrEmpty(TxtHoTen.Text) || string.IsNullOrEmpty(TxtDiachi.Text))
            {
                return false;
            }
            return true;
        }
        //Add
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                NewHSCounter++;
                HOSOHOCSINH newHS = new HOSOHOCSINH();

                newHS.HOTEN = TxtHoTen.Text;
                newHS.MAHOCSINH = hoSoHocSinhBus.LayMaHocSinhCuoi() + NewHSCounter;
                newHS.GIOITINH = CmBoxGioitinh.Text;
                newHS.EMAIL = TxtEmail.Text;
                newHS.DIACHI = TxtDiachi.Text;
                newHS.NGAYSINH = dateTime.Value;

                //Add List HocSinh Insert To Save DB
            
                ListHoSoHocSinhADD.Add(newHS);

                listHoSoHocSinh.Add(newHS);
                LoadDataGridView();
                dataGridView.CurrentCell = dataGridView.Rows[dataGridView.RowCount - 1].Cells[0];
                TxtHoTen.Clear();
                TxtEmail.Clear();
                TxtDiachi.Clear();
            }
            else
            {
                MessageBox.Show("Bạn không thể nhập dữ liệu trống", "Error");
            }
        }
        #endregion

        private void frHoSoHocSinh_Load(object sender, EventArgs e)
        {
            listHoSoHocSinh = hoSoHocSinhBus.LayTatCaHocSinh();
            LoadDataGridView();
            if (_IsSelectedBefore)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells["MaHocSinh"].Value.ToString() == _SelectedMaHocSinh.ToString())
                        dataGridView.CurrentCell = row.Cells[0];
                }
            }
        }

        private void LoadData() //Load data từ datagirdview lên textbox tương ứng
        {
            try
            {
               
               TxtHoTen.Text = Convert.ToString(dataGridView.CurrentRow.Cells["HoTen"].Value.ToString().Trim());
               CmBoxGioitinh.Text = Convert.ToString(dataGridView.CurrentRow.Cells["GioiTinh"].Value.ToString().Trim());
               TxtDiachi.Text = Convert.ToString(dataGridView.CurrentRow.Cells["DiaChi"].Value.ToString().Trim());
               dateTime.Text= dataGridView.CurrentRow.Cells["NgaySinh"].Value.ToString();
             
            }
            catch { }

        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadDataGridView()
        {
            dataGridView.DataSource = listHoSoHocSinh.ToArray();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        //Update
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                int CurrentIndex = dataGridView.CurrentRow.Index;
                String id = dataGridView.CurrentRow.Cells["MaHocSinh"].Value.ToString();

                foreach (HOSOHOCSINH h in listHoSoHocSinh)
                {
                    if (h.MAHOCSINH.ToString() == id)
                    {
                        //Add List HocSinh Update To Save DB


                        h.HOTEN = TxtHoTen.Text;
                        h.GIOITINH = CmBoxGioitinh.Text;
                        h.NGAYSINH = dateTime.Value;
                        h.EMAIL = TxtEmail.Text;
                        h.DIACHI = TxtDiachi.Text;

                        ListHoSoHocSinhUpdate.Add(h);

                        break;
                    }
                }
                LoadDataGridView();
                dataGridView.CurrentCell = dataGridView.Rows[CurrentIndex].Cells[0];
            }
            else
            {
                MessageBox.Show("Bạn không thể nhập dữ liệu trống", "Error");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string id;
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                id = row.Cells["MaHocSinh"].Value.ToString();

                foreach (HOSOHOCSINH h in listHoSoHocSinh)
                {
                    if (h.MAHOCSINH.ToString() == id)
                    {
                        ListHoSoHocSinhDelete.Add(h);

                        listHoSoHocSinh.Remove(h);
                        break;
                    }
                }
            }
            LoadDataGridView();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ListHoSoHocSinhADD.Count == 0 && ListHoSoHocSinhDelete.Count == 0 && ListHoSoHocSinhUpdate.Count == 0)
            {
                if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Dữ liệu có thay đổi, bạn có muốn lưu lại ko?", "THOÁT ỨNG DỤNG", MessageBoxButtons.YesNoCancel);
                if (dr != DialogResult.Cancel)
                {
                    if (DialogResult.Yes == dr)
                    {
                        simpleButton5_Click(sender, e);
                    }
                    this.Close();
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //Delete
            foreach (HOSOHOCSINH newHs in ListHoSoHocSinhDelete)
            {
                hoSoHocSinhBus.Delete(newHs.MAHOCSINH);
            }
            //ADD
            foreach(HOSOHOCSINH newHs in ListHoSoHocSinhADD)
            {
                hoSoHocSinhBus.Them(newHs.HOTEN, newHs.DIACHI, newHs.NGAYSINH, newHs.EMAIL, newHs.GIOITINH);
            }
            //Update
            foreach (HOSOHOCSINH newHs in ListHoSoHocSinhUpdate)
            {
                hoSoHocSinhBus.Update(newHs.MAHOCSINH, newHs.HOTEN, newHs.DIACHI, newHs.NGAYSINH, newHs.EMAIL, newHs.GIOITINH);
            }

            ListHoSoHocSinhDelete.Clear();
            ListHoSoHocSinhADD.Clear();
            ListHoSoHocSinhUpdate.Clear();

            MessageBox.Show("Lưu thành công", "Success");
            listHoSoHocSinh = hoSoHocSinhBus.LayTatCaHocSinh();
            LoadDataGridView();
        }
        #region Đọc tập tin Excel
        private void btTapTin_Click(object sender, EventArgs e)
        {
            DocTapTin();  
        }

        private void DocTapTin()
        {
            try
            {
                OpenFileDialog iopen = new OpenFileDialog();
                iopen.Filter = "Excel Files|*.xls;*.xlsx";
                iopen.Title = "Chọn tập tin excel";
                iopen.InitialDirectory = @"C:\\";

                if (iopen.ShowDialog() == DialogResult.OK)
                {
                    string ipath = iopen.FileName;
                    lbpath.Text = ipath;
                    DocFileExcel(ipath);
                    if (DialogResult.OK == MessageBox.Show("Bạn có muốn tiếp tục thêm dữ liệu từ tập tin Excel?", "Tiếp tục", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        DuaduLieuData(listtemp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DocFileExcel(string ipath)
        {
            IExcelDataReader FileExcel;
            FileStream stream = File.Open(ipath, FileMode.Open, FileAccess.Read);   //Đọc file vào
            try
            {
                //1. Câu lệnh sau dùng cho Excel 2007 trở lên
                FileExcel = ExcelReaderFactory.CreateOpenXmlReader(stream);      //1.
            }
            catch
            {
                //2. Nếu bạn dùng Excel 2003 trở xuống vui lòng dùng câu lệnh 2. thay cho 1.
                FileExcel = ExcelReaderFactory.CreateBinaryReader(stream);    //2.
            }

            DataSet result = FileExcel.AsDataSet();
            FileExcel.IsFirstRowAsColumnNames = true;
            listtemp = new List<string>();
            foreach (System.Data.DataTable table in result.Tables)
            {
                for (int i = 2; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        listtemp.Add(table.Rows[i].ItemArray[j].ToString());
                    }
                }
            }
            FileExcel.Close();
        }

        private void DuaduLieuData(List<string> ilist)
        {
            for (int i = 0; i < ilist.Count; i = i + 5)
            {
                NewHSCounter++;
                HOSOHOCSINH newHS = new HOSOHOCSINH();

                newHS.HOTEN = ilist[i];
                newHS.MAHOCSINH = hoSoHocSinhBus.LayMaHocSinhCuoi() + NewHSCounter;
                newHS.GIOITINH = ilist[i+3];
                newHS.EMAIL = ilist[i+2];
                newHS.DIACHI = ilist[i+4];
                newHS.NGAYSINH = DateTime.Parse(ilist[i+1]);
                ListHoSoHocSinhADD.Add(newHS);
                listHoSoHocSinh.Add(newHS);
            }
            LoadDataGridView();
        }
        #endregion
    }
}