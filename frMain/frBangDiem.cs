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
using System.Data.Linq;
using DataAccessObject.DAO;

namespace frMain
{
    public partial class frBangDiem : DevExpress.XtraEditors.XtraForm
    {
        public class CBangDiemChanged
        {
            public string NamHoc;
            public int MaHocKy;
            public string MaKhoi;
            public int MaLop;
            public string MaMon;
            public List<BangDiem_BUS> ListDiem = new List<BangDiem_BUS>();

            public CBangDiemChanged(string _NamHoc, int _MaHocKy, string _MaKhoi, int _MaLop, string _MaMon, List<BangDiem_BUS> _ListDiem)
            {
                NamHoc = _NamHoc;
                MaHocKy = _MaHocKy;
                MaKhoi = _MaKhoi;
                MaLop = _MaLop;
                MaMon = _MaMon;
                ListDiem = _ListDiem;
            }
        }

        NamHoc_BUS _NHBUS = new NamHoc_BUS();
        Khoi_BUS _KBUS = new Khoi_BUS();
        HocKy_BUS _HKBUS = new HocKy_BUS();
        MonHoc_BUS _MHBUS = new MonHoc_BUS();
        Diem_BUS _DBUS = new Diem_BUS();
        XepLop_BUS _XepBus = new XepLop_BUS();
        HoSoHocSinh_Bus _HSBUS = new HoSoHocSinh_Bus();
        QuiDinh_BUS _QuiDinh = new QuiDinh_BUS();

        Bitmap bitmap;
        bool _IsSelectedBefore = false;
        int _NamHocIndex, _KhoiIndex, _LopIndex, _MaHocSinh;

        DanhSachLop_BUS _LopBus = new DanhSachLop_BUS();

        List<BangDiem_BUS> _ListBangDiem = new List<BangDiem_BUS>();
        List<CBangDiemChanged> _ListBangDiemChanged = new List<CBangDiemChanged>();

        double? PreviousValue = 0;   //Để gắn lại nếu người dùng nhập sai quy định

        //List<usp_SelectBangdiemsPagedResult> _ListNam = new List<usp_SelectBangdiemsPagedResult>();
        public frBangDiem(bool _IsAllowToUpdate)
        {
            InitializeComponent();
            if (!_IsAllowToUpdate)
            {
                dataGridView.Columns["DIEM15"].ReadOnly = true;
                dataGridView.Columns["DIEM1Tiet"].ReadOnly = true;
                dataGridView.Columns["DIEMHK"].ReadOnly = true;
            }
        }

        public frBangDiem(bool _IsAllowToUpdate, int NamHocIndex, int KhoiIndex, int LopIndex, int MaHocSinh)
        {
            InitializeComponent();
            if (!_IsAllowToUpdate)
            {
                dataGridView.Columns["DIEM15"].ReadOnly = true;
                dataGridView.Columns["DIEM1Tiet"].ReadOnly = true;
                dataGridView.Columns["DIEMHK"].ReadOnly = true;
            }
            _IsSelectedBefore = true;
            _NamHocIndex = NamHocIndex;
            _KhoiIndex = KhoiIndex;
            _LopIndex = LopIndex;
            _MaHocSinh = MaHocSinh;
        }

