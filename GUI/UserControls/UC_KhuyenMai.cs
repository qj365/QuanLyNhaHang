using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachHang.DAO;

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_KhuyenMai : UserControl
    {
        string luunv = "";
        DateTime today = DateTime.Now;

        public UC_KhuyenMai()
        {
            InitializeComponent();
            Refresh();
            luunv = "";
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
            txtMaKM.Enabled = false;
            txtNgayBatDau.Enabled = false;
            txtNgayKetThuc.Enabled = false;
            txtPhanTram.Enabled = false;

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
            txtMaKM.Text = DataProvider.Instance.executeScalar("select dbo.TAOMAKM()").ToString();
            btnLuuKM.Enabled = true;
            btnHuyKM.Enabled = false;
            txtPhanTram.Clear();
            txtMaKM.Enabled = false;
            txtNgayKetThuc.Value = Convert.ToDateTime(txtNgayBatDau.Text);
            luunv = "themnv";
            txtNgayBatDau.Value = new DateTime(today.Year, today.Month, today.Day);
            txtNgayKetThuc.Value = new DateTime(today.Year, today.Month, today.Day);
            txtNgayBatDau.Enabled = true;
            txtNgayKetThuc.Enabled = true;
            txtPhanTram.Enabled = true;
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
            if (CheckKM() && (luunv == "themnv"))
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
            else if (CheckKM() && (luunv == "suanv"))
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

        private void btnSuaKM_Click(object sender, EventArgs e)
        {
            btnHuyKM.Enabled = false;
            btnLuuKM.Enabled = true;
            txtMaKM.Enabled = false;
            txtNgayKetThuc.MinDate = Convert.ToDateTime(txtNgayBatDau.Text);
            luunv = "suanv";
            txtNgayBatDau.Enabled = true;
            txtNgayKetThuc.Enabled = true;
            txtPhanTram.Enabled = true;
        }

        private void btnHuyKM_Click(object sender, EventArgs e)
        {
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
            txtSMaKM.Text = "";
            txtSPhanTram.Text = "";
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";
            LoadKMList();
        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            string ngaybatdau = dateTimePicker1.Text;
            string ngayketthuc = dateTimePicker2.Text;
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKM(ngaybatdau, ngayketthuc, makm, phantram);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            string ngaybatdau = dateTimePicker1.Text;
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKMByNBD(makm, phantram, ngaybatdau);
        }

        private void txtSMaKM_TextChange(object sender, EventArgs e)
        {
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKMBy(makm, phantram);
        }

        private void txtSPhanTram_TextChange(object sender, EventArgs e)
        {
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKMBy(makm, phantram);
        }
    }
}
