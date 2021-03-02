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
    public partial class DanhMuc_LoaiMon : UserControl
    {
        public DanhMuc_LoaiMon()
        {
            InitializeComponent();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addLoaiMon_Click(object sender, EventArgs e)
        {
            using (Add_LoaiMon tt = new Add_LoaiMon())
            {
                tt.ShowDialog();
            }
        }
    }
}
