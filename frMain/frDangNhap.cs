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
using System.Security.Cryptography;
using System.IO;
using System.Data.SqlClient;
using BUS;
using DataAccessObject.DAO;

namespace frMain
{
    public partial class frDangNhap : DevExpress.XtraEditors.XtraForm
    {
        #region Biến khởi tạo
        TaiKhoan_BUS _taikhoan = new TaiKhoan_BUS();
        List<TAIKHOAN> ListTK;
        private int _quyen;
        

        public frDangNhap()
        {
            InitializeComponent();
            ListTK = _taikhoan.LayTatCaTaiKhoan();
            KiemTra();
        }
        private void KiemTra()
        {
            try
            {
                foreach (TAIKHOAN newTK in ListTK)
                {
                    if (newTK.LOAITK == 0)
                    {
                        return;
                    }
                }
                TaiKhoan_BUS _taikhoan = new TaiKhoan_BUS();
                _taikhoan.Them(0, "Admin", MaHoaMD5(MaHoaMD5("Admin")), 0);
                ListTK = _taikhoan.LayTatCaTaiKhoan();
            }
            catch
            {

            }
        }
         #endregion
        #region Mã hóa MD5
        private string MaHoaMD5(string str)
        {
            Byte[] dauvao = ASCIIEncoding.Default.GetBytes(str);
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                var daura = md5.ComputeHash(dauvao);
                return BitConverter.ToString(daura).Replace("-", "");
            }
        }
         #endregion
        #region Đăng nhập
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textTen.Text.Trim() != "" && textMatKhau.Text.Trim() != "")
                {
                    foreach (TAIKHOAN newtk in ListTK)
                    {
                        if (newtk.TENTK ==textTen.Text && newtk.MATKHAU == MaHoaMD5(MaHoaMD5(textMatKhau.Text)))
                        {
                            MessageBox.Show("Chào " + textTen.Text + " đến với phần mềm QUẢN LÝ HỌC SINH", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _quyen = newtk.LOAITK;
                            this.Close();
                            return;
                        }
                    }
                }
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _quyen = -1;
            }
            catch { }
           
        }
        #endregion
        #region Xem thông tin
        private void thongtin_Click(object sender, EventArgs e)
        {
            _quyen = 3;
            this.Close();
        }
        #endregion
        #region Thoát
        private void simpleButton2_Click(object sender, EventArgs e)
        {    
            if(DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
            {
                _quyen = -1;
                this.Close();
            }
        }
        #endregion
        #region Trả về giá trị quyền
        public int Quyen()
        {
            return _quyen;
        }
        #endregion
        #region Hiển thị mật khẩu
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkMK.Checked == true)
            {
                textMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                textMatKhau.UseSystemPasswordChar = true;
            }
        }
        #endregion

        #region even Bắt phím
        private void frDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Đăng nhập
                if (e.KeyChar == 13)
                {
                    simpleButton1_Click(sender, e);
                }
                //thoát
                if (e.KeyChar == 27)
                {
                    simpleButton2_Click(sender, e);
                }
            }
            catch { }
        }
        #endregion
    }
}