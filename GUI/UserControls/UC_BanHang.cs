using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachHang.UserControls
{
    public partial class UC_BanHang : UserControl
    {
        public UC_BanHang()
        {
            InitializeComponent();
        }

        private void UC_BanHang_Load(object sender, EventArgs e)
        {

        }

       

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string[] arr = new string[6];
            ListViewItem itm;
            //thêm Item vào ListView
            arr[0] = "Rau muống xào tỏi";
            arr[1] = "Đĩa";
            arr[2] = "10";
            arr[3] = "10,000";
            arr[4] = "100,000";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
        }

        private void bunifuButton18_Click(object sender, EventArgs e)
        {
            using (ThanhToan tt = new ThanhToan())
            {
                tt.ShowDialog();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        /* private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             bunifuDataGridView1.Rows.Add(
                 new object[]
                 {
                     "Rau muống xào tỏi",
                     "Đĩa",
                     "2",
                     "10,000",
                     "20,000"

                 }
             );
             bunifuDataGridView1.Rows.Add(
                 new object[]
                 {
                     "Hamberger",
                     "Cái",
                     "2",
                     "5,000",
                     "10,000"

                 }
             );
         }*/
    }
}