        private void frBangDiem_Load(object sender, EventArgs e)
        {
            LoadDanhSachNam();
            if (comboNam.Items.Count > 0)
            {
                if (!_IsSelectedBefore)
                {
                    LoadDanhSachHocKy();
                    comboHocKy.SelectedIndex = 0;
                    comboNam.SelectedIndex = 0;
                }
                else
                {
                    LoadDanhSachHocKy();
                    LoadDanhSachMonHoc();
                    comboNam.SelectedIndex = _NamHocIndex;
                    comboKhoi.SelectedIndex = _KhoiIndex;
                    comboLop.SelectedIndex = _LopIndex;
                    comboHocKy.SelectedIndex = 0;
                    comboMon.SelectedIndex = 0;
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells["MaHocSinh"].Value.ToString() == _MaHocSinh.ToString())
                            dataGridView.CurrentCell = row.Cells[0];
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        void LoadDanhSachNam()
        {
            comboNam.Items.Clear();
            foreach (NAMHOC nam in _NHBUS.LayNamHoc())
            {
                comboNam.Items.Add(nam.NAMHOC1);
            }
        }

        void LoadDanhSachHocKy()
        {
            comboHocKy.Items.Clear();
            foreach (HOCKY hk in _HKBUS.LayDanhSachHocKy())
            {
                comboHocKy.Items.Add(hk.TENHOCKY);
            }
        }

        void LoadDanhSachMonHoc()
        {
            comboMon.Items.Clear();
            foreach (MONHOC mh in _MHBUS.LayDanhSachMonHoc())
            {
                comboMon.Items.Add(mh.TENMONHOC);
            }
        }

        void LoadDanhSachKhoi()
        {
            comboKhoi.Items.Clear();
            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                comboKhoi.Items.Add(khoi.KHOI.ToString());
            }
        }

        void LoadDanhSachLop()
        {
            comboLop.Items.Clear();
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoi.Tag.ToString(), comboNam.Text))
            {
                comboLop.Items.Add(lop.TENLOP.ToString());
            }
        }

        //-1 là ko có
        int CheckExistedInListBangDiemChanged(string _NamHoc, int _MaHocKy, string _MaKhoi, int _MaLop, string _MaMon)
        {
            for (int i = 0; i < _ListBangDiemChanged.Count; i++)
            {
                if (_ListBangDiemChanged[i].NamHoc == _NamHoc && _ListBangDiemChanged[i].MaHocKy == _MaHocKy && _ListBangDiemChanged[i].MaKhoi == _MaKhoi && _ListBangDiemChanged[i].MaLop == _MaLop && _ListBangDiemChanged[i].MaMon == _MaMon)
                    return i;
            }
            return -1;
        }

        int FindIndexInListBangDiem(int _MaHocSinh, List<BangDiem_BUS> _BangDiem)
        {
            for (int i = 0; i < _BangDiem.Count; i++)
            {
                if (_MaHocSinh == _BangDiem[i]._MaHocSinh)
                    return i;
            }
            return -1;
        }

        void LoadBangDiem()
        {

        }

