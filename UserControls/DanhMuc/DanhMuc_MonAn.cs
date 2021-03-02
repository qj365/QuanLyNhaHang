using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang.UserControls.DanhMuc
{
    public partial class DanhMuc_MonAn : UserControl
    {
        public DanhMuc_MonAn()
        {
            InitializeComponent();
        }



        private void btnAddMonAn_Click(object sender, EventArgs e)
        {
            using (Add_MonAn tt = new Add_MonAn())
            {
                tt.ShowDialog();
            }
        }
    }
}
