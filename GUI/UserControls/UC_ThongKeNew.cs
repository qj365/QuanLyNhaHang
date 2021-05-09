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
            dateNgayLapTK.CustomFormat = "dd-mm-yyyy";
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
        }

        private void btnTaiKhoan(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(4);
            loadTaiKhoan();
        }

        private void dateNgayLapTK_ValueChanged(object sender, EventArgs e)
        {
            dateNgayLapTK.CustomFormat = "dd-MM-yyyy";
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
        }

        public void HDBinding()
        {
            txtMaHD.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "MAHD", true, DataSourceUpdateMode.Never));
            txtNgayLap.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "NGAYLAP", true, DataSourceUpdateMode.Never));
            txtNguoiLap.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "HOTEN", true, DataSourceUpdateMode.Never));
            txtPhanTram.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "PHANTRAM", true, DataSourceUpdateMode.Never));
            txtTongTien.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "TONGTIEN", true, DataSourceUpdateMode.Never));
            txtKH.DataBindings.Add(new Binding("text", dtgvListHD.DataSource, "TENKH", true, DataSourceUpdateMode.Never));
        }

        private void btnClearSHD_Click(object sender, EventArgs e)
        {
            txtSMaHD.Text = " ";
            txtSNguoiLap.Text = " ";
            txtSNgayLapDau.CustomFormat = " ";
            txtSNgayLapCuoi.CustomFormat = " ";
            txtDoanhThu.Text = " ";
            LoadListHD();
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

        #endregion


    }
}
