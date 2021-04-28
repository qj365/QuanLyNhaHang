using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachHang.DAO;
using QuanLyKhachHang.DTO;

namespace QuanLyKhachHang.DAO
{
    class NguyenLieuDAO
    {
        readonly DataProvider Da = new DataProvider();

        public NguyenLieuDTO[] GetListNguyenLieu()
        {
            DataTable table = Da.Query("select * from NGUYENLIEU");

            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            NguyenLieuDTO[] list = new NguyenLieuDTO[n];
            for (i = 0; i < n; i++)
            {
                list[i] = GetListNguyenLieu(table.Rows[i]);
            }
            return list;
        }
        public NguyenLieuDTO GetListNguyenLieu(DataRow row)
        {
            NguyenLieuDTO NL = new NguyenLieuDTO
            {
                MANL = row["MANL"].ToString().Trim(),
                TENNL = row["TENNL"].ToString().Trim(),
                DVT = row["DVT"].ToString().Trim(),
                DONGIA = int.Parse(row["DONGIA"].ToString())
            };
            return NL;
        }
        public bool Update_NL(NguyenLieuDTO NL)
        {
            Da.NonQuery("updateNL '" + NL.MANL + "', '" + NL.DVT + "', '" + NL.DONGIA + "'");
            return true;
        }
        /*create proc[dbo].[updateNL] (@ma char(10), @dvt nvarchar(30), @dongia int )
           as
           begin
             update NGUYENLIEU set DVT = @dvt, DONGIA = @dongia where Ma = @ma
          end*/
        public bool XoaNL(NguyenLieuDTO NL)
        {
            Da.NonQuery("delete NGUYENLIEU where MANL='" + NL.MANL + "'");
            return true;
        }
        public bool ThemNL(NguyenLieuDTO NL)
        {
            Da.NonQuery("proc_insertNL '" + NL.MANL + "','" + NL.TENNL + "','" + NL.DVT + "','" + NL.DONGIA + "'");
            return true;
        }
        /* create proc[dbo].[proc_insertNL] (@ma char(10),@ten nvarchar(50), @dvt nvarchar(30), @dongia int)
           as
           begin
               insert into NGUYENLIEU(MANL, TENNL, DVT, DONGIA)
               values(@Ma, @ten, @dvt, @dongia)
           end*/


    }
}
