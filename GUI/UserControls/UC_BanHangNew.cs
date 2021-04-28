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

namespace QuanLyKhachHang.GUI.UserControls
{
    public partial class UC_BanHangNew : UserControl
    {
        public UC_BanHangNew()
        {
            InitializeComponent();
            loadBanHang();
            
        }

        List<Table> lstTables = new List<Table>();

        #region Methods
        void loadBanHang()
        {
            loadTable();
            loadLoaiMon();
            lblBan.Visible = false;
            loadChuyenBan();
        }


        public void loadTable()
        {
            List<Table> tableList = TableDAO.Instance.loadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.tableWeight, Height = TableDAO.tableHeight };
                
                Font f = new Font("Open Sans", 10, FontStyle.Bold);
                btn.Font = f;
                btn.FlatStyle = FlatStyle.Flat;
                btn.ForeColor = Color.White;

                CheckBox chk = new CheckBox();
                chk.Parent = btn;
                chk.Location = new Point(5, 5);
                chk.BackColor = Color.Transparent;
                chk.Visible = false;

                btn.Click += btn_Click;
                chk.CheckedChanged += chk_CheckedChanged;

                btn.Tag = item;
                chk.Tag = item;

                switch (item.Mapyc)
                {
                    case "":
                        btn.BackColor = Color.FromArgb(233, 137, 126);
                        btn.Text = "Bàn " + item.Maban + Environment.NewLine + Environment.NewLine + "Trống";
                        break;
                    default:
                        btn.BackColor = Color.FromArgb(210, 56, 108);
                        btn.Text = "Bàn " + item.Maban + Environment.NewLine + Environment.NewLine + "Có người";
                        break;
                }
                fpnlBanAn.Controls.Add(btn);
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            lblBan.Visible = true;
            lblBan.Text = "Bàn  ";
            if ((sender as CheckBox).Checked)
            {
                lstTables.Add((sender as CheckBox).Tag as Table);
                
            }
            else
            {
                lstTables.Remove((sender as CheckBox).Tag as Table);
                
            }
            foreach (Table item in lstTables)
            {
                lblBan.Text += " " + item.Maban;
            }
            
        }

        void showBill(string maban)
        {
            lsvThucDon.Items.Clear();
            List<ChiTietDatMon> ctList = ChiTietDatMonDAO.Instance.getChiTietDatMon(PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(maban));
            int tongTien = 0;
            foreach (ChiTietDatMon item in ctList)
            {   
                ListViewItem listItem = new ListViewItem(item.Mama);
                listItem.SubItems.Add(MonAnDAO.Instance.getTenMonByMaMon(item.Mama.ToString()));
                listItem.SubItems.Add(item.Dongia.ToString());
                listItem.SubItems.Add(item.Soluong.ToString());
                listItem.SubItems.Add(item.Thanhtien.ToString());
                lsvThucDon.Items.Add(listItem);

                tongTien += item.Thanhtien;
            }
            lblTongTien.Text = tongTien.ToString("N0") + "đ";
        }

        void loadLoaiMon()
        {
            List<LoaiMon> list = LoaiMonDAO.Instance.getListLoaiMon();
            cbLoaiMon.DataSource = list;
            cbLoaiMon.DisplayMember = "Tenloaimon";
        }
        void loadMonAnbyLoaiMon(string maloai)
        {
            List<MonAn> list = MonAnDAO.Instance.getMonAnByLoaiMon(maloai);
            cbMonAn.DataSource = list;
            cbMonAn.DisplayMember = "Tenmon";
        }

        void loadChuyenBan()
        {
            cbChuyenBan.DataSource = TableDAO.Instance.loadTableList();
            cbChuyenBan.DisplayMember = "maban";
            cbChuyenBan.SelectedIndex = -1;
            cbChuyenBan.Text = "  Chuyển bàn";
        }

        #endregion

