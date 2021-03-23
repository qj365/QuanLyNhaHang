using System;
using System.Windows.Forms;

namespace QuanLyKhachHang.GUI.UserControls.ThongKe
{
    public partial class UC_ThongKeNew : UserControl
    {
        public UC_ThongKeNew()
        {
            InitializeComponent();

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
    }
}
