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
using System.Data.Linq;

namespace frMain
{
    public partial class frPhanLop : DevExpress.XtraEditors.XtraForm
    {
        public frPhanLop()
        {
            InitializeComponent();
        }

        #region Wrap Class
        public class CLopChange
        {
            public int _MaLop;
            public List<usp_SelectHocSinhTheoMALOPResult> _ListLop;

            public CLopChange(int MaLop, List<usp_SelectHocSinhTheoMALOPResult> ListLop)
            {
                _MaLop = MaLop;
                _ListLop = ListLop;
            }
        }
        class CChuaPhanLopChange
        {
            public string _NamHoc;
            public List<usp_SelectHocSinhChuaPhanLopResult> _List;

            public CChuaPhanLopChange(string NamHoc, List<usp_SelectHocSinhChuaPhanLopResult> List)
            {
                _NamHoc = NamHoc;
                _List = List;
            }
        }
        #endregion

        #region Biến toàn cục
        NamHoc_BUS _NHBUS = new NamHoc_BUS();
        Khoi_BUS _KBUS = new Khoi_BUS();
        DanhSachLop_BUS _LopBus = new DanhSachLop_BUS();
        XepLop_BUS _XepBus = new XepLop_BUS();
        HoSoHocSinh_Bus _HSBUS = new HoSoHocSinh_Bus();
        QuiDinh_BUS _QuiDinhBus = new QuiDinh_BUS();

        List<CLopChange> _ListLopChange = new List<CLopChange>();
        List<CChuaPhanLopChange> _ListChuaPhanLopChange = new List<CChuaPhanLopChange>();
        #endregion

        #region Các hàm chức năng

        void LoadDanhSachNam()
        {
            foreach (NAMHOC NH in _NHBUS.LayNamHoc())
            {
                comboNamCurrent.Items.Add(NH.NAMHOC1.ToString());
                comboNamnew.Items.Add(NH.NAMHOC1.ToString());
            }
        }

        void LoadDanhSachKhoi()
        {
            comboKhoiCurrent.Items.Clear();
            comboKhoinew.Items.Clear();
            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                comboKhoiCurrent.Items.Add(khoi.KHOI.ToString());
                comboKhoinew.Items.Add(khoi.KHOI.ToString());
            }
        }

