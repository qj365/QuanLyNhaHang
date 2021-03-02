using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_TongQuan : UserControl
    {
        public UC_TongQuan()
        {
            InitializeComponent();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void loadChart()
        {
            var r = new Random();
            var canvas = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.Canvas();
            var doanhthu = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizBasic._type.Bunifu_spline);
            doanhthu.addLabely("SUN", r.Next(0, 100).ToString());
            doanhthu.addLabely("MON", r.Next(0, 100).ToString());
            doanhthu.addLabely("TUE", r.Next(0, 100).ToString());
            doanhthu.addLabely("WED", r.Next(0, 100).ToString());
            doanhthu.addLabely("THU", r.Next(0, 100).ToString());
            doanhthu.addLabely("FRI", r.Next(0, 100).ToString());
            doanhthu.addLabely("SAT", r.Next(0, 100).ToString());

            
            var tongchi = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizBasic._type.Bunifu_spline);
            tongchi.addLabely("SUN", r.Next(0, 100).ToString());
            tongchi.addLabely("MON", r.Next(0, 100).ToString());
            tongchi.addLabely("TUE", r.Next(0, 100).ToString());
            tongchi.addLabely("WED", r.Next(0, 100).ToString());
            tongchi.addLabely("THU", r.Next(0, 100).ToString());
            tongchi.addLabely("FRI", r.Next(0, 100).ToString());
            tongchi.addLabely("SAT", r.Next(0, 100).ToString());
            // Add data sets to canvas   
            canvas.addData(doanhthu);
            canvas.addData(tongchi);
            //render canvas   
            chartTongQuan.Render(canvas);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadChart();
        }

        private void UC_TongQuan_Load(object sender, EventArgs e)
        {

        }
    }
}
