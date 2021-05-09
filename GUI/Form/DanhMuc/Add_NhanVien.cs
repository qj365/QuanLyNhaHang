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
    public partial class Add_NhanVien : Form
    {
        public Add_NhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
                txtMaNV.Clear();
                txtTenNV.Clear();
                txtGioiTinh.Text = "";
                txtChucVu.Text = "";
                txtLuong.Clear();
                txtDiaChi.Clear();
                txtSDT.Clear();
                txtNgaySinh.CustomFormat = " ";
                this.Close();
        }

        public Boolean CheckNV()
        {
            if (txtMaNV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Mã nhân viên!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return false;
            }

            if (txtTenNV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Tên nhân viên!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNV.Focus();
                return false;
            }

            if (txtNgaySinh.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Ngày sinh nhân viên!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgaySinh.Focus();
                return false;
            }

            if (txtSDT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập SDT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }

            if (txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Địa chỉ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }

            if (txtGioiTinh.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Giới tính!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGioiTinh.Focus();
                return false;
            }

            if (txtLuong.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Lương nhân viên!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLuong.Focus();
                return false;
            }

            if (txtChucVu.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Chức vụ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChucVu.Focus();
                return false;
            }

            return true;
        }


        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            if (CheckNV() && (btnLuuNV.Text == "Thêm NV"))
            {
                string manv = txtMaNV.Text;
                string tennv = txtTenNV.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                string gioitin = txtGioiTinh.Text;
                string chucvu = txtChucVu.Text;
                DateTime ngaysinh = Convert.ToDateTime(txtNgaySinh.Text);
                decimal luong = Convert.ToDecimal(txtLuong.Text);
                if (DAO.NhanVienDAO.Instance.ThemNV(manv, tennv, ngaysinh, diachi, sdt, gioitin, luong, chucvu))
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới thất bại");
                }
            }
            else if (CheckNV() && (btnLuuNV.Text == "Sửa NV"))
            {
                string manv = txtMaNV.Text;
                string tennv = txtTenNV.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                string gioitin = txtGioiTinh.Text;
                string chucvu = txtChucVu.Text;
                DateTime ngaysinh = Convert.ToDateTime(txtNgaySinh.Text);
                decimal luong = Convert.ToDecimal(txtLuong.Text);
                if (DAO.NhanVienDAO.Instance.SuaNV(manv, tennv, ngaysinh, diachi, sdt, gioitin, luong, chucvu))
                {
                    MessageBox.Show("Sửa nhân viên thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }

            }
        }

        private void txtNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            txtNgaySinh.CustomFormat = "MM/dd/yyyy";
        }
    }
}
