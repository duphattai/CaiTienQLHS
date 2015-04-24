using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DataAccessObject.DAO;
using BUS;

namespace frMain
{
    public partial class frMainHocSinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Biến, Khai báo, khởi tạo.
        DanhSachLop_BUS _LopBUS = new DanhSachLop_BUS();
        Khoi_BUS _KhoiBUS = new Khoi_BUS();
        NamHoc_BUS _NamHocBUS = new NamHoc_BUS();
        HoSoHocSinh_BUS _HocSinhBUS = new HoSoHocSinh_BUS();
        List<HOSOHOCSINH> _ListHocSinh = new List<HOSOHOCSINH>();
        bool _IsAllowRightClick = false;
        bool _AllowUpdateDiem;
        #endregion

        #region Các hàm chức năng
        private void LoadNamHoc()
        {
            foreach (NAMHOC namhoc in _NamHocBUS.LayNamHoc())
            {
                cbNamHoc.Items.Add(namhoc.NAMHOC1);
            }
        }

        private void LoadTreeView()
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add(cbNamHoc.Text);
            foreach (usp_SelectKhoisAllResult khoi in _KhoiBUS.LayDanhSachKhoi())
            {
                TreeNode node = new TreeNode(khoi.KHOI);
                node.Tag = khoi.MAKHOI;
                treeView.Nodes[0].Nodes.Add(node);
            }

