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
    public partial class frQuyDinh : DevExpress.XtraEditors.XtraForm
    {
        QuiDinh_BUS _TSBUS = new QuiDinh_BUS();
        public frQuyDinh()
        {
            InitializeComponent();
        }

        private void frQuyDinh_Load(object sender, EventArgs e)
        {
            LoadThamSoVaoTextBox();

        }
        void LoadThamSoVaoTextBox()
        {
            foreach (THAMSO ts in _TSBUS.LayDanhSachThamSo())
            {
                TxtDiemDatMon.Text = ts.DIEMDATMON.ToString();
                txtDiemToiDa.Text = ts.DIEMTOIDA.ToString();
                txtDiemToiThieu.Text = ts.DIEMTOITHIEU.ToString();
                txtSiSoToiDa.Text = ts.SISOTOIDA.ToString();
                TxtTuoiToiDa.Text = ts.TUOITOIDA.ToString();
                TxtTuoiToiThieu.Text = ts.TUOITOITHIEU.ToString();
                txtlop10.Text = ts.SOLOPTOIDAKHOI10.ToString();
                txtlop11.Text = ts.SOLOPTOIDAKHOI11.ToString();
                txtlop12.Text = ts.SOLOPTOIDAKHOI12.ToString();

            }
        }
        void UpdateThamSo()
        {

            _TSBUS.Update(TxtTuoiToiThieu.Text.ToString(), TxtTuoiToiDa.Text.ToString(), TxtDiemDatMon.Text.ToString(), txtSiSoToiDa.Text.ToString(), txtDiemToiThieu.Text.ToString(), txtDiemToiDa.Text.ToString(),txtlop10.Text.ToString(),txtlop11.Text.ToString(),txtlop12.Text.ToString());
            MessageBox.Show("Cập nhật thành công!!");

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) //Luu
        {
            if (TxtDiemDatMon.Text == "" || TxtTuoiToiThieu.Text == "" || TxtTuoiToiDa.Text == "" || txtDiemToiThieu.Text == "" || txtDiemToiDa.Text == "" || txtSiSoToiDa.Text == "" || txtlop10.Text == "" || txtlop11.Text == "" || txtlop12.Text == "")
            {
                MessageBox.Show("Không thể xóa quy định !");
                if (TxtDiemDatMon.Text == "")
                {
                    TxtDiemDatMon.Text = _TSBUS.LayDiemDatMon().ToString();
                }
                if (TxtTuoiToiThieu.Text == "")
                {
                    TxtTuoiToiThieu.Text = _TSBUS.LayDanhSachThamSo().First().TUOITOITHIEU.ToString();
                }
                if (TxtTuoiToiDa.Text == "")
                {
                    TxtTuoiToiDa.Text = _TSBUS.LayTuoiToiDa().ToString();
                }
                if (txtDiemToiThieu.Text == "")
                {
                    txtDiemToiThieu.Text = _TSBUS.LayDiemToiThieu().ToString();
                }
                if (txtDiemToiDa.Text == "")
                {
                    txtDiemToiDa.Text = _TSBUS.LayDiemToiDa().ToString();
                }
                if (txtSiSoToiDa.Text == "")
                {
                    txtSiSoToiDa.Text = _TSBUS.LaySiSoToiDa().ToString();
                }
                if (txtlop10.Text == "")
                {
                    txtlop10.Text = _TSBUS.LayDanhSachThamSo().First().SOLOPTOIDAKHOI10.ToString();
                }
                if (txtlop11.Text == "")
                {
                    txtlop11.Text = _TSBUS.LayDanhSachThamSo().First().SOLOPTOIDAKHOI11.ToString();
                }
                if (txtlop12.Text == "")
                {
                    txtlop12.Text = _TSBUS.LayDanhSachThamSo().First().SOLOPTOIDAKHOI12.ToString();
                }
            }
            else
                UpdateThamSo();
        }

      
        private void TxtDiemDatMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void TxtTuoiToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void TxtTuoiToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void txtDiemToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void txtDiemToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void txtSiSoToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void txtlop10_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void txtlop11_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void txtlop12_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt16(e.KeyChar);
            if (key > 47 && key < 58 || key == 8) e.Handled = false;
            else e.Handled = true;
        }
    }
}