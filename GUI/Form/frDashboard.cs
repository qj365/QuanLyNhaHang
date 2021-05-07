using BunifuAnimatorNS;
using QuanLyKhachHang.DAO;
using QuanLyKhachHang.GUI.UserControls;
using QuanLyKhachHang.GUI.UserControls.DanhMuc;
using QuanLyKhachHang.GUI.UserControls.DoiTac;
using QuanLyKhachHang.GUI.UserControls.ThongKe;
using QuanLyKhachHang.UserControls;
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
    public partial class frDashboard : Form
    {

        
        public frDashboard()
        {
            InitializeComponent();
            panelWidth = pnlLeft.Width;
            isCollapse = false;
            timerDongHo.Start();
            UC_TongQuan uctq = new UC_TongQuan();
            addControltoPanel(uctq);
            lblHoTen.Text = AccountDAO.hoten;
            lblPhanQuyen.Text = AccountDAO.phanquyen;
            phanQuyen();

        }
        #region Giao diện


        int panelWidth;
        bool isCollapse;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapse)
            {
                pnlLeft.Width = pnlLeft.Width + 26;
                if (pnlLeft.Width >= panelWidth)
                {
                    timer1.Stop();
                    isCollapse = false;
                    this.Refresh();
                }
            }
            else
            {
                pnlLeft.Width = pnlLeft.Width - 26;
                if (pnlLeft.Width <= 62)
                {
                    timer1.Stop();
                    isCollapse = true;
                    this.Refresh();
                }
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToString("HH:mm:ss");
        }
        private void moveSidePanel(Control btn)
        {
            pnlSide.Top = btn.Top;
            pnlSide.Height = btn.Height;
        }
        
        private void addControltoPanel(Control c)
        {
            
            c.Dock = DockStyle.Fill;
            pnlControl.Controls.Clear();
            pnlControl.Controls.Add(c);

        }
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnTongQuan);
            UC_TongQuan uctq = new UC_TongQuan();
            addControltoPanel(uctq);
        }


        private void btnBanHang_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnBanHang);
            //UC_BanHang ucbh = new UC_BanHang();
            //addControltoPanel(ucbh);
            UC_BanHangNew uctq = new UC_BanHangNew();
            addControltoPanel(uctq);
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnNhapHang);
            UC_NhapHang ucnh = new UC_NhapHang();
            addControltoPanel(ucnh);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnDanhMuc);
            UC_DanhMucNew ucdm = new UC_DanhMucNew();
            addControltoPanel(ucdm);
        }
        private void btnDoiTac_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnDoiTac);
            UC_DoiTacNew ucdt = new UC_DoiTacNew();
            addControltoPanel(ucdt);


        }
        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnKhuyenMai);
            UC_KhuyenMai uckm = new UC_KhuyenMai();
            addControltoPanel(uckm);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnThongKe);
            UC_ThongKeNew uctk = new UC_ThongKeNew();
            addControltoPanel(uctk);
            

        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            using (frDoiMK f = new frDoiMK())
            {
                f.ShowDialog();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
               this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }




        #endregion

        void phanQuyen()
        {
            switch (AccountDAO.phanquyen.Trim())
            {
                case "Thu ngân":
                    btnNhapHang.Visible = false;
                    btnDanhMuc.Visible = false;
                    btnDoiTac.Visible = false;
                    btnKhuyenMai.Visible = false;
                    btnThongKe.Visible = false;
                    break;
                case "Đầu bếp":
                    btnBanHang.Visible = false;
                    btnDanhMuc.Visible = false;
                    btnDoiTac.Visible = false;
                    btnKhuyenMai.Visible = false;
                    btnThongKe.Visible = false;
                    break;
            }
        }
    }
}
