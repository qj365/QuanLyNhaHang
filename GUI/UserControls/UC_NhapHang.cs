using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachHang.DTO;
using QuanLyKhachHang.DAO;


namespace QuanLyKhachHang.UserControls
{
    public partial class UC_NhapHang : UserControl
    {
        public UC_NhapHang()
        {
            InitializeComponent();
            loadKhoiDau();
           
        }

        void loadKhoiDau()
        {
            addSuggestion();
            
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNhapHang.SelectTab(1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pageNhapHang.SelectTab(0);
        }

        void addSuggestion()
        {
            AutoCompleteStringCollection CollectionMaNL = new AutoCompleteStringCollection();
            AutoCompleteStringCollection CollectionTenNL = new AutoCompleteStringCollection();
            AutoCompleteStringCollection CollectionTenNCC = new AutoCompleteStringCollection();

            foreach (NguyenLieu item in NguyenLieuDAONew.Instance.getListNguyenLieu())
            {
                CollectionMaNL.Add(item.Manl);
                CollectionTenNL.Add(item.Tennl);
            }
            
            foreach (NhaCungCap item in NhaCungCapDAO.Instance.getListNCC())
            {
                CollectionTenNCC.Add(item.Tenncc);
            }
            txtMaNL.AutoCompleteCustomSource = CollectionMaNL;
            txtTenNL.AutoCompleteCustomSource = CollectionTenNL;
            txtNCC.AutoCompleteCustomSource = CollectionTenNCC;
        }

        private void btnTimMaNL_Click(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu nl = NguyenLieuDAONew.Instance.timNLTheoMa(txtMaNL.Text);
                txtTenNL.Text = nl.Tennl;
            }
            catch { }
        }

        private void btnTimTenNL_Click(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu nl = NguyenLieuDAONew.Instance.timNLtheoTen(txtTenNL.Text);
                txtMaNL.Text = nl.Manl;
            }
            catch { }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        
        private void btnThem_Click(object sender, EventArgs e)
        {

            int thanhtien = 0;
            int tongtien = 0;
            try
            {
                if (NguyenLieuDAONew.Instance.maNLtontai(txtMaNL.Text) == 0)
                    MessageBox.Show("Mã nguyên liệu không tồn tại");
                else
                {
                    NguyenLieu nl = NguyenLieuDAONew.Instance.timNLTheoMa(txtMaNL.Text);
                    if (ktTonTaiLsv(txtMaNL.Text) > -1)
                    {
                        int i = ktTonTaiLsv(txtMaNL.Text);
                        int soluong = int.Parse(lsvNhapHang.Items[i].SubItems[2].Text) + int.Parse(txtSL.Text);
                        if (soluong > 0)
                        {
                            lsvNhapHang.Items[i].SubItems[2].Text = soluong.ToString();
                            thanhtien = soluong * nl.Dongia;
                            lsvNhapHang.Items[i].SubItems[4].Text = thanhtien.ToString();
                        }
                        else
                        {
                            lsvNhapHang.Items.RemoveAt(i);
                        }
                    }
                    else
                    {
                        if (int.Parse(txtSL.Text) > 0)
                        {

                            ListViewItem listItem = new ListViewItem(nl.Manl);
                            listItem.SubItems.Add(nl.Tennl);
                            listItem.SubItems.Add(txtSL.Text);
                            listItem.SubItems.Add(nl.Dongia.ToString());

                            thanhtien = int.Parse(txtSL.Text) * nl.Dongia;
                            listItem.SubItems.Add(thanhtien.ToString());
                            lsvNhapHang.Items.Add(listItem);
                        }

                    }
                    for (int i = 0; i < lsvNhapHang.Items.Count; i++)
                    {
                        tongtien += int.Parse(lsvNhapHang.Items[i].SubItems[4].Text);
                    }
                    lblTongTien.Text = tongtien.ToString("N0") + " đ";
                }
            }
            catch { }
            
            
        }

        int ktTonTaiLsv(string manl)
        {
            for (int i = 0; i < lsvNhapHang.Items.Count; i++)
            {
                if (txtMaNL.Text == lsvNhapHang.Items[i].Text) 
                    return i;
            }
            return -1;
        }

        private void txtMaNL_Leave(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu nl = NguyenLieuDAONew.Instance.timNLTheoMa(txtMaNL.Text);
                txtTenNL.Text = nl.Tennl;
            }
            catch { }
        }