            foreach (TreeNode node in treeView.Nodes[0].Nodes)
            {
                foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBUS.LayDanhSachLopTheoKhoiMaNam(node.Tag.ToString(), cbNamHoc.Text))
                {
                    TreeNode newNode = new TreeNode(lop.TENLOP);
                    newNode.Tag = lop.MALOP;
                    node.Nodes.Add(newNode);
                }
            }
            treeView.SelectedNode = treeView.Nodes[0];
            treeView.Focus();
        }

        private void HeaderKhoi()
        {
            listView1.Clear();
            listView1.Columns.Add("Lớp", 400, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Số Lượng Lớp", 200, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Số Lượng Học Sinh", 400, System.Windows.Forms.HorizontalAlignment.Left);
            _IsAllowRightClick = false;
        }

        private void HeaderLop()
        {
            listView1.Clear();
            listView1.Columns.Add("Lớp", 400, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Số lượng Sinh Viên", 200, System.Windows.Forms.HorizontalAlignment.Left);
            _IsAllowRightClick = false;
        }

        private void HeaderHocSinh()
        {
            listView1.Clear();
            listView1.Columns.Add("STT", 200, System.Windows.Forms.HorizontalAlignment.Center);
            listView1.Columns.Add("Họ & Tên", 220, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Ngày Sinh", 100, System.Windows.Forms.HorizontalAlignment.Center);
            listView1.Columns.Add("Giới tính", 100, System.Windows.Forms.HorizontalAlignment.Center);
            listView1.Columns.Add("Email", 200, System.Windows.Forms.HorizontalAlignment.Center);
            listView1.Columns.Add("Địa chỉ", 200, System.Windows.Forms.HorizontalAlignment.Center);
            _IsAllowRightClick = true;
        }
        #endregion

        public frMainHocSinh(bool AllowUpdateDiem, bool AllowUpdateInfo)
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(ribbonGallery, true);
            contextMenuStrip1.Items[0].Enabled = AllowUpdateInfo;
            _AllowUpdateDiem = AllowUpdateDiem;
        }

        #region Các event của form
        private void frMainHocSinh_Load(object sender, EventArgs e)
        {
            LoadNamHoc();
            if (cbNamHoc.Items.Count > 0)
            {
                cbNamHoc.SelectedIndex = 0;
                LoadTreeView();
            }
        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTreeView();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Clear();
            if (e.Node.Parent == null)
            {
                HeaderKhoi();
                foreach (usp_SelectKhoisAllResult khoi in _KhoiBUS.LayDanhSachKhoi())
                {
                    int TongSiSo = 0;
                    int TongSoLop = 0;
                    foreach(usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBUS.LayDanhSachLopTheoKhoiMaNam(khoi.MAKHOI, e.Node.Text))
                    {
                        TongSiSo += lop.SISO;
                        TongSoLop++;
                    }
                    ListViewItem item = new ListViewItem(khoi.KHOI);
                    item.SubItems.Add(TongSoLop.ToString());
                    item.SubItems.Add(TongSiSo.ToString());
                    item.Tag = khoi.MAKHOI;
                    listView1.Items.Add(item);
                }
            }
            else
            {
                if (e.Node.Parent.Parent == null)
                {
                    HeaderLop();
                    foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBUS.LayDanhSachLopTheoKhoiMaNam(e.Node.Tag.ToString(), cbNamHoc.Text))
                    {
                        ListViewItem item = new ListViewItem(lop.TENLOP);
                        item.SubItems.Add(lop.SISO.ToString());
                        item.Tag = lop.MALOP;
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    int i = 0;
                    HeaderHocSinh();
                    foreach (usp_SelectHocSinhTheoMALOPResult hocsinh in _HocSinhBUS.TruyVanHocSinhTheoMaLop(int.Parse(e.Node.Tag.ToString())))
                    {
                        i++;
                        ListViewItem item = new ListViewItem(i.ToString());
                        item.SubItems.Add(hocsinh.HOTEN);
                        item.SubItems.Add(hocsinh.GIOITINH);
                        item.SubItems.Add(hocsinh.NGAYSINH.ToShortDateString());
                        item.SubItems.Add(hocsinh.GIOITINH.ToString());
                        item.SubItems.Add(hocsinh.EMAIL);
                        item.SubItems.Add(hocsinh.DIACHI);
                        item.Tag = hocsinh.MAHOCSINH;
                        listView1.Items.Add(item);
                    }
                }
            }
        }
        
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Nodes.Count != 0)
            {
                foreach (TreeNode node in treeView.SelectedNode.Nodes)
                {
                    if (node.Tag.ToString() == listView1.SelectedItems[0].Tag.ToString())
                    {
                        treeView.SelectedNode = node;
                        treeView.Focus();
                        break;
                    }
                }
            }
        }


        private void checkHoTen_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchHoTen.Clear();
            txtSearchHoTen.Enabled = checkHoTen.Checked;
        }

        private void checkGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            cbGioiTinh.Enabled = checkGioiTinh.Checked;
            if (checkGioiTinh.Checked == true)
            {
                cbGioiTinh.SelectedIndex = 0;
            }
            else
            {
                cbGioiTinh.SelectedIndex = -1;
            }
        }

        private void checkDiaChi_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchDiaChi.Clear();
            txtSearchDiaChi.Enabled = checkDiaChi.Checked;
        }

        private void checkNgaySinh_CheckedChanged(object sender, EventArgs e)
        {
            dtNgaySinh.Enabled = checkNgaySinh.Checked;
        }

        private void checkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchEmail.Clear();
            txtSearchEmail.Enabled = checkEmail.Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchHoTen.Clear();
            checkHoTen.Checked = true;
            checkGioiTinh.Checked = false;
            checkNgaySinh.Checked = false;
            checkDiaChi.Checked = false;
            checkEmail.Checked = false;
            checkFindAll.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                listView1.Clear();
                HeaderHocSinh();
                bool IsCorrert;
                int STT = 0;
                if (checkFindAll.Checked)
                {
                    foreach (HOSOHOCSINH hs in _HocSinhBUS.LayTatCaHocSinh())
                    {
                        IsCorrert = true;
                        if (checkHoTen.Checked)
                        {
                            if (!hs.HOTEN.ToLower().Contains(txtSearchHoTen.Text.ToLower()))
                                IsCorrert = false;
                        }
                        if (checkDiaChi.Checked)
                        {
                            if (!hs.DIACHI.ToLower().Contains(txtSearchDiaChi.Text.ToLower()))
                                IsCorrert = false;
                        }
                        if (checkEmail.Checked)
                        {
                            if (!hs.EMAIL.ToLower().Contains(txtSearchEmail.Text.ToLower()))
                                IsCorrert = false;
                        }
                        if (checkNgaySinh.Checked)
                        {
                            if (hs.NGAYSINH != dtNgaySinh.Value)
                                IsCorrert = false;
                        }
                        if (checkGioiTinh.Checked)
                        {
                            if (hs.GIOITINH != cbGioiTinh.Text)
                                IsCorrert = false;
                        }

                        if (IsCorrert)
                        {
                            STT++;
                            ListViewItem item = new ListViewItem(STT.ToString());
                            item.SubItems.Add(hs.HOTEN);
                            item.SubItems.Add(hs.NGAYSINH.ToShortDateString());
                            item.SubItems.Add(hs.GIOITINH);
                            item.SubItems.Add(hs.EMAIL);
                            item.SubItems.Add(hs.DIACHI);
                            item.Tag = hs.MAHOCSINH;
                            listView1.Items.Add(item);
                        }
                    }
                }
                else
                {
                    if (treeView.SelectedNode.Parent == null)
                    {
                        foreach (usp_SelectLopByNamHocResult lop in _LopBUS.LayDanhSachLopNamHoc(treeView.SelectedNode.Text))
                        {
                            foreach (usp_SelectHocSinhTheoMALOPResult hs in _LopBUS.LayDanhSachHocSinhTheoMaLop(lop.MALOP))
                            {
                                IsCorrert = true;
                                if (checkHoTen.Checked)
                                {
                                    if (!hs.HOTEN.ToLower().Contains(txtSearchHoTen.Text.ToLower()))
                                        IsCorrert = false;
                                }
                                if (checkDiaChi.Checked)
                                {
                                    if (!hs.DIACHI.ToLower().Contains(txtSearchDiaChi.Text.ToLower()))
                                        IsCorrert = false;
                                }
                                if (checkEmail.Checked)
                                {
                                    if (!hs.EMAIL.ToLower().Contains(txtSearchEmail.Text.ToLower()))
                                        IsCorrert = false;
                                }
                                if (checkNgaySinh.Checked)
                                {
                                    if (hs.NGAYSINH != dtNgaySinh.Value)
                                        IsCorrert = false;
                                }
                                if (checkGioiTinh.Checked)
                                {
                                    if (hs.GIOITINH != cbGioiTinh.Text)
                                        IsCorrert = false;
                                }

                                if (IsCorrert)
                                {
                                    STT++;
                                    ListViewItem item = new ListViewItem(STT.ToString());
                                    item.SubItems.Add(hs.HOTEN);
                                    item.SubItems.Add(hs.NGAYSINH.ToShortDateString());
                                    item.SubItems.Add(hs.GIOITINH);
                                    item.SubItems.Add(hs.EMAIL);
                                    item.SubItems.Add(hs.DIACHI);
                                    item.Tag = hs.MAHOCSINH;
                                    listView1.Items.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (treeView.SelectedNode.Parent.Parent == null)
                        {
                            foreach (usp_SelectLopsByMAKHOI_NAMHOCResult lop in _LopBUS.LayDanhSachLopTheoKhoiMaNam(treeView.SelectedNode.Tag.ToString(), treeView.Nodes[0].Text))
                            {
                                foreach (usp_SelectHocSinhTheoMALOPResult hs in _LopBUS.LayDanhSachHocSinhTheoMaLop(lop.MALOP))
                                {
                                    IsCorrert = true;
                                    if (checkHoTen.Checked)
                                    {
                                        if (!hs.HOTEN.ToLower().Contains(txtSearchHoTen.Text.ToLower()))
                                            IsCorrert = false;
                                    }
                                    if (checkDiaChi.Checked)
                                    {
                                        if (!hs.DIACHI.ToLower().Contains(txtSearchDiaChi.Text.ToLower()))
                                            IsCorrert = false;
                                    }
                                    if (checkEmail.Checked)
                                    {
                                        if (!hs.EMAIL.ToLower().Contains(txtSearchEmail.Text.ToLower()))
                                            IsCorrert = false;
                                    }
                                    if (checkNgaySinh.Checked)
                                    {
                                        if (hs.NGAYSINH != dtNgaySinh.Value)
                                            IsCorrert = false;
                                    }
                                    if (checkGioiTinh.Checked)
                                    {
                                        if (hs.GIOITINH != cbGioiTinh.Text)
                                            IsCorrert = false;
                                    }

                                    if (IsCorrert)
                                    {
                                        STT++;
                                        ListViewItem item = new ListViewItem(STT.ToString());
                                        item.SubItems.Add(hs.HOTEN);
                                        item.SubItems.Add(hs.NGAYSINH.ToShortDateString());
                                        item.SubItems.Add(hs.GIOITINH);
                                        item.SubItems.Add(hs.EMAIL);
                                        item.SubItems.Add(hs.DIACHI);
                                        item.Tag = hs.MAHOCSINH;
                                        listView1.Items.Add(item);
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (usp_SelectHocSinhTheoMALOPResult hs in _LopBUS.LayDanhSachHocSinhTheoMaLop(int.Parse(treeView.SelectedNode.Tag.ToString())))
                            {
                                IsCorrert = true;
                                if (checkHoTen.Checked)
                                {
                                    if (!hs.HOTEN.ToLower().Contains(txtSearchHoTen.Text.ToLower()))
                                        IsCorrert = false;
                                }
                                if (checkDiaChi.Checked)
                                {
                                    if (!hs.DIACHI.ToLower().Contains(txtSearchDiaChi.Text.ToLower()))
                                        IsCorrert = false;
                                }
                                if (checkEmail.Checked)
                                {
                                    if (!hs.EMAIL.ToLower().Contains(txtSearchEmail.Text.ToLower()))
                                        IsCorrert = false;
                                }
                                if (checkNgaySinh.Checked)
                                {
                                    if (hs.NGAYSINH != dtNgaySinh.Value)
                                        IsCorrert = false;
                                }
                                if (checkGioiTinh.Checked)
                                {
                                    if (hs.GIOITINH != cbGioiTinh.Text)
                                        IsCorrert = false;
                                }

                                if (IsCorrert)
                                {
                                    STT++;
                                    ListViewItem item = new ListViewItem(STT.ToString());
                                    item.SubItems.Add(hs.HOTEN);
                                    item.SubItems.Add(hs.NGAYSINH.ToShortDateString());
                                    item.SubItems.Add(hs.GIOITINH);
                                    item.SubItems.Add(hs.EMAIL);
                                    item.SubItems.Add(hs.DIACHI);
                                    item.Tag = hs.MAHOCSINH;
                                    listView1.Items.Add(item);
                                }
                            }
                        }
                    }
                }

                this.Cursor = Cursors.Default;
                if (listView1.Items.Count == 0)
                    MessageBox.Show("Không tìm thấy học sinh nào thỏa yêu cầu", "Search Result");
            }
            catch
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Không tìm thấy học sinh nào thỏa yêu cầu", "Search Result");
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_IsAllowRightClick)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (listView1.GetItemAt(e.X, e.Y) != null)
                        contextMenuStrip1.Show(MousePosition);
                }
            }
        }

        private void sừaThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frHoSoHocSinh HoSo = new frHoSoHocSinh(int.Parse(listView1.SelectedItems[0].Tag.ToString()));
            HoSo.Show();
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormBangDiem BangDiem = new FormBangDiem(_AllowUpdateDiem, cbNamHoc.SelectedIndex, treeView.SelectedNode.Parent.Index, treeView.SelectedNode.Index, int.Parse(listView1.SelectedItems[0].Tag.ToString()));
                BangDiem.Show();
            }
            catch
            {
                FormBangDiem BangDiem = new FormBangDiem(_AllowUpdateDiem);
                BangDiem.Show();
            }
        }
        #endregion
        #region Thoát
        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(DialogResult.Yes == di)
            {
                this.Close();
            }
        }
        #endregion
    }
}