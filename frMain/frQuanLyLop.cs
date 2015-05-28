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

namespace frMain
{
    public partial class frQuanLyLop : DevExpress.XtraEditors.XtraForm
    {
      
        NamHoc_BUS _NHBUS = new NamHoc_BUS();
        Khoi_BUS _KBUS = new Khoi_BUS();
        DanhSachLop_BUS _DSLop = new DanhSachLop_BUS();
        QuiDinh_BUS _QDBUS = new QuiDinh_BUS();

        List<usp_SelectLopsByMAKHOI_NAMHOCResult> _ListLop = new List<usp_SelectLopsByMAKHOI_NAMHOCResult>();
        List<usp_SelectLopsByMAKHOI_NAMHOCResult> _ListAdd = new List<usp_SelectLopsByMAKHOI_NAMHOCResult>();
        List<LOP> _ListAll = new List<LOP>();
        List<usp_SelectLopsByMAKHOI_NAMHOCResult> _ListUpdate = new List<usp_SelectLopsByMAKHOI_NAMHOCResult>();
        List<usp_SelectLopsByMAKHOI_NAMHOCResult> _ListDelete = new List<usp_SelectLopsByMAKHOI_NAMHOCResult>();

        int _index = 0;


        public frQuanLyLop()
        {
            InitializeComponent();
        }

        void LoadDanhSachNam()
        {
            comboNam.Items.Clear();
            foreach (NAMHOC nam in _NHBUS.LayNamHoc())
            {
                comboNam.Items.Add(nam.NAMHOC1);
            }
        }

        void LoadData()
        {
           txtTenLop.Text= dataGridView.CurrentRow.Cells["TENLOP"].Value.ToString();
        }
        void LoadDanhSachKhoi()
        {
            comboKhoi.Items.Clear();
            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                comboKhoi.Items.Add(khoi.KHOI.ToString());
            }
        }
        private void frQuanLyLop_Load(object sender, EventArgs e)
        {
            LoadDanhSachNam();
            if (comboNam.Items.Count > 0)
            {
                LoadDanhSachKhoi();
            }
        }

        void LoadDataGridView()
        {
            if (comboKhoi.SelectedIndex != -1 && comboNam.SelectedIndex != -1)
            {
                _ListLop.Clear();
                foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _DSLop.LayDanhSachLopTheoKhoiMaNam(comboKhoi.Tag.ToString(), comboNam.Text.ToString()))
                {
                    _ListLop.Add(lop);
                }

                dataGridView.DataSource = _ListLop.ToArray();

            }
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                dataGridView.Columns["MALOP"].Visible = false;
                dataGridView.Columns["SISO"].Visible = false;
                dataGridView.Columns["NAMHOC"].Visible = false;
                dataGridView.Columns["MAKHOI"].Visible = false;

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells["STT"].Value = i + 1;
                }
            }
            catch { }
        }

        private void comboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (NAMHOC nam in _NHBUS.LayNamHoc())
            {
                if (index == comboNam.SelectedIndex)
                {
                    comboNam.Tag = nam.NAMHOC1;
                }
                index++;
            }
            LoadDataGridView();
        }

        private void comboKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                if (index == comboKhoi.SelectedIndex)
                {
                    comboKhoi.Tag = khoi.MAKHOI;

                }
                index++;
            }
            LoadDataGridView();

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            if(txtTenLop.Text !="")
            {
                _index++;
                usp_SelectLopsByMAKHOI_NAMHOCResult newLop = new usp_SelectLopsByMAKHOI_NAMHOCResult();

                newLop.TENLOP = txtTenLop.Text.ToString();
                newLop.NAMHOC = comboNam.Tag.ToString();
                newLop.MAKHOI = comboKhoi.Tag.ToString();
                newLop.MALOP = _DSLop.LayMaLopCuoi() + _index;

                if (dataGridView.Rows.Count >= _QDBUS.LayLopToiDaCuaKhoi(newLop.MAKHOI))
                {
                    MessageBox.Show("Không thể thể thêm lớp do sai quy định!");
                }
                else
                {
                    _ListLop.Add(newLop);
                    dataGridView.DataSource = _ListLop.ToArray();
                    _ListAdd.Add(newLop);
                }

               
            }
            else MessageBox.Show("Xảy ra lỗi !!");
           
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {

                String id = dataGridView.CurrentRow.Cells["MALOP"].Value.ToString();

                if (id == "") MessageBox.Show("Xảy ra lỗi !");
                else
                {
                    foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _ListLop)
                    {
                        if (lop.MALOP.ToString() == id)
                        {
                            //Add List HocSinh Update To Save DB
                            lop.TENLOP = txtTenLop.Text.ToString();

                            _ListUpdate.Add(lop);
                            //_ListUpdate.Add(mh);
                            break;
                        }
                    }
                    dataGridView.DataSource = _ListLop.ToArray();

                    MessageBox.Show("Sửa thành công! ");
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại! ");
            }

        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _ListUpdate)
                {
                    _DSLop.Update(lop.MALOP, lop.TENLOP, lop.NAMHOC, lop.MAKHOI);
                }
                foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _ListAdd)
                {
                    _DSLop.Insert(lop.MALOP, lop.TENLOP, lop.NAMHOC, lop.MAKHOI);
                }
                foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _ListDelete)
                {
                    _DSLop.Delete(lop.MALOP);   
                }

                _ListUpdate.Clear();
                _ListAdd.Clear();
                _ListDelete.Clear();

                MessageBox.Show("Lưu thành công !");
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi Lưu!");
            }
            
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            String id = dataGridView.CurrentRow.Cells["MALOP"].Value.ToString();

            if(id!=null)
            {
                if (_DSLop.LayDanhSachLop(int.Parse(id)).First().SISO > 0)
                {
                    MessageBox.Show("Không thể xóa lớp do có học sinh.");
                }
                else
                {
                    foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _ListLop)
                    {
                        if (lop.MALOP == int.Parse(id))
                        {
                            _ListLop.Remove(lop);
                            MessageBox.Show("Xóa thành công.");
                            _ListDelete.Add(lop);
                            break;
                        }
                    }

                    dataGridView.DataSource = _ListLop.ToArray();
                }
            }
            
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }
    }
}