        private void txtTenNL_Leave(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu nl = NguyenLieuDAONew.Instance.timNLtheoTen(txtTenNL.Text);
                txtMaNL.Text = nl.Manl;
            }
            catch { }
        }

        private void lsvNhapHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhapHang.SelectedItems.Count == 0)
                return;
            ListViewItem item = lsvNhapHang.SelectedItems[0];
            btnNhapHang.Tag = item.Text;
            btnThem.Tag = lsvNhapHang.Items.IndexOf(lsvNhapHang.SelectedItems[0]);
        }

        void tinhTongTien(ListView lst, int index)
        {
            if (lsvNhapHang.Items.Count == 0)
            {
                lblTongTien.Text = "0đ";
                return;
            }
                
            int tongtien = 0;
            int sl = int.Parse(lsvNhapHang.Items[index].SubItems[2].Text);
            int dg = int.Parse(lsvNhapHang.Items[index].SubItems[3].Text);
            lsvNhapHang.Items[index].SubItems[4].Text = (sl * dg).ToString();
            for (int i = 0; i < lsvNhapHang.Items.Count; i++)
            {
                
                tongtien += int.Parse(lsvNhapHang.Items[i].SubItems[4].Text);
            }
            lblTongTien.Text = tongtien.ToString("N0") + " đ";
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThem.Tag != null)
                {
                    int index = (int)btnThem.Tag;
                    int oldValue = int.Parse(lsvNhapHang.Items[index].SubItems[2].Text);
                    oldValue++;
                    lsvNhapHang.Items[index].SubItems[2].Text = oldValue.ToString();
                    tinhTongTien(lsvNhapHang, index);
                }
            }
            catch { }
            
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThem.Tag != null)
                {
                    int index = (int)btnThem.Tag;
                    int oldValue = int.Parse(lsvNhapHang.Items[index].SubItems[2].Text);
                    oldValue--;
                    if (oldValue > 0)
                    {
                        lsvNhapHang.Items[index].SubItems[2].Text = oldValue.ToString();

                    }
                    else
                    {
                        lsvNhapHang.Items[index].Remove();
                        btnThem.Tag = null;
                    }
                    tinhTongTien(lsvNhapHang, index);
                }
            }
            catch { }
            
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnThem.Tag != null)
                {
                    int index = (int)btnThem.Tag;
                    lsvNhapHang.Items[index].Remove();
                    tinhTongTien(lsvNhapHang, index);
                    btnThem.Tag = null;
                }
                
            }
            catch { }
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            lsvNhapHang.Items.Clear();
            lblTongTien.Text = "0đ";
            btnThem.Tag = null;
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn chắc chắn muốn nhập hàng?", "Thông báo", MessageBoxButtons.YesNo);
            if(r == DialogResult.Yes)
            {
                if(txtNCC.Text != "")
                {
                    Data.TenNCC = txtNCC.Text;
                    if(lsvNhapHang.Items.Count > 0)
                    {
                        DataTable data = NhaCungCapDAO.Instance.timNCCbangTen(txtNCC.Text);
                        if(data.Rows.Count > 0)
                        {
                            int tongtien = int.Parse(lblTongTien.Text.Replace(" đ", "").Replace(".", ""));
                            PhieuNhapDAO.Instance.themPN(tongtien, data.Rows[0].Field<string>(0), AccountDAO.username); // chú ý
                            for (int i = 0; i < lsvNhapHang.Items.Count; i++)
                            {
                                string manl = lsvNhapHang.Items[i].Text;
                                int dongia = int.Parse(lsvNhapHang.Items[i].SubItems[3].Text);
                                int sl = int.Parse(lsvNhapHang.Items[i].SubItems[2].Text);
                                int thanhtien = int.Parse(lsvNhapHang.Items[i].SubItems[4].Text);

                                PhieuNhapDAO.Instance.themCTPN(PhieuNhapDAO.Instance.getMaxPhieuNhap(), manl, dongia, sl, thanhtien);
                                NguyenLieuDAONew.Instance.themSLNguyenLieu(manl, sl);
                            }
                            MessageBox.Show("Nhập hàng thành công");
                            using(Form fr = new frNhapHangIn())
                            {
                                fr.ShowDialog();
                            }
                            lsvNhapHang.Items.Clear();
                            txtMaNL.Text = "";
                            txtTenNL.Text = "";
                            txtNCC.Text = "";
                            txtSL.Text = "";
                            

                        }

                        else
                        {
                            MessageBox.Show("Tên nhà cung cấp không tồn tại");
                            pageNhapHang.SelectTab(0);
                        }
                        

                    }
                    else
                    {
                        MessageBox.Show("Không có nguyên liệu trong danh sách nhập");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên nhà cung cấp");
                    pageNhapHang.SelectTab(0);
                }
            }
        }
    }
}
