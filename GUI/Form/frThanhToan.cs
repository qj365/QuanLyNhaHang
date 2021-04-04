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
    public partial class frThanhToan : Form
    {
        public frThanhToan()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhachHang.Checked)
            {
                txtSDT.ReadOnly = false;
                txtTenKH.ReadOnly = false;
            }
            else
            {
                txtSDT.ReadOnly = true;
                txtTenKH.ReadOnly = true;
            }
        }

        private void cbKhuyeMai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
