using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachHang.UserControls.DanhMuc;

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_DanhMuc : UserControl
    {
        public UC_DanhMuc()
        {
            InitializeComponent();
        }
        private void addPaneltoPanel (Control c)
        {
            c.Dock = DockStyle.Fill;
            pnlDanhMuc.Controls.Clear();
            pnlDanhMuc.Controls.Add(c);
        }


        private void btnBanAn_Click(object sender, EventArgs e)
        {
            DanhMuc_BanAn dm_ba = new DanhMuc_BanAn();
            addPaneltoPanel(dm_ba);
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            DanhMuc_MonAn dm_ma = new DanhMuc_MonAn();
            addPaneltoPanel(dm_ma);
        }

        private void btnLoaiMon_Click(object sender, EventArgs e)
        {
            DanhMuc_LoaiMon dm_lm = new DanhMuc_LoaiMon();
            addPaneltoPanel(dm_lm);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            DanhMuc_NhanVien dm_nv = new DanhMuc_NhanVien();
            addPaneltoPanel(dm_nv);
        }
    }
}
