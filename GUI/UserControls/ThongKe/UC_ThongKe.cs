using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachHang.UserControls.ThongKe;

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_ThongKe : UserControl
    {
        public UC_ThongKe()
        {
            InitializeComponent();
        }
        private void addPaneltoUC(Control c)
        {
            c.Dock = DockStyle.Fill;
            pnlThongKe.Controls.Clear();
            pnlThongKe.Controls.Add(c);

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ThongKe_HoaDon tkhd = new ThongKe_HoaDon();
            addPaneltoUC(tkhd);
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            ThongKe_PhieuNhap tkpn = new ThongKe_PhieuNhap();
            addPaneltoUC(tkpn);
        }

        private void btnBanAn_Click(object sender, EventArgs e)
        {
            ThongKe_TheoBan tktb = new ThongKe_TheoBan();
            addPaneltoUC(tktb);
        }

        private void btnTheoMon_Click(object sender, EventArgs e)
        {
            ThongKe_MonAn tktm = new ThongKe_MonAn();
            addPaneltoUC(tktm);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ThongKe_TaiKhoan tktk = new ThongKe_TaiKhoan();
            addPaneltoUC(tktk);
        }
    }
    
}
