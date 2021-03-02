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
    public partial class DanhMuc_NhanVien : UserControl
    {
        public DanhMuc_NhanVien()
        {
            InitializeComponent();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            using (Add_NhanVien tt = new Add_NhanVien())
            {
                tt.ShowDialog();
            }
        }
    }
}
