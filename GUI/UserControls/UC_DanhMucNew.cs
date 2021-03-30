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
using QuanLyKhachHang.DTO;

namespace QuanLyKhachHang.GUI.UserControls.DanhMuc
{
    public partial class UC_DanhMucNew : UserControl
    {
        public UC_DanhMucNew()
        {
            InitializeComponent();
            loadMonAn();
        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(0);
            clearAllBindings();
            loadMonAn();
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(1);
            clearAllBindings();
            loadLoaiMon();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(2);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(3);
            bunifuCustomDataGridBanAn.DataSource = (new BanAnDAO()).GetListBanAn();
            Load_BanAN();
            MacDinhBanAn();
        }

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(4);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            using (Add_NhanVien f = new Add_NhanVien())
                f.ShowDialog();
        }

        void clearAllBindings()
        {
            ClearAllBindingsLoaiMon();
            ClearAllBindingsMonAn();
        }

        #region Món ăn
        void loadMonAn()
        {
            loadMonAnList();
            monAnBinding();
            loadLoaiMonComboBox();
            
            
        }
        void loadMonAnList()
        {
            dtgvMonAn.DataSource = MonAnDAO.Instance.getMonAnList();
        }

        void loadLoaiMonComboBox()
        {
            List<LoaiMon> list = LoaiMonDAO.Instance.getListLoaiMon();
            cbbLoaiMon.DataSource = list;
            cbbLoaiMon.DisplayMember = "Tenlm";

        }

        void monAnBinding()
        {
            txtMaMon.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "mama"));
            txtTenMon.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "tenmonan"));
            txtDVT.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "dvt"));
            txtDonGia.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "dongia"));
            cbbLoaiMon.DataBindings.Add(new Binding("Text", dtgvMonAn.DataSource, "Maloai"));
        }
        void ClearAllBindingsMonAn()
        {
            foreach (Control c in grbChinhSuaMon.Controls)
                c.DataBindings.Clear();
        }
        #endregion


        #region Loại món

        void loadLoaiMon()
        {
            loadLoaiMonList();
            loaiMonBinding();
            
        }
        void loadLoaiMonList()
        {
            dtgvLoaiMon.DataSource = LoaiMonDAO.Instance.getListLoaiMon();
        }
        void loaiMonBinding()
        {
            txtMaLoaiMon.DataBindings.Add(new Binding("Text", dtgvLoaiMon.DataSource, "Malm"));
            txtTenLoaiMon.DataBindings.Add(new Binding("text", dtgvLoaiMon.DataSource, "Tenlm"));
        }
        void ClearAllBindingsLoaiMon()
        {
            foreach (Control c in grbChinhSuaLoai.Controls)
                c.DataBindings.Clear();
        }
        #endregion


        #region Nhân viên

        #endregion


        #region Bàn ăn
        readonly BanAnDTO bandto = new BanAnDTO();
        readonly BanAnDAO bandao = new BanAnDAO();
        public void MacDinhBanAn()
        {
            bunifuTextBoxmabanan.Enabled = false;
            bunifuTextBoxsochongoi.Enabled = false;

            BtnThemBanAn.Enabled = true;
            BtnSuaBanAn.Enabled = true;
            BtnXoaBanAn.Enabled = true;
            BtnLuuBanAn.Enabled = false;
            BtnHuyBanAn.Enabled = false;
        }
        public void SuaBanAn()
        {
            bunifuTextBoxsochongoi.Enabled = true;
            bunifuTextBoxmabanan.Enabled = true;

            BtnThemBanAn.Enabled = false;
            BtnSuaBanAn.Enabled = true;
            BtnXoaBanAn.Enabled = false;
            BtnLuuBanAn.Enabled = true;
            BtnHuyBanAn.Enabled = true;
        }

        private void Load_BanAN()
        {

            bunifuCustomDataGridBanAn.Columns["MABAN"].HeaderText = "Mã Bàn Ăn";
            bunifuCustomDataGridBanAn.Columns["SOCHONGOI"].HeaderText = "Số Ngồi Tối Đa";
            bunifuCustomDataGridBanAn.Columns["MAPYC"].HeaderText = "Mã Phiếu Yêu Cầu";
            bunifuCustomDataGridBanAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //bunifuCustomDataGridBanAn.Columns["MABANAN"].Width = 100;
            //bunifuCustomDataGridBanAn.Columns["SOCHONGOI"].Width = 200;
            //bunifuCustomDataGridBanAn.Columns["MAPYC"].Width = 200;
            bunifuCustomDataGridBanAn.DataSource = bandao.GetListBanAn();
        }
        public void Load_Lai_BanAn()
        {
            bunifuCustomDataGridBanAn.DataSource = (bandao.GetListBanAn());
        }


        private void BunifuCustomDataGridBanAn_SelectionChanged(object sender, EventArgs e)
        {
            int index = bunifuCustomDataGridBanAn.CurrentCell == null ? -1 : bunifuCustomDataGridBanAn.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxmabanan.Text = bunifuCustomDataGridBanAn.Rows[bunifuCustomDataGridBanAn.CurrentRow.Index].Cells[0].Value.ToString().Trim();
                bunifuTextBoxsochongoi.Text = bunifuCustomDataGridBanAn.Rows[bunifuCustomDataGridBanAn.CurrentRow.Index].Cells[2].Value.ToString().Trim();
            }
        }
        private void BtnThemBanAn_Click(object sender, EventArgs e)
        {

            Add_BanAn BanAn = new Add_BanAn();
            BanAn.ShowDialog();
            Load_Lai_BanAn();
        }
        private void BtnSuaBanAn_Click(object sender, EventArgs e)
        {
            SuaBanAn();
        }
        private void BunifuButtonLuuBanAn_Click(object sender, EventArgs e)
        {
            MacDinhBanAn();
            bandto.MABAN = bunifuTextBoxmabanan.Text.ToString().Trim();
            bandto.SOCHONGOI = int.Parse(bunifuTextBoxsochongoi.Text.ToString().Trim());
            bandto.MAPYC = "";
            bool suaban = bandao.Update_ban(bandto);
            if (suaban == true)
            {
                DialogResult result = MessageBox.Show("Thành công", "Chỉnh sửa", MessageBoxButtons.OK);// _ = MessageBox.Show("Thành công", "Chỉnh sửa", MessageBoxButtons.OK);
                Load_Lai_BanAn();
            }
        }
        private void BtnXoaBanAn_Click(object sender, EventArgs e)
        {

        }

        private void BtnHuyBanAn_Click(object sender, EventArgs e)
        {
            Load_Lai_BanAn();
            MacDinhBanAn();
        }
        #endregion

        #region Nguyên liệu

        #endregion
    }
}
