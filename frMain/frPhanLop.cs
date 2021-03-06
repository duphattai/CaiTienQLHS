﻿using System;
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
    public partial class FormPhanLop : DevExpress.XtraEditors.XtraForm
    {
        #region Biến toàn cục
        private NamHoc_BUS _namHocBus = new NamHoc_BUS(); // biến dùng để truy xuất bảng NAMHOC từ database
        private Khoi_BUS _khoiBus = new Khoi_BUS(); // truy xuất bảng KHOI
        private DanhSachLop_BUS _danhSachLopBus = new DanhSachLop_BUS(); 
        private XepLop_BUS _xepLopBus = new XepLop_BUS(); // truy xuất bảng XEPLOP
        private HoSoHocSinh_BUS _hoSoHocSinhBus = new HoSoHocSinh_BUS(); // truy xuất bảng HOSOHOCSINH
        private QuiDinh_BUS _quiDinhBus = new QuiDinh_BUS();// truy xuất bảng QUIDINH

        List<CLopChange> _listLopChange = new List<CLopChange>(); // lưu danh sách lớp có danh sách học sinh bi thay đổi (sự thay đổi chưa được lưu xuống database)
        List<CChuaPhanLopChange> _listChuaPhanLopChange = new List<CChuaPhanLopChange>(); // lưu danh sách hoc sinh chưa phân lớp bị thay đối  (sự thay đổi chưa được lưu xuống database)
        #endregion

        public FormPhanLop()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bắt sự kiện khi form PhanLop được load lên, nếu tồn tại năm học thì sẽ cho phép mở, không thì sẽ đóng form lại.
        /// </summary>
        private void formPhanLop_Load(object sender, EventArgs e)
        {
            loadDanhSachNam();

            // kiểm tra xem năm học có tồn tại không
            if (comBoBoxNamCurrent.Items.Count > 0)
            {
                loadDanhSachKhoi();
                comBoBoxNamCurrent.SelectedIndex = 0;// thiết lập chọn item có index = 0
                comBoBoxNamHocMoi.SelectedIndex = 0;// thiết lập chọn item có index = 0
                radioButtonPhanLopHoSo_ChuaPhanLop.Checked = true; // thiết lập mặc định chọn danh sách hoc sinh chưa phân lớp
            }
            else
            {
                MessageBox.Show("Bạn hiện không có năm học nào trong cơ sở dữ liệu", "Error");
                this.Close(); // đóng form vừa mở
            }
        }
     
        #region Wrap Class

        // Đối tương dùng để chứa danh sách học sinh theo lớp
        public class CLopChange
        {
            public int maLop;
            public List<usp_SelectHocSinhTheoMALOPResult> listLop; // danh sách học sinh lấy từ database theo mã lớp

            public CLopChange(int maLop, List<usp_SelectHocSinhTheoMALOPResult> listLop)
            {
                this.maLop = maLop;
                this.listLop = listLop;
            }
        }

        // Đối tượng dùng để chứa danh sách học sinh chưa phân lớp tương ứng với năm học
        class CChuaPhanLopChange
        {
            public string namHoc;
            public List<usp_SelectHocSinhChuaPhanLopResult> danhSachHocSinh; // dùng để lưu danh sách học sinh theo năm học

            public CChuaPhanLopChange(string namHoc, List<usp_SelectHocSinhChuaPhanLopResult> list)
            {
                this.namHoc = namHoc;
                this.danhSachHocSinh = list;
            }
        }
        #endregion

        #region Các hàm chức năng
        
        /// <summary>
        /// Lấy danh sach năm học từ database sau đó add vào comBoBoxNamHoc
        /// </summary>
        void loadDanhSachNam()
        {
            foreach (NAMHOC NH in _namHocBus.LayNamHoc())
            {
                // add các năm học vào các combobox
                comBoBoxNamCurrent.Items.Add(NH.NAMHOC1.ToString());
                comBoBoxNamHocMoi.Items.Add(NH.NAMHOC1.ToString());
            }
        }

        /// <summary>
        /// Lấy danh sách khối từ database thêm vào comBoBoxKhoi 
        /// </summary>
        void loadDanhSachKhoi()
        {
            // xóa các dữ liệu cũ đã add vào comBoBoxKhoiCurrent và comBoBoxKhoiMoi
            comBoBoxKhoiCurrent.Items.Clear();
            comBoBoxKhoiMoi.Items.Clear();

            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                // add dữ liệu mới vào các combobox
                comBoBoxKhoiCurrent.Items.Add(khoi.KHOI.ToString());
                comBoBoxKhoiMoi.Items.Add(khoi.KHOI.ToString());
            }
        }

        /// <summary>
        /// Lấy danh sach lớp đã có từ database lên thêm vào comBoBoxLopCurrent
        /// </summary>
        void loadDanhSachLopCu()
        {
            comBoBoxLopCurrent.Items.Clear(); // xóa dữ liệu đã thêm vào

            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comBoBoxKhoiCurrent.Tag.ToString(), comBoBoxNamCurrent.Text))
            {
                comBoBoxLopCurrent.Items.Add(lop.TENLOP); // thêm dữ liệu mới vào
            }
        }

        /// <summary>
        /// Lấy danh sách lớp mới từ database thêm vào comBoBoxLopMoi
        /// </summary>
        void loadDanhSachLopMoi()
        {
            comBoBoxLopMoi.Items.Clear(); // xóa dữ liệu cũ đã thêm vào

            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comBoBoxKhoiMoi.Tag.ToString(), comBoBoxNamHocMoi.Text))
            {
                comBoBoxLopMoi.Items.Add(lop.TENLOP); // thêm dữ liệu mới vào
            }
        }

        /// <summary>
        /// Kiểu trả về: List<usp_SelectHocSinhTheoMALOPResult>
        /// Tham số truyền vào là mã lớp theo kiểu chuỗi
        /// Lấy danh sách học sinh từ database theo mã lớp
        /// </summary>
        List<usp_SelectHocSinhTheoMALOPResult> loadDanhSachHocSinhTheoMaLop(int MaLop)
        {
            List<usp_SelectHocSinhTheoMALOPResult> ListHSLop = new List<usp_SelectHocSinhTheoMALOPResult>();
            foreach (usp_SelectHocSinhTheoMALOPResult hs in _danhSachLopBus.LayDanhSachHocSinhTheoMaLop(MaLop))
            {
                ListHSLop.Add(hs);
            }
            return ListHSLop;
        }

        /// <summary>
        /// Kiểu trả về: List<usp_SelectHocSinhChuaPhanLopResult>
        /// Tham số truyền vào là năm học theo kiểu chuỗi
        /// Lấy danh sách học sinh chưa phân lớp theo năm học  từ database
        /// </summary>
        List<usp_SelectHocSinhChuaPhanLopResult> loadDanhSachHocSinhChuaPhanLop(string NamHoc)
        {
            // biến tạm thời dùng lưu trữ dữ liệu lấy từ database
            List<usp_SelectHocSinhChuaPhanLopResult> _ListHS = new List<usp_SelectHocSinhChuaPhanLopResult>();
            foreach (usp_SelectHocSinhChuaPhanLopResult hs in _danhSachLopBus.LayDanhSachHocSinhChuaPhanLop(NamHoc))
            {
                _ListHS.Add(hs); // them dữ liệu vào
            }
            return _ListHS;
        }
        #endregion

        #region Các event của form
        
        /// <summary>
        /// Hiển thị danh sách học sinh lên dataGridViewCurrent tương ứng theo comBoBoxNamCurrent và loại danh sách học sinh(phân lớp và chưa phân lớp)
        /// Nếu là danh sách chưa phân lớp thì chức năng xóa hoặc sắp xếp vào lớp có thể sử dụng, ngược lại thì không.
        /// </summary>
        void loadDataGridViewCurrent()
        {
            // xử lý cho trường hợp danh sách học sinh chưa phân lớp
            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                btnBo.Enabled = true; // bật chức năng button Bỏ
                buttonDoiCho.Enabled = true; // bật chức năng button Đổi Chỗ
                
                int i = checkExistedInListChuaPhanLopLopChange(comBoBoxNamCurrent.Text); // Kiểm tra xem đã tồn tại danh sách hoc sinh chưa phân lớp đã có sự thay đổi hay chưa
                if (i != -1) // nếu tồn tại thì hiển thị danh sách đó lên
                {
                    dataGridViewCurrent.DataSource = _listChuaPhanLopChange[i].danhSachHocSinh.ToArray();// Hiển thị dữ liệu lên datagridview
                }
                else // nếu chưa thì lấy danh sách từ database lên
                {
                    dataGridViewCurrent.DataSource = loadDanhSachHocSinhChuaPhanLop(comBoBoxNamCurrent.Text).ToArray();// Hiển thị dữ liệu lên datagridview
                }
            }
            else // trường hợp danh sách học sinh đã phân lớp rồi
            {
                if (comBoBoxNamCurrent.SelectedIndex != -1 && comBoBoxLopCurrent.SelectedIndex != -1 && comBoBoxKhoiCurrent.SelectedIndex != -1)
                {
                    int i = checkExistedInListLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString())); //Kiểm tra xem tương ứng với lớp học đó thì danh sách hoc sinh có thay đổi chưa (người dùng thay đổi mà chưa lưu lại, còn thay đổi tiếp tục)
                    if (i != -1) // tồn tại thì sẽ lấy danh sách đã thay đổi đó
                    {
                        dataGridViewCurrent.DataSource = _listLopChange[i].listLop.ToArray();
                    }
                    else // không thì lấy từ database lên
                    {
                        dataGridViewCurrent.DataSource = loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString())).ToArray();
                    }

                    btnBo.Enabled = true; // bật chức năng của button bỏ
                    buttonDoiCho.Enabled = true; // bật chức năng của button đổi chỗ
                }
                else
                {
                    dataGridViewCurrent.DataSource = new List<usp_SelectHocSinhTheoMALOPResult>();
                    btnBo.Enabled = false;
                    buttonDoiCho.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Hiển thị danh sách học sinh tương ứng với lớp đã chọn trên comBoBoxLopMoi
        /// </summary>
        void loadDataGridViewNew()
        {
            if (comBoBoxNamHocMoi.SelectedIndex != -1 && comBoBoxLopMoi.SelectedIndex != -1 && comBoBoxKhoiMoi.SelectedIndex != -1)
            {
                int i = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));
                if (i != -1)
                {
                    dataGridViewNew.DataSource = _listLopChange[i].listLop.ToArray(); // Hiển thị dữ liệu lên datagridview
                }
                else
                {
                    dataGridViewNew.DataSource = loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString())).ToArray();// Hiển thị dữ liệu lên datagridview
                }
                buttonThem.Enabled = true;
                buttonDoiCho.Enabled = true;
            }
            else
            {
                dataGridViewNew.DataSource = new List<usp_SelectHocSinhTheoMALOPResult>();
                buttonThem.Enabled = false;
                buttonDoiCho.Enabled = false;
            }
        }

        /// <summary>
        /// Kiểm tra lớp đó có nằm trong danh sách lớp có danh sách học sinh đã bị thay đổi, nếu không tồn tại trả về -1, ngược lại trả về index của mã lớp đã tìm được trong list
        /// </summary>
        int checkExistedInListLopChange(int MaLop)
        {
            for (int i = 0; i < _listLopChange.Count; i++)
            {
                if (_listLopChange[i].maLop == MaLop)
                    return i;
            }
            return -1;
        }

        
        /// <summary>
        /// Kiểm tra trong các năm học thì danh sách học sinh chưa phân lớp ứng với năm học đó có bị thay đổi rồi chưa, nếu không trả về -1, ngược lại trả về index của mã lớp đang tìm trong list
        /// </summary>
        int checkExistedInListChuaPhanLopLopChange(string NamHoc)
        {
            for (int i = 0; i < _listChuaPhanLopChange.Count; i++)
            {
                if (_listChuaPhanLopChange[i].namHoc == NamHoc)
                    return i;
            }
            return -1;
        }

       

        #region button

        // Coder: Tai
        void copyInformationClassFromAnotherClass(usp_SelectHocSinhTheoMALOPResult dest, usp_SelectHocSinhChuaPhanLopResult src)
        {
            dest.DIACHI = src.DIACHI;
            dest.EMAIL = src.EMAIL;
            dest.GIOITINH = src.GIOITINH;
            dest.HOTEN = src.HOTEN;
            dest.MAHOCSINH = src.MAHOCSINH;
            dest.NGAYSINH = src.NGAYSINH;
        }

        // Coder: Tai
        void copyInformationClassFromAnotherClass(usp_SelectHocSinhChuaPhanLopResult dest, usp_SelectHocSinhTheoMALOPResult src)
        {
            dest.DIACHI = src.DIACHI;
            dest.EMAIL = src.EMAIL;
            dest.GIOITINH = src.GIOITINH;
            dest.HOTEN = src.HOTEN;
            dest.MAHOCSINH = src.MAHOCSINH;
            dest.NGAYSINH = src.NGAYSINH;
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi button Thêm được click vào
        /// Thêm học sinh được chọn vào lớp đang thao tác 
        /// </summary>
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (comBoBoxNamCurrent.Text == comBoBoxNamHocMoi.Text && comBoBoxKhoiCurrent.Text == comBoBoxKhoiMoi.Text && comBoBoxLopCurrent.Text == comBoBoxLopMoi.Text)
            {
                MessageBox.Show("Bạn không thể chuyển học sinh trong cùng một lớp", "Error");
            }
            else
            {
                ICollection<int> ListIndexRemove = new List<int>(); // lưu vị trí của học sinh sẽ bị xóa khỏi trên datagridviewcurrent
                int RemoveIndex = -1; // vị trí của học sinh đã được chọn trên datagridview
                foreach (DataGridViewRow row in dataGridViewCurrent.SelectedRows)
                {
                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                    {
                        int i = checkExistedInListChuaPhanLopLopChange(comBoBoxNamCurrent.Text); // kiểm tra danh sách hoc sinh chưa phân lớp có bị thay đổi so với lúc lấy từ database lên chưa
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString())); // kiểm tra lớp đó có danh sách học sinh bị thay đổi so với lúc lấy từ database lên chưa
                        
                        if (i != -1) // danh sách chưa phân lớp đã có sự thay đồi
                        {
                            // danh sách học sinh trong lớp đó đã thay đổi
                            if (j != -1)
                            {
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(new usp_SelectHocSinhTheoMALOPResult()); // add một đối tượng (thông tin học sinh)

                                // Coder: Tài
                                // rút ngắn dòng code
                                // sao chép thông tin học sinh vào đối tượng vừa mới thêm vào
                                copyInformationClassFromAnotherClass(_listLopChange[j].listLop[_listLopChange[j].listLop.Count - 1], _listChuaPhanLopChange[i].danhSachHocSinh[row.Index]);
                            }
                            else // danh sách học sinh trong lớp đó chưa thay đổi
                            {
                                // thêm một lớp có danh sách học sinh bị thay đổi, thông tin danh sách học sinh ban đầu của lớp đó lấy từ database lên
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                int index = _listLopChange.Count - 1;
                                if (_listLopChange[index].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[index].listLop.Add(new usp_SelectHocSinhTheoMALOPResult()); // trong lớp vừa thêm vào, thêm một đối tượng (thông tin học sinh) vào danh sách lớp đó
                                
                                // Coder: Tài
                                // rút ngắn dòng code
                                // sao chép dữ liệu học sinh vào đối tượng (thông tin học sinh) vừa mới thêm vào
                                copyInformationClassFromAnotherClass(_listLopChange[index].listLop[_listLopChange[index].listLop.Count - 1], _listChuaPhanLopChange[i].danhSachHocSinh[row.Index]);
                            }
                            RemoveIndex = i; // dùng để lưu vị trí học sinh chọn trên datagridview chút nữa sẽ xóa khỏi datagridview 

                        }
                        else// danh sách chưa phân lớp không có sự thay đồi
                        {
                            // thêm một danh sách học sinh chưa phân lớp tương ứng với năm học
                            _listChuaPhanLopChange.Add(new CChuaPhanLopChange(comBoBoxNamCurrent.Text, loadDanhSachHocSinhChuaPhanLop(comBoBoxNamCurrent.Text)));
                            int index = _listChuaPhanLopChange.Count - 1;

                            if (j != -1) // danh sách học sinh trong lớp đó đã thay đổi
                            {
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(new usp_SelectHocSinhTheoMALOPResult()); // thêm đối tượng(thông tin học sinh)

                                // Coder: Tài
                                // rút ngắn dòng code
                                // sao chép thông tin học sinh vào đối tượng vừa thêm
                                copyInformationClassFromAnotherClass(_listLopChange[j].listLop[_listLopChange[j].listLop.Count - 1], _listChuaPhanLopChange[index].danhSachHocSinh[row.Index]);
                            }
                            else// danh sách học sinh trong lớp đó chưa thay đổi
                            {
                                // thêm một lớp có danh sách học sinh sẽ bị thay đổi, với danh sách ban đầu lấy từ database lên
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                int index2 = _listLopChange.Count - 1;

                                if (_listLopChange[index2].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[index2].listLop.Add(new usp_SelectHocSinhTheoMALOPResult());// thêm đôi tượng (thông tin học sinh)

                                // Coder: Tài
                                // rút ngắn dòng code
                                // sao chép thông tin học sinh vào đối tượng vừa thêm
                                copyInformationClassFromAnotherClass(_listLopChange[index2].listLop[_listLopChange[index2].listLop.Count - 1], _listChuaPhanLopChange[index].danhSachHocSinh[row.Index]);
                            }
                            RemoveIndex = index;
                        }
                    }
                    else // xử lý đổi với danh sách học sinh đã phân lớp
                    {
                        int i = checkExistedInListLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString())); // Kiểm tra lớp đó danh sách học sinh bị thay đổi chưa
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));// Kiểm tra lớp đó danh sách học sinh bị thay đổi chưa
                        if (i != -1) // danh sách lớp current đã bị thay đổi
                        {
                            if (j != -1) // danh sách lớp mới đã bị thay đổi
                            {
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(_listLopChange[i].listLop[row.Index]); // thêm học sinh vào lớp mới
                            }
                            else// danh sách lớp mới chưa thay đổi
                            {
                                // thêm một lớp có danh sách bị thay đổi, danh sách ban đầu lấy từ database lên
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[i].listLop[row.Index]); // thêm học sinh vào lớp mới
                            }
                            RemoveIndex = i; // vị trí học sinh bên lớp current sẽ bị xóa khỏi datagridviewcurrent
                        }
                        else// danh sách lớp current chưa thay đổi
                        {
                            if (j != -1)// danh sách lớp mới đã bị thay đổi
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()));// lưu danh sách học sinh theo lớp current được lấy lên từ database 
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), temp)); // thêm vào lớp có danh sách học sinh bị thay đổi 
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(temp[row.Index]); // thêm học sinh vào bên lớp mới
                                RemoveIndex = _listLopChange.Count - 1;// học sinh được chọn sẽ xóa khỏi bên lớp current
                            }
                            else // danh sách lớp mới chưa thay đổi
                            {
                                // thêm lớp có danh sách học sinh bị thay đổi
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()))));
                                // thêm lớp có danh sách học sinh bị thay đổi
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[_listLopChange.Count - 2].listLop[row.Index]);
                                RemoveIndex = _listLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove.Add(row.Index); // thêm vị trí học sinh sẽ bị xóa khỏi datagridviewcurrent
                }

                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                {
                    // xóa (cập nhật) danh sách học sinh chưa phân lớp
                    foreach (int index in ListIndexRemove.OrderByDescending(v => v))
                    {
                        _listChuaPhanLopChange[RemoveIndex].danhSachHocSinh.RemoveAt(index);
                    }
                }
                else
                {
                    // xóa (cập nhật) danh sách học sinh đã phân lớp
                    foreach (int index in ListIndexRemove.OrderByDescending(v => v))
                    {
                        _listLopChange[RemoveIndex].listLop.RemoveAt(index);
                    }
                }

                loadDataGridViewCurrent(); // hiển thị lai danh sách học sinh
                loadDataGridViewNew();// hiển thị lai danh sách học sinh
            }
        }


        /// <summary>
        /// Sự kiện: bắt sự kiện khi button Đỗi Chỗ được click
        /// Chuyển thông tin học sinh được chọn giữa dataGridViewCurrent và học sinh được chọn từ dataGridViewNew và ngược lại.
        /// </summary>
        private void buttonDoiCho_Click(object sender, EventArgs e)
        {
            // Nếu là học sinh cùng 1 lớp thì không thực hiện được
            if (comBoBoxNamCurrent.Text == comBoBoxNamHocMoi.Text && comBoBoxKhoiCurrent.Text == comBoBoxKhoiMoi.Text && comBoBoxLopCurrent.Text == comBoBoxLopMoi.Text)
            {
                MessageBox.Show("Bạn không thể chuyển học sinh trong cùng một lớp", "Error");
            }
            else
            {
                ICollection<int> ListIndexRemove1 = new List<int>(); // lưu các vị trí học sinh đã chọn trên datagridviewCurrent sẽ bị xóa
                int RemoveIndex1 = -1;
                ICollection<int> ListIndexRemove2 = new List<int>();// lưu các vị trí học sinh đã chọn trên datagridviewMoi sẽ bị xóa
                int RemoveIndex2 = -1;


                foreach (DataGridViewRow row in dataGridViewCurrent.SelectedRows)
                {
                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked) // xử lý vơi trường hợp danh sách học sinh chưa phân lớp
                    {
                        int i = checkExistedInListChuaPhanLopLopChange(comBoBoxNamCurrent.Text);
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));
                        //Danh sách hoc sinh chua phan lop đã bị thay đổi
                        if (i != -1)
                        {
                            //Lớp có danh sách đã bị thay đổi
                            if (j != -1)
                            {
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listLopChange[j].listLop[_listLopChange[j].listLop.Count - 1], _listChuaPhanLopChange[i].danhSachHocSinh[row.Index]);
                            }
                            else//Lớp có danh sách chưa thay đổi
                            {
                                // thêm lớp đó vào danh sách lớp có danh sách học sinh bị thay đổi
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                int index = _listLopChange.Count - 1;
                                if (_listLopChange[index].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }


                                _listLopChange[index].listLop.Add(new usp_SelectHocSinhTheoMALOPResult()); // thêm học sinh vào lớp 
                                // Coder: Tài
                                // rút ngắn dòng code
                                // cập thông tin học sinh vừa mới thêm vào lớp 
                                copyInformationClassFromAnotherClass(_listLopChange[index].listLop[_listLopChange[index].listLop.Count - 1], _listChuaPhanLopChange[i].danhSachHocSinh[row.Index]);
                            }

                            RemoveIndex1 = i; // vị trí hoc sinh sẽ bị xóa khỏi datagridviewcurrent
                        }
                        else // danh sách chưa bị thay đổi
                        {
                            _listChuaPhanLopChange.Add(new CChuaPhanLopChange(comBoBoxNamCurrent.Text, loadDanhSachHocSinhChuaPhanLop(comBoBoxNamCurrent.Text)));
                            int index = _listChuaPhanLopChange.Count - 1;
                            //Lớp có danh sách bị thay đổi 
                            if (j != -1)
                            {
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listLopChange[j].listLop[_listLopChange[j].listLop.Count - 1], _listChuaPhanLopChange[index].danhSachHocSinh[row.Index]);
                            }
                            else//Lớp có danh sách chưa thay đổi 
                            {
                                // thêm lớp đó vào danh sách lớp có danh sách học sinh bị thay đổi
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                int index2 = _listLopChange.Count - 1;

                                if (_listLopChange[index2].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[index2].listLop.Add(new usp_SelectHocSinhTheoMALOPResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listLopChange[index2].listLop[_listLopChange[index2].listLop.Count - 1], _listChuaPhanLopChange[index].danhSachHocSinh[row.Index]);
                            }
                            RemoveIndex1 = index;
                        }
                    }
                    else// xử lý vơi trường hợp danh sách học sinh đã phân lớp
                    {
                        int i = checkExistedInListLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()));
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));
                        if (i != -1) // danh sách học sinh bên lớp current đã bị thay đổi
                        {
                            if (j != -1) // danh sách học sinh bên lớp mới đã bị thay đổi
                            {
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(_listLopChange[i].listLop[row.Index]);
                            }
                            else // danh sách học sinh bên lớp mởi chưa thay đổi
                            {

                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[i].listLop[row.Index]);
                            }
                            RemoveIndex1 = i;
                        }
                        else // danh sách học sinh bên lớp current chưa thay đổi
                        {
                            if (j != -1)
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()));
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), temp));
                                if (_listLopChange[j].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[j].listLop.Add(temp[row.Index]);
                                RemoveIndex1 = _listLopChange.Count - 1;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()))));
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count == _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[_listLopChange.Count - 2].listLop[row.Index]);
                                RemoveIndex1 = _listLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove1.Add(row.Index); // thêm vị trí học sinh đã chọn trên datagridviewcurrent
                }

                foreach (DataGridViewRow row in dataGridViewNew.SelectedRows)
                {

                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                    {
                        int i = checkExistedInListChuaPhanLopLopChange(comBoBoxNamCurrent.Text);
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));
                        //Đã tồn tại
                        if (i != -1)
                        {
                            //Đã tồn tại
                            if (j != -1)
                            {
                                _listChuaPhanLopChange[i].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[i].danhSachHocSinh[_listChuaPhanLopChange[i].danhSachHocSinh.Count - 1], _listLopChange[j].listLop[row.Index]);
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                _listChuaPhanLopChange[i].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[i].danhSachHocSinh[_listChuaPhanLopChange[i].danhSachHocSinh.Count - 1], _listLopChange[_listLopChange.Count - 1].listLop[row.Index]);
                               
                                RemoveIndex2 = _listLopChange.Count - 1;
                            }

                        }
                        else
                        {
                            if (j != -1)
                            {
                                _listChuaPhanLopChange.Add(new CChuaPhanLopChange(comBoBoxNamCurrent.Text, loadDanhSachHocSinhChuaPhanLop(comBoBoxNamCurrent.Text)));
                                _listChuaPhanLopChange[_listChuaPhanLopChange.Count - 1].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                int index = _listChuaPhanLopChange.Count - 1;
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[index].danhSachHocSinh[_listChuaPhanLopChange[index].danhSachHocSinh.Count - 1], _listLopChange[j].listLop[row.Index]);
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                _listChuaPhanLopChange.Add(new CChuaPhanLopChange(comBoBoxNamCurrent.Text, loadDanhSachHocSinhChuaPhanLop(comBoBoxNamCurrent.Text)));
                                int index = _listChuaPhanLopChange.Count - 1;
                                _listChuaPhanLopChange[index].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[index].danhSachHocSinh[_listChuaPhanLopChange[index].danhSachHocSinh.Count - 1], _listLopChange[_listLopChange.Count - 1].listLop[row.Index]);
                                RemoveIndex2 = _listLopChange.Count - 1;
                            }
                        }
                    }
                    else
                    {
                        int i = checkExistedInListLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()));
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));
                        if (i != -1)
                        {
                            if (j != -1)
                            {
                                if (_listLopChange[i].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[i].listLop.Add(_listLopChange[j].listLop[row.Index]);
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                if (_listLopChange[i].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[i].listLop.Add(_listLopChange[_listLopChange.Count - 1].listLop[row.Index]);
                                RemoveIndex2 = _listLopChange.Count - 1;
                            }
                        }
                        else
                        {
                            if (j != -1)
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()));
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), temp));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[j].listLop[row.Index]);
                                RemoveIndex2 = j;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()))));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[_listLopChange.Count - 2].listLop[row.Index]);
                                RemoveIndex2 = _listLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove2.Add(row.Index);
                }

                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                {
                    foreach (int index in ListIndexRemove1.OrderByDescending(v => v))
                    {
                        _listChuaPhanLopChange[RemoveIndex1].danhSachHocSinh.RemoveAt(index);
                    }
                    foreach (int index in ListIndexRemove2.OrderByDescending(v => v))
                    {
                        _listLopChange[RemoveIndex2].listLop.RemoveAt(index);
                    }
                }
                else
                {
                    foreach (int index in ListIndexRemove1.OrderByDescending(v => v))
                    {
                        _listLopChange[RemoveIndex1].listLop.RemoveAt(index);
                    }

                    foreach (int index in ListIndexRemove2.OrderByDescending(v => v))
                    {
                        _listLopChange[RemoveIndex2].listLop.RemoveAt(index);
                    }
                }

                loadDataGridViewCurrent();
                loadDataGridViewNew();
            
            }
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi button Bỏ được click
        /// chuyển học sinh đang được phân lớp sang chưa phân lớp (ứng với radioButtonChuyenLopCungKhoi đã được check) hoặc chuyễn giữa lớp nay sang lớp khác (ứng với radioButtonPhanLopHoSo_ChuaPhanLop đã được chọn) 
        /// </summary>
        private void buttonBo_Click(object sender, EventArgs e) //Remove HS
        {
            if (comBoBoxNamCurrent.Text == comBoBoxNamHocMoi.Text && comBoBoxKhoiCurrent.Text == comBoBoxKhoiMoi.Text && comBoBoxLopCurrent.Text == comBoBoxLopMoi.Text)
            {
                MessageBox.Show("Bạn không thể chuyển học sinh trong cùng một lớp", "Error");
            }
            else
            {
                ICollection<int> ListIndexRemove = new List<int>(); // lưu vị trí các dòng học sinh được chọn trên datagridviewMoi
                int RemoveIndex = -1;
                foreach (DataGridViewRow row in dataGridViewNew.SelectedRows)
                {

                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked) // xử lý cho trường hợp DSHS chưa phân lớp
                    {
                        int i = checkExistedInListChuaPhanLopLopChange(comBoBoxNamCurrent.Text);
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));
                        // DSHS chưa phân lớp đã bị thay đổi
                        if (i != -1)
                        {
                            //Lớp có DSHS bị thay đổi
                            if (j != -1)
                            {
                                _listChuaPhanLopChange[i].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[i].danhSachHocSinh[_listChuaPhanLopChange[i].danhSachHocSinh.Count - 1], _listLopChange[j].listLop[row.Index]);
                                RemoveIndex = j;
                            }
                            else//Lớp có DSHS chưa thay đổi
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                _listChuaPhanLopChange[i].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[i].danhSachHocSinh[_listChuaPhanLopChange[i].danhSachHocSinh.Count - 1], _listLopChange[_listLopChange.Count - 1].listLop[row.Index]);
                                RemoveIndex = _listLopChange.Count - 1;
                            }
                        }
                        else// DSHS chưa phân lớp chưa thay đổi
                        {
                            if (j != -1)
                            {
                                _listChuaPhanLopChange.Add(new CChuaPhanLopChange(comBoBoxNamCurrent.Text, loadDanhSachHocSinhChuaPhanLop(comBoBoxNamCurrent.Text)));
                                _listChuaPhanLopChange[_listChuaPhanLopChange.Count - 1].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                int index = _listChuaPhanLopChange.Count - 1;
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[index].danhSachHocSinh[_listChuaPhanLopChange[index].danhSachHocSinh.Count - 1], _listLopChange[j].listLop[row.Index]);
                                RemoveIndex = j;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                _listChuaPhanLopChange.Add(new CChuaPhanLopChange(comBoBoxNamCurrent.Text, loadDanhSachHocSinhChuaPhanLop(comBoBoxNamCurrent.Text)));
                                int index = _listChuaPhanLopChange.Count - 1;
                                _listChuaPhanLopChange[index].danhSachHocSinh.Add(new usp_SelectHocSinhChuaPhanLopResult());
                                // Coder: Tài
                                // rút ngắn dòng code
                                copyInformationClassFromAnotherClass(_listChuaPhanLopChange[index].danhSachHocSinh[_listChuaPhanLopChange[index].danhSachHocSinh.Count - 1], _listLopChange[_listLopChange.Count - 1].listLop[row.Index]);
                                RemoveIndex = _listLopChange.Count - 1;
                            }
                        }
                    }
                    else // xử lý với trường hợp DSHS đã phân lớp
                    {
                        int i = checkExistedInListLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()));
                        int j = checkExistedInListLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()));
                        if (i != -1)
                        {
                            if (j != -1)
                            {
                                if (_listLopChange[i].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[i].listLop.Add(_listLopChange[j].listLop[row.Index]);
                                RemoveIndex = j;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                if (_listLopChange[i].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[i].listLop.Add(_listLopChange[_listLopChange.Count - 1].listLop[row.Index]);
                                RemoveIndex = _listLopChange.Count - 1;
                            }
                        }
                        else
                        {
                            if (j != -1)
                            {
                                List<usp_SelectHocSinhTheoMALOPResult> temp = loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()));
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), temp));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[j].listLop[row.Index]);
                                RemoveIndex = j;
                            }
                            else
                            {
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopMoi.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopMoi.Tag.ToString()))));
                                _listLopChange.Add(new CLopChange(int.Parse(comBoBoxLopCurrent.Tag.ToString()), loadDanhSachHocSinhTheoMaLop(int.Parse(comBoBoxLopCurrent.Tag.ToString()))));
                                if (_listLopChange[_listLopChange.Count - 1].listLop.Count >= _quiDinhBus.LaySiSoToiDa())
                                {
                                    MessageBox.Show("Sĩ số học sinh của một lớp không thể vượt quá " + _quiDinhBus.LaySiSoToiDa().ToString() + "\nBạn phải sửa qui định nếu muốn thêm vào");
                                    break;
                                }
                                _listLopChange[_listLopChange.Count - 1].listLop.Add(_listLopChange[_listLopChange.Count - 2].listLop[row.Index]);
                                RemoveIndex = _listLopChange.Count - 2;
                            }
                        }
                    }
                    ListIndexRemove.Add(row.Index);
                }

                // xóa các dòng học sinh đã được chọn trên datagridviewMoi
                foreach (int index in ListIndexRemove.OrderByDescending(v => v))
                {
                    _listLopChange[RemoveIndex].listLop.RemoveAt(index);
                }

                // Hiển thị danh sách HS sau khi thay đổi
                loadDataGridViewCurrent(); 
                loadDataGridViewNew();
            }
        
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi button Lưu được chọn
        /// cập nhật dữ liệu vào database
        /// </summary>
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            // duyệt DS lớp có DSHS bị thay đổi
            foreach (CLopChange lop in _listLopChange)
            {
                // duyệt DSHS của lớp
                foreach (usp_SelectHocSinhTheoMALOPResult hs in lop.listLop)
                {
                    //string temp = _DanhSachLopBus.LayNamHocTheoMaLop(lop.MaLop);
                    // Tìm xem học sinh đó ban đầu có thuộc lớp không
                    int _MalopCu = _xepLopBus.TimMaLopTheoMaHS_NamHoc(hs.MAHOCSINH, _danhSachLopBus.LayNamHocTheoMaLop(lop.maLop));
                    if (_MalopCu != -1)// là học sinh cũ
                    {
                        _xepLopBus.Update(hs.MAHOCSINH, _MalopCu, hs.MAHOCSINH, lop.maLop);// cập nhật lại thông tin cho học sinh đó
                    }
                    else// là học sinh mới
                    {
                        _xepLopBus.Insert(hs.MAHOCSINH, lop.maLop);// thêm học sinh đó vào lớp
                    }
                }
            }

            // duyệt trong các năm học khác nhau, chứa thông tin học sinh chưa phân lớp
            foreach (CChuaPhanLopChange c in _listChuaPhanLopChange)
            {
                // duyệt DSHS trong mỗi năm học chưa phân lớp
                foreach (usp_SelectHocSinhChuaPhanLopResult hs in c.danhSachHocSinh)
                {
                    int _MaLop = _xepLopBus.TimMaLopTheoMaHS_NamHoc(hs.MAHOCSINH, c.namHoc);// Tìm xem học sinh đó lúc đầu đã được phân lớp chưa
                    if (_MaLop != -1)// ban đầu được phân lớp
                    {
                        _xepLopBus.Delete(hs.MAHOCSINH, _MaLop);// xóa học sinh đó khỏi lớp tìm được để chuyển học sinh từ đã có lớp -> chưa phân lớp
                    }
                }
            }
            MessageBox.Show("Lưu thành công", "Success");
            _listLopChange.Clear();// làm sạch dữ liệu
            _listChuaPhanLopChange.Clear();// làm sạch dữ liệu
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi button Thoát được chọn
        /// Đóng form đang thao tác
        /// </summary>
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            if (_listChuaPhanLopChange.Count == 0 && _listLopChange.Count == 0)
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
                        buttonLuu_Click(sender, e);
                    }
                    this.Close();
                }
            }
        }
        #endregion

        #region chọn combobox

        /// <summary>
        /// Hiển thị danh sách học sinh lên dataGridViewCurrent, nếu trường hợp danh sách là chưa phân lớp thì chức năng chọn lớp và khối sẽ không được thực hiện (bên thông tin lớp thường) hoặc ngược lại
        /// Xứ lý sự kiện khi comBoBoxNamHocCurrent được chọn
        /// </summary>
        private void comBoBoxNamHocCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                comBoBoxKhoiCurrent.SelectedIndex = -1;
                comBoBoxLopCurrent.SelectedIndex = -1;
                comBoBoxNamHocMoi.SelectedIndex = comBoBoxNamCurrent.SelectedIndex;
            }
            else
            {
                if (radioButtonChuyenLopCungKhoi.Checked)
                {
                    comBoBoxNamHocMoi.SelectedIndex = comBoBoxNamCurrent.SelectedIndex;
                }
                comBoBoxKhoiCurrent.SelectedIndex = -1;
                comBoBoxKhoiCurrent.SelectedIndex = 0;
            }
            loadDataGridViewCurrent();
        }


        /// <summary>
        /// Sự kiện: bắt sự kiện khi comBoBoxNamHocMoi được click
        /// hiển thị danh sách học sinh tương ứng với lớp và khối được chọn lên dataGridViewNew
        /// </summary>
        private void comBoBoxNamHocMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBoBoxKhoiMoi.SelectedIndex = -1;
            comBoBoxKhoiMoi.SelectedIndex = 0;
            loadDataGridViewNew();
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi người dùng click vào comBoBoxKhoiCurrent
        /// hiển thị danh sách học sinh tương ứng với lớp và khối được chọn lên dataGridViewCurrent
        /// </summary>
        private void comBoBoxKhoiCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                if (index == comBoBoxKhoiCurrent.SelectedIndex)
                {
                    comBoBoxKhoiCurrent.Tag = khoi.MAKHOI;

                }
                index++;
            }
            if (comBoBoxKhoiCurrent.SelectedIndex != -1)
            {
                loadDanhSachLopCu();
                if (comBoBoxLopCurrent.Items.Count > 0)
                {
                    comBoBoxLopCurrent.SelectedIndex = -1;
                    comBoBoxLopCurrent.SelectedIndex = 0;
                }

            }
            loadDataGridViewCurrent();
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi người dùng click vào comBoBoxKhoiMoi
        /// hiển thị danh sách học sinh tương ứng với lớp và khối được chọn lên dataGridViewNew
        /// </summary>
        private void comBoBoxKhoiMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (usp_SelectKhoisAllResult khoi in _khoiBus.LayDanhSachKhoi())
            {
                if (index == comBoBoxKhoiMoi.SelectedIndex)
                {
                    comBoBoxKhoiMoi.Tag = khoi.MAKHOI;

                }
                index++;
            }

            loadDanhSachLopMoi();
            if (comBoBoxLopMoi.Items.Count > 0)
            {
                comBoBoxLopMoi.SelectedIndex = -1;
                comBoBoxLopMoi.SelectedIndex = 0;
            }
            loadDataGridViewNew();
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi người dùng click vào comBoBoxLopCurrent
        /// Hiển thị danh sách sinh viên lên dataGridViewCurrent theo mong muốn người dùng 
        /// </summary>
        private void comBoBoxLopCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comBoBoxKhoiCurrent.Tag.ToString(), comBoBoxNamCurrent.Text))
            {
                if (index == comBoBoxLopCurrent.SelectedIndex)
                {
                    comBoBoxLopCurrent.Tag = lop.MALOP;
                    break;
                }

                index++;
            }
            if (comBoBoxLopCurrent.SelectedIndex != -1)
                loadDataGridViewCurrent();
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi người dùng click vào comBoBoxLopNew
        /// Hiển thị danh sách sinh viên lên dataGridViewNew theo mong muốn người dùng 
        /// </summary>
        private void comBoBoxLopMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _danhSachLopBus.LayDanhSachLopTheoKhoiMaNam(comBoBoxKhoiMoi.Tag.ToString(), comBoBoxNamHocMoi.Text))
            {
                if (index == comBoBoxLopMoi.SelectedIndex)
                {
                    comBoBoxLopMoi.Tag = lop.MALOP;
                    break;
                }

                index++;
            }

            loadDataGridViewNew();
        }
        #endregion

        #region radioButton
        /// <summary>
        /// Sự kiện: bắt sự kiện khi người dùng tích vào radioButtonPhanLopHoSo_ChuaPhanLop
        /// thiết lập thuộc tính cho các đối tượng: comBoBoxLopCurrent, comBoBoxKhoiCurrent, ... và hiển thị danh sách sinh viên chưa phân lớp nếu có
        /// </summary>
        private void radioButtonPhanLopHoSo_ChuaPhanLop_CheckedChanged(object sender, EventArgs e)
        {
            comBoBoxLopCurrent.Enabled = false;
            comBoBoxKhoiCurrent.Enabled = false;
            comBoBoxNamHocMoi.Enabled = false;
            comBoBoxKhoiMoi.Enabled = true;
            comBoBoxKhoiCurrent.SelectedIndex = -1;
            comBoBoxLopCurrent.SelectedIndex = -1;
            comBoBoxNamHocMoi.SelectedIndex = comBoBoxNamCurrent.SelectedIndex;
            loadDataGridViewCurrent();
        }

        /// <summary>
        /// Sự kiện: bắt sự kiện khi người dùng tích vào radioButtonChuyenLopCungKhoi
        /// thiết lập thuộc tính cho các đối tượng: comBoBoxLopCurrent, comBoBoxKhoiCurrent,.. và hiển thị danh sách sinh viên theo mong muốn người dùng
        /// </summary>
        private void radioButtonChuyenLopCungKhoi_CheckedChanged(object sender, EventArgs e)
        {
            comBoBoxLopCurrent.Enabled = true;
            comBoBoxKhoiCurrent.Enabled = true;
            comBoBoxNamHocMoi.Enabled = false;
            if (comBoBoxKhoiCurrent.SelectedIndex == -1)
                comBoBoxKhoiCurrent.SelectedIndex = 0;
            comBoBoxNamHocMoi.SelectedIndex = comBoBoxNamCurrent.SelectedIndex;
        }
        #endregion

        /// <summary>
        /// Sự kiện: bắt sự kiện khi dataGridViewCurrent được vẽ lại
        /// thiết lập số thứ tự khi được vẽ trên mỗi dòng, làm ẩn cột MAHOCSINH
        /// </summary>
        private void dataGridViewCurrent_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                dataGridViewCurrent.Columns["MAHOCSINH"].Visible = false;
                for (int i = 0; i < dataGridViewCurrent.Rows.Count; i++)
                {
                    dataGridViewCurrent.Rows[i].Cells["STT"].Value = i + 1;
                }
            }
            catch { }
        }


        /// <summary>
        /// Sự kiện: bắt sự kiện khi dataGridViewNew được vẽ lại
        /// thiết lập số thứ tự khi được vẽ trên mỗi dòng, làm ẩn cột MAHOCSINH
        /// </summary>
        private void dataGridViewNew_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                dataGridViewNew.Columns["MAHOCSINH"].Visible = false;

                for (int i = 0; i < dataGridViewNew.Rows.Count; i++)
                {
                    dataGridViewNew.Rows[i].Cells["STT1"].Value = i + 1;
                }
            }
            catch { }
        }


        #endregion
    }
}