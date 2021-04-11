using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyKhachHang.DAO;

namespace QuanLyKhachHang.GUI.UserControls.DoiTac
{
    public partial class UC_DoiTacNew : UserControl
    {
        public UC_DoiTacNew()
        {
            InitializeComponent();
            loadKH();
            disEnableBtnKH(true);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(0);
            loadKH();
            clearAllBindings();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(1);
        }

        private void clearAllBindings()
        {
            clearBindingsKH();
        }

        #region KhachHang

        private void loadKH()
        {
            clearBindingsKH();
            loadListKH();
            kHBinding();
        }

        private void clearBindingsKH()
        {
            foreach (Control c in gbChinhSuaKH.Controls)
            {
                c.DataBindings.Clear();
            }
            foreach (Control c in gbTimKiemKH.Controls)
            {
                c.DataBindings.Clear();
            }
        }

        private void loadListKH()
        {
            dtgvKH.DataSource = KhachHangDAO.Instance.getKHList();
        }

        void kHBinding()
        {
            tbChinhSuaMaKH.DataBindings.Add(new Binding("text", dtgvKH.DataSource, "makh"));
            tbChinhSuaTenKH.DataBindings.Add(new Binding("text", dtgvKH.DataSource, "tenkh"));
            tbChinhSuaSDTKH.DataBindings.Add(new Binding("text", dtgvKH.DataSource, "sdt"));
        }

        private void disEnableBtnKH(bool x)
        {
            btnThemKH.Enabled = x;
            btnSuaKH.Enabled = x;
            btnXoaKH.Enabled = x;
            btnLuuKH.Enabled = !x;
            btnHuyKH.Enabled = !x;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            disEnableBtnKH(false);
            clearBindingsKH();
            tbChinhSuaMaKH.Text = DataProvider.Instance.executeScalar("SELECT [dbo].[TAOMAKH]()").ToString();
            tbChinhSuaTenKH.Text = "";
            tbChinhSuaSDTKH.Text = "";
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            disEnableBtnKH(false);
            clearBindingsKH();
            tbChinhSuaMaKH.DataBindings.Add(new Binding("text", dtgvKH.DataSource, "makh"));
            tbChinhSuaTenKH.DataBindings.Add(new Binding("text", dtgvKH.DataSource, "tenkh"));
            tbChinhSuaSDTKH.DataBindings.Add(new Binding("text", dtgvKH.DataSource, "sdt"));
        }

        private void themSuaKH(string makh, string tenkh, string sdtkh)
        {
            DataProvider.Instance.executeNonQuery("exec [dbo].[ThemSuaKH] @makh , @tenkh , @sdtkh",
                new object[] {makh, tenkh, sdtkh});
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            string makh = tbChinhSuaMaKH.Text;
            string tenkh = tbChinhSuaTenKH.Text;
            string sdtkh = tbChinhSuaSDTKH.Text;
            themSuaKH(makh, tenkh, sdtkh);
            clearBindingsKH();
            loadKH();
            disEnableBtnKH(true);
        }

        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            disEnableBtnKH(true);
            loadKH();
        }

        private void tbTimKiemMaKH_TextChange(object sender, EventArgs e)
        {
            string makh = tbTimKiemMaKH.Text;
            string tenkh = tbTimKiemTenKH.Text;
            dtgvKH.DataSource = KhachHangDAO.Instance.timKiemKH(makh, tenkh);
        }

        private void tbTimKiemTenKH_TextChange(object sender, EventArgs e)
        {
            string makh = tbTimKiemMaKH.Text;
            string tenkh = tbTimKiemTenKH.Text;
            dtgvKH.DataSource = KhachHangDAO.Instance.timKiemKH(makh, tenkh);
        }


        #endregion

        #region NhaCungCap

        private void disEnableBtnNCC(bool x)
        {
            btnThemNCC.Enabled = x;
            btnSuaNCC.Enabled = x;
            btnXoaNCC.Enabled = x;
            btnLuuNCC.Enabled = !x;
            btnHuyNCC.Enabled = !x;
        }






        #endregion
    }
}
