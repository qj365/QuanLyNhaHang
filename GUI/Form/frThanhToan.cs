using QuanLyKhachHang.DAO;
using QuanLyKhachHang.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyKhachHang
{
    public partial class frThanhToan : Form
    {
        public frThanhToan()
        {
            InitializeComponent();
            loadBanDau();

        }

        void loadBanDau()
        {
            loadCbKhuyenMai();
            lblTraLai.Text = "0 đ";
            addSuggestion();
        }
        void addSuggestion()
        {
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            foreach (KhachHang item in KhachHangDAO.Instance.loadKhachHangList())
            {
                Collection.Add(item.Makh);
            }
            txtMaKH.AutoCompleteCustomSource = Collection;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkKhachHang.Checked)
            {
                txtMaKH.Enabled = true;
                txtSDT.Enabled = false;
                txtTenKH.Enabled = false;
                txtSDT.Text = "";
                txtTenKH.Text = "";
                txtMaKH.Text = "";
            }
            else
            {
                txtMaKH.Enabled = false;
                txtSDT.Enabled = true;
                txtTenKH.Enabled = true;
                txtMaKH.Text = DataProvider.Instance.executeScalar("select [dbo].TAOMAKH()").ToString();
                txtSDT.Text = "";
                txtTenKH.Text = "";
            }
        }

        void loadCbKhuyenMai()
        {
            cbKhuyeMai.DataSource = KhuyenMaiDAO.Instance.TimKiemKMChuaHetHan();
            cbKhuyeMai.DisplayMember = "fullkm";
            cbKhuyeMai.SelectedIndex = -1;
        }
        private void cbKhuyeMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhuyeMai.SelectedIndex == -1)
            {
                txtGiam.Text = "0 đ";
                float tongtien = float.Parse(HoaDonDAO.Instance.ThanhToan(Data.MaPYC, 0));
                txtTongTien.Text = tongtien.ToString("N0") + " đ";
            }

            else
            {
                string mapyc = Data.MaPYC.ToString();
                float km = (float)((cbKhuyeMai.SelectedItem) as KhuyenMaiDTO).Phantram;
                float tongtien = float.Parse(HoaDonDAO.Instance.ThanhToan(mapyc, 0));
                float tienthanhtoan = float.Parse(HoaDonDAO.Instance.ThanhToan(mapyc, km));
                txtTongTien.Text = tienthanhtoan.ToString("N0") + " đ";
                txtGiam.Text = (tongtien - tienthanhtoan).ToString("N0") + " đ";

                if (txtKhachTra.Text != "")
                {
                    float kt = float.Parse(txtKhachTra.Text);

                    if (kt >= tienthanhtoan)
                    {
                        lblTraLai.Text = (kt - tienthanhtoan).ToString("N0") + " đ";
                    }
                    else
                        lblTraLai.Text = "0 đ";
                }

            }

        }

        private void cbKhuyeMai_Format(object sender, ListControlConvertEventArgs e)
        {
            string makm = ((KhuyenMaiDTO)e.ListItem).Makm;
            string phantram = (((KhuyenMaiDTO)e.ListItem).Phantram.ToString());
            e.Value = makm + " - Giảm " + phantram + "%";
        }

        private void btnClearKM_Click(object sender, EventArgs e)
        {
            cbKhuyeMai.SelectedIndex = -1;
            txtGiam.Text = "0 đ";

        }




        private void txtKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtKhachTra_TextChanged(object sender, EventArgs e)
        {
            float kt = float.Parse(txtKhachTra.Text.Replace(" đ", ""));
            float tt = float.Parse(txtTongTien.Text.Replace(" đ", ""));
            if (kt >= tt)
            {
                lblTraLai.Text = (kt - tt).ToString("N0") + " đ";
            }
            else
                lblTraLai.Text = "0 đ";

        }

        private void btnLopCN_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = KhachHangDAO.Instance.timKHTheoMa(txtMaKH.Text);
                txtTenKH.Text = kh.Tenkh;
                txtSDT.Text = kh.Sdt;
            }
            catch { }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Data.Maban = TableDAO.Instance.getMaBanbyPYC(Data.MaPYC);
            Data.TongcongHD = txtTongTien.Text;
            if (txtMaKH.Text == "")
                MessageBox.Show("Vui lòng nhập thông tin khách hàng");
            else
            {
                if (chkKhachHang.Checked)
                {
                    if (txtTenKH.Text == "" || txtSDT.Text == "")
                        MessageBox.Show("Vui lòng nhập đủ thông tin khách hàng");
                    else
                    {
                        float tt = float.Parse(txtTongTien.Text.Replace(" đ", ""));
                        string makh = txtMaKH.Text;
                        string tenkh = txtTenKH.Text;
                        string sdt = txtSDT.Text;

                        DataProvider.Instance.executeNonQuery("exec [dbo].[ThemKhachHang] @MAKH , @TENKH , @SDT ", new object[] { makh, tenkh, sdt });

                        if (cbKhuyeMai.SelectedIndex == -1)
                        {

                            DataProvider.Instance.executeNonQuery("exec ThanhToanHoaDon @tongtien , @user , @mapyc , @makm , @makhn ",
                            new object[] { tt, AccountDAO.username, Data.MaPYC, DBNull.Value, makh }); //chú ý
                        }
                        else
                        {
                            string makm = ((cbKhuyeMai.SelectedItem) as KhuyenMaiDTO).Makm;
                            DataProvider.Instance.executeNonQuery("exec ThanhToanHoaDon @tongtien , @user , @mapyc , @makm , @makhn ",
                            new object[] { tt, AccountDAO.username, Data.MaPYC, makm, makh }); //chú ý
                        }

                    }

                }
                else
                {
                    string ttn = txtTongTien.Text.Replace(" đ", "");
                    float tt = float.Parse(ttn);
                    if (KhachHangDAO.Instance.kiemTraKH(txtMaKH.Text) > 0)
                    {
                        if (cbKhuyeMai.SelectedIndex == -1)
                        {
                            DataProvider.Instance.executeNonQuery("exec ThanhToanHoaDon @tongtien , @user , @mapyc , @makm , @makhn ",
                                new object[] { tt, AccountDAO.username, Data.MaPYC, DBNull.Value, txtMaKH.Text }); //chú ý
                        }
                        else
                        {
                            string makm = ((cbKhuyeMai.SelectedItem) as KhuyenMaiDTO).Makm;
                            DataProvider.Instance.executeNonQuery("exec ThanhToanHoaDon @tongtien , @user , @mapyc , @makm , @makhn ",
                                new object[] { tt, AccountDAO.username, Data.MaPYC, makm, txtMaKH.Text }); //chú ý
                        }
                    }
                    else
                        MessageBox.Show("Mã khách hàng không tồn tại");
                }
                MessageBox.Show("Thanh toán thành công");
                Data.ChietkhauHD = txtGiam.Text;
                Data.TongtienHD = txtTongTien.Text;
                
                using (Form fr = new frHoaDonIn())
                {
                    fr.ShowDialog();
                    
                }
                this.Close();



            }
        }


    }
}
