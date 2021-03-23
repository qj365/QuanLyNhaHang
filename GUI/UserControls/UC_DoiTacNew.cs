using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang.GUI.UserControls.DoiTac
{
    public partial class UC_DoiTacNew : UserControl
    {
        public UC_DoiTacNew()
        {
            InitializeComponent();
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(0);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(1);
        }


    }
}
