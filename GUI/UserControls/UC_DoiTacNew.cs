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

namespace QuanLyKhachHang.GUI.UserControls.DoiTac
{
    public partial class UC_DoiTacNew : UserControl
    {
        public UC_DoiTacNew()
        {
            InitializeComponent();
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(0);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(1);
        }

        private string connectionStr = @"Data Source=DESKTOP-EIE72SO;Initial Catalog=QUANLYNHAHANG;Integrated Security=True";

        #region KhachHang
        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionStr);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand ThemNCC = new SqlCommand("ThemKhachHang", sqlCon);
            ThemNCC.CommandType = CommandType.StoredProcedure;
            ThemNCC.Parameters.AddWithValue("@MAKH", bunifuTextBox11.Text.Trim());
            ThemNCC.Parameters.AddWithValue("@TENKH", bunifuTextBox12.Text.Trim());
            ThemNCC.Parameters.AddWithValue("@SDT", bunifuTextBox13.Text.Trim());
            ThemNCC.ExecuteNonQuery();
            MessageBox.Show("Thanh cong");
        }

        /*
CREATE PROCEDURE dbo.ThemKhachHang
    @MAKH AS CHAR(10),
	@TENKH AS NVARCHAR(50),
	@SDT AS CHAR(10)
AS
BEGIN
    INSERT dbo.KHACHHANG
    (
        MAKH,
        TENKH,
        SDT
    )
    VALUES
    (   @MAKH,  -- MAKH - char(10)
        @TENKH, -- TENKH - nvarchar(50)
        @SDT   -- SDT - char(10)
        )
END
GO
         */

        #endregion

        #region NhaCungCap
        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionStr);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand ThemNCC = new SqlCommand("ThemNCC", sqlCon);
            ThemNCC.CommandType = CommandType.StoredProcedure;
            ThemNCC.Parameters.AddWithValue("@MANCC", bunifuTextBox3.Text.Trim());
            ThemNCC.Parameters.AddWithValue("@TENNCC", bunifuTextBox1.Text.Trim());
            ThemNCC.Parameters.AddWithValue("@DIACHI", bunifuTextBox6.Text.Trim());
            ThemNCC.Parameters.AddWithValue("@SDT", bunifuTextBox2.Text.Trim());
            ThemNCC.ExecuteNonQuery();
            MessageBox.Show("Thanh cong");
        }

        /*
CREATE PROCEDURE dbo.ThemNCC
    @MANCC AS CHAR(10),
	@TENNCC AS nvarchar(50),
	@DIACHI AS nvarchar(100),
	@SDT AS CHAR(10)
AS
BEGIN
    INSERT dbo.NHACUNGCAP
    (
        MANCC,
        TENNCC,
        DIACHI,
        SDT
    )
    VALUES
    (   @MANCC,  -- MANCC - char(10)
        @TENNCC, -- TENNCC - nvarchar(50)
        @DIACHI, -- DIACHI - nvarchar(100)
        @SDT   -- SDT - char(10)
        )
END
GO        
        */
        #endregion


    }
}
