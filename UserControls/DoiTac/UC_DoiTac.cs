using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachHang.UserControls.DoiTac;

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_DoiTac : UserControl
    {
        public UC_DoiTac()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void addPaneltoUC(Control c)
        {
            c.Dock = DockStyle.Fill;
            pnlDoiTac.Controls.Clear();
            pnlDoiTac.Controls.Add(c);

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            DoiTac_KhachHang dt_kh = new DoiTac_KhachHang();
            addPaneltoUC(dt_kh);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            DoiTac_NhaCC dt_ncc = new DoiTac_NhaCC();
            addPaneltoUC(dt_ncc);
        }
    }
}
