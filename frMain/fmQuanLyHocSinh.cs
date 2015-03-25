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

namespace frMain
{
    public partial class fmQuanLyHocSinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Khởi tạo
        private int _quyen = -1;
        public fmQuanLyHocSinh()
        {
            InitializeComponent();
            DangNhap();
            //_quyen = 0;
            KhoiTaoChucNang();
        }
        #region SKIN, Phân quyền người dùng
        private void Form1_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinGallery(ribbonGallery, true);
        }
        #endregion
        #endregion
        #region QUAN LY, PHÂN QUYỀN
        #region Đăng nhập
        private void barButtonItem12_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DangNhap();
        }
        private void DangNhap()
        {
            try
            {
                frDangNhap idangnhap = new frDangNhap();
                idangnhap.ShowDialog();
                int iquyen = idangnhap.Quyen();
                if (iquyen != -1)
                {
                    _quyen = iquyen;
                }
                else
                    if (_quyen == -1)
                        this.Close();
                KhoiTaoChucNang();
            }
            catch { }
        }
        #endregion
        #region Khởi tạo chức năng cho từng loại tài khoản
        private void KhoiTaoChucNang()
        {
            try
            {
                switch (_quyen)
                {
                    case -1:
                        _phanquyen.Enabled = false;
                        _namhoc.Enabled = false;
                        _monhoc.Enabled = false;
                        _lopmoi.Enabled = false;
                        _hocsinhmoi.Enabled = false;
                        _phanLop.Enabled = false;
                        _nhapdiem.Enabled = false;
                        _dshocsinh.Enabled = false;
                        _dslop.Enabled = false;
                        _thongtinhs.Enabled = false;
                        _doiquidinh.Enabled = false;
                        _tongketmon.Enabled = false;
                        _tonghk.Enabled = false;
                        btnConnectDatabase.Enabled = false;

                        break;
                    case 0:
                        //_phanquyen.Enabled = true;
                        //_namhoc.Enabled = true;
                        //_monhoc.Enabled = true;
                        //_lopmoi.Enabled = true;
                        //_hocsinhmoi.Enabled = true;
                        //_phanLop.Enabled = true;
                        //_nhapdiem.Enabled = true;
                        //_dshocsinh.Enabled = true;
                        //_dslop.Enabled = true;
                        //_thongtinhs.Enabled = true;
                        //_doiquidinh.Enabled = true;
                        //_tongketmon.Enabled = true;
                        //_tonghk.Enabled = true;

                         _phanquyen.Enabled = true;
                        _namhoc.Enabled = false;
                        _monhoc.Enabled = false;
                        _lopmoi.Enabled = false;
                        _hocsinhmoi.Enabled = false;
                        _phanLop.Enabled = false;
                        _nhapdiem.Enabled = true;
                        _dshocsinh.Enabled = false;
                        _dslop.Enabled = false;
                        _thongtinhs.Enabled = true;
                        _doiquidinh.Enabled = false;
                        _tongketmon.Enabled = false;
                        _tonghk.Enabled = false;
                        btnConnectDatabase.Enabled = true;
                        break;
                    case 1://BGH
                        _phanquyen.Enabled = false;
                        _namhoc.Enabled = true;
                        _monhoc.Enabled = true;
                        _lopmoi.Enabled = true;
                        _hocsinhmoi.Enabled = false;
                        _phanLop.Enabled = false;
                        _nhapdiem.Enabled = true;
                        _dshocsinh.Enabled = false;
                        _dslop.Enabled = false;
                        _thongtinhs.Enabled = true;
                        _doiquidinh.Enabled = true;
                        _tongketmon.Enabled = false;
                        _tonghk.Enabled = false;
                        btnConnectDatabase.Enabled = false;
                        break;
                    case 2://GV
                        _phanquyen.Enabled = false;
                        _namhoc.Enabled = false;
                        _monhoc.Enabled = false;
                        _lopmoi.Enabled = false;
                        _hocsinhmoi.Enabled = true;
                        _phanLop.Enabled = true;
                        _nhapdiem.Enabled = true;
                        _dshocsinh.Enabled = true;
                        _dslop.Enabled = true;
                        _thongtinhs.Enabled = true;
                        _doiquidinh.Enabled = false;
                        _tongketmon.Enabled = true;
                        _tonghk.Enabled = true;
                        btnConnectDatabase.Enabled = false;
                        break;
                    case 3://Khác
                        _phanquyen.Enabled = false;
                        _namhoc.Enabled = false;
                        _monhoc.Enabled = false;
                        _lopmoi.Enabled = false;
                        _hocsinhmoi.Enabled = false;
                        _phanLop.Enabled = false;
                        _nhapdiem.Enabled = true;
                        _dshocsinh.Enabled = false;
                        _dslop.Enabled = false;
                        _thongtinhs.Enabled = true;
                        _doiquidinh.Enabled = false;
                        _tongketmon.Enabled = false;
                        _tonghk.Enabled = false;
                        btnConnectDatabase.Enabled = false;
                        break;
                }
                if (_quyen == 2)
                    _nhapdiem.Text = "QUẢN LÝ ĐIỂM";
                else
                    _nhapdiem.Text = "XEM ĐIỂM";
            }
            catch { }
        }
        #endregion
        #region ADMIN phân quyền người dùng
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmQuanLyHocSinh fm = new fmQuanLyHocSinh();
            fm.Show();
        }
        //thoat
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        private void _lopmoi_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frQuanLyLop iquanly = new frQuanLyLop();
            iquanly.ShowDialog();
        }
        //Nhập điểm
        private void _nhapdiem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frBangDiem formBD;
            if (_quyen == 2)
                formBD = new frBangDiem(true);
            else
                formBD = new frBangDiem(false);
            formBD.Show();
        }
        #region Bang diem
        private void _dMonHoc_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frBangDiem formBD = new frBangDiem(false);
            formBD.Show();
        }
        #endregion
        #region Danh sach hoc sinh
        private void tileItem19_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frDanhSachHS formDS = new frDanhSachHS();
            formDS.Show();
        }
        #endregion

        //-------------------------------------------------------------------------
        // Danh Sách lớp
        private void tileItem18_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frDanhSachLop formDS = new frDanhSachLop();
            formDS.Show();
        }

        //-------------------------------------------------------------------------
        // Tổng kết môn
        private void _dHocKy_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frBaoCaoMon formTKM = new frBaoCaoMon();
            formTKM.Show();
        }

        //-------------------------------------------------------------------------
        // Tổng kết học kỳ
        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frBaoCaoTKHK formTKHK = new frBaoCaoTKHK();
            formTKHK.Show();
        }

        //Hồ sơ học sinh
        private void _hocsinhmoi_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frHoSoHocSinh frHoSoHS = new frHoSoHocSinh();
            frHoSoHS.Show();
        }

        //Phân lớp
        private void _phanLop_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frPhanLop PhanLop = new frPhanLop();
            PhanLop.Show();
        }

        //Thay đổi qui định
        private void _doiquidinh_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frQuyDinh iQuydinh = new frQuyDinh();
            iQuydinh.ShowDialog();
        }

        //Thêm năm học
        private void _namhoc_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frQuanLyNamHoc _NamHoc = new frQuanLyNamHoc();
            _NamHoc.ShowDialog();
        }

        //ConnectToDatabase
        private void btnConnectDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string OldConnectionString = Settings.Default.ConnectString;
            frConnectToDatabase _frConnect = new frConnectToDatabase();
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

    }
}
