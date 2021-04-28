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

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_TongQuan : UserControl
    {
        public UC_TongQuan()
        {
            InitializeComponent();
            cbThoiGian.SelectedIndex = 0;
        }
        private void loadChart(int index)
        {
            var canvas = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.Canvas();
            var doanhthu = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizBasic._type.Bunifu_spline);
            var tongchi = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizBasic._type.Bunifu_spline);

            List<DateTime> lst = PhieuNhapDAO.Instance.dsNgay(index);

            foreach (DateTime item in lst)
            {
                string dm = item.ToString("dd/MM");
                string ymd = item.ToString("yyyy-MM-dd");
                doanhthu.addLabely(dm,HoaDonDAO.Instance.doanhThuNgay(ymd));
                tongchi.addLabely(dm, PhieuNhapDAO.Instance.tongChiNgay(ymd));
            }

            canvas.addData(doanhthu);
            canvas.addData(tongchi);
            
            chartTongQuan.Render(canvas);
        }

        private void cbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblHoaDon.Text = HoaDonDAO.Instance.soHoaDon(cbThoiGian.SelectedIndex);
            int dt = int.Parse(HoaDonDAO.Instance.DoanhThu(cbThoiGian.SelectedIndex));
            int tc = int.Parse(PhieuNhapDAO.Instance.TongChi(cbThoiGian.SelectedIndex));
            lblDoanhThu.Text = dt.ToString("N0");
            lblTongChi.Text = tc.ToString("N0");
            loadChart(cbThoiGian.SelectedIndex);
            PhieuNhapDAO.Instance.dsNgay(cbThoiGian.SelectedIndex);
        }
    }
}
