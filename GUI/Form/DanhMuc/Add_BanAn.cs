using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachHang.DAO;
using QuanLyKhachHang.DTO;
using QuanLyKhachHang.GUI.UserControls;


namespace QuanLyKhachHang
{
    public partial class Add_BanAn : Form
    {
        readonly BanAnDTO bandto = new BanAnDTO();
        readonly BanAnDAO bandao = new BanAnDAO();
        public Add_BanAn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButtonXacNhan_Click(object sender, EventArgs e)
        {

            if (CheckThemBA())
            {
                bandto.MABAN = textBoxmabanan.Text.ToString().Trim();
                bandto.SOCHONGOI = int.Parse(textBoxsochongoi.Text.ToString().Trim());
                bool themBan = bandao.ThemBA(bandto);
                if (themBan == true)
                {
                    DialogResult result = MessageBox.Show("Thành công", "Thêm", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        btnThoat_Click(sender, e);
                    }
                }
            }
        }
        public bool CheckThemBA()
        {

            if (textBoxmabanan.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập số bàn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxmabanan.Focus();
                return false;
            }

            if (textBoxsochongoi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập số chỗ ngồi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxmabanan.Focus();
                return false;
            }
            return true;
        }
    }
}
