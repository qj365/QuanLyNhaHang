using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang.GUI.UserControls.DanhMuc
{
    public partial class UC_DanhMucNew : UserControl
    {
        public UC_DanhMucNew()
        {
            InitializeComponent();
        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(0);
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(1);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(2);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(3);
        }
        

      
    }
}
