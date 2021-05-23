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
using QuanLyKhachHang.GUI;

namespace QuanLyKhachHang.GUI.UserControls.DanhMuc
{
    public partial class UC_DanhMucNew : UserControl
    {
        string thread;
        public UC_DanhMucNew()
        {
            InitializeComponent();
            loadMonAn();
            DisEnbBtn(false);
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
            LoadListAllNV();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(3);
            LoadBanAn();
        }

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(4);
            Load_NL();
        }


        void clearAllBindings()
        {
            ClearAllBindingsLoaiMon();
            ClearAllBindingsMonAn();
        }

        #region Món ăn
        void loadMonAn()
        {
            ClearAllBindingsMonAn();
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
            cbbLoaiMon.DisplayMember = "Tenloaimon";

        }

        void monAnBinding()
        {
            txtMaMon.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "mama"));
            txtTenMon.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "tenmonan"));
            txtDVT.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "dvt"));
            txtDonGia.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "dongia"));
            //cbbLoaiMon.DataBindings.Add(new Binding("Text", dtgvMonAn.DataSource, "Tenloaimon"));
        }
        void ClearAllBindingsMonAn()
        {
            foreach (Control c in grbChinhSuaMon.Controls)
                c.DataBindings.Clear();
        }
        private void btnThemMA_Click(object sender, EventArgs e)
        {
            thread = txtMaMon.Text;
            DisEnbBtn(true);
            txtMaMon.Text = DataProvider.Instance.executeScalar("select MAMA = dbo.TAOMAMON()").ToString();
            txtTenMon.Text = "";
            txtDVT.Text = "";
            txtDonGia.Text = "";
        }

        private void btnSuaMA_Click(object sender, EventArgs e)
        {
            thread = txtMaMon.Text;
            DisEnbBtn(true);
        }

        private void btnXoaMA_Click(object sender, EventArgs e)
        {
            string MaMa = txtMaMon.Text;
            if (MessageBox.Show("Bạn có thực sự muốn xoá món này?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MonAnDAO.Instance.DeleteFood(MaMa))
                {
                    MessageBox.Show("Xoá món thành công");

                }
                else
                {
                    MessageBox.Show("Có lỗi khi xoá món");
                }
                loadMonAn();
            }
        }

        private void btnSave1_Click_1(object sender, EventArgs e)
        {
            string MaMa = txtMaMon.Text;
            string TenMa = txtTenMon.Text;
            string DVT = txtDVT.Text;
            int Dongia = Convert.ToInt32(txtDonGia.Text);
            string MaLM = (cbbLoaiMon.SelectedItem as LoaiMon).Malm;
            if (string.Compare(thread, txtMaMon.Text, true) != 0)
            {
                if (MonAnDAO.Instance.InsertFood(MaMa, TenMa, DVT, Dongia, MaLM))
                {
                    MessageBox.Show("Thêm món thành công");
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm món");
                }
            }
            else
            {
                if (MonAnDAO.Instance.UpdateFood(MaMa, TenMa, DVT, Dongia, MaLM))
                {
                    MessageBox.Show("Sửa món thành công");
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm món");
                }
            }
            loadMonAn();
            DisEnbBtn(false);
        }

        private void btnCancel1_Click_1(object sender, EventArgs e)
        {
            DisEnbBtn(false);
            ClearAllBindingsMonAn();
            monAnBinding();
        }
        private void txtTKMA1_TextChange(object sender, EventArgs e)
        {
            string MaMa = txtTKMA1.Text;
            string TenMa = txtTKMA2.Text;
            dtgvMonAn.DataSource = MonAnDAO.Instance.SearchFood(MaMa, TenMa);
        }

        private void txtTKMA2_TextChange(object sender, EventArgs e)
        {
            string MaMa = txtTKMA1.Text;
            string TenMa = txtTKMA2.Text;
            dtgvMonAn.DataSource = MonAnDAO.Instance.SearchFood(MaMa, TenMa);
        }
        private void btnClearMA_Click_1(object sender, EventArgs e)
        {
            txtTKMA2.Text = "";
            txtTKMA1.Text = "";
        }
        #endregion


        #region Loại món

        void loadLoaiMon()
        {
            ClearAllBindingsLoaiMon();
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
            txtTenLoaiMon.DataBindings.Add(new Binding("text", dtgvLoaiMon.DataSource, "Tenloaimon"));
        }
        void ClearAllBindingsLoaiMon()
        {
            foreach (Control c in grbChinhSuaLoai.Controls)
                c.DataBindings.Clear();
        }
        void DisEnbBtn(bool e)
        {
            btnCancel1.Enabled = e;
            btnSave1.Enabled = e;
            btnCancel2.Enabled = e;
            btnSave2.Enabled = e;
            btnThemLoaiMon.Enabled = !e;
            btnThemMA.Enabled = !e;
            btnSuaLoaiMon.Enabled = !e;
            btnSuaMA.Enabled = !e;
            btnXoaMA.Enabled = !e;
            btnXoaLoaiMon.Enabled = !e;
            txtTenLoaiMon.Enabled = e;
            txtTenMon.Enabled = e;
            txtDonGia.Enabled = e;
            txtDVT.Enabled = e;
            cbbLoaiMon.Enabled = e;
        }
        private void btnThemLoaiMon_Click_1(object sender, EventArgs e)
        {
            thread = txtMaLoaiMon.Text;
            DisEnbBtn(true);
            txtMaLoaiMon.Text = DataProvider.Instance.executeScalar("select MALOAI = dbo.TAOMALOAIMON()").ToString();
            txtTenLoaiMon.Text = "";
        }

        private void btnSuaLoaiMon_Click_1(object sender, EventArgs e)
        {
            thread = txtMaLoaiMon.Text;
            DisEnbBtn(true);
        }

        private void btnXoaLoaiMon_Click_1(object sender, EventArgs e)
        {
            string MaLM = txtMaLoaiMon.Text;
            string TenLM = txtTenLoaiMon.Text;
            if (MessageBox.Show("Bạn có thực sự muốn xoá loại món này?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiMonDAO.Instance.DeleteFoodCategory(MaLM, TenLM))
                {
                    MessageBox.Show("Xoá loại món thành công");

                }
                else
                {
                    MessageBox.Show("Có lỗi khi xoá loại món");
                }
                loadLoaiMon();
            }
        }

        private void txtTKLM_TextChange(object sender, EventArgs e)
        {
            string MaLM = txtTKLM.Text;
            dtgvLoaiMon.DataSource = LoaiMonDAO.Instance.SearchFoodCategory(MaLM);
        }

        private void btnSave2_Click_1(object sender, EventArgs e)
        {
            string MaLM = txtMaLoaiMon.Text;
            string TenLM = txtTenLoaiMon.Text;
            if (string.Compare(thread, txtMaLoaiMon.Text, true) != 0)
            {
                if (LoaiMonDAO.Instance.InsertFoodCategory(MaLM, TenLM))
                {
                    MessageBox.Show("Thêm loại món thành công");

                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm loại món");
                }
            }
            else
            {
                if (LoaiMonDAO.Instance.UpdateFoodCategory(MaLM, TenLM))
                {
                    MessageBox.Show("Sửa loại món thành công");

                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm loại món");
                }
            }


            loadLoaiMon();
            DisEnbBtn(false);
        }

        private void btnCancel2_Click_1(object sender, EventArgs e)
        {
            DisEnbBtn(false);
            ClearAllBindingsLoaiMon();
            loaiMonBinding();
        }

        #endregion


        #region Nhân viên

        Add_NhanVien f = new Add_NhanVien();

        void LoadListAllNV()
        {
            dtgvNV.DataSource = DAO.NhanVienDAO.Instance.GetListNV();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSMaNV.Clear();
            txtSTenNV.Clear();
            LoadListAllNV();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            f.txtMaNV.Text = DataProvider.Instance.executeScalar("select dbo.TAOMANV()").ToString();
            f.txtMaNV.Enabled = false;
            f.txtTenNV.Text = "";
            f.txtNgaySinh.CustomFormat = " ";
            f.txtSDT.Text = "";
            f.txtDiaChi.Text = "";
            f.txtGioiTinh.Text = "";
            f.txtLuong.Text = "";
            f.txtChucVu.Text = "";
            f.btnLuuNV.Text = "Thêm NV";
            f.ShowDialog();
            dtgvNV.DataSource = DAO.NhanVienDAO.Instance.GetListNV();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            f.txtMaNV.Enabled = false;
            f.btnLuuNV.Text = "Sửa NV";
            f.ShowDialog();
            dtgvNV.DataSource = DAO.NhanVienDAO.Instance.GetListNV();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string manv = f.txtMaNV.Text;
            if (DAO.NhanVienDAO.Instance.XoaNV(manv))
            {
                MessageBox.Show("Xóa thành công");
                LoadListAllNV();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void dtgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dtgvNV.Rows[e.RowIndex];
            f.txtMaNV.Text = row.Cells[0].Value.ToString();
            f.txtTenNV.Text = row.Cells[1].Value.ToString();
            f.txtSDT.Text = row.Cells[5].Value.ToString();
            f.txtDiaChi.Text = row.Cells[3].Value.ToString();
            f.txtGioiTinh.Text = row.Cells[4].Value.ToString();
            f.txtLuong.Text = row.Cells[6].Value.ToString();
            f.txtNgaySinh.Text = row.Cells[2].Value.ToString();
            f.txtChucVu.Text = row.Cells[7].Value.ToString();
        }

        private void txtSMaNV_TextChange(object sender, EventArgs e)
        {
            string manv = txtSMaNV.Text;
            string tennv = txtSTenNV.Text;
            dtgvNV.DataSource = DAO.NhanVienDAO.Instance.SearchNV(manv, tennv);
        }

        private void txtSTenNV_TextChange(object sender, EventArgs e)
        {
            string manv = txtSMaNV.Text;
            string tennv = txtSTenNV.Text;
            dtgvNV.DataSource = DAO.NhanVienDAO.Instance.SearchNV(manv, tennv);
        }

        #endregion


    

        #region Bàn ăn
        string a = "";
        private void LoadBanAn()
        {
            Load_Lai_BanAn();
            disEnabledBanAn(true);
            bunifuTextBoxmabanan.Enabled = false;
            bunifuCustomDataGridBanAn.Columns["MaBan"].HeaderText = "Mã Bàn Ăn";
            bunifuCustomDataGridBanAn.Columns["SoChoNgoi"].HeaderText = "Số Ngồi Tối Đa";
        }
        private void Load_Lai_BanAn()
        {
            bunifuCustomDataGridBanAn.DataSource = BanAnDAO.Instance.getBanList();
        }
        private void BunifuCustomDataGridBanAn_SelectionChanged(object sender, EventArgs e)
        {
            int index = bunifuCustomDataGridBanAn.CurrentCell == null ? -1 : bunifuCustomDataGridBanAn.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxmabanan.Text = bunifuCustomDataGridBanAn.Rows[index].Cells[0].Value.ToString().Trim();
                bunifuTextBoxsochongoi.Text = bunifuCustomDataGridBanAn.Rows[index].Cells[1].Value.ToString().Trim();

            }
        }

        private void bunifuCustomDataGridBanAn_SelectionChanged_1(object sender, EventArgs e)
        {

            int index = bunifuCustomDataGridBanAn.CurrentCell == null ? -1 : bunifuCustomDataGridBanAn.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxmabanan.Text = bunifuCustomDataGridBanAn.Rows[index].Cells[0].Value.ToString().Trim();
                bunifuTextBoxsochongoi.Text = bunifuCustomDataGridBanAn.Rows[index].Cells[1].Value.ToString().Trim();

            }
        }

        private void disEnabledBanAn(bool x)
        {
            BtnThemBanAn.Enabled = x;
            BtnSuaBanAn.Enabled = x;
            BtnXoaBanAn.Enabled = x;
            BtnLuuBanAn.Enabled = !x;
            BtnHuyBanAn.Enabled = !x;
            bunifuTextBoxsochongoi.Enabled = !x;
        }
        private void BtnThemBanAn_Click(object sender, EventArgs e)
        {
            a = "them";
            disEnabledBanAn(false);
            bunifuTextBoxmabanan.Text = "Ban" + DataProvider.Instance.LaySTT(bunifuCustomDataGridBanAn.Rows.Count);
            bunifuTextBoxsochongoi.Text = "";
        }

        private void BtnSuaBanAn_Click(object sender, EventArgs e)
        {
            a = "sua";
            disEnabledBanAn(false);
            bunifuTextBoxmabanan.Enabled = false;
        }

        private void BtnXoaBanAn_Click(object sender, EventArgs e)
        {
            string maban = bunifuTextBoxmabanan.Text;
            DialogResult result = MessageBox.Show("Ban chắc chắn muốn xóa bàn số " + maban + " chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (BanAnDAO.Instance.XoaBan(maban))
                {
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Lai_BanAn();
                    disEnabledBanAn(true);
                }
                else
                {
                    MessageBox.Show("Xóa Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Load_Lai_BanAn();
                    disEnabledBanAn(true);
                }
            }
        }

        private bool Check()
        {
            if (bunifuTextBoxmabanan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxmabanan.Focus();
                return false;
            }
            if (bunifuTextBoxsochongoi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số chỗ ngòi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxsochongoi.Focus();
                return false;
            }
            return true;
        }
        private void BunifuButtonLuuBanAn_Click(object sender, EventArgs e)
        {
            string maban = bunifuTextBoxmabanan.Text;
            if (a == "them" && Check())
            {
                int sochongoi = int.Parse(bunifuTextBoxsochongoi.Text);
                if (BanAnDAO.Instance.ThemBan(maban, sochongoi))
                    MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (a == "sua" && Check())
            {
                int sochongoi = int.Parse(bunifuTextBoxsochongoi.Text);
                if (BanAnDAO.Instance.SuaBan(maban, sochongoi))
                    MessageBox.Show("Sủa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Load_Lai_BanAn();
            disEnabledBanAn(true);
        }

        private void BtnHuyBanAn_Click(object sender, EventArgs e)
        {
            Load_Lai_BanAn();
            disEnabledBanAn(true);
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            string ma = bunifuTextBox5.Text;
            bunifuCustomDataGridBanAn.DataSource = BanAnDAO.Instance.TimBan(ma);
        }



        //---------------------------------------------------------------------------------------------------------------------------------
        /* #region cái cũ
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
             bunifuCustomDataGridBanAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             bunifuCustomDataGridBanAn.DataSource = bandao.GetListBanAn();

             bunifuCustomDataGridBanAn.Columns["MABAN"].HeaderText = "Mã Bàn Ăn";
             bunifuCustomDataGridBanAn.Columns["SOCHONGOI"].HeaderText = "Số Ngồi Tối Đa";
             bunifuCustomDataGridBanAn.Columns["MAPYC"].HeaderText = "Mã Phiếu Yêu Cầu";
             //bunifuCustomDataGridBanAn.Columns["MABANAN"].Width = 100;
             //bunifuCustomDataGridBanAn.Columns["SOCHONGOI"].Width = 200;
             //bunifuCustomDataGridBanAn.Columns["MAPYC"].Width = 200;
         }
         public bool CheckThemBA()
         {

             if (bunifuTextBoxmabanan.Text.Trim().Equals(""))
             {
                 MessageBox.Show("Lỗi", "Bạn chưa nhập số bàn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 bunifuTextBoxmabanan.Focus();
                 return false;
             }

             if (bunifuTextBoxsochongoi.Text.Trim().Equals(""))
             {
                 MessageBox.Show("Lỗi", "Bạn chưa nhập số chỗ ngồi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 bunifuTextBoxsochongoi.Focus();
                 return false;
             }
             return true;
         }
         public void Load_Lai_BanAn()
         {
             //bunifuCustomDataGridBanAn.DataSource = (bandao.GetListBanAn());
         }


         private void BunifuCustomDataGridBanAn_SelectionChanged(object sender, EventArgs e)
         {

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

         private void BtnHuyBanAn_Click(object sender, EventArgs e)
         {
             Load_Lai_BanAn();
             MacDinhBanAn();
         }
         #endregion*/
        #endregion

        #region Nguyên liệu
        string b = "";
        private void Load_NL()
        {
            Load_Lai_NL();
            bunifuTextBoxMaNL.Enabled = false;
            DisEnabledNL(true);
            bunifuCustomDataGridNL.Columns["MANL"].HeaderText = "Mã Nguyên Liệu";
            bunifuCustomDataGridNL.Columns["TENNL"].HeaderText = "Tên Nguyên Liệu";
            bunifuCustomDataGridNL.Columns["DVT"].HeaderText = "Đơn Vị Tính";
            bunifuCustomDataGridNL.Columns["DONGIA"].HeaderText = "Đơn Giá";
            bunifuCustomDataGridNL.Columns["SOLUONG"].HeaderText = "Số Lượng";

        }
        private void Load_Lai_NL()
        {
            bunifuCustomDataGridNL.DataSource = NguyenLieuDAO.Instance.getNguyeLieuList();

        }
        private void DisEnabledNL(bool a)
        {
            bunifuTextBoxTenNL.Enabled = !a;
            bunifuTextBoxDVT.Enabled = !a;
            bunifuTextBoxDonGia.Enabled = !a;
            bunifuTextBoxSoLuong.Enabled = !a;

            BtnThemNguyenLieu.Enabled = a;
            BtnSuaNguyenLieu.Enabled = a;
            BtnXoaNguyenLieu.Enabled = a;
            BtnLuuNguyenLieu.Enabled = !a;
            BtnHuyNguyenLieu.Enabled = !a;
        }
        private void BunifuCustomDataGridNL_SelectionChanged(object sender, EventArgs e)
        {
            int index = bunifuCustomDataGridNL.CurrentCell == null ? -1 : bunifuCustomDataGridNL.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxMaNL.Text = bunifuCustomDataGridNL.Rows[index].Cells[0].Value.ToString().Trim();
                bunifuTextBoxTenNL.Text = bunifuCustomDataGridNL.Rows[index].Cells[1].Value.ToString().Trim();
                bunifuTextBoxDVT.Text = bunifuCustomDataGridNL.Rows[index].Cells[2].Value.ToString().Trim();
                bunifuTextBoxDonGia.Text = bunifuCustomDataGridNL.Rows[index].Cells[3].Value.ToString().Trim();
                bunifuTextBoxSoLuong.Text = bunifuCustomDataGridNL.Rows[index].Cells[4].Value.ToString().Trim();
            }
        }
        private bool CheckNL()
        {
            if (bunifuTextBoxMaNL.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập mã nguyên liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxMaNL.Focus();
                return false;
            }

            if (bunifuTextBoxTenNL.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập tên nguyên liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxTenNL.Focus();
                return false;
            }
            if (bunifuTextBoxDVT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập đơn vị tính!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxDVT.Focus();
                return false;
            }
            if (bunifuTextBoxDonGia.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập đơn giá!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxDonGia.Focus();
                return false;
            }
            if (bunifuTextBoxSoLuong.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập số lượng!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxSoLuong.Focus();
                return false;
            }
            return true;
        }
        private void BtnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            b = "them";
            DisEnabledNL(false);
            bunifuTextBoxMaNL.Text = "NL" + DataProvider.Instance.LaySTT(bunifuCustomDataGridNL.Rows.Count);
            bunifuTextBoxTenNL.Text = "";
            bunifuTextBoxDVT.Text = "";
            bunifuTextBoxDonGia.Text = "";
            bunifuTextBoxSoLuong.Text = "";
        }

        private void BtnSuaNguyenLieu_Click(object sender, EventArgs e)
        {
            b = "sua";
            DisEnabledNL(false);
            bunifuTextBoxMaNL.Enabled = false;
        }

        private void BtnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            string ma = bunifuTextBoxMaNL.Text;
            string ten = bunifuTextBoxTenNL.Text;
            DialogResult result = MessageBox.Show("Bạn chắc chắm muốn xóa Nguyên Liệu: " + ten + " có mã là " + ma + " này chứ?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == result)
            {
                if (NguyenLieuDAO.Instance.XoaNL(ma))
                {
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Lai_NL();
                    DisEnabledNL(true);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnHuyNguyenLieu_Click(sender, e);
                }
            }
        }

        private void BtnLuuNguyenLieu_Click(object sender, EventArgs e)
        {
            string ma = bunifuTextBoxMaNL.Text;
            string ten = bunifuTextBoxTenNL.Text;
            string dvt = bunifuTextBoxDVT.Text;

            if (b == "them" && CheckNL())
            {
                int dongia = int.Parse(bunifuTextBoxDonGia.Text);
                int soluong = int.Parse(bunifuTextBoxSoLuong.Text);
                if (NguyenLieuDAO.Instance.ThemNguyenLieu(ma, ten, dvt, dongia, soluong))
                {
                    MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Lai_NL();
                    DisEnabledNL(true);
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnHuyNguyenLieu_Click(sender, e);
                }
            }
            else if (b == "sua" && CheckNL())
            {
                int dongia = int.Parse(bunifuTextBoxDonGia.Text);
                int soluong = int.Parse(bunifuTextBoxSoLuong.Text);

                if (NguyenLieuDAO.Instance.SuaNL(ma, ten, dvt, dongia, soluong))
                {
                    MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Lai_NL();
                    DisEnabledNL(true);
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnHuyNguyenLieu_Click(sender, e);
                }
            }
        }

        private void BtnHuyNguyenLieu_Click(object sender, EventArgs e)
        {
            Load_Lai_NL();
            DisEnabledNL(true);
        }

        private void bunifuTextBox17_TextChanged(object sender, EventArgs e)
        {
            string ten = bunifuTextBox17.Text;
            bunifuCustomDataGridNL.DataSource = NguyenLieuDAO.Instance.TimNguyenLieu(ten);
        }





        /* #region cái cũ
         readonly NguyenLieuDAO NLdao = new NguyenLieuDAO();
         //readonly NguyenLieuDTO NLdto = new NguyenLieuDTO();
         string luu = "";
         public void MacDinhNL()
         {
             BtnThemNguyenLieu.Text = "Thêm";
             bunifuTextBoxMaNL.Enabled = false;
             bunifuTextBoxTenNL.Enabled = false;
             bunifuTextBoxDVT.Enabled = false;
             bunifuTextBoxDonGia.Enabled = false;

             BtnThemNguyenLieu.Enabled = true;
             BtnSuaNguyenLieu.Enabled = true;
             BtnXoaNguyenLieu.Enabled = true;
             BtnLuuNguyenLieu.Enabled = false;
             BtnHuyNguyenLieu.Enabled = false;
         }
         public void SuaNL()
         {
             BtnThemNguyenLieu.Text = "Thêm";
             bunifuTextBoxMaNL.Enabled = true;
             bunifuTextBoxTenNL.Enabled = true;
             bunifuTextBoxDVT.Enabled = true;
             bunifuTextBoxDonGia.Enabled = true;

             BtnThemNguyenLieu.Enabled = false;
             BtnSuaNguyenLieu.Enabled = true;
             BtnXoaNguyenLieu.Enabled = false;
             BtnLuuNguyenLieu.Enabled = true;
             BtnHuyNguyenLieu.Enabled = true;
         }
         public void ThemNL()
         {
             bunifuTextBoxMaNL.Text = "";
             bunifuTextBoxTenNL.Text = "";
             bunifuTextBoxDVT.Text = "";
             bunifuTextBoxDonGia.Text = "";
             bunifuTextBoxMaNL.Enabled = true;
             bunifuTextBoxTenNL.Enabled = true;
             bunifuTextBoxDVT.Enabled = true;
             bunifuTextBoxDonGia.Enabled = true;

             BtnThemNguyenLieu.Enabled = true;
             BtnThemNguyenLieu.Text = "Làm Mới";
             BtnSuaNguyenLieu.Enabled = false;
             BtnXoaNguyenLieu.Enabled = false;
             BtnLuuNguyenLieu.Enabled = true;
             BtnHuyNguyenLieu.Enabled = true;

         }
         public void Load_NL()
         {
             bunifuCustomDataGridNL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             bunifuCustomDataGridNL.DataSource = NLdao.GetListNguyenLieu();

             bunifuCustomDataGridNL.Columns["MANL"].HeaderText = "Mã Nguyên Liệu";
             bunifuCustomDataGridNL.Columns["TENNL"].HeaderText = "Tên Nguyên Liệu";
             bunifuCustomDataGridNL.Columns["DVT"].HeaderText = "Đơn Vị Tính";
             bunifuCustomDataGridNL.Columns["DONGIA"].HeaderText = "Đơn Giá";
         }
         public void Load_lai_NL()
         {
             //bunifuCustomDataGridNL.DataSource = NLdao.GetListNguyenLieu();
         }
         public bool CheckThemNL()
         {

             if (bunifuTextBoxMaNL.Text.Trim().Equals(""))
             {
                 MessageBox.Show("Lỗi", "Bạn chưa nhập mã nguyên liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 bunifuTextBoxMaNL.Focus();
                 return false;
             }

             if (bunifuTextBoxTenNL.Text.Trim().Equals(""))
             {
                 MessageBox.Show("Lỗi", "Bạn chưa nhập tên nguyên liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 bunifuTextBoxTenNL.Focus();
                 return false;
             }
             if (bunifuTextBoxDVT.Text.Trim().Equals(""))
             {
                 MessageBox.Show("Lỗi", "Bạn chưa nhập đơn vị tính!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 bunifuTextBoxDVT.Focus();
                 return false;
             }
             if (bunifuTextBoxDonGia.Text.Trim().Equals(""))
             {
                 MessageBox.Show("Lỗi", "Bạn chưa nhập đơn giá!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 bunifuTextBoxDonGia.Focus();
                 return false;
             }
             return true;
         }
         private void BtnThemNguyenLieu_Click(object sender, EventArgs e)
         {
             ThemNL();
             luu = "them";
         }
         private void BtnSuaNguyenLieu_Click(object sender, EventArgs e)
         {
             SuaNL();
             luu = "sua";
         }

         private void BtnHuyNguyenLieu_Click(object sender, EventArgs e)
         {
             MacDinhNL();
             Load_lai_NL();
         }

         private void BunifuCustomDataGridNL_SelectionChanged(object sender, EventArgs e)
         {
             int index = bunifuCustomDataGridNL.CurrentCell == null ? -1 : bunifuCustomDataGridNL.CurrentCell.RowIndex;
             if (index != -1)
             {
                 bunifuTextBoxMaNL.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[0].Value.ToString().Trim();
                 bunifuTextBoxTenNL.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                 bunifuTextBoxDVT.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[2].Value.ToString().Trim();
                 bunifuTextBoxDonGia.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[3].Value.ToString().Trim();
             }
         }


         #endregion*/
        #endregion

        
    }
}