        void LoadDanhSachLopCu()
        {
            comboLopCurrent.Items.Clear();
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoiCurrent.Tag.ToString(), comboNamCurrent.Text))
            {
                comboLopCurrent.Items.Add(lop.TENLOP);
            }
        }

        void LoadDanhSachLopMoi()
        {
            comboLopnew.Items.Clear();
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoinew.Tag.ToString(), comboNamnew.Text))
            {
                comboLopnew.Items.Add(lop.TENLOP);
            }
        }

        List<usp_SelectHocSinhTheoMALOPResult> LoadDanhSachHocSinhTheoMaLop(int MaLop)
        {
            List<usp_SelectHocSinhTheoMALOPResult> ListHSLop = new List<usp_SelectHocSinhTheoMALOPResult>();
            foreach (usp_SelectHocSinhTheoMALOPResult hs in _LopBus.LayDanhSachHocSinhTheoMaLop(MaLop))
            {
                ListHSLop.Add(hs);
            }
            return ListHSLop;
        }

        List<usp_SelectHocSinhChuaPhanLopResult> LoadDanhSachHocSinhChuaPhanLop(string NamHoc)
        {
            List<usp_SelectHocSinhChuaPhanLopResult> _ListHS = new List<usp_SelectHocSinhChuaPhanLopResult>();
            foreach (usp_SelectHocSinhChuaPhanLopResult hs in _LopBus.LayDanhSachHocSinhChuaPhanLop(NamHoc))
            {
                _ListHS.Add(hs);
            }
            return _ListHS;
        }
        #endregion

        #region Các event của form
        void LoadDataGridViewCurrent()
        {
            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                btnRemove.Enabled = true;
                btnSwap.Enabled = true;
                int i = CheckExistedInListChuaPhanLopLopChange(comboNamCurrent.Text);
                if (i != -1)
                {
                    dataGridViewcurrent.DataSource = _ListChuaPhanLopChange[i]._List.ToArray();
                }
                else
                {
                    dataGridViewcurrent.DataSource = LoadDanhSachHocSinhChuaPhanLop(comboNamCurrent.Text).ToArray();
                }
            }
            else
            {
                if (comboNamCurrent.SelectedIndex != -1 && comboLopCurrent.SelectedIndex != -1 && comboKhoiCurrent.SelectedIndex != -1)
                {
                    int i = CheckExistedInListLopChange(int.Parse(comboLopCurrent.Tag.ToString()));
                    if (i != -1)
                    {
                        dataGridViewcurrent.DataSource = _ListLopChange[i]._ListLop.ToArray();
                    }
                    else
                    {
                        dataGridViewcurrent.DataSource = LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString())).ToArray();
                    }
                    btnRemove.Enabled = true;
                    btnSwap.Enabled = true;
                }
                else
                {
                    dataGridViewcurrent.DataSource = new List<usp_SelectHocSinhTheoMALOPResult>();
                    btnRemove.Enabled = false;
                    btnSwap.Enabled = false;
                }
            }
        }

        void LoadDataGridViewNew()
        {
            if (comboNamnew.SelectedIndex != -1 && comboLopnew.SelectedIndex != -1 && comboKhoinew.SelectedIndex != -1)
            {
                int i = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                if (i != -1)
                {
                    dataGridViewnew.DataSource = _ListLopChange[i]._ListLop.ToArray();
                }
                else
                {
                    dataGridViewnew.DataSource = LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString())).ToArray();
                }
                btnAdd.Enabled = true;
                btnSwap.Enabled = true;
            }
            else
            {
                dataGridViewnew.DataSource = new List<usp_SelectHocSinhTheoMALOPResult>();
                btnAdd.Enabled = false;
                btnSwap.Enabled = false;
            }
        }

        //nếu không tồn tại trả về -1, ngược lại trả về index của mã lớp đang tìm trong list
        int CheckExistedInListLopChange(int MaLop)
        {
            for (int i = 0; i < _ListLopChange.Count; i++)
            {
                if (_ListLopChange[i]._MaLop == MaLop)
                    return i;
            }
            return -1;
        }

        //nếu không tồn tại trả về -1, ngược lại trả về index của mã lớp đang tìm trong list
        int CheckExistedInListChuaPhanLopLopChange(string NamHoc)
        {
            for (int i = 0; i < _ListChuaPhanLopChange.Count; i++)
            {
                if (_ListChuaPhanLopChange[i]._NamHoc == NamHoc)
                    return i;
            }
            return -1;
        }

        private void frPhanLop_Load(object sender, EventArgs e)
        {
            LoadDanhSachNam();
            if (comboNamCurrent.Items.Count > 0)
            {
                LoadDanhSachKhoi();
                comboNamCurrent.SelectedIndex = 0;
                comboNamnew.SelectedIndex = 0;
                radioButtonPhanLopHoSo_ChuaPhanLop.Checked = true;
            }
            else
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close();
            }
        }

        #region button
        private void btnAdd_Click(object sender, EventArgs e) //Add HOcSInh
        {
            if (comboNamCurrent.Text == comboNamnew.Text && comboKhoiCurrent.Text == comboKhoinew.Text && comboLopCurrent.Text == comboLopnew.Text)
            {
                MessageBox.Show("Bạn không thể chuyển học sinh trong cùng một lớp", "Error");
            }
            else
            {
                ICollection<int> ListIndexRemove = new List<int>();
                int RemoveIndex = -1;
                foreach (DataGridViewRow row in dataGridViewcurrent.SelectedRows)
                {
                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                    {
                        int i = CheckExistedInListChuaPhanLopLopChange(comboNamCurrent.Text);
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        //Đã tồn tại
                        if (i != -1)
                        {
                            //Đã tồn tại
                            if (j != -1)
                            {
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[i]._List[row.Index].MAHOCSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[i]._List[row.Index].HOTEN;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[i]._List[row.Index].EMAIL;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[i]._List[row.Index].DIACHI;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[i]._List[row.Index].NGAYSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[i]._List[row.Index].GIOITINH;
                            }
                            else
                            {

                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                int index = _ListLopChange.Count - 1;
                                if (_ListLopChange[index]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[index]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[i]._List[row.Index].MAHOCSINH;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[i]._List[row.Index].HOTEN;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[i]._List[row.Index].EMAIL;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[i]._List[row.Index].DIACHI;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[i]._List[row.Index].NGAYSINH;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[i]._List[row.Index].GIOITINH;
                            }
                            RemoveIndex = i;

                        }
                        else
                        {
                            _ListChuaPhanLopChange.Add(new CChuaPhanLopChange(comboNamCurrent.Text, LoadDanhSachHocSinhChuaPhanLop(comboNamCurrent.Text)));
                            int index = _ListChuaPhanLopChange.Count - 1;
                            //Đã tồn tại
                            if (j != -1)
                            {
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[index]._List[row.Index].MAHOCSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[index]._List[row.Index].HOTEN;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[index]._List[row.Index].EMAIL;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[index]._List[row.Index].DIACHI;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[index]._List[row.Index].NGAYSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[index]._List[row.Index].GIOITINH;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                int index2 = _ListLopChange.Count - 1;

                                if (_ListLopChange[index2]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[index2]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[index]._List[row.Index].MAHOCSINH;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[index]._List[row.Index].HOTEN;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[index]._List[row.Index].EMAIL;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[index]._List[row.Index].DIACHI;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[index]._List[row.Index].NGAYSINH;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[index]._List[row.Index].GIOITINH;
                            }
                            RemoveIndex = index;
                        }
                    }
                    else
                    {
                        int i = CheckExistedInListLopChange(int.Parse(comboLopCurrent.Tag.ToString()));
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        if (i != -1)
                        {
                            if (j != -1)
                            {
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(_ListLopChange[i]._ListLop[row.Index]);
                            }
                            else
                            {

                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[i]._ListLop[row.Index]);
                            }
                            RemoveIndex = i;
                        }
                        else
                        {
                            if (j != -1)
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), temp));
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(temp[row.Index]);
                                RemoveIndex = _ListLopChange.Count - 1;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()))));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[_ListLopChange.Count - 2]._ListLop[row.Index]);
                                RemoveIndex = _ListLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove.Add(row.Index);
                }

                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                {
                    foreach (int index in ListIndexRemove.OrderByDescending(v => v))
                    {
                        _ListChuaPhanLopChange[RemoveIndex]._List.RemoveAt(index);
                    }
                }
                else
                {
                    foreach (int index in ListIndexRemove.OrderByDescending(v => v))
                    {
                        _ListLopChange[RemoveIndex]._ListLop.RemoveAt(index);
                    }
                }

                LoadDataGridViewCurrent();
                LoadDataGridViewNew();
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (comboNamCurrent.Text == comboNamnew.Text && comboKhoiCurrent.Text == comboKhoinew.Text && comboLopCurrent.Text == comboLopnew.Text)
            {
                MessageBox.Show("Bạn không thể chuyển học sinh trong cùng một lớp", "Error");
            }
            else
            {
                ICollection<int> ListIndexRemove1 = new List<int>();
                int RemoveIndex1 = -1;
                ICollection<int> ListIndexRemove2 = new List<int>();
                int RemoveIndex2 = -1;
                foreach (DataGridViewRow row in dataGridViewcurrent.SelectedRows)
                {
                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                    {
                        int i = CheckExistedInListChuaPhanLopLopChange(comboNamCurrent.Text);
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        //Đã tồn tại
                        if (i != -1)
                        {
                            //Đã tồn tại
                            if (j != -1)
                            {
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[i]._List[row.Index].MAHOCSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[i]._List[row.Index].HOTEN;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[i]._List[row.Index].EMAIL;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[i]._List[row.Index].DIACHI;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[i]._List[row.Index].NGAYSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[i]._List[row.Index].GIOITINH;
                            }
                            else
                            {

                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                int index = _ListLopChange.Count - 1;
                                if (_ListLopChange[index]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[index]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[i]._List[row.Index].MAHOCSINH;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[i]._List[row.Index].HOTEN;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[i]._List[row.Index].EMAIL;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[i]._List[row.Index].DIACHI;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[i]._List[row.Index].NGAYSINH;
                                _ListLopChange[index]._ListLop[_ListLopChange[index]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[i]._List[row.Index].GIOITINH;
                            }
                            RemoveIndex1 = i;

                        }
                        else
                        {
                            _ListChuaPhanLopChange.Add(new CChuaPhanLopChange(comboNamCurrent.Text, LoadDanhSachHocSinhChuaPhanLop(comboNamCurrent.Text)));
                            int index = _ListChuaPhanLopChange.Count - 1;
                            //Đã tồn tại
                            if (j != -1)
                            {
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[index]._List[row.Index].MAHOCSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[index]._List[row.Index].HOTEN;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[index]._List[row.Index].EMAIL;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[index]._List[row.Index].DIACHI;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[index]._List[row.Index].NGAYSINH;
                                _ListLopChange[j]._ListLop[_ListLopChange[j]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[index]._List[row.Index].GIOITINH;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                int index2 = _ListLopChange.Count - 1;

                                if (_ListLopChange[index2]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[index2]._ListLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].MAHOCSINH = _ListChuaPhanLopChange[index]._List[row.Index].MAHOCSINH;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].HOTEN = _ListChuaPhanLopChange[index]._List[row.Index].HOTEN;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].EMAIL = _ListChuaPhanLopChange[index]._List[row.Index].EMAIL;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].DIACHI = _ListChuaPhanLopChange[index]._List[row.Index].DIACHI;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].NGAYSINH = _ListChuaPhanLopChange[index]._List[row.Index].NGAYSINH;
                                _ListLopChange[index2]._ListLop[_ListLopChange[index2]._ListLop.Count - 1].GIOITINH = _ListChuaPhanLopChange[index]._List[row.Index].GIOITINH;
                            }
                            RemoveIndex1 = index;
                        }
                    }
                    else
                    {
                        int i = CheckExistedInListLopChange(int.Parse(comboLopCurrent.Tag.ToString()));
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        if (i != -1)
                        {
                            if (j != -1)
                            {
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(_ListLopChange[i]._ListLop[row.Index]);
                            }
                            else
                            {

                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[i]._ListLop[row.Index]);
                            }
                            RemoveIndex1 = i;
                        }
                        else
                        {
                            if (j != -1)
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), temp));
                                if (_ListLopChange[j]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[j]._ListLop.Add(temp[row.Index]);
                                RemoveIndex1 = _ListLopChange.Count - 1;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()))));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count == _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[_ListLopChange.Count - 2]._ListLop[row.Index]);
                                RemoveIndex1 = _ListLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove1.Add(row.Index);
                }

                foreach (DataGridViewRow row in dataGridViewnew.SelectedRows)
                {

                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                    {
                        int i = CheckExistedInListChuaPhanLopLopChange(comboNamCurrent.Text);
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        //Đã tồn tại
                        if (i != -1)
                        {
                            //Đã tồn tại
                            if (j != -1)
                            {
                                _ListChuaPhanLopChange[i]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].MAHOCSINH = _ListLopChange[j]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].HOTEN = _ListLopChange[j]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].EMAIL = _ListLopChange[j]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].NGAYSINH = _ListLopChange[j]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].DIACHI = _ListLopChange[j]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].GIOITINH = _ListLopChange[j]._ListLop[row.Index].GIOITINH;
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                _ListChuaPhanLopChange[i]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].MAHOCSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].HOTEN = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].EMAIL = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].NGAYSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].DIACHI = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].GIOITINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].GIOITINH;
                                RemoveIndex2 = _ListLopChange.Count - 1;
                            }

                        }
                        else
                        {
                            if (j != -1)
                            {
                                _ListChuaPhanLopChange.Add(new CChuaPhanLopChange(comboNamCurrent.Text, LoadDanhSachHocSinhChuaPhanLop(comboNamCurrent.Text)));
                                _ListChuaPhanLopChange[_ListChuaPhanLopChange.Count - 1]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                int index = _ListChuaPhanLopChange.Count - 1;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].MAHOCSINH = _ListLopChange[j]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].HOTEN = _ListLopChange[j]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].EMAIL = _ListLopChange[j]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].NGAYSINH = _ListLopChange[j]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].DIACHI = _ListLopChange[j]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].GIOITINH = _ListLopChange[j]._ListLop[row.Index].GIOITINH;
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                _ListChuaPhanLopChange.Add(new CChuaPhanLopChange(comboNamCurrent.Text, LoadDanhSachHocSinhChuaPhanLop(comboNamCurrent.Text)));
                                int index = _ListChuaPhanLopChange.Count - 1;
                                _ListChuaPhanLopChange[index]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].MAHOCSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].HOTEN = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].EMAIL = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].NGAYSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].DIACHI = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].GIOITINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].GIOITINH;
                                RemoveIndex2 = _ListLopChange.Count - 1;
                            }
                        }
                    }
                    else
                    {
                        int i = CheckExistedInListLopChange(int.Parse(comboLopCurrent.Tag.ToString()));
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        if (i != -1)
                        {
                            if (j != -1)
                            {
                                if (_ListLopChange[i]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[i]._ListLop.Add(_ListLopChange[j]._ListLop[row.Index]);
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                if (_ListLopChange[i]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[i]._ListLop.Add(_ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index]);
                                RemoveIndex2 = _ListLopChange.Count - 1;
                            }
                        }
                        else
                        {
                            if (j != -1)
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), temp));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[j]._ListLop[row.Index]);
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()))));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[_ListLopChange.Count - 2]._ListLop[row.Index]);
                                RemoveIndex2 = _ListLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove2.Add(row.Index);
                }

                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                {
                    foreach (int index in ListIndexRemove1.OrderByDescending(v => v))
                    {
                        _ListChuaPhanLopChange[RemoveIndex1]._List.RemoveAt(index);
                    }
                    foreach (int index in ListIndexRemove2.OrderByDescending(v => v))
                    {
                        _ListLopChange[RemoveIndex2]._ListLop.RemoveAt(index);
                    }
                }
                else
                {
                    foreach (int index in ListIndexRemove1.OrderByDescending(v => v))
                    {
                        _ListLopChange[RemoveIndex1]._ListLop.RemoveAt(index);
                    }

                    foreach (int index in ListIndexRemove2.OrderByDescending(v => v))
                    {
                        _ListLopChange[RemoveIndex2]._ListLop.RemoveAt(index);
                    }
                }

                LoadDataGridViewCurrent();
                LoadDataGridViewNew();
            
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) //Remove HS
        {
            if (comboNamCurrent.Text == comboNamnew.Text && comboKhoiCurrent.Text == comboKhoinew.Text && comboLopCurrent.Text == comboLopnew.Text)
            {
                MessageBox.Show("Bạn không thể chuyển học sinh trong cùng một lớp", "Error");
            }
            else
            {
                ICollection<int> ListIndexRemove = new List<int>();
                int RemoveIndex = -1;
                foreach (DataGridViewRow row in dataGridViewnew.SelectedRows)
                {

                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                    {
                        int i = CheckExistedInListChuaPhanLopLopChange(comboNamCurrent.Text);
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        //Đã tồn tại
                        if (i != -1)
                        {
                            //Đã tồn tại
                            if (j != -1)
                            {
                                _ListChuaPhanLopChange[i]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].MAHOCSINH = _ListLopChange[j]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].HOTEN = _ListLopChange[j]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].EMAIL = _ListLopChange[j]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].NGAYSINH = _ListLopChange[j]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].DIACHI = _ListLopChange[j]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].GIOITINH = _ListLopChange[j]._ListLop[row.Index].GIOITINH;
                                RemoveIndex = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                _ListChuaPhanLopChange[i]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].MAHOCSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].HOTEN = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].EMAIL = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].NGAYSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].DIACHI = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[i]._List[_ListChuaPhanLopChange[i]._List.Count - 1].GIOITINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].GIOITINH;
                                RemoveIndex = _ListLopChange.Count - 1;
                            }

                        }
                        else
                        {
                            if (j != -1)
                            {
                                _ListChuaPhanLopChange.Add(new CChuaPhanLopChange(comboNamCurrent.Text, LoadDanhSachHocSinhChuaPhanLop(comboNamCurrent.Text)));
                                _ListChuaPhanLopChange[_ListChuaPhanLopChange.Count - 1]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                int index = _ListChuaPhanLopChange.Count - 1;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].MAHOCSINH = _ListLopChange[j]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].HOTEN = _ListLopChange[j]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].EMAIL = _ListLopChange[j]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].NGAYSINH = _ListLopChange[j]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].DIACHI = _ListLopChange[j]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].GIOITINH = _ListLopChange[j]._ListLop[row.Index].GIOITINH;
                                RemoveIndex = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                _ListChuaPhanLopChange.Add(new CChuaPhanLopChange(comboNamCurrent.Text, LoadDanhSachHocSinhChuaPhanLop(comboNamCurrent.Text)));
                                int index = _ListChuaPhanLopChange.Count - 1;
                                _ListChuaPhanLopChange[index]._List.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].MAHOCSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].MAHOCSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].HOTEN = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].HOTEN;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].EMAIL = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].EMAIL;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].NGAYSINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].NGAYSINH;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].DIACHI = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].DIACHI;
                                _ListChuaPhanLopChange[index]._List[_ListChuaPhanLopChange[index]._List.Count - 1].GIOITINH = _ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index].GIOITINH;
                                RemoveIndex = _ListLopChange.Count - 1;
                            }
                        }
                    }
                    else
                    {
                        int i = CheckExistedInListLopChange(int.Parse(comboLopCurrent.Tag.ToString()));
                        int j = CheckExistedInListLopChange(int.Parse(comboLopnew.Tag.ToString()));
                        if (i != -1)
                        {
                            if (j != -1)
                            {
                                if (_ListLopChange[i]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[i]._ListLop.Add(_ListLopChange[j]._ListLop[row.Index]);
                                RemoveIndex = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                if (_ListLopChange[i]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[i]._ListLop.Add(_ListLopChange[_ListLopChange.Count - 1]._ListLop[row.Index]);
                                RemoveIndex = _ListLopChange.Count - 1;
                            }
                        }
                        else
                        {
                            if (j != -1)
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), temp));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[j]._ListLop[row.Index]);
                                RemoveIndex = j;
                            }
                            else
                            {
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopnew.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopnew.Tag.ToString()))));
                                _ListLopChange.Add(new CLopChange(int.Parse(comboLopCurrent.Tag.ToString()), LoadDanhSachHocSinhTheoMaLop(int.Parse(comboLopCurrent.Tag.ToString()))));
                                if (_ListLopChange[_ListLopChange.Count - 1]._ListLop.Count >= _QuiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _QuiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _ListLopChange[_ListLopChange.Count - 1]._ListLop.Add(_ListLopChange[_ListLopChange.Count - 2]._ListLop[row.Index]);
                                RemoveIndex = _ListLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove.Add(row.Index);
                }

                foreach (int index in ListIndexRemove.OrderByDescending(v => v))
                {
                    _ListLopChange[RemoveIndex]._ListLop.RemoveAt(index);
                }
                LoadDataGridViewCurrent();
                LoadDataGridViewNew();
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (CLopChange lop in _ListLopChange)
            {
                foreach (usp_SelectHocSinhTheoMALOPResult hs in lop._ListLop)
                {
                    string temp = _LopBus.LayNamHocTheoMaLop(lop._MaLop);
                    int _MalopCu = _XepBus.TimMaLopTheoMaHS_NamHoc(hs.MAHOCSINH, _LopBus.LayNamHocTheoMaLop(lop._MaLop));
                    if (_MalopCu != -1)
                    {
                        _XepBus.Update(hs.MAHOCSINH, _MalopCu, hs.MAHOCSINH, lop._MaLop);
                    }
                    else
                    {
                        _XepBus.Insert(hs.MAHOCSINH, lop._MaLop);
                    }
                }
            }


            foreach (CChuaPhanLopChange c in _ListChuaPhanLopChange)
            {
                foreach (usp_SelectHocSinhChuaPhanLopResult hs in c._List)
                {
                    int _MaLop = _XepBus.TimMaLopTheoMaHS_NamHoc(hs.MAHOCSINH, c._NamHoc);
                    if (_MaLop != -1)
                    {
                        _XepBus.Delete(hs.MAHOCSINH, _MaLop);
                    }
                }
            }
            MessageBox.Show("Lưu thành công", "Success");
            _ListLopChange.Clear();
            _ListChuaPhanLopChange.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (_ListChuaPhanLopChange.Count == 0 && _ListLopChange.Count == 0)
            {
                if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát!", "THOÁT ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Dữ liệu có thay đổi, bạn có muốn lưu lại ko?", "Exit", MessageBoxButtons.YesNoCancel);
                if (dr != DialogResult.Cancel)
                {
                    if (DialogResult.Yes == dr)
                    {
                        btnSave_Click(sender, e);
                    }
                    this.Close();
                }
            }
        }
        #endregion

        #region chọn combobox
        private void comboNamhocCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                comboKhoiCurrent.SelectedIndex = -1;
                comboLopCurrent.SelectedIndex = -1;
                comboNamnew.SelectedIndex = comboNamCurrent.SelectedIndex;
            }
            else
            {
                if (radioButtonChuyenLopCungKhoi.Checked)
                {
                    comboNamnew.SelectedIndex = comboNamCurrent.SelectedIndex;
                }
                comboKhoiCurrent.SelectedIndex = -1;
                comboKhoiCurrent.SelectedIndex = 0;
            }
            LoadDataGridViewCurrent();
        }

        private void comboNamHocnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboKhoinew.SelectedIndex = -1;
            comboKhoinew.SelectedIndex = 0;
            LoadDataGridViewNew();
        }

        private void comboKhoiCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                if (index == comboKhoiCurrent.SelectedIndex)
                {
                    comboKhoiCurrent.Tag = khoi.MAKHOI;

                }
                index++;
            }
            if (comboKhoiCurrent.SelectedIndex != -1)
            {
                LoadDanhSachLopCu();
                if (comboLopCurrent.Items.Count > 0)
                {
                    comboLopCurrent.SelectedIndex = -1;
                    comboLopCurrent.SelectedIndex = 0;
                }

            }
            LoadDataGridViewCurrent();
        }

        private void comboKhoinew_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (usp_SelectKhoisAllResult khoi in _KBUS.LayDanhSachKhoi())
            {
                if (index == comboKhoinew.SelectedIndex)
                {
                    comboKhoinew.Tag = khoi.MAKHOI;

                }
                index++;
            }

            LoadDanhSachLopMoi();
            if (comboLopnew.Items.Count > 0)
            {
                comboLopnew.SelectedIndex = -1;
                comboLopnew.SelectedIndex = 0;
            }
            LoadDataGridViewNew();
        }

        private void comboLopCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoiCurrent.Tag.ToString(), comboNamCurrent.Text))
            {
                if (index == comboLopCurrent.SelectedIndex)
                {
                    comboLopCurrent.Tag = lop.MALOP;
                    break;
                }

                index++;
            }
            if (comboLopCurrent.SelectedIndex != -1)
                LoadDataGridViewCurrent();
        }

        private void comboLopnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBus.LayDanhSachLopTheoKhoiMaNam(comboKhoinew.Tag.ToString(), comboNamnew.Text))
            {
                if (index == comboLopnew.SelectedIndex)
                {
                    comboLopnew.Tag = lop.MALOP;
                    break;
                }

                index++;
            }

            LoadDataGridViewNew();
        }
        #endregion

        #region radioButton
        private void radioButtonPhanLopHoSo_ChuaPhanLop_CheckedChanged(object sender, EventArgs e)
        {
            comboLopCurrent.Enabled = false;
            comboKhoiCurrent.Enabled = false;
            comboNamnew.Enabled = false;
            comboKhoinew.Enabled = true;
            comboKhoiCurrent.SelectedIndex = -1;
            comboLopCurrent.SelectedIndex = -1;
            comboNamnew.SelectedIndex = comboNamCurrent.SelectedIndex;
            LoadDataGridViewCurrent();
        }

        private void radioButtonChuyenLopCungKhoi_CheckedChanged(object sender, EventArgs e)
        {
            comboLopCurrent.Enabled = true;
            comboKhoiCurrent.Enabled = true;
            comboNamnew.Enabled = false;
            if (comboKhoiCurrent.SelectedIndex == -1)
                comboKhoiCurrent.SelectedIndex = 0;
            comboNamnew.SelectedIndex = comboNamCurrent.SelectedIndex;
        }
        #endregion

        private void dataGridViewcurrent_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                dataGridViewcurrent.Columns["MAHOCSINH"].Visible = false;
                for (int i = 0; i < dataGridViewcurrent.Rows.Count; i++)
                {
                    dataGridViewcurrent.Rows[i].Cells["STT"].Value = i + 1;
                }
            }
            catch { }
        }

        private void dataGridViewnew_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                dataGridViewnew.Columns["MAHOCSINH"].Visible = false;
                for (int i = 0; i < dataGridViewnew.Rows.Count; i++)
                {
                    dataGridViewnew.Rows[i].Cells["STT1"].Value = i + 1;
                }
            }
            catch { }
        }


        #endregion
    }
}