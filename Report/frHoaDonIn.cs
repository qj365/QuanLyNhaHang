using QuanLyKhachHang.DAO;
using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang
{
    public partial class frHoaDonIn : Form
    {
        public frHoaDonIn()
        {
            InitializeComponent();
        }

        private void frHoaDonIn_Load(object sender, EventArgs e)
        {
            string mahd = HoaDonDAO.Instance.getMaxMaHD();
            HoaDon hd = HoaDonDAO.Instance.getHoaDon(mahd);
            KhachHang kh = KhachHangDAO.Instance.getKHbyMaHD(mahd);
            this.getCTPYCTableAdapter.Fill(this.QUANLYNHAHANGDataSet.getCTPYC, Data.MaPYC);
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("mahd",mahd),
                new Microsoft.Reporting.WinForms.ReportParameter("maban",Data.Maban),
                new Microsoft.Reporting.WinForms.ReportParameter("ngaylap",hd.Ngaylap.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("makh",kh.Makh),
                new Microsoft.Reporting.WinForms.ReportParameter("tenkh",kh.Tenkh),
                new Microsoft.Reporting.WinForms.ReportParameter("sdt",kh.Sdt),
                new Microsoft.Reporting.WinForms.ReportParameter("chietkhau",Data.ChietkhauHD),
                new Microsoft.Reporting.WinForms.ReportParameter("tongtien",Data.TongtienHD),
                new Microsoft.Reporting.WinForms.ReportParameter("tongcong",Data.TongcongHD),
            };
            this.reportViewer1.LocalReport.SetParameters(p);

            this.reportViewer1.RefreshReport();
        }
    }
}
