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
    public partial class Dashboard : Form
    {
        int panelWidth;
        bool isCollapse;
        public Dashboard()
        {
            InitializeComponent();
            panelWidth = pnlLeft.Width;
            isCollapse = false;
            timerDongHo.Start();
            UC_TongQuan uctq = new UC_TongQuan();
            addControltoPanel(uctq);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapse)
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
                if(pnlLeft.Width<=62)
                {
                    timer1.Stop();
                    isCollapse = true;
                    this.Refresh();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
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
            UC_BanHang ucbh = new UC_BanHang();
            addControltoPanel(ucbh);
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
            UC_DanhMuc ucdm = new UC_DanhMuc();
            addControltoPanel(ucdm);
        }
        private void btnDoiTac_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnDoiTac);
            UC_DoiTac ucdt = new UC_DoiTac();
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
            UC_ThongKe uctk = new UC_ThongKe();
            addControltoPanel(uctk);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnDangXuat);
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToString("HH:MM:ss");
        }

       
       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
