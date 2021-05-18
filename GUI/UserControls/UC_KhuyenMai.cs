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
            LoadKMList();
            luunv = "";
            KMBinding();
            btnLuuKM.Enabled = false;
            btnHuyKM.Enabled = false;
            txtMaKM.Enabled = false;
            txtNgayBatDau.Enabled = false;
            txtNgayKetThuc.Enabled = false;
            txtPhanTram.Enabled = false;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void reLoad()
        {
            LoadKMList();
            btnThemKM.Enabled = true;
            btnSuaKM.Enabled = true;
            btnXoaKM.Enabled = true;
            btnLuuKM.Enabled = false;
            btnHuyKM.Enabled = false;
            txtMaKM.Enabled = false;
            txtNgayBatDau.Enabled = false;
            txtNgayKetThuc.Enabled = false;
            txtPhanTram.Enabled = false;
            clearBindingKM();
            KMBinding();
        }

        public void LoadKMList()
        {
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.GetListKM();
        }

        public void KMBinding()
        {
            txtMaKM.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "MAKM"));
            txtNgayBatDau.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "NGAYBATDAU"));
            txtNgayKetThuc.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "NGAYKETTHUC"));
            txtPhanTram.DataBindings.Add(new Binding("text", dtgvKMList.DataSource, "PHANTRAM"));
        }

        private void btnThemKM_Click(object sender, EventArgs e)
        {
            txtMaKM.Text = DataProvider.Instance.executeScalar("select dbo.TAOMAKM()").ToString();
            btnSuaKM.Enabled = false;
            btnXoaKM.Enabled = false;
            btnLuuKM.Enabled = true;
            btnHuyKM.Enabled = true;
            txtPhanTram.Clear();
            txtMaKM.Enabled = false;
            txtNgayKetThuc.Value = Convert.ToDateTime(txtNgayBatDau.Text);
            luunv = "themkm";
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
            if (CheckKM() && (luunv == "themkm"))
            {
                string makm = txtMaKM.Text;
                string ngaybatdau = txtNgayBatDau.Text;
                string ngayketthuc = txtNgayKetThuc.Text;
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
            else if (CheckKM() && (luunv == "suakm"))
            {
                string makm = txtMaKM.Text;
                string ngaybatdau = txtNgayBatDau.Text;
                string ngayketthuc = txtNgayKetThuc.Text;
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
            btnHuyKM.Enabled = true;
            btnLuuKM.Enabled = true;
            btnThemKM.Enabled = false;
            btnXoaKM.Enabled = false;
            txtMaKM.Enabled = false;
            txtNgayKetThuc.MinDate = Convert.ToDateTime(txtNgayBatDau.Text);
            luunv = "suakm";
            txtNgayBatDau.Enabled = true;
            txtNgayKetThuc.Enabled = true;
            txtPhanTram.Enabled = true;
        }

        private void btnHuyKM_Click(object sender, EventArgs e)
        {
            reLoad();
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
            txtSNgayBatDau.CustomFormat = " ";
            txtSNgayKetThuc.CustomFormat = " ";
            reLoad();
        }

        private void clearBindingKM()
        {
            txtMaKM.DataBindings.Clear();
            txtNgayBatDau.DataBindings.Clear();
            txtNgayKetThuc.DataBindings.Clear();
            txtPhanTram.DataBindings.Clear();
        }


        private void txtSMaKM_TextChanged(object sender, EventArgs e)
        {
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKMBy(makm, phantram);
        }

        private void txtSNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            txtSNgayBatDau.CustomFormat = "MM/dd/yyyy";
            string ngaybatdau = txtSNgayBatDau.Text;
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKMByNBD(makm, phantram, ngaybatdau);
        }

        private void txtSNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            txtSNgayKetThuc.CustomFormat = "MM/dd/yyyy";
            string ngaybatdau = txtSNgayBatDau.Text;
            string ngayketthuc = txtSNgayKetThuc.Text;
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKM(ngaybatdau, ngayketthuc, makm, phantram);
        }

        private void txtSPhanTram_TextChange(object sender, EventArgs e)
        {
            string makm = txtSMaKM.Text;
            string phantram = txtSPhanTram.Text;
            dtgvKMList.DataSource = DAO.KhuyenMaiDAO.Instance.SearchKMBy(makm, phantram);
        }
    }
}
