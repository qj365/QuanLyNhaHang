using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachHang.DAO;
using QuanLyKhachHang.DTO;
using QuanLyKhachHang.GUI;
namespace QuanLyKhachHang.GUI.UserControls.ThongKe
{
    public partial class UC_ThongKeNew : UserControl
    {
        public UC_ThongKeNew()
        {
            InitializeComponent();
            LoadListHD();
            HDBinding();

        }

        private void dateNgayLap_ValueChanged(object sender, EventArgs e)
        {
           // dateNgayLapTK.CustomFormat = "dd-mm-yyyy";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(0);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(3);
        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(2);
            loadMA();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(1);
            Load_PhieuNhap();
        }

        private void btnTaiKhoan(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(4);
            loadTaiKhoan();
        }

        private void dateNgayLapTK_ValueChanged(object sender, EventArgs e)
        {
           // dateNgayLapTK.CustomFormat = "dd-MM-yyyy";
        }

        private void bunifuTextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        #region Tài khoản
        void loadTaiKhoan()
        {
            ClearAllBindingsTaiKhoan();
            loadTaiKhoanList();
            taiKhoanBinding();
            DisEnbBtn(false);
        }
        void loadTaiKhoanList()
        {
            dtgvTaiKhoan.DataSource = AccountDAO.Instance.getListTaiKhoan();
        }
        void taiKhoanBinding()
        {
            txtUsername.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "Username"));
            txtName.DataBindings.Add(new Binding("text", dtgvTaiKhoan.DataSource, "Hoten"));
            cbbPhanQuyen.DataBindings.Add(new Binding("text", dtgvTaiKhoan.DataSource, "Phanquyen"));
        }
        void ClearAllBindingsTaiKhoan()
        {
            foreach (Control c in grbChinhSuaTaiKhoan.Controls)
                c.DataBindings.Clear();
        }
        void DisEnbBtn(bool e)
        {
            btnSave3.Enabled = e;
            btnCancel3.Enabled = e;
            btnThemTk.Enabled = !e;
            btnSuaTk.Enabled = !e;
            btnXoaTk.Enabled = !e;
            txtName.Enabled = e;
            txtUsername.Enabled = e;
            cbbPhanQuyen.Enabled = e;
        }
        string thread;
        private void btnThemTk_Click_1(object sender, EventArgs e)
        {
            thread = txtUsername.Text;
            txtUsername.Text = "";
            txtName.Text = "";
            cbbPhanQuyen.Text = "";
            DisEnbBtn(true);
        }

        private void btnSuaTk_Click_1(object sender, EventArgs e)
        {
            thread = txtUsername.Text;
            DisEnbBtn(true);
            txtUsername.Enabled = false;
        }



        private void btnSave3_Click_1(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Hoten = txtName.Text;
            string PhanQuyen = cbbPhanQuyen.Text;
            if (string.Compare(thread, txtUsername.Text, true) != 0)
            {
                if (AccountDAO.Instance.InsertAccount(Username, Hoten, PhanQuyen))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                }
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(Username, Hoten, PhanQuyen))
                {
                    MessageBox.Show("Sửa tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa tài khoản");
                }
            }
            loadTaiKhoan();
            DisEnbBtn(false);
        }

        private void btnCancel3_Click_1(object sender, EventArgs e)
        {
            DisEnbBtn(false);
        }
        private void txtTkUsername_TextChange_1(object sender, EventArgs e)
        {
            string Username = txtTkUsername.Text;
            dtgvTaiKhoan.DataSource = AccountDAO.Instance.SearchAccount(Username);
        }
        private void btnClearUsername_Click(object sender, EventArgs e)
        {
            txtTkUsername.Text = "";
        }


        #endregion

        #region Món ăn

        private void loadMA()
        {
            setInitDtpMA();
            loadListMA();
        }

        private void loadListMA()
        {
            dtgvMA.DataSource = MonAnDAO.Instance.DemSoMonAn(dpFromMA.Value, dpToMA.Value);
        }

        private void setInitDtpMA()
        {
            dpFromMA.CustomFormat = " ";
            dpToMA.CustomFormat = " ";
        }

        private void dpFromMA_ValueChanged(object sender, EventArgs e)
        {
            dpFromMA.CustomFormat = "dd-MM-yyyy";
            dtgvMA.DataSource = DAO.MonAnDAO.Instance.DemSoMonAn(dpFromMA.Value, dpToMA.Value);
        }

        private void dpToMA_ValueChanged(object sender, EventArgs e)
        {
            dpToMA.CustomFormat = "dd-MM-yyyy";
            dtgvMA.DataSource = DAO.MonAnDAO.Instance.DemSoMonAn(dpFromMA.Value, dpToMA.Value);
        }


        #endregion

        #region Hoa Don

        public void LoadListHD()
        {
            dtgvListHD.DataSource = DAO.HoaDonDAO.Instance.GetAllHD();
            txtMaHD.Enabled = false;
            txtNguoiLap.Enabled = false;
            txtKH.Enabled = false;
            txtNgayLap.Enabled = false;
            txtTongTien.Enabled = false;
            txtPhanTram.Enabled = false;
            txtDoanhThu.Enabled = false;
            clearBindingHD();
            HDBinding();
        }

        public void HDBinding()
        {
            clearBindingHD();
            txtMaHD.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "MAHD", true, DataSourceUpdateMode.Never));
            txtNgayLap.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "NGAYLAP", true, DataSourceUpdateMode.Never));
            txtNguoiLap.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "HOTEN", true, DataSourceUpdateMode.Never));
            txtPhanTram.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "PHANTRAM", true, DataSourceUpdateMode.Never));
            txtTongTien.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "TONGTIEN", true, DataSourceUpdateMode.Never));
            txtKH.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "TENKH", true, DataSourceUpdateMode.Never));
        }

        private void clearBindingHD()
        {
            txtMaHD.DataBindings.Clear();
            txtNgayLap.DataBindings.Clear();
            txtNguoiLap.DataBindings.Clear();
            txtPhanTram.DataBindings.Clear();
            txtTongTien.DataBindings.Clear();
            txtKH.DataBindings.Clear();
        }

        private void btnClearSHD_Click(object sender, EventArgs e)
        {
            txtSMaHD.Text = " ";
            txtSNguoiLap.Text = " ";
            txtSNgayLapDau.CustomFormat = " ";
            txtSNgayLapCuoi.CustomFormat = " ";
            txtDoanhThu.Text = " ";
            LoadListHD();
            clearBindingHD();
            HDBinding();    
        }

        private void txtSMaHD_TextChange(object sender, EventArgs e)
        {
            string mahd = txtSMaHD.Text;
            string nguoilap = txtSNguoiLap.Text;
            dtgvListHD.DataSource = DAO.HoaDonDAO.Instance.SearchListHDBy(mahd, nguoilap);
        }

        private void txtSNguoiLap_TextChange(object sender, EventArgs e)
        {
            string mahd = txtSMaHD.Text;
            string nguoilap = txtSNguoiLap.Text;
            dtgvListHD.DataSource = DAO.HoaDonDAO.Instance.SearchListHDBy(mahd, nguoilap);
        }

        private void txtSNgayLapDau_ValueChanged(object sender, EventArgs e)
        {
            txtSNgayLapDau.CustomFormat = "MM/dd/yyyy";
            string ngaydau = txtSNgayLapDau.Text;
            string mahd = txtSMaHD.Text;
            string nguoilap = txtSNguoiLap.Text;
            dtgvListHD.DataSource = DAO.HoaDonDAO.Instance.SearchListHDByND(mahd, nguoilap, ngaydau);
        }

        private void txtSNgayLapCuoi_ValueChanged(object sender, EventArgs e)
        {
            txtSNgayLapCuoi.CustomFormat = "MM/dd/yyyy";
            string ngaydau = txtSNgayLapDau.Text;
            string ngaycuoi = txtSNgayLapCuoi.Text;
            string mahd = txtSMaHD.Text;
            string nguoilap = txtSNguoiLap.Text;
            dtgvListHD.DataSource = DAO.HoaDonDAO.Instance.SearchHD(mahd, nguoilap, ngaydau, ngaycuoi);
            txtDoanhThu.Text = DataProvider.Instance.executeScalar("select dbo.ThongKeTongTien('" + ngaydau + "','" + ngaycuoi + "')").ToString();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHD.Text;
            if (DAO.HoaDonDAO.Instance.DeleteHD(mahd))
            {
                MessageBox.Show("Xóa thành công");
                LoadListHD();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
                LoadListHD();
            }
        }

        #endregion

        #region Phiếu Nhập


        private void Load_PhieuNhap()
        {
            Load_Lai_PhieuNhap();
            DisEnabledPN(true);
            bunifuCustomDataGridPhieuNhap.Columns["MaPN"].HeaderText = "Mã Phiếu Nhập";
            bunifuCustomDataGridPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày Lập";
            bunifuCustomDataGridPhieuNhap.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
            bunifuCustomDataGridPhieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
            bunifuCustomDataGridPhieuNhap.Columns["UserName"].HeaderText = "Người Lập";

        }
        private void DisEnabledPN(bool a)
        {

            bunifuDropdownNguoiLap.Enabled = !a;
            bunifuDatePickerNgayLap.Enabled = !a;
            bunifuDropdownNhaCungCap.Enabled = !a;
            bunifuTextBoxTongTien.Enabled = !a;

            bunifuButtonSuaPhieuNhap.Enabled = a;
            bunifuButtonXoaPhieuNhap.Enabled = a;
            bunifuButtonLuuPhieuNhap.Enabled = !a;
            bunifuButtonHuyPhieuNhap.Enabled = !a;
        }
        private void Load_Lai_PhieuNhap()
        {
            bunifuCustomDataGridPhieuNhap.DataSource = PhieuNhapDAO.Instance.getPhieuNhapList();
        }
        private void bunifuCustomDataGridPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            int index = bunifuCustomDataGridPhieuNhap.CurrentCell == null ? -1 : bunifuCustomDataGridPhieuNhap.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxMaPhieuNhap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[0].Value.ToString();
                bunifuDropdownNguoiLap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[4].Value.ToString();
                if (bunifuCustomDataGridPhieuNhap.Rows[index].Cells[1].Value.ToString() != "")
                {
                    bunifuDatePickerNgayLap.Value = DateTime.Parse(bunifuCustomDataGridPhieuNhap.Rows[index].Cells[1].Value.ToString());
                }
                else bunifuDatePickerNgayLap.Value = DateTime.Now;
                bunifuDropdownNhaCungCap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[3].Value.ToString();
                bunifuTextBoxTongTien.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[2].Value.ToString();
            }
        }

        private void bunifuCustomDataGridPhieuNhap_SelectionChanged_1(object sender, EventArgs e)
        {
            int index = bunifuCustomDataGridPhieuNhap.CurrentCell == null ? -1 : bunifuCustomDataGridPhieuNhap.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxMaPhieuNhap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[0].Value.ToString();
                bunifuDropdownNguoiLap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[4].Value.ToString();
                if (bunifuCustomDataGridPhieuNhap.Rows[index].Cells[1].Value.ToString() != "")
                {
                    bunifuDatePickerNgayLap.Value = DateTime.Parse(bunifuCustomDataGridPhieuNhap.Rows[index].Cells[1].Value.ToString());
                }
                else bunifuDatePickerNgayLap.Value = DateTime.Now;
                bunifuDropdownNhaCungCap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[3].Value.ToString();
                bunifuTextBoxTongTien.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[2].Value.ToString();
            }
        }
        private void bunifuButtonClearTimKiem_Click(object sender, EventArgs e)
        {
            bunifuTextBoxTimKiemMaPhieuNhap.Text = "";
            bunifuTextBoxTimKiemNguoiLap.Text = "";
            bunifuTextBoxTimKiemNCC.Text = "";
            bunifuDatePickerTimKiemNgayLap.Value = DateTime.Now;
            Load_PhieuNhap();
        }
        private void bunifuTextBoxTimKiemMaPhieuNhap_TextChanged(object sender, EventArgs e)
        {
            string mapn = bunifuTextBoxTimKiemMaPhieuNhap.Text;
            string username = bunifuTextBoxTimKiemNguoiLap.Text;
            string ncc = bunifuTextBoxTimKiemNCC.Text;
            DateTime ngaylap = DateTime.Parse(bunifuDatePickerNgayLap.Value.ToString());
            bunifuCustomDataGridPhieuNhap.DataSource = PhieuNhapDAO.Instance.TimPhieuNhap(mapn, username, ncc, ngaylap);
        }
        private void bunifuButtonSuaPhieuNhap_Click(object sender, EventArgs e)
        {
            DisEnabledPN(false);
            bunifuDropdownNguoiLap.DataSource = PhieuNhapDAO.Instance.getUserName();
            bunifuDropdownNhaCungCap.DataSource = PhieuNhapDAO.Instance.getNhaCungCap();

        }

        private void bunifuButtonXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            string mapn = bunifuTextBoxMaPhieuNhap.Text;
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa Phiếu nhập: " + mapn + " này chứ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == result)
            {
                if (PhieuNhapDAO.Instance.XoaPN(mapn))
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_PhieuNhap();
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuButtonHuyPhieuNhap_Click(sender, e);
                }
            }

        }

        private void bunifuButtonLuuPhieuNhap_Click(object sender, EventArgs e)
        {
            string mapn = bunifuTextBoxMaPhieuNhap.Text;
            string username = bunifuDropdownNguoiLap.Text;
            string ncc = bunifuDropdownNhaCungCap.Text;
            DateTime ngaylap = DateTime.Parse(bunifuDatePickerNgayLap.Value.ToString());
            int tong = 0;
            int.TryParse(bunifuTextBoxTongTien.Text.ToString(), out tong);
            if (PhieuNhapDAO.Instance.SuaPN(mapn, ngaylap, tong, ncc, username))
            {
                MessageBox.Show("Lưu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_PhieuNhap();
            }
            else
            {
                MessageBox.Show("Lưu Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuButtonHuyPhieuNhap_Click(sender, e);
            }
        }

        private void bunifuButtonHuyPhieuNhap_Click(object sender, EventArgs e)
        {
            DisEnabledPN(true);
            Load_PhieuNhap();
        }


        /* #region cái cũ
         //PhieuNhapDTO _phieunhapdto = new PhieuNhapDTO();
         PhieuNhapDAO _phieunhapdao = new PhieuNhapDAO();
         public void Macdinh_phieunhap()
         {
             bunifuTextBoxMaPhieuNhap.Enabled = false;
             bunifuDropdownNguoiLap.Enabled = false;
             bunifuDatePickerNgayLap.Enabled = false;
             bunifuDropdownNhaCungCap.Enabled = false;
             bunifuTextBoxTongTien.Enabled = false;
             bunifuDropdownTimKiemNhaCungCap.Text = "";
             bunifuDropdownTimKiemNguoiLap.Text = "";
             //bunifuDatePickerTimKiemNgayLap.Format = DateTimePickerFormat.Custom;

             bunifuButtonSuaPhieuNhap.Enabled = true;
             bunifuButtonXoaPhieuNhap.Enabled = true;
             bunifuButtonLuuPhieuNhap.Enabled = false;
             bunifuButtonHuyPhieuNhap.Enabled = false;
         }
         public void Sua_phieunhap()
         {
             bunifuTextBoxMaPhieuNhap.Enabled = false;
             bunifuDropdownNguoiLap.Enabled = true;
             bunifuDatePickerNgayLap.Enabled = true;
             bunifuDropdownNhaCungCap.Enabled = true;
             bunifuTextBoxTongTien.Enabled = true;

             bunifuButtonSuaPhieuNhap.Enabled = false;
             bunifuButtonXoaPhieuNhap.Enabled = false;
             bunifuButtonLuuPhieuNhap.Enabled = true;
             bunifuButtonHuyPhieuNhap.Enabled = true;
         }
         public void Load_PhieuNhap()
         {
             bunifuCustomDataGridPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             bunifuCustomDataGridPhieuNhap.DataSource = _phieunhapdao.GetListPhieuNhap();
             bunifuDropdownTimKiemNhaCungCap.DataSource = _phieunhapdao.getNhaCungCap();
             bunifuDropdownTimKiemNguoiLap.DataSource = _phieunhapdao.getUserName();
             bunifuDropdownNhaCungCap.DataSource = _phieunhapdao.getNhaCungCap();
             bunifuDropdownNguoiLap.DataSource = _phieunhapdao.getUserName();

             bunifuCustomDataGridPhieuNhap.Columns["MaPN"].HeaderText = "Mã Phiếu Nhập";
             bunifuCustomDataGridPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày Lập";
             bunifuCustomDataGridPhieuNhap.Columns["MaNCC"].HeaderText = "Nhà Cung Cấp";
             bunifuCustomDataGridPhieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
             bunifuCustomDataGridPhieuNhap.Columns["UserName"].HeaderText = "Người Lập";

             bunifuCustomDataGridPhieuNhap.Columns["MaPN"].Width = 100;
             bunifuCustomDataGridPhieuNhap.Columns["MaNCC"].Width = 100;

         }
         public void Load_lai_PhieuNhap()
         {
             bunifuCustomDataGridPhieuNhap.DataSource = _phieunhapdao.GetListPhieuNhap();
             bunifuDropdownTimKiemNhaCungCap.DataSource = _phieunhapdao.getNhaCungCap();
             bunifuDropdownTimKiemNguoiLap.DataSource = _phieunhapdao.getUserName();
             bunifuDropdownNhaCungCap.DataSource = _phieunhapdao.getNhaCungCap();
             bunifuDropdownNguoiLap.DataSource = _phieunhapdao.getUserName();
         }
         private void bunifuCustomDataGridPhieuNhap_SelectionChanged(object sender, EventArgs e)
         {
             int index = bunifuCustomDataGridPhieuNhap.CurrentCell == null ? -1 : bunifuCustomDataGridPhieuNhap.CurrentCell.RowIndex;
             if (index != -1)
             {
                 bunifuTextBoxMaPhieuNhap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[0].Value.ToString();
                 bunifuDropdownNguoiLap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[4].Value.ToString();
                 bunifuDatePickerNgayLap.Value = DateTime.Parse(bunifuCustomDataGridPhieuNhap.Rows[index].Cells[1].Value.ToString());
                 bunifuDropdownNhaCungCap.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[3].Value.ToString();
                 bunifuTextBoxTongTien.Text = bunifuCustomDataGridPhieuNhap.Rows[index].Cells[2].Value.ToString();
             }
         }
         private void bunifuButton2_Click(object sender, EventArgs e)
         {
             Sua_phieunhap();

         }
         private void bunifuButtonXoaPhieuNhap_Click(object sender, EventArgs e)
         {
             _phieunhapdto.MaPN = bunifuTextBoxMaPhieuNhap.Text;

             DialogResult xoa = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu nhập có mã: " + _phieunhapdto.MaPN + " chứ", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             if (xoa == DialogResult.Yes && _phieunhapdao.XoaPhieuNhap(_phieunhapdto.MaPN))
             {
                 DialogResult result = MessageBox.Show("Thành công", "Xóa", MessageBoxButtons.OK);
                 if (result == DialogResult.OK)
                 {
                     Load_lai_PhieuNhap();
                 }
             }
         }

         private void bunifuButtonLuuPhieuNhap_Click(object sender, EventArgs e)
         {
             _phieunhapdto.MaPN = bunifuTextBoxMaPhieuNhap.Text;
             _phieunhapdto.NgayLap = bunifuDatePickerNgayLap.Value;
             _phieunhapdto.TongTien = int.Parse(bunifuTextBoxTongTien.Text);
             _phieunhapdto.MaNCC = _phieunhapdao.getMaNhaCungCap(bunifuDropdownNhaCungCap.Text);
             _phieunhapdto.UserName = bunifuDropdownNguoiLap.Text;
             if (_phieunhapdao.SuaPhieuNhap(_phieunhapdto))
             {
                 DialogResult result = MessageBox.Show("Thành công", "Sửa", MessageBoxButtons.OK);
                 if (result == DialogResult.OK)
                 {
                     Load_lai_PhieuNhap();
                     Macdinh_phieunhap();
                 }
             }

         }
         private void bunifuButtonHuyPhieuNhap_Click(object sender, EventArgs e)
         {
             Macdinh_phieunhap();
         }
         private void bunifuButtonClearTimKiem_Click(object sender, EventArgs e)
         {
             Macdinh_phieunhap();
         }
         #endregion*/

        #endregion

        
    }
}
