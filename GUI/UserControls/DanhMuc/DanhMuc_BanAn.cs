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
    public partial class DanhMuc_BanAn : UserControl
    {
        public DanhMuc_BanAn()
        {
            InitializeComponent();
        }

        private void addBan_Click(object sender, EventArgs e)
        {
            using (Add_BanAn ba = new Add_BanAn())
            {
                ba.ShowDialog();
            }
        }

        private void DanhMuc_BanAn_Load(object sender, EventArgs e)
        {

        }
    }
}
