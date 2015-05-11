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
using System.Data.Linq;

namespace frMain
{
    public partial class fmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        #region Biến khởi tạo
        private TaiKhoan_BUS _TaiKhoan = new TaiKhoan_BUS();
        private List<TAIKHOAN> ListTaiKhoan;// chứa danh sách tài khoản ban đầu lấy từ database
        private List<TAIKHOAN> ListTaiKhoanInsert = new List<TAIKHOAN>(); // chứa danh sách tài khoản sẽ được thêm vào
        private List<TAIKHOAN> ListTaiKhoanDelete = new List<TAIKHOAN>(); // chứa danh sách tài khoản sẽ được xóa
        private List<TAIKHOAN> ListTaiKhoanUpdate = new List<TAIKHOAN>();// chứa danh sách tài khoản sẽ được cập nhật

        string _tk, _mk;
        int _loai;
        bool _luu = false;
        public fmPhanQuyen()
        {
            InitializeComponent();
            ListTaiKhoan = _TaiKhoan.LayTatCaTaiKhoan();// lấy tất cả tài khoản có trong cơ sở dữ liệu
            dataPhanQuyen.DataSource = ListTaiKhoan; // thiết lập dữ liệu hiển thị lên datagridview
            dataPhanQuyen.Columns[2].Visible = false;
        }
        #endregion
        #region Hiện ẩn mật khẩu

        // dùng để thiết lập hiển thị hay ẩn mật khẩu 
        private void Hien_An_MatKhau_CheckedChanged(object sender, EventArgs e)
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

        // mã hóa dữ liệu trước khi đưa vào cơ sở dữ liệu 
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
        //làm sạch dữ liệu đã nhập
        private void ClearText()
        {
            textTK.Clear();
            textMK1.Clear();
            textMK2.Clear();
        }
        //Sự kiện: xảy ra khi button Thêm được click
        // thêm tài khoản vào cơ sở dữ liệu
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textTK.Text.Trim() == "" || textMK1.Text.Trim() == "" || textMK2.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy dủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textMK1.Text == textMK2.Text)// nếu mật khẩu nhập 2 lần như nhau
                    {
                        bool trung = false;

                        // Kiểm tra tài khoản mới nhập đã tồn tại chưa
                        foreach (TAIKHOAN newtk in ListTaiKhoan)
                        {
                            if (newtk.TENTK == textTK.Text)
                            {
                                trung = true;
                                break;
                            }
                        }


                        if (!trung)// nếu chưa tồn tại thì thêm vào
                        {
                            TAIKHOAN newTK = new TAIKHOAN();
                            ISingleResult<usp_SelectLastMaTKResult> results = _TaiKhoan.LayMaTKCuoiCung();// lấy mã tài khoản cuối cùng
                            
                            foreach(usp_SelectLastMaTKResult result in results)
                            {
                                newTK.MATK = result.MATK + 1;
                            }
                            
                            newTK.TENTK = textTK.Text;
                            newTK.MATKHAU = MaHoaMD5(MaHoaMD5(textMK1.Text));
                            newTK.LOAITK = radioGroup1.SelectedIndex;

                            //Add List HocSinh Insert To Save DB
                            ListTaiKhoanInsert.Add(newTK);
                            ListTaiKhoan.Add(newTK);
                            dataPhanQuyen.DataSource = ListTaiKhoan.ToArray();
                            MessageBox.Show("Tài khoản bạn tạo thành công!", "Thêm tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _luu = true;
                            ClearText();

                            // Coder: Tài
                            Luu();
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

        // Sự kiện: xảy ra khi button Sửa được click
        // Sửa thông tin tài khoản
         private void ButtonSua_Click(object sender, EventArgs e)
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

                        foreach (TAIKHOAN newTK in ListTaiKhoan)
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
                                        foreach (TAIKHOAN newTK1 in ListTaiKhoan)
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
                                        ListTaiKhoanUpdate.Add(newTK);
                                        dataPhanQuyen.DataSource = ListTaiKhoan.ToArray();
                                        _luu = true;
                                        ClearText();
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

        // Sự kiện: xảy ra khi button Xóa được click
        // Xóa tài khoản
         private void ButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataPhanQuyen.CurrentRow.Cells["MATK"].Value.ToString();

                foreach (TAIKHOAN newtk in ListTaiKhoan)
                {
                    if (newtk.MATK.ToString() == id)
                    {
                        ListTaiKhoanDelete.Add(newtk);

                        ListTaiKhoan.Remove(newtk);
                        _luu = true;
                        break;
                    }
                }
                dataPhanQuyen.DataSource = ListTaiKhoan.ToArray();
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
                foreach (TAIKHOAN newHs in ListTaiKhoanDelete)
                {
                    _TaiKhoan.Xoa(newHs.MATK);
                }
                //ADD
                foreach (TAIKHOAN newHs in ListTaiKhoanInsert)
                {
                    _TaiKhoan.Them(newHs.MATK, newHs.TENTK, newHs.MATKHAU, newHs.LOAITK);
                }
                //Update
                foreach (TAIKHOAN newHs in ListTaiKhoanUpdate)
                {
                    _TaiKhoan.Sua(newHs.MATK, newHs.TENTK, newHs.MATKHAU, newHs.LOAITK);
                }
                _luu = false;
            }
            catch { }
        }
        //Thoát
        private void ButtonThoat_Click(object sender, EventArgs e)
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
        private void ButtonLuu_Click(object sender, EventArgs e)
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