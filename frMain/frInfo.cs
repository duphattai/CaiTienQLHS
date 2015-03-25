using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace frMain
{
    public partial class frInfo : Form
    {
        #region List thông tin sinh viên
        public List<string> _mshs = new List<string>();
        public List<string> _ho = new List<string>();
        public List<string> _ten = new List<string>();
        public List<string> _khoa = new List<string>();
        public List<string> _khoi = new List<string>();
        public List<string> _ns = new List<string>();
        public List<string> _lop = new List<string>();
        public List<string> _gioitinh = new List<string>();
        public CKiemTraDuLieu _kiemtrathem = new CKiemTraDuLieu();

        SQLiteConnection sqliteconnect = new SQLiteConnection(@"Data Source=Source\QLHS.db");
        DataTable newtable;
        string g_path = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        string g_ImagePath = null;
        #endregion
        #region About: Khởi tạo và gán dữ liệu từ cha.
        public frInfo()
        {
            InitializeComponent();
        
        }
        public frInfo(DataTable table)
        {

            if (!Directory.Exists(g_path))
                Directory.CreateDirectory(g_path);
            try
            {
                InitializeComponent();
                newtable = table;
                WindowState = FormWindowState.Maximized;//tạo màn hình form to ra hết cỡ
                dataSinhVien.DataSource = table;
                dataSinhVien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataSinhVien.CurrentCell = dataSinhVien.Rows[0].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Kiểm tra nhập
        // Kiểm tra xem đã từng tồn tại mssv đó chưa
        bool CheckMAHS(string ms)
        {
            for (int i = 0; i < dataSinhVien.Rows.Count; i++ )
            {
                string imshs = dataSinhVien.Rows[i].Cells[1].Value.ToString().Trim();
                if (imshs == ms.Trim())
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckInputDataForm()
        {
            AddDuLieuVaoList();

            if (TxtHo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng bạn nhập Họ và Tên.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtHo.Clear();
                TxtHo.Focus();
                return false;
            }
            else
                if (!_kiemtrathem.KiemTraLop(TxtLop.Text.ToString(), _lop, TxtKhoa1.Text.ToString() + "-" + TxtKhoa2.Text.ToString(),_khoa))
                    {
                        MessageBox.Show("Bạn vừa nhập lớp bị lỗi !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtLop.Clear();
                        TxtLop.Focus();
                        return false;
                    }
                    else
                        if (!_kiemtrathem.KiemTraTuoi(date.Value))
                        {
                            MessageBox.Show("Bạn vừa nhập ngày sinh bị lỗi !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtLop.Clear();
                            TxtLop.Focus();
                            return false;
                        }
                        else
                            if (TxtTen.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn vừa nhập tên bị lỗi !.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                TxtTen.Clear();
                                TxtTen.Focus();
                                return false;
                            }
                            else
                                if (!_kiemtrathem.KiemTraKhoi(TxtKhoi.Text.ToString()))
                                {
                                    MessageBox.Show("Bạn vừa nhập khối bị lỗi !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    TxtKhoi.Clear();
                                    TxtKhoi.Focus();
                                    return false;
                                }
                                else
                                    if (!_kiemtrathem.KiemTraKhoa(TxtKhoa1.Text.ToString(),TxtKhoa2.Text.ToString()))
                                    {
                                        MessageBox.Show("Bạn vừa nhập khóa bị lỗi !.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        TxtKhoa1.Clear();
                                        TxtKhoa1.Focus();
                                        TxtKhoa2.Clear();
                                        TxtKhoa2.Focus();
                                        return false;
                                    }                        
                                    else
                                        if (!_kiemtrathem.KiemTraMSHS(TxtMaHS.Text.ToString(), _mshs, TxtKhoa1.Text.ToString() + "-" + TxtKhoa2.Text.ToString(),  _khoa))
                                            {

                                                MessageBox.Show("MSHS " +  TxtMaHS.Text.Trim() + " đã bị trùng. Vui lòng nhập lại.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return false;
                                            }


            return true;
        }  
        #endregion
        #region ADD

        private string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{2}-{1}-{0} ";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputDataForm())
                {
                    string gt;
                    if (radioButton1.Checked)
                    {
                        gt = "Nam";
                    }
                    else
                        if (radioButton2.Checked)
                        {
                            gt = "Nữ";
                        }
                        else
                            gt = "Khác";

                        DataRow newRow = newtable.NewRow();
                        newRow["STT"] = dataSinhVien.Rows.Count.ToString();
                        newRow["MaHS"] = TxtMaHS.Text.ToString();
                        newRow["Ho"] = TxtHo.Text.ToString();
                        newRow["Ten"] = TxtTen.Text.ToString();
                        newRow["Gioi Tinh"] = gt;
                        newRow["Ngay Sinh"] = DateTimeSQLite(DateTime.Parse(date.Value.ToString()));
                        newRow["Lop"] = TxtLop.Text.ToString();
                        newRow["Khoi"] = TxtKhoi.Text.ToString();
                        newRow["Khoa"] = TxtKhoa1.Text.ToString() + "-" + TxtKhoa2.Text.ToString();
                        newtable.Rows.Add(newRow);
                        SaveImage(g_ImagePath);

                        //Xoá các ô và đặt trỏ chuột vào ô Họ Tên
                        button2_Click(sender, e);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region EDIT
        private bool CheckEditData()
        {
            AddDuLieuVaoList();

            if (TxtHo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng bạn nhập Họ và Tên.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtHo.Clear();
                TxtHo.Focus();
                return false;
            }
            else
                if (!_kiemtrathem.KiemTraLop(TxtLop.Text.ToString(), _lop, TxtKhoa1.Text.ToString() + "-" + TxtKhoa2.Text.ToString(), _khoa))
                {
                    MessageBox.Show("Bạn vừa nhập lớp bị lỗi !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtLop.Clear();
                    TxtLop.Focus();
                    return false;
                }
                else
                    if (!_kiemtrathem.KiemTraTuoi(date.Value))
                    {
                        MessageBox.Show("Bạn vừa nhập ngày sinh bị lỗi !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtLop.Clear();
                        TxtLop.Focus();
                        return false;
                    }
                    else
                        if (TxtTen.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn vừa nhập tên bị lỗi !.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtTen.Clear();
                            TxtTen.Focus();
                            return false;
                        }
                        else
                            if (!_kiemtrathem.KiemTraKhoi(TxtKhoi.Text.ToString()))
                            {
                                MessageBox.Show("Bạn vừa nhập khối bị lỗi !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                TxtKhoi.Clear();
                                TxtKhoi.Focus();
                                return false;
                            }
                            else
                                if (!_kiemtrathem.KiemTraKhoa(TxtKhoa1.Text.ToString(), TxtKhoa2.Text.ToString()))
                                {
                                    MessageBox.Show("Bạn vừa nhập khóa bị lỗi !.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    TxtKhoa1.Clear();
                                    TxtKhoa1.Focus();
                                    TxtKhoa2.Clear();
                                    TxtKhoa2.Focus();
                                    return false;
                                }

            return true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                    int row = dataSinhVien.SelectedRows.Count;
                    // nếu không chọn
                    if (row == 0)
                        MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu để có thể thực hiện tiếp tiến trình EDIT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else // nếu chọn 1 dòng
                        if (row == 1)
                        {
                            if (CheckEditData())
                            {
                                dataSinhVien.CurrentRow.Cells[1].Value = TxtMaHS.Text;                 //ID
                                dataSinhVien.CurrentRow.Cells[2].Value = TxtHo.Text;                 //ho   
                                dataSinhVien.CurrentRow.Cells[3].Value = TxtTen.Text;                 //ten
                                dataSinhVien.CurrentRow.Cells[5].Value = date.Value.ToString("dd/MM/yyyy");
                                dataSinhVien.CurrentRow.Cells[6].Value = TxtLop.Text;                 //lop    
                                dataSinhVien.CurrentRow.Cells[7].Value = TxtKhoi.Text;                 //khoi   
                                dataSinhVien.CurrentRow.Cells[8].Value = TxtKhoa1.Text + "-" + TxtKhoa2.Text;                 //khoa   

                                if (radioButton1.Checked == true)
                                    dataSinhVien.CurrentRow.Cells[4].Value = "Nam";
                                else
                                    if (radioButton2.Checked == true)
                                        dataSinhVien.CurrentRow.Cells[4].Value = "Nữ";
                                    else
                                        dataSinhVien.CurrentRow.Cells[4].Value = "Khác";
                                SaveImage(g_ImagePath);
                            }
                        }
                        else //nếu chọn nhiều dòng cùng 1 lúc

                            MessageBox.Show("Vui lòng chỉ chọn 1 dòng để dữ liệu có thể cập nhật tốt nhất", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region CLEAR
        //Xoá các ô và đặt trỏ chuột vào ô Họ Tên
        private void button2_Click(object sender, EventArgs e)
        {
            TxtHo.Clear();
            TxtMaHS.Clear();
            TxtLop.Clear();
            TxtTen.Clear();
            TxtKhoi.Clear();
            TxtKhoa1.Clear();
            TxtKhoa2.Clear();
            TxtHo.Focus();
        }
        #endregion
        #region DELETE
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int KT = dataSinhVien.SelectedRows.Count;    // Số dòng chọn
                if (KT == 0)
                    MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu để có thể thực hiện tiếp tiến trình DELETE", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    foreach (DataGridViewRow row in dataSinhVien.SelectedRows)
                        if (!row.IsNewRow)
                            dataSinhVien.Rows.Remove(row);
                for (int i = 0; i < dataSinhVien.Rows.Count; i++)
                {
                    dataSinhVien.Rows[i].Cells[0].Value = i + 1;
                }
                String[] extension = { ".jpg", ".png", ".bmp" };
                string temp = TxtKhoa1.Text + "-" + TxtKhoa2.Text + "\\" + TxtKhoi.Text + "\\" + TxtLop.Text + "\\" + TxtMaHS.Text;
                for (int i = 0; i < extension.Count(); i++)
                {
                    if (File.Exists(Path.Combine(g_path, temp + extension[i])))
                    {
                        File.Delete(Path.Combine(g_path, temp + extension[i]));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion     
        #region CLICK CHUỘT DATA, CHỌN BÀN PHÍM CẬP NHẬT CÁC Ô TEXTBOX
        
        //chọn thông qua bàn phím và mặc định
        private void dataSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                g_ImagePath = null;
                TxtHo.Text = dataSinhVien.CurrentRow.Cells[2].Value.ToString();  //họ
                TxtMaHS.Text = dataSinhVien.CurrentRow.Cells[1].Value.ToString();  //mshs 
                TxtLop.Text = dataSinhVien.CurrentRow.Cells[6].Value.ToString();  //lớp
                TxtTen.Text = dataSinhVien.CurrentRow.Cells[3].Value.ToString();  // tên
                TxtKhoi.Text = dataSinhVien.CurrentRow.Cells[7].Value.ToString();  //khối

                TxtKhoa1.Clear();
                TxtKhoa2.Clear();
                string ikhoa = dataSinhVien.CurrentRow.Cells[8].Value.ToString().Trim();
                for (int i = 0; i < 4; i++)
                {
                    TxtKhoa1.Text += ikhoa[i];
                    TxtKhoa2.Text += ikhoa[ikhoa.Count() - 4 + i];
                }

                string gt = dataSinhVien.CurrentRow.Cells[4].Value.ToString();
                if (gt == "Nam")
                {
                    radioButton1.Checked = true;
                }
                else
                    if (gt == "Nữ")
                    {
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton3.Checked = true;
                    }
                date.Value = DateTime.ParseExact(dataSinhVien.CurrentRow.Cells[5].Value.ToString(), "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                bool IsImageExist = false;
                String[] extension = { ".jpg", ".png", ".bmp" };
                string temp = TxtKhoa1.Text + "-" + TxtKhoa2.Text + "\\" + TxtKhoi.Text + "\\" + TxtLop.Text + "\\" + TxtMaHS.Text;
                for (int i = 0; i < extension.Count(); i++)
                {
                    if (File.Exists(Path.Combine(g_path, temp + extension[i])))
                    {
                        FileStream fs = new FileStream(Path.Combine(g_path, temp + extension[i]), FileMode.Open);
                        pictureBox1.Image = Image.FromStream(fs);
                        fs.Flush();
                        fs.Close();
                        IsImageExist = true;
                        break;
                    }
                }
                if (!IsImageExist)
                {
                    if (gt == "Nam")
                        pictureBox1.Image = Image.FromFile("Icon//boy.png");
                    else
                        if (gt == "Nữ")
                            pictureBox1.Image = Image.FromFile("Icon//girl.png");
                        else
                            pictureBox1.Image = Image.FromFile("Icon//nosex.png");
                }
            }
            catch { }
        }
        #endregion
        #region EXIT: "LÂM" làm tiếp phần này.  Đây là dữ liệu ra vui lòng: Viết 1 lớp kiểm tra dữ liệu rùi add lai dùng dữ liệu này cho bảng về sau với Update lại dữ liệu vào CSDL
        void AddDuLieuVaoList()
        {
            _mshs.Clear();
            _ho.Clear();
            _ten.Clear();
            _gioitinh.Clear();
            _ns.Clear();
            _lop.Clear();
            _khoi.Clear();
            _khoa.Clear();

            for (int i = 0; i < dataSinhVien.Rows.Count - 1; i++)  // Bỏ hàng cuối vì trống
            {
                _mshs.Add(dataSinhVien.Rows[i].Cells[1].Value.ToString().Trim());
                _ho.Add(dataSinhVien.Rows[i].Cells[2].Value.ToString().Trim());
                _ten.Add(dataSinhVien.Rows[i].Cells[3].Value.ToString().Trim());
                _gioitinh.Add(dataSinhVien.Rows[i].Cells[4].Value.ToString().Trim());
                _ns.Add(dataSinhVien.Rows[i].Cells[5].Value.ToString());
                _lop.Add(dataSinhVien.Rows[i].Cells[6].Value.ToString());
                _khoi.Add(dataSinhVien.Rows[i].Cells[7].Value.ToString());
                _khoa.Add(dataSinhVien.Rows[i].Cells[8].Value.ToString().Trim());
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Bạn có muốn thoát?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mes == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region Click Picture and Save image
        void SaveImage(string ImagePath)
        {
            if (ImagePath != null)
            {
                string temp = TxtKhoa1.Text + "-" + TxtKhoa2.Text + "\\" + TxtKhoi.Text + "\\" + TxtLop.Text;
                if (Directory.Exists(Path.Combine(g_path, temp)))
                {
                    File.Copy(ImagePath, Path.Combine(g_path, temp + "\\" + TxtMaHS.Text + Path.GetExtension(ImagePath)), true);
                }
                else
                {
                    Directory.CreateDirectory(Path.Combine(g_path, temp));
                    File.Copy(ImagePath, Path.Combine(g_path, temp + "\\" + TxtMaHS.Text + Path.GetExtension(ImagePath)), true);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.jpg, *.png, *.bmp)|*.jpg; *.png; *.bmp|All(*.*)|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                g_ImagePath = ofd.FileName;
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                pictureBox1.Image = Image.FromStream(fs);
                fs.Flush();
                fs.Close();
            }
        }
        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Bạn có muốn lưu dữ liệu vào cơ sở dữ liệu không ?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mes == DialogResult.OK)
            {
                _mshs.Clear();
                _ho.Clear();
                _ten.Clear();
                _gioitinh.Clear();
                _ns.Clear();
                _lop.Clear();
                _khoi.Clear();
                _khoa.Clear();

                for (int i = 0; i < dataSinhVien.Rows.Count - 1; i++)  // Bỏ hàng cuối vì trống
                {
                    _mshs.Add(dataSinhVien.Rows[i].Cells[1].Value.ToString().Trim());
                    _ho.Add(dataSinhVien.Rows[i].Cells[2].Value.ToString().Trim());
                    _ten.Add(dataSinhVien.Rows[i].Cells[3].Value.ToString().Trim());
                    _gioitinh.Add(dataSinhVien.Rows[i].Cells[4].Value.ToString().Trim());
                    _ns.Add(dataSinhVien.Rows[i].Cells[5].Value.ToString());
                    _lop.Add(dataSinhVien.Rows[i].Cells[6].Value.ToString());
                    _khoi.Add(dataSinhVien.Rows[i].Cells[7].Value.ToString());
                    _khoa.Add(dataSinhVien.Rows[i].Cells[8].Value.ToString().Trim());
                }
                //Đưa lại dữ liệu vào CSDL

                if (sqliteconnect.State == ConnectionState.Closed)
                    sqliteconnect.Open();

                SQLiteCommand xoa = new SQLiteCommand("delete from HoSoHocSinh", sqliteconnect);
                xoa.CommandType = CommandType.Text;
                xoa.ExecuteNonQuery();

                for (int i = 0; i < dataSinhVien.Rows.Count - 1; i++)  // Bỏ hàng cuối vì trống
                {
                    SQLiteCommand them = new SQLiteCommand("insert into  HoSoHocSinh values ( '" + i + "','" + _mshs[i].ToString().Trim() + "','" + _ho[i].ToString().Trim() + "','" +
                    _ten[i].ToString().Trim() + "','" + _gioitinh[i].ToString().Trim() + "','" + _ns[i].ToString().Trim() + "','" +
                    _lop[i].ToString().Trim() + "','" + _khoi[i].ToString().Trim() + "','" + _khoa[i].ToString().Trim() + "')", sqliteconnect);

                    them.CommandType = CommandType.Text;
                    them.ExecuteNonQuery();
                }

                sqliteconnect.Close();

            }
        }

    }
}