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
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            pageThanhToan.SetPage(tabBan);
            
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
                        btn.Text = "    Bàn " + item.Maban + Environment.NewLine + Environment.NewLine + "Trống";
                        break;
                    default:
                        btn.BackColor = Color.FromArgb(210, 56, 108);
                        btn.Text = "    Bàn " + item.Maban + Environment.NewLine + Environment.NewLine + "Có người";
                        break;
                }
                fpnlBanAn.Controls.Add(btn);
            }
        }

        void showBill(string maban)
        {
            List<ChiTietDatMon> ctList = ChiTietDatMonDAO.Instance.getChiTietDatMon(PhieuYeuCauDAO.Instance.getPycByMaban(maban));
        }


        #endregion

        #region Events

        private void btn_Click(object sender, EventArgs e)
        {
            string maban = ((sender as Button).Tag as Table).Maban;
            showBill(maban);
        }



        #endregion
    }
}
