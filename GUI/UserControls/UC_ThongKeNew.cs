using System;
using System.Windows.Forms;

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
            txtSNgayLapDau.CustomFormat = "dd-mm-yyyy";
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
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(1);
        }

        private void btnTaiKhoan(object sender, EventArgs e)
        {
            pageThongKe.SelectTab(4);
        }

        private void dateNgayLapTK_ValueChanged(object sender, EventArgs e)
        {
            txtSNgayLapDau.CustomFormat = "dd-MM-yyyy";
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
        #region Hoadon

        public void LoadListHD()
        {
            dtgvListHD.DataSource = DAO.HoaDonDAO.Instance.GetAllHD();
            txtMaHD.Enabled = false;
            txtNguoiLap.Enabled = false;
            txtKH.Enabled = false;
            txtNgayLap.Enabled = false;
            txtTongTien.Enabled = false;
            txtPhanTram.Enabled = false;
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
            LoadListHD();
        }

        private void txtSMaHD_TextChange(object sender, EventArgs e)
        {
            string mahd = txtSMaHD.Text;
            string nguoilap = txtNguoiLap.Text;
            dtgvListHD.DataSource = DAO.HoaDonDAO.Instance.SearchListHDBy(mahd, nguoilap);

        }

        private void txtSNguoiLap_TextChange(object sender, EventArgs e)
        {
            string mahd = txtSMaHD.Text;
            string nguoilap = txtNguoiLap.Text;
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
        }

        #endregion 
    }
}
