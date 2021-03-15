using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang.GUI.UserControls
{
    public partial class UC_BanHangNew : UserControl
    {
        public UC_BanHangNew()
        {
            InitializeComponent();
            
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            pageThanhToan.SetPage(tabBan);
            
        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            pageThanhToan.SetPage(tabThucDon);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