        #region Events
        private void btnBan_Click(object sender, EventArgs e)
        {
            pageThanhToan.SetPage(tabBan);
            fpnlBanAn.Controls.Clear();
            pageThanhToan.Tag = null;
            loadTable();
            ckbChonNhieuBan.Visible = true;
            cbChuyenBan.SelectedIndex = -1;
            cbChuyenBan.Text = "  Chuyển bàn";
            if (ckbChonNhieuBan.Checked)
                lblBan.Visible = false;
            if (btnBan.selected == false)
                ckbChonNhieuBan.Checked = false;
            
        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            pageThanhToan.SetPage(tabThucDon);
            ckbChonNhieuBan.Visible = false;
        }

        
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lsvThucDon.Tag != null)
            {
                Table table = lsvThucDon.Tag as Table;
                string mapyc = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(table.Maban);
                if (mapyc != "-1")
                {
                    Data.MaPYC = mapyc;
                    using (frThanhToan frtt = new frThanhToan())
                    {
                        frtt.ShowDialog();
                        
                            fpnlBanAn.Controls.Clear();
                            loadTable();

                        showBill(table.Maban);
                        
                    }

                }
                else
                {
                    MessageBox.Show("Không thể thanh toán bàn trống");
                }
                
            }
        }

        

        private void btn_Click(object sender, EventArgs e)
        {
            if(ckbChonNhieuBan.Checked == false)
            {
                string maban = ((sender as Button).Tag as Table).Maban;
                lsvThucDon.Tag = (sender as Button).Tag;
                showBill(maban);
                btnThucDon_Click(sender, e);
                btnThucDon.selected = true;
                btnBan.selected = false;
                lblBan.Text = "Bàn    " + maban;
                lblBan.Visible = true;
                cbChuyenBan.SelectedIndex = -1;
                cbChuyenBan.Text = "  Chuyển bàn";
            }
        }
        private void cbLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maloai = "";
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            LoaiMon selected = cb.SelectedItem as LoaiMon;
            maloai = selected.Malm;
            loadMonAnbyLoaiMon(maloai);
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (ckbChonNhieuBan.Checked)
                {
                    foreach (Table table in lstTables)
                    {
                        string mapyc = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(table.Maban);
                        string mamon = (cbMonAn.SelectedItem as MonAn).Mama;
                        
                        {
                            int soluong = int.Parse(txtSoLuong.Text);

                            if (mapyc == "-1")
                            {
                                PhieuYeuCauDAO.Instance.insertPYC(AccountDAO.username, table.Maban); // chú ý
                                ChiTietDatMonDAO.Instance.insertCTDatMon(PhieuYeuCauDAO.Instance.getMaxPYC(), mamon, soluong);
                            }
                            else
                            {
                                ChiTietDatMonDAO.Instance.insertCTDatMon(mapyc, mamon, soluong);
                                if (ChiTietDatMonDAO.Instance.kiemTraCTDatMon(mapyc) == 0)
                                    DataProvider.Instance.executeNonQuery("exec HuyBan @maban", new object[] { table.Maban });
                            }
                            showBill(table.Maban);
                        }
                    }
                }
                else
                {
                    if(lsvThucDon.Tag != null)
                    
                    {
                        Table table = lsvThucDon.Tag as Table;
                        string mapyc = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(table.Maban);
                        string mamon = (cbMonAn.SelectedItem as MonAn).Mama;
                        int soluong = int.Parse(txtSoLuong.Text);

                        if (mapyc == "-1")
                        {
                            PhieuYeuCauDAO.Instance.insertPYC(AccountDAO.username, table.Maban); // chú ý
                            ChiTietDatMonDAO.Instance.insertCTDatMon(PhieuYeuCauDAO.Instance.getMaxPYC(), mamon, soluong);
                        }
                        else
                        {
                            ChiTietDatMonDAO.Instance.insertCTDatMon(mapyc, mamon, soluong);
                            if (ChiTietDatMonDAO.Instance.kiemTraCTDatMon(mapyc) == 0)
                                DataProvider.Instance.executeNonQuery("exec HuyBan @maban", new object[] { table.Maban });
                        }
                        showBill(table.Maban);
                    }
                }
            }
            catch { }
            
        }
        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (pageThanhToan.Tag != null)
            {
                Table table = lsvThucDon.Tag as Table;
                string mapyc = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(table.Maban);
                string mama = pageThanhToan.Tag.ToString();
                DataProvider.Instance.executeNonQuery("delete CHITIETDATMON where MAPYC = '" + mapyc + "' and MAMA = '" + mama + "'");
                showBill(table.Maban);
            }
            else return;
        }

        private void lsvThucDon_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lsvThucDon.SelectedItems.Count == 0)
                return;
            ListViewItem item = lsvThucDon.SelectedItems[0];
            pageThanhToan.Tag = item.Text;

        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (pageThanhToan.Tag != null)
                {
                    Table table = lsvThucDon.Tag as Table;
                    string mamon = pageThanhToan.Tag.ToString();
                    string mapyc = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(table.Maban);
                    ChiTietDatMonDAO.Instance.insertCTDatMon(mapyc, mamon, 1);
                    showBill(table.Maban);
                }
            }
            catch 
            {
                
            }
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (pageThanhToan.Tag != null)
            {
                Table table = lsvThucDon.Tag as Table;
                string mamon = pageThanhToan.Tag.ToString();
                string mapyc = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(table.Maban);
                ChiTietDatMonDAO.Instance.insertCTDatMon(mapyc, mamon, -1);
                showBill(table.Maban);
                int check = ChiTietDatMonDAO.Instance.kiemTraCTDatMon(mapyc);
                if (check == 0)
                    DataProvider.Instance.executeNonQuery("exec HuyBan @maban", new object[] { table.Maban });
            }
            else
                return;
        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            if (lsvThucDon.Tag != null)
            {
                Table table = lsvThucDon.Tag as Table;
                DataProvider.Instance.executeNonQuery("exec HuyBan @maban", new object[] { table.Maban });
                showBill(table.Maban);
                fpnlBanAn.Controls.Clear();
                loadTable();
            }
            


        }

        private void ckbChonNhieuBan_CheckedChanged(object sender, EventArgs e)
        {
            lstTables.Clear();
            lsvThucDon.Items.Clear();
            lblBan.Visible = false;
            lsvThucDon.Tag = null;
            lblTongTien.Text = "0đ";
            if (ckbChonNhieuBan.Checked)
            {
                btnCong.Enabled = false;
                btnTru.Enabled = false;
                btnXoaMon.Enabled = false;
                btnHuyBan.Enabled = false;
                cbChuyenBan.Enabled = false;
                foreach (Control btn in fpnlBanAn.Controls)
                {
                    if (btn is Button)
                    {
                        foreach (Control chk in btn.Controls)
                        {
                            chk.Visible = true;
                        }
                    }
                }
            }
            else
            {
                btnCong.Enabled = true;
                btnTru.Enabled = true;
                btnXoaMon.Enabled = true;
                btnHuyBan.Enabled = true;
                cbChuyenBan.Enabled = true;
                foreach (Control btn in fpnlBanAn.Controls)
                {
                    if (btn is Button)
                    {
                        foreach (Control chk in btn.Controls)
                        {
                            chk.Visible = false;
                            (chk as CheckBox).Checked = false;
                        }

                    }
                }
            }

        }
        void chuyenBan(string ban1, string ban2)
        {
            string mapyc1 = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(ban1);
            string mapyc2 = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(ban2);
            if (mapyc1 != "-1")
            {
                List<ChiTietDatMon> list = ChiTietDatMonDAO.Instance.getChiTietDatMon(mapyc1);
                if (mapyc2 == "-1")
                {
                    PhieuYeuCauDAO.Instance.insertPYC(AccountDAO.username, ban2); // chú ý                  
                    foreach (ChiTietDatMon item in list)
                    {
                        ChiTietDatMonDAO.Instance.insertCTDatMon(PhieuYeuCauDAO.Instance.getMaxPYC(), item.Mama, item.Soluong);
                    }

                }
                else
                {
                    foreach (ChiTietDatMon item in list)
                    {
                        ChiTietDatMonDAO.Instance.insertCTDatMon(mapyc2, item.Mama, item.Soluong);
                    }

                }
                DataProvider.Instance.executeNonQuery("exec HuyBan @maban", new object[] { ban1 });
            }
        }
        private void cbChuyenBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChuyenBan.SelectedIndex != -1)
            {
                if (lsvThucDon.Tag != null)
                {
                    string ban1 = (lsvThucDon.Tag as Table).Maban;
                    string ban2 = (cbChuyenBan.SelectedItem as Table).Maban;
                    if (ban1 == ban2)
                        MessageBox.Show("Không thể chuyển bàn đến bàn hiện tại");

                    else
                    {
                        if (MessageBox.Show(string.Format("Bạn thực sự muốn chuyển bàn {0} qua bàn {1}", ban1, ban2), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            chuyenBan(ban1, ban2);
                            btnBan_Click(sender, e);
                            btnBan.selected = true;
                            btnThucDon.selected = false;
                            lsvThucDon.Tag = null;
                            lblBan.Visible = false;
                            lsvThucDon.Items.Clear();
                            lblTongTien.Text = "0đ";
                        }
                    }
                }
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }


        #endregion


    }
}
