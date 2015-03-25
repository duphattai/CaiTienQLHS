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
using System.Security.Cryptography;

namespace frMain
{
    public partial class fmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        #region Biến khởi tạo
        TaiKhoan_BUS _taikhoan = new TaiKhoan_BUS();
        List<TAIKHOAN> ListTK;
        List<TAIKHOAN> ListHSADD = new List<TAIKHOAN>();
        List<TAIKHOAN> ListHSDelete = new List<TAIKHOAN>();
        List<TAIKHOAN> ListHSUpdate = new List<TAIKHOAN>();
        string _tk, _mk;
        int _loai;
        bool _luu = false;
        public fmPhanQuyen()
        {
            InitializeComponent();
            ListTK = _taikhoan.LayTatCaTaiKhoan();
            dataPhanQuyen.DataSource = ListTK;
            dataPhanQuyen.Columns[2].Visible = false;
        }
        #endregion
        #region Hiện ẩn mật khẩu
        private void checkMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMK.Checked == true)
            {
                textMK1.UseSystemPasswordChar = false;
                textMK2.UseSystemPasswordChar = false;
            }
            else
            {
                textMK1.UseSystemPasswordChar = true;
                textMK2.UseSystemPasswordChar = true;
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
        #region button
        //Clear textbox
        private void Clear()
        {
            textTK.Clear();
            textMK1.Clear();
            textMK2.Clear();
        }
        //Thêm
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textTK.Text.Trim() == "" || textMK1.Text.Trim() == "" || textMK2.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy dủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textMK1.Text == textMK2.Text)
                    {
                        bool trung = false;

                        foreach (TAIKHOAN newtk in ListTK)
                        {
                            if (newtk.TENTK == textTK.Text)
                            {
                                trung = true;
                                break;
                            }
                        }
                        if (!trung)
                        {
                            TAIKHOAN newTK = new TAIKHOAN();

                            newTK.MATK = dataPhanQuyen.RowCount + 1;
                            newTK.TENTK = textTK.Text;
                            newTK.MATKHAU = MaHoaMD5(MaHoaMD5(textMK1.Text));
                            newTK.LOAITK = radioGroup1.SelectedIndex;

                            //Add List HocSinh Insert To Save DB
                            ListHSADD.Add(newTK);
                            ListTK.Add(newTK);
                            dataPhanQuyen.DataSource = ListTK.ToArray();
                            MessageBox.Show("Tài khoản bạn tạo thành công!", "Thêm tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _luu = true;
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản bạn vừa thêm đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu xác nhận giống và mật khẩu giống nhau!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch { }
        }

        //Sửa
         private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (textTK.Text.Trim() == "" || textMK1.Text.Trim() == "" || textMK2.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy dủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textMK1.Text == textMK2.Text)//2 mật khẩu giống nhau
                    {
                        bool trung = false;
                        bool ok = false;

                        String id = dataPhanQuyen.CurrentRow.Cells["MATK"].Value.ToString();

                        foreach (TAIKHOAN newTK in ListTK)
                        {
                            if (newTK.MATK.ToString() == id)
                            {
                                if (textTK.Text == _tk && textMK1.Text == _mk && radioGroup1.SelectedIndex == _loai)//không có thay đổi
                                {
                                    break;
                                }
                                else
                                {
                                    if (textTK.Text != _tk)//tên tk thay đổi
                                    {
                                        foreach (TAIKHOAN newTK1 in ListTK)
                                        {
                                            if (newTK1.TENTK == textTK.Text && newTK1.MATK != newTK.MATK)//trùng tk
                                            {
                                                trung = true;
                                                break;
                                            }
                                        }
                                        if (!trung)//khác trùng thì đổi
                                        {
                                            newTK.TENTK = textTK.Text;
                                            ok = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Tài khoản bạn vừa thêm đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    if (textMK1.Text != _mk)//mat khẩu
                                    {
                                        newTK.MATKHAU = MaHoaMD5(MaHoaMD5(textMK1.Text));
                                        ok = true;
                                    }
                                    if (radioGroup1.SelectedIndex != _loai)//loại
                                    {
                                        newTK.LOAITK = radioGroup1.SelectedIndex;
                                        ok = true;
                                    }
                                    if (!trung && ok)
                                    {
                                        ListHSUpdate.Add(newTK);
                                        dataPhanQuyen.DataSource = ListTK.ToArray();
                                        _luu = true;
                                        Clear();
                                    }
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu xác nhận và mật khẩu giống nhau!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch { }
        }

        //Xóa
         private void BtXoa_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataPhanQuyen.CurrentRow.Cells["MATK"].Value.ToString();

                foreach (TAIKHOAN newtk in ListTK)
                {
                    if (newtk.MATK.ToString() == id)
                    {
                        ListHSDelete.Add(newtk);

                        ListTK.Remove(newtk);
                        _luu = true;
                        break;
                    }
                }
                dataPhanQuyen.DataSource = ListTK.ToArray();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

         private void Luu()
        {
            try
            {
                //Delete
                foreach (TAIKHOAN newHs in ListHSDelete)
                {
                    _taikhoan.Xoa(newHs.MATK);
                }
                //ADD
                foreach (TAIKHOAN newHs in ListHSADD)
                {
                    _taikhoan.Them(newHs.MATK, newHs.TENTK, newHs.MATKHAU, newHs.LOAITK);
                }
                //Update
                foreach (TAIKHOAN newHs in ListHSUpdate)
                {
                    _taikhoan.Sua(newHs.MATK, newHs.TENTK, newHs.MATKHAU, newHs.LOAITK);
                }
                _luu = false;
            }
            catch { }
        }
        //Thoát
        private void btThoat_Click(object sender, EventArgs e)
        {
            if (_luu)
            {
                DialogResult di = MessageBox.Show("Bạn có muốn lưu lại dữ liệu lại trước khi thoát?", "ĐÓNG ỨNG DỤNG", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == di)
                {
                    Luu();
                    this.Close();
                }
                else
                {
                    if (DialogResult.No == di)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                DialogResult di = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "ĐÓNG ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == di)
                {
                    this.Close();
                }
            }
            
           
        }
        //Lưu
        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu();
        }
        #endregion
        #region Click DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textTK.Text = Convert.ToString(dataPhanQuyen.CurrentRow.Cells["TenTK"].Value.ToString().Trim());
                textMK1.Clear();
                textMK2.Clear();
                radioGroup1.SelectedIndex = Convert.ToInt32(Convert.ToString(dataPhanQuyen.CurrentRow.Cells["LoaiTK"].Value.ToString().Trim()));
                _tk = textTK.Text;
                _mk = textMK1.Text;
                _loai = radioGroup1.SelectedIndex;
            }
            catch { }
        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t\t\tHƯỚNG DẪN\n"+
            "THÊM: Hãy nhập tên mới(không trùng), mật khẩu và mật khẩu xác nhận phải giống nhau\n"+
            "SỬA: Chọn vào 1 tài khoản muốn sửa->Sau đó nhập mật khẩu và xác nhận. Lưu ý nhập tên tài khoản mong muốn, không để mặc định vì tên tài khoản đó"+
            " đã mã hóa và chương trình sẽ tự hiểu là tài khoản mới.\n"+
            "XÓA: Xóa tài khoản mà bạn chọn.\n"+
            "GIÚP ĐỠ: Sẽ hướng dẫn cách sử dụng.\n"+
            "LƯU: sẽ lưu lại thay đổi của bạn lên dữ liệu.\n"+
            "THOÁT: Thoát khỏi chương trình và sẽ hỏi lại bạn có muốn lưu lại trước khi thoát không.\n"+
            "Bên trái là các nút chức năng và các ô tên đăng nhập và tài khoản.\n"+
            "Ở giữa là quyền của loại tài khoản mà bạn chọn.\n"+
            "Bên phải là danh sách và thông tin tài khoản.\n"
            ,
            "Hướng dẫn dùng!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}