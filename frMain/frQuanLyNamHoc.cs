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
    public partial class frQuanLyNamHoc : DevExpress.XtraEditors.XtraForm
    {
        public frQuanLyNamHoc()
        {
            InitializeComponent();
        }

        #region Khai báo biến toàn tục
        NamHoc_BUS _NamHocBUS = new NamHoc_BUS();
        DanhSachLop_BUS _LopBUS = new DanhSachLop_BUS();

        List<NAMHOC> _ListNamHoc = new List<NAMHOC>();
        List<NAMHOC> _ListAdd = new List<NAMHOC>();
        List<NAMHOC> _ListDelete = new List<NAMHOC>();
        #endregion

        #region Các hàm chức năng
        void LoadNamHoc()
        {
            _ListNamHoc =  _NamHocBUS.LayNamHoc();
        }

        void LoadDataGridView()
        {
            int i = 0;
            dataGridView.DataSource = _ListNamHoc.ToArray();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                i++;
                row.Cells["STT"].Value = i;
            }
        }

        int CheckNamHoc(string _NamCheck, List<NAMHOC> _ListCheck)
        {
            int i = -1;
            foreach (NAMHOC nh in _ListCheck)
            {
                i++;
                if (nh.NAMHOC1 == _NamCheck)
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion

        #region Các sự kiện của form
        private void frQuanLyNamHoc_Load(object sender, EventArgs e)
        {
            LoadNamHoc();
            LoadDataGridView();
        }

        //Cập nhật dữ liệu lúc bấm vào gridview

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                string[] temp = dataGridView.CurrentRow.Cells["NamHoc"].Value.ToString().Split('-');
                txtNamBatDau.Text = temp[0];
            }
            catch
            { }
        }

        #region Các event lúc sửa các textbox
        private void txtNamBatDau_TextChanged(object sender, EventArgs e)
        {
            if (txtNamBatDau.Text.Length > 0)
            {
                txtNamKetThuc.Text = (int.Parse(txtNamBatDau.Text) + 1).ToString();
            }
            else
            { 
                txtNamKetThuc.Text = "";
            }
        }

        private void txtNamBatDau_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 ||  key == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (txtNamBatDau.Text.Length >= 4 && key != 8)
            {
                e.Handled = true;
            }
        }

        private void txtNamKetThuc_TextChanged(object sender, EventArgs e)
        {
            if (txtNamKetThuc.Text.Length > 0)
            {
                txtNamBatDau.Text = (int.Parse(txtNamKetThuc.Text) - 1).ToString();
            }
            else
            {
                txtNamBatDau.Text = "";
            }
        }

        private void txtNamKetThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (txtNamBatDau.Text.Length >= 4 && key != 8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Các event click buttuon
        private void btthem_Click(object sender, EventArgs e)
        {
            if (txtNamBatDau.Text == null)
            {
                MessageBox.Show("Không thể để trống năm học", "Error");
            }
            else
            {
                string namhoc = txtNamBatDau.Text + "-" + txtNamKetThuc.Text;
                foreach (NAMHOC nh in _ListNamHoc)
                {
                    if (namhoc == nh.NAMHOC1)
                    {
                        MessageBox.Show("Năm học vừa nhập đã tồn tại", "Error");
                        return;
                    }
                }

                foreach (NAMHOC nh in _ListDelete)
                {
                    if (namhoc == nh.NAMHOC1)
                    {
                        MessageBox.Show("Năm học vừa nhập đã tồn tại", "Error");
                        return;
                    }
                }

                _ListNamHoc.Add(new NAMHOC());
                _ListNamHoc[_ListNamHoc.Count - 1].NAMHOC1 = namhoc;

                _ListAdd.Add(new NAMHOC());
                _ListAdd[_ListAdd.Count - 1].NAMHOC1 = namhoc;

                LoadDataGridView();
                dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[0];
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            int k = CheckNamHoc(dataGridView.CurrentRow.Cells["NamHoc"].Value.ToString(), _ListAdd);
            if (k != -1)
            {
                _ListAdd.RemoveAt(k);
                k = CheckNamHoc(dataGridView.CurrentRow.Cells["NamHoc"].Value.ToString(), _ListNamHoc);
                _ListNamHoc.RemoveAt(k);
            }
            else
            {
                k = CheckNamHoc(dataGridView.CurrentRow.Cells["NamHoc"].Value.ToString(), _ListNamHoc);
                if (_LopBUS.LayDanhSachLopNamHoc(dataGridView.CurrentRow.Cells["NamHoc"].Value.ToString()).Count() == 0)
                {
                    _ListNamHoc.RemoveAt(k);
                    _ListDelete.Add(new NAMHOC());
                    _ListDelete[_ListDelete.Count - 1].NAMHOC1 = dataGridView.CurrentRow.Cells["NamHoc"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng xóa hết tất cả các lớp trước khi thay đổi", "Error");
                }
            }
            LoadDataGridView();
            if(k == dataGridView.Rows.Count)
                dataGridView.CurrentCell = dataGridView.Rows[k - 1].Cells[0]; 
            else
                dataGridView.CurrentCell = dataGridView.Rows[k].Cells[0];
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            foreach (NAMHOC nh in _ListDelete)
            {
                _NamHocBUS.XoaNamHoc(nh);
            }

            foreach (NAMHOC nh in _ListAdd)
            {
                _NamHocBUS.ThemNamHoc(nh);
            }

            _ListAdd.Clear();
            _ListDelete.Clear();
            MessageBox.Show("Lưu thành công", "Success");
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            if (_ListAdd.Count > 0 || _ListDelete.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Dữ liệu có thay đổi, bạn có muốn lưu lại ko?", "Exit", MessageBoxButtons.YesNoCancel);
                if (dr != DialogResult.Cancel)
                {
                    if (DialogResult.Yes == dr)
                    {
                        btluu_Click(sender, e);
                    }
                    this.Close();
                }
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    this.Close();
                }
            }
        }
        #endregion

        #endregion
    }
}