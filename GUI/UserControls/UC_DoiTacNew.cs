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
            loadNCC();
            clearAllBindings();
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
            disEnableBtnKH(true);
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
            tbChinhSuaTenKH.Enabled = !x;
            tbChinhSuaSDTKH.Enabled = !x;
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

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            disEnableBtnKH(false);
        }

        #endregion

        #region NhaCungCap

        private void loadNCC()
        {
            clearBindingsNCC();
            loadListNCC();
            nCCBinding();
            disEnableBtnNCC(true);
        }

        private void clearBindingsNCC()
        {
            foreach (Control c in gbChinhSuaNCC.Controls)
            {
                c.DataBindings.Clear();
            }

            foreach (Control c in gbTimKiemNCC.Controls)
            {
                c.DataBindings.Clear();
            }
        }

        private void loadListNCC()
        {
            dtgvNCC.DataSource = NhaCungCapDAO.Instance.getNCCList();
        }

        private void nCCBinding()
        {
            tbChinhSuaMaNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "mancc"));
            tbChinhSuaTenNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "tenncc"));
            tbChinhSuaSDTNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "sdt"));
            tbChinhSuaDiaChiNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "diachi"));
        }

        private void disEnableBtnNCC(bool x)
        {
            btnThemNCC.Enabled = x;
            btnSuaNCC.Enabled = x;
            btnXoaNCC.Enabled = x;
            btnLuuNCC.Enabled = !x;
            btnHuyNCC.Enabled = !x;
            tbChinhSuaTenNCC.Enabled = !x;
            tbChinhSuaSDTNCC.Enabled = !x;
            tbChinhSuaDiaChiNCC.Enabled = !x;
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            disEnableBtnNCC(false);
            clearBindingsNCC();
            tbChinhSuaMaNCC.Text = DataProvider.Instance.executeScalar("SELECT [dbo].[TAOMANCC]()").ToString();
            tbChinhSuaTenNCC.Text = "";
            tbChinhSuaSDTNCC.Text = "";
            tbChinhSuaDiaChiNCC.Text = "";
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            disEnableBtnNCC(false);
            clearBindingsNCC();
            tbChinhSuaMaNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "mancc"));
            tbChinhSuaTenNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "tenncc"));
            tbChinhSuaSDTNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "sdt"));
            tbChinhSuaDiaChiNCC.DataBindings.Add(new Binding("text", dtgvNCC.DataSource, "diachi"));
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            disEnableBtnNCC(false);
        }

        private void themSuaNCC(string mancc, string tenncc, string sdtncc, string diachincc)
        {
            DataProvider.Instance.executeNonQuery("exec [dbo].[ThemSuaNCC] @mancc , @tenncc , @sdtncc , @diachincc",
                new object[] {mancc, tenncc, sdtncc, diachincc});
        }

        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            string mancc = tbChinhSuaMaNCC.Text;
            string tenncc = tbChinhSuaTenNCC.Text;
            string sdtncc = tbChinhSuaSDTNCC.Text;
            string diachincc = tbChinhSuaDiaChiNCC.Text;
            themSuaNCC(mancc, tenncc, sdtncc, diachincc);
            clearBindingsNCC();
            loadNCC();
            disEnableBtnNCC(true);
        }

        private void btnHuyNCC_Click(object sender, EventArgs e)
        {
            disEnableBtnNCC(true);
            loadNCC();
        }

        private void tbTimKiemMaNCC_TextChange(object sender, EventArgs e)
        {
            string mancc = tbTimKiemMaNCC.Text;
            string tenncc = tbTimKiemTenNCC.Text;
            dtgvKH.DataSource = NhaCungCapDAO.Instance.timKiemNCC(mancc, tenncc);
        }

        private void tbTimKiemTenNCC_TextChange(object sender, EventArgs e)
        {
            string mancc = tbTimKiemMaNCC.Text;
            string tenncc = tbTimKiemTenNCC.Text;
            dtgvKH.DataSource = NhaCungCapDAO.Instance.timKiemNCC(mancc, tenncc);
        }


        #endregion

        
    }
}
