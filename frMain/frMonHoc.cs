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
    public partial class frMonHoc : DevExpress.XtraEditors.XtraForm
    {
        MonHoc_BUS _MHBUS = new MonHoc_BUS();
        List<MONHOC> _ListMonHoc = new List<MONHOC>();
        List<MONHOC> _ListAdd = new List<MONHOC>();
        List<MONHOC> _ListUpdate = new List<MONHOC>();
        List<MONHOC> _ListDelete = new List<MONHOC>();

        public frMonHoc()
        {
            InitializeComponent();
        }

        private void frMonHoc_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        void LoadDataGridView()
        {
            _ListMonHoc = _MHBUS.LayDanhSachMonHoc();
            dataGridView.DataSource = _ListMonHoc.ToArray();

            dataGridView.Columns["MAMONHOC"].Visible = false;
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView.CurrentRow.Cells["MAMONHOC"].Value.ToString();

                if (txtmonhoc.Text == "") MessageBox.Show("Xảy ra lỗi !");
                else
                {
                    foreach (MONHOC mh in _ListMonHoc)
                    {
                        if (mh.MAMONHOC.ToString() == id)
                        {
                            //Add List HocSinh Update To Save DB
                            mh.TENMONHOC = txtmonhoc.Text.ToString();

                            _ListUpdate.Add(mh);
                            break;
                        }
                    }
                    dataGridView.DataSource = _ListMonHoc.ToArray();

                    MessageBox.Show("Sửa thành công! ");
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại! ");
            }

        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int index = rand.Next(0, 1000);
            try
            {
                if (txtmonhoc.Text != "" && _MHBUS.KiemTraMonHoc(txtmonhoc.Text, _ListMonHoc))
                {

                    MONHOC newMonHoc = new MONHOC();
                    newMonHoc.TENMONHOC = txtmonhoc.Text.ToString();
                    newMonHoc.MAMONHOC = txtmonhoc.Text.ToString()[0].ToString() + txtmonhoc.Text.ToString()[txtmonhoc.Text.Length - 1].ToString() + index.ToString();
                    _ListMonHoc.Add(newMonHoc);
                    _ListAdd.Add(newMonHoc);

                    dataGridView.DataSource = _ListMonHoc.ToArray();

                    MessageBox.Show("Thêm thành công !");
                }
                else
                    MessageBox.Show("Thêm thất bại, môn học đã tồn tại hoặc bạn không nhập tên môn học !");

            }
            catch
            {
                MessageBox.Show("Thêm thất bại!");
            }

        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show("Nếu bạn xóa dữ liệu sẽ bị mất. Bạn có muốn tiếp tục", "XÓA DỮ LIỆU", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    String id = dataGridView.CurrentRow.Cells["MAMONHOC"].Value.ToString();

                    foreach (MONHOC mh in _ListMonHoc)
                    {
                        if (mh.MAMONHOC.ToString() == id)
                        {
                            _ListMonHoc.Remove(mh);

                            _ListDelete.Add(mh);
                            break;
                        }
                    }
                    dataGridView.DataSource = _ListMonHoc.ToArray();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!");
            }

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (MONHOC mh in _ListAdd)
                {
                    _MHBUS.Them(mh.MAMONHOC, mh.TENMONHOC);
                }

                foreach (MONHOC mh in _ListUpdate)
                {
                    _MHBUS.Update(mh.MAMONHOC, mh.TENMONHOC);
                }
                foreach (MONHOC mh in _ListDelete)
                {
                    _MHBUS.Delete(mh.MAMONHOC);
                }

                MessageBox.Show("Lưu thay đổi thành công! ");
            }
            catch
            {
                MessageBox.Show("Lưu thay đổi thất bại !");
            }
        }

        private void frMonHoc_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmonhoc.Text = dataGridView.CurrentRow.Cells["TENMONHOC"].Value.ToString();
        }
    }
}