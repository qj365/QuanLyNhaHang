using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_KhuyenMai : UserControl
    {
        public UC_KhuyenMai()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Refresh()
        {
            LoadKMList();
            KMBinding();
            btnLuuKM.Enabled = false;
            btnHuyKM.Enabled = false;

        }

        public void LoadKMList()
        {
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.GetListKM();
        }

        public void KMBinding()
        {
            txtMaKM.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "MAKM", true, DataSourceUpdateMode.Never));
            txtNgayBatDau.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "NGAYBATDAU", true, DataSourceUpdateMode.Never));
            txtNgayKetThuc.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "NGAYKETTHUC", true, DataSourceUpdateMode.Never));
            txtPhanTram.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "PHANTRAM", true, DataSourceUpdateMode.Never));
        }

        private void btnThemKM_Click(object sender, EventArgs e)
        {
            btnLuuKM.Enabled = true;
            btnHuyKM.Enabled = false;
            txtPhanTram.Clear();
            txtMaKM.Enabled = true;
            txtNgayKetThuc.Value = Convert.ToDateTime(txtNgayBatDau.Text);
        }

        public Boolean CheckKM()
        {
            if (txtMaKM.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Mã KM!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKM.Focus();
                return false;
            }

            if (txtNgayBatDau.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Ngày bắt đầu KM!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKM.Focus();
                return false;
            }

            if (txtNgayKetThuc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Ngày kết thúc KM!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKM.Focus();
                return false;
            }

            if (txtPhanTram.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập Phần trăm KM!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKM.Focus();
                return false;
            }

            return true;
        }

        private void btnLuuKM_Click(object sender, EventArgs e)
        {
            if (CheckKM())
            {
                string makm = txtMaKM.Text;
                DateTime ngaybatdau = Convert.ToDateTime(txtNgayBatDau.Text);
                DateTime ngayketthuc = Convert.ToDateTime(txtNgayKetThuc.Text);
                decimal phantram = Convert.ToDecimal(txtPhanTram.Text);
                if (DAO.KhuyenMaiDAO.Instance.ThemKM(makm, ngaybatdau, ngayketthuc, phantram))
                {
                    MessageBox.Show("Thêm mới thành công");
                    LoadKMList();
                }
                else
                {
                    MessageBox.Show("Thêm mới thất bại");
                }
            }
        }

        private void btnSuaKM_Click(object sender, EventArgs e)
        {
            btnHuyKM.Enabled = true;
            btnLuuKM.Enabled = false;
            txtMaKM.Enabled = false;
            txtNgayKetThuc.MinDate = Convert.ToDateTime(txtNgayBatDau.Text);
        }

        private void btnHuyKM_Click(object sender, EventArgs e)
        {
            if (CheckKM())
            {
                string makm = txtMaKM.Text;
                DateTime ngaybatdau = Convert.ToDateTime(txtNgayBatDau.Text);
                DateTime ngayketthuc = Convert.ToDateTime(txtNgayKetThuc.Text);
                decimal phantram = Convert.ToDecimal(txtPhanTram.Text);
                if (DAO.KhuyenMaiDAO.Instance.SuaKM(makm, ngaybatdau, ngayketthuc, phantram))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadKMList();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void btnXoaKM_Click(object sender, EventArgs e)
        {
            string makm = txtMaKM.Text;
            if (DAO.KhuyenMaiDAO.Instance.XoaKM(makm))
            {
                MessageBox.Show("Xóa thành công");
                LoadKMList();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnClearSKM_Click(object sender, EventArgs e)
        {
            txtSMaKM.Clear();
            txtSPhanTram.Clear();
            LoadKMList();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            decimal phantram = Convert.ToDecimal(txtSPhanTram.Text);
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchListKMByPT(phantram);
        }

        private void txtSMaKM_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
