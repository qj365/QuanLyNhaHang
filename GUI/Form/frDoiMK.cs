using QuanLyKhachHang.DAO;
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
    public partial class frDoiMK : Form
    {
        public frDoiMK()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if(txtHienTai.Text != "" || txtMoi.Text != "" || txtNhapLai.Text != "")
            {
                if(txtMoi.Text != txtNhapLai.Text)
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại phải trùng nhau");

                }
                else
                {
                    if (AccountDAO.Instance.Login(AccountDAO.username, txtHienTai.Text))
                    {
                        AccountDAO.Instance.doiMK(AccountDAO.username, txtMoi.Text);
                        MessageBox.Show("Đổi mật khẩu thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập lại mật khẩu hiện tại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
    }
}
