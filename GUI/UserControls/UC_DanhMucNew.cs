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

        #endregion


        #region Nguyên liệu

        #endregion
    }
}