        private void comboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachKhoi();
            if (comboKhoi.Items.Count > 0)
                comboKhoi.SelectedIndex = 0;
        }

        private void comboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (HOCKY hk in _HKBUS.LayDanhSachHocKy())
            {
                if (index == comboHocKy.SelectedIndex)
                {
                    comboHocKy.Tag = hk.MAHOCKY;
                    break;
                }
                index++;
            }
            LoadDatagridview();
        }

        private void comboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (MONHOC mh in _MHBUS.LayDanhSachMonHoc())
            {
                if (index == comboMon.SelectedIndex)
                {
                    comboMon.Tag = mh.MAMONHOC;
                    break;
                }
                index++;
            }
            LoadDatagridview();
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

            LoadDanhSachLop();
            if (comboLop.Items.Count > 0)
                comboLop.SelectedIndex = 0;
        }

        private void comboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            LoadDanhSachMonHoc();

            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoi.Tag.ToString(), comboNam.Text))
            {
                if (index == comboLop.SelectedIndex)
                {
                    comboLop.Tag = lop.MALOP;
                    break;
                }
                index++;
            }
            if (comboMon.Items.Count > 0)
                comboMon.SelectedIndex = 0;
        }

        void LoadDatagridview()
        {

            if (comboLop.SelectedIndex != -1 && comboMon.SelectedIndex != -1 && comboNam.SelectedIndex != -1 && comboHocKy.SelectedIndex != -1 && comboKhoi.SelectedIndex != -1)
            {
                lbhocky.Text = comboHocKy.Text;
                lbmon.Text = comboMon.Text;
                lblop.Text = comboLop.Text;

                _ListBangDiem.Clear();
                int i = CheckExistedInListBangDiemChanged(comboNam.Text, int.Parse(comboHocKy.Tag.ToString()), comboKhoi.Tag.ToString(), int.Parse(comboLop.Tag.ToString()), comboMon.Tag.ToString());

                if (i == -1)
                {
                    foreach (usp_SelectXeplopsByMALOPResult hs in _XepBus.TruyVanTheoMaLop(int.Parse(comboLop.Tag.ToString())))
                    {
                        BangDiem_BUS diem = _DBUS.LayBangDiem((int)hs.MAHOCSINH, comboNam.Text, int.Parse(comboHocKy.Tag.ToString()), comboMon.Tag.ToString());
                        _ListBangDiem.Add(diem);
                    }
                    dataGridView.DataSource = _ListBangDiem.ToArray();
                }
                else
                {
                    dataGridView.DataSource = _ListBangDiemChanged[i].ListDiem.ToArray();
                }
                //dataGridView.Columns["MaHocSinh"].Visible = false;
            }
            else
            {
                lbhocky.Text = null;
                lbmon.Text = null;
                lblop.Text = null;
            }
            for (int j = 0; j < dataGridView.Rows.Count; j++)
            {
                dataGridView.Rows[j].Cells["STT"].Value = j + 1;
            }

        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double _Diem = -1;
            double? _DiemTB = null;

            try
            {
                double.TryParse(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out _Diem);
            }
            catch
            {
                _Diem = -1;
            }
            finally
            {
                int _DiemToiDa = _QuiDinh.LayDiemToiDa();
                int _DiemToiThieu = _QuiDinh.LayDiemToiThieu();
                if (_Diem > _DiemToiDa || _Diem < _DiemToiThieu)
                {
                    MessageBox.Show("Điểm không được vượt quá " + _DiemToiDa.ToString() + " hay nhỏ hơn " + _DiemToiThieu.ToString(), "Error");
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = PreviousValue;
                    dataGridView.CancelEdit();
                }
                else
                {
                    if (dataGridView.Rows[e.RowIndex].Cells["Diem15"].Value != null && dataGridView.Rows[e.RowIndex].Cells["Diem1Tiet"].Value != null && dataGridView.Rows[e.RowIndex].Cells["DiemHK"].Value != null)
                    {
                        double _Diem15 = double.Parse(dataGridView.Rows[e.RowIndex].Cells["Diem15"].Value.ToString());
                        double _Diem1Tiet = double.Parse(dataGridView.Rows[e.RowIndex].Cells["Diem1Tiet"].Value.ToString());
                        double _DiemHK = double.Parse(dataGridView.Rows[e.RowIndex].Cells["DiemHK"].Value.ToString());
                        _DiemTB = Math.Round((_Diem15 + _Diem1Tiet * 2 + _DiemHK * 3) / 6, 1);

                        dataGridView.Rows[e.RowIndex].Cells["DiemTB"].Value = _DiemTB;
                    }

                    int i = CheckExistedInListBangDiemChanged(comboNam.Text, int.Parse(comboHocKy.Tag.ToString()), comboKhoi.Tag.ToString(), int.Parse(comboLop.Tag.ToString()), comboMon.Tag.ToString());
                    if (i == -1)
                    {

                        _ListBangDiemChanged.Add(new CBangDiemChanged(comboNam.Text, int.Parse(comboHocKy.Tag.ToString()), comboKhoi.Tag.ToString(), int.Parse(comboLop.Tag.ToString()), comboMon.Tag.ToString(), new List<BangDiem_BUS>(_ListBangDiem)));
                        int index = _ListBangDiemChanged.Count - 1;
                        int j = FindIndexInListBangDiem(int.Parse(dataGridView.Rows[e.RowIndex].Cells["MaHocSinh"].Value.ToString()), _ListBangDiemChanged[index].ListDiem);
                        switch (e.ColumnIndex)
                        {
                            case 3:
                                _ListBangDiemChanged[index].ListDiem[j]._Diem15 = _Diem;
                                break;
                            case 4:
                                _ListBangDiemChanged[index].ListDiem[j]._Diem1Tiet = _Diem;
                                break;
                            case 5:
                                _ListBangDiemChanged[index].ListDiem[j]._DiemHK = _Diem;
                                break;
                            default:
                                break;
                        }
                        _ListBangDiemChanged[index].ListDiem[j]._DiemTB = _DiemTB;
                    }
                    else
                    {
                        int j = FindIndexInListBangDiem(int.Parse(dataGridView.Rows[e.RowIndex].Cells["MaHocSinh"].Value.ToString()), _ListBangDiemChanged[i].ListDiem);
                        switch (e.ColumnIndex)
                        {
                            case 3:
                                _ListBangDiemChanged[i].ListDiem[j]._Diem15 = _Diem;
                                break;
                            case 4:
                                _ListBangDiemChanged[i].ListDiem[j]._Diem1Tiet = _Diem;
                                break;
                            case 5:
                                _ListBangDiemChanged[i].ListDiem[j]._DiemHK = _Diem;
                                break;
                            default:
                                break;
                        }
                        _ListBangDiemChanged[i].ListDiem[j]._DiemTB = _DiemTB;
                    }
                }
            }

        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Vui lòng chỉ nhập số", "Error");
            dataGridView.CancelEdit();
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                PreviousValue = double.Parse(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
            catch
            {
                PreviousValue = null;
            }
        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _ListBangDiemChanged.Count; i++)
            {
                for (int j = 0; j < _ListBangDiemChanged[i].ListDiem.Count; j++)
                    _DBUS.UpdateDiem(_ListBangDiemChanged[i].ListDiem[j], _ListBangDiemChanged[i].NamHoc, _ListBangDiemChanged[i].MaHocKy, _ListBangDiemChanged[i].MaMon);
            }
            MessageBox.Show("Lưu thành công", "Success");
            _ListBangDiemChanged.Clear();
        }

        private void toolStripBtnExit_Click(object sender, EventArgs e)
        {
            if (_ListBangDiemChanged.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Dữ liệu có thay đổi, bạn có muốn lưu lại ko?", "THOÁT ỨNG DỤNG", MessageBoxButtons.YesNoCancel);
                if (dr != DialogResult.Cancel)
                {
                    if (DialogResult.Yes == dr)
                    {
                        toolStripBtnSave_Click(sender, e);
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

        private void BtIn_Click(object sender, EventArgs e)
        {
            printPreviewBangDiem.Document = printBangDiem;

            ((Form)printPreviewBangDiem).WindowState = FormWindowState.Maximized;
            printPreviewBangDiem.PrintPreviewControl.AutoZoom = false;
            printPreviewBangDiem.PrintPreviewControl.Zoom = 1.0;

            printPreviewBangDiem.ShowDialog();
        }
        void PrintDataGridview()
        {
            bitmap = new Bitmap(this.dataGridView.Width, (this.dataGridView.Rows.Count + 1) * dataGridView.Rows[0].Height);
            dataGridView.DrawToBitmap(bitmap, this.dataGridView.ClientRectangle);
        }
        private void printBangDiem_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridview();
            Font font = new Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            e.Graphics.DrawString("BẢNG ĐIỂM MÔN " + comboMon.Text.ToString().ToUpper() +" LỚP "+comboLop.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 180, 50);
            e.Graphics.DrawString(comboHocKy.Text.ToString().ToUpper()+ ", NĂM HỌC " + comboNam.Text.ToString().ToUpper(), font, System.Drawing.Brushes.Black, 200, 100);

            e.Graphics.DrawImage(bitmap, new Point(40, 170));
        }

       

    }
}