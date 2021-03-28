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
            loadTable();
            loadLoaiMon();
        }

        #region Giao Diện
        private void btnBan_Click(object sender, EventArgs e)
        {
            pageThanhToan.SetPage(tabBan);
            fpnlBanAn.Controls.Clear();
            loadTable();


        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            pageThanhToan.SetPage(tabThucDon);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            using(frThanhToan frtt = new frThanhToan())
            {
                frtt.ShowDialog();
            }
        }
        #endregion

        #region Methods
        void loadTable()
        {
            List<Table> tableList = TableDAO.Instance.loadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.tableWeight, Height = TableDAO.tableHeight };
                
                Font f = new Font("Open Sans", 10, FontStyle.Bold);
                btn.Font = f;
                btn.FlatStyle = FlatStyle.Flat;
                btn.ForeColor = Color.White;
                
                btn.Click += btn_Click;
                
                btn.Tag = item;

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

        

        void showBill(string maban)
        {
            lsvThucDon.Items.Clear();
            List<ChiTietDatMon> ctList = ChiTietDatMonDAO.Instance.getChiTietDatMon(PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(maban));
            int tongTien = 0;
            foreach (ChiTietDatMon item in ctList)
            {   
                ListViewItem listItem = new ListViewItem(MonAnDAO.Instance.getTenMonByMaMon(item.Mama.ToString()));
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
            cbLoaiMon.DisplayMember = "Tenlm";
        }
        void loadMonAnbyLoaiMon(string maloai)
        {
            List<MonAn> list = MonAnDAO.Instance.getMonAnByLoaiMon(maloai);
            cbMonAn.DataSource = list;
            cbMonAn.DisplayMember = "Tenmon";
        }

        #endregion

        #region Events

        private void btn_Click(object sender, EventArgs e)
        {
            string maban = ((sender as Button).Tag as Table).Maban;
            lsvThucDon.Tag = (sender as Button).Tag;
            showBill(maban);
            btnThucDon_Click(sender, e);
            btnThucDon.selected = true;
            btnBan.selected = false;
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
            Table table = lsvThucDon.Tag as Table;
            string mapyc = PhieuYeuCauDAO.Instance.getPycByMabanChuaThanhToan(table.Maban);
            string mamon = (cbMonAn.SelectedItem as MonAn).Mama;
            if (mapyc == "-1")
            {
                PhieuYeuCauDAO.Instance.insertPYC("NV1", table.Maban); // chú ý
                ChiTietDatMonDAO.Instance.insertCTDatMon(PhieuYeuCauDAO.Instance.getMaxPYC(), mamon, 1);
            }
            else
            {
                ChiTietDatMonDAO.Instance.insertCTDatMon(mapyc, mamon, 1);
            }
            showBill(table.Maban);
        }
        

        #endregion


    }
}
