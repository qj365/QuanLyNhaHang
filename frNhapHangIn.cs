using QuanLyKhachHang.DAO;
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
    public partial class frNhapHangIn : Form
    {
        public frNhapHangIn()
        {
            InitializeComponent();
        }

        private void frNhapHangIn_Load(object sender, EventArgs e)
        {
            string mapn = PhieuNhapDAO.Instance.getMaxPhieuNhap();
            DataTable pn = PhieuNhapDAO.Instance.getPhieuNhap(mapn);
            string ngaynhap = pn.Rows[0].Field<DateTime>(1).ToString();
            string tongtien = pn.Rows[0].Field<int>(2).ToString("N0")+ " đ";
            string nhacc = Data.TenNCC;
            // TODO: This line of code loads data into the 'QUANLYNHAHANGDataSet1.getCTPNmax' table. You can move, or remove it, as needed.
            this.getCTPNmaxTableAdapter.Fill(this.QUANLYNHAHANGDataSet1.getCTPNmax);
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("mapn",mapn),
                new Microsoft.Reporting.WinForms.ReportParameter("nguoinhap",AccountDAO.hoten),
                new Microsoft.Reporting.WinForms.ReportParameter("ngaynhap",ngaynhap),
                new Microsoft.Reporting.WinForms.ReportParameter("nhacc",nhacc),
                new Microsoft.Reporting.WinForms.ReportParameter("tongtien",tongtien),
            };
            this.reportViewer1.LocalReport.SetParameters(p);
            this.reportViewer1.RefreshReport();
        }
    }
}
