using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using frMain;
using ConnectToDatabase;
using Settings = ConnectToDatabase.Properties.Settings;
using System.Data.SqlClient;

namespace frMain
{
    public partial class fmQuanLyHocSinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Khởi tạo
        public int Quyen = -1; // khởi tạo phân quyền chức năng cho tài khoảng 
        public fmQuanLyHocSinh()
        {
            InitializeComponent();
        }
        #region SKIN, Phân quyền người dùng
        private void fmQuanLyHocSinh_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinGallery(ribbonGallery, true);

            frDangNhap dangNhap = new frDangNhap();
            dangNhap.ShowDialog();
            Quyen = dangNhap._quyen;
            KhoiTaoChucNang();
        }
        #endregion
        #endregion
        #region QUAN LY, PHÂN QUYỀN
        #region Đăng nhập
        private void BarButtonDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frDangNhap dangNhap = new frDangNhap();
            dangNhap.ShowDialog();
            Quyen = dangNhap._quyen;
            KhoiTaoChucNang();
        }
       
        #endregion
        #region Khởi tạo chức năng cho từng loại tài khoản
        
        private void ThietLapMacDinhDieuKhien(Boolean temp)
        {
            _phanquyen.Enabled = temp;
            _namHoc.Enabled = temp;
            _monhoc.Enabled = temp;
            _quanLyLop.Enabled = temp;
            _hocsinhmoi.Enabled = temp;
            _phanLop.Enabled = temp;
            _nhapdiem.Enabled = temp;
            _dshocsinh.Enabled = temp;
            _dslop.Enabled = temp;
            _thongtinhs.Enabled = temp;
            _doiquidinh.Enabled = temp;
            _tongketmon.Enabled = temp;
            _tonghk.Enabled = temp;
            _phanCongGiangDay.Enabled = temp;
            _lapThoiKhoaBieu.Enabled = temp;
            _phanCongGiangDay.Enabled = temp;
            _dsgiaovien.Enabled = temp;
            _traCuuThoiKhoaBieu.Enabled = temp;
            btnConnectDatabase.Enabled = temp;
        }

        private void KhoiTaoChucNang()
        {
            try
            {
                switch (Quyen)
                {
                    case -1:
                        ThietLapMacDinhDieuKhien(false);
                        break;
                    case 0:
                        ThietLapMacDinhDieuKhien(false);

                         _phanquyen.Enabled = true;
                        _nhapdiem.Enabled = true;
                        _thongtinhs.Enabled = true;
                        btnConnectDatabase.Enabled = true;
                        break;
                    case 1://BGH
                        ThietLapMacDinhDieuKhien(false);

                        _namHoc.Enabled = true;
                        _monhoc.Enabled = true;
                        _quanLyLop.Enabled = true;
                        _nhapdiem.Enabled = true;
                        _thongtinhs.Enabled = true;
                        _doiquidinh.Enabled = true;
                        _dsgiaovien.Enabled = true;
                        _lapThoiKhoaBieu.Enabled = true;
                        _phanCongGiangDay.Enabled = true;
                        _traCuuThoiKhoaBieu.Enabled = true;
                        break;
                    case 2://GV
                        ThietLapMacDinhDieuKhien(false);

                        _hocsinhmoi.Enabled = true;
                        _phanLop.Enabled = true;
                        _nhapdiem.Enabled = true;
                        _dshocsinh.Enabled = true;
                        _dslop.Enabled = true;
                        _thongtinhs.Enabled = true;
                        _tongketmon.Enabled = true;
                        _tonghk.Enabled = true;
                        break;
                    case 3://Khác
                        ThietLapMacDinhDieuKhien(false);

                        _nhapdiem.Enabled = true;

                        _thongtinhs.Enabled = true;
                        _doiquidinh.Enabled = false;
                        _tongketmon.Enabled = false;
                        _tonghk.Enabled = false;
                        btnConnectDatabase.Enabled = false;
                        break;
                }
                if (Quyen == 2)
                    _nhapdiem.Text = "QUẢN LÝ ĐIỂM";
                else
                    _nhapdiem.Text = "XEM ĐIỂM";
            }
            catch { }
        }

        #endregion
        #region ADMIN phân quyền người dùng
        private void BarButtonPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                fmPhanQuyen iphanquyen = new fmPhanQuyen();
                iphanquyen.ShowDialog();
            }
            catch { }
        }
        #endregion

        //Cua so moi
        private void BarButtonCuaSoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmQuanLyHocSinh fm = new fmQuanLyHocSinh();
            fm.Show();
        }
        //thoat
        private void BarButtonThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "ĐÓNG ỨNG DỤNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion
        #region Tile World
        private void backstageViewTabItem4_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion
        #region DUONG DAN DEN CAC FORM
        //-------------------------------------------------------------------------
        // Thông tin tất cả học sinh
        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frMainHocSinh ifm = new frMainHocSinh(_nhapdiem.Enabled, _hocsinhmoi.Enabled);
            ifm.Show();
        }
        //-------------------------------------------------------------------------
        //Thêm môn học
        private void _monhoc_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frMonHoc iMonHoc = new frMonHoc();
            iMonHoc.ShowDialog();
        }
        //-------------------------------------------------------------------------
        //thêm lớp
        private void quanLyLop_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frQuanLyLop iquanly = new frQuanLyLop();
            iquanly.ShowDialog();
        }
        //Nhập điểm
        private void bangDiem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            formBangDiem formBD;
            if (Quyen == 2)
                formBD = new formBangDiem(true);
            else
                formBD = new formBangDiem(false);
            formBD.Show();
        }

        #region Bang diem
        private void _dMonHoc_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            formBangDiem formBD = new formBangDiem(false);
            formBD.Show();
        }
        #endregion


        #region Danh sach hoc sinh
        private void danhSachHocSinh_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormDanhSachHocSinh formDS = new FormDanhSachHocSinh();
            formDS.Show();
        }

        private void danhSachGiaoVien_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frHoSoGiaoVien form = new frHoSoGiaoVien();
            form.Show();
        }

        private void traCuuThoiKhoaBieu_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            formTraCuuThoiKhoaBieu form = new formTraCuuThoiKhoaBieu();
            form.ShowDialog();
        }
        #endregion

        //-------------------------------------------------------------------------
        // Danh Sách lớp
        private void danhSachLop_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            formDanhSachLop formDS = new formDanhSachLop();
            formDS.Show();
        }

        //-------------------------------------------------------------------------
        // Tổng kết môn
        private void baoCaoTongKetMon_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frBaoCaoMon formTKM = new frBaoCaoMon();
            formTKM.Show();
        }

        //-------------------------------------------------------------------------
        // Tổng kết học kỳ
        private void baoCaoTongKetHocKy_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frBaoCaoTKHK formTKHK = new frBaoCaoTKHK();
            formTKHK.Show();
        }

        // Hồ sơ học sinh
        private void hoSoHocSinh_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frHoSoHocSinh frHoSoHS = new frHoSoHocSinh();
            frHoSoHS.Show();
        }

        //Phân lớp
        private void phanLop_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormPhanLop PhanLop = new FormPhanLop();
            PhanLop.Show();
        }

        // Phân công giảng dạy
        private void phanCongGiangDay_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frPhanCongGiangDay form = new frPhanCongGiangDay();
            form.Show();
        }

        // Lập thời khóa biểu
        private void lapThoiKhoaBieu_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frLapKhoiKhoaBieu form = new frLapKhoiKhoaBieu();
            form.Show();
        }

        // Thay đổi qui định
        private void thayDoiQuiDinh_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frQuyDinh iQuydinh = new frQuyDinh();
            iQuydinh.ShowDialog();
        }

        // Thêm năm học
        private void quanLyNamHoc_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frQuanLyNamHoc _NamHoc = new frQuanLyNamHoc();
            _NamHoc.ShowDialog();
        }

        //ConnectToDatabase
        private void btnConnectDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string OldConnectionString = Settings.Default.ConnectString;
            FormConnectToDatabase _frConnect = new FormConnectToDatabase();
            _frConnect.ShowDialog();
        }

        //Thong tin
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frThongTin _ThongTin = new frThongTin();
            _ThongTin.Show();
        }
        #endregion
        #region CHINH SUA
        //tim kiem
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frMainHocSinh ifm = new frMainHocSinh(_nhapdiem.Enabled, _hocsinhmoi.Enabled);
            ifm.Show();
        }
        #endregion  

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"Resources\HuongDanSuDungPhanMem.chm");
            }
            catch { }
         
        }


        // Coder: Tài
        private SqlConnection Connect; // lưu trữ kết nối với database
        /// <summary>
        /// Sự kiện: xảy ra khi người dùng click vào button Sao lưu
        /// Sao lưu database
        /// </summary>
        private void BarButtonItemBackUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saoLuuDuLieu();
        }

        private void saoLuuDuLieu()
        {
            Connect = new SqlConnection(ConnectToDatabase.Properties.Settings.Default.ConnectString); //  tạo lập kết nối
            string nameDatabase = ConnectToDatabase.Properties.Settings.Default.DatabaseName; // lấy tên database

            string date = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + " " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();

            SaveFileDialog saveFile = new SaveFileDialog(); // mở hộp thoại save file
            saveFile.FileName = "QLHS " + date; // thiết lập tên file mặc định
            saveFile.Filter = "File(*.bak)|*.bak";  // kiểu file

            string currentPath;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                currentPath = (saveFile.FileName); // lấy đường dẫn

                string QueryBackup = "BACKUP DATABASE " + nameDatabase + " TO DISK ='" + currentPath + "' WITH INIT";

                try
                {
                    SqlCommand cm = new SqlCommand(QueryBackup, Connect);
                    cm.Connection.Open();
                    cm.ExecuteNonQuery();

                    Connect.Close();
                    MessageBox.Show("Sao lưu thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể sao lưu dữ liệu", "Lỗi");
                }
            }
        }


        /// <summary>
        /// Sự kiện: xảy ra khi người dùng click vào button Phục Hồi
        /// Phục hồi database
        /// </summary>
        private void BarButtonItemRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phucHoiDuLieu();
        }

        private void phucHoiDuLieu()
        {
            Connect = new SqlConnection(ConnectToDatabase.Properties.Settings.Default.ConnectString); //  tạo lập kết nối
            string nameDatabase = ConnectToDatabase.Properties.Settings.Default.DatabaseName; // lấy tên database

            OpenFileDialog openFile = new OpenFileDialog(); // mở hộp thoại open file
            openFile.Filter = "File(*.bak)|*.bak";  // kiểu file

            string currentPath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                currentPath = (openFile.FileName); // lấy đường dẫn

                string QueryRestore = "USE master\nALTER DATABASE " + nameDatabase + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE \n\n RESTORE DATABASE " + nameDatabase + " FROM DISK ='" + currentPath + "' \n\nWITH REPLACE\n\nALTER DATABASE " + nameDatabase + " SET MULTI_USER";

                try
                {
                    SqlCommand cm = new SqlCommand(QueryRestore, Connect);
                    cm.Connection.Open();
                    cm.ExecuteNonQuery();

                    Connect.Close();
                    MessageBox.Show("Phục hồi thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể phục hồi dữ liệu", "Lỗi");
                    //MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }
    }
}
