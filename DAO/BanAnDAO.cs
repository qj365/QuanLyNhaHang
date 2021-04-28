using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachHang.DTO;
using QuanLyKhachHang.DAO;


namespace QuanLyKhachHang.DAO
{
    class BanAnDAO
    {
        readonly DataProvider Da1 = new DataProvider();

        public BanAnDTO[] GetListBanAn()
        {
            DataTable table = Da1.Query("select * from BANAN");

            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            BanAnDTO[] list = new BanAnDTO[n];
            for (i = 0; i < n; i++)
            {
                list[i] = GetListBanAn(table.Rows[i]);
            }
            return list;
        }
        public BanAnDTO GetListBanAn(DataRow row)
        {
            BanAnDTO ban = new BanAnDTO
            {
                MABAN = row["MABAN"].ToString().Trim(),
                SOCHONGOI = int.Parse((row["SOCHONGOI"]).ToString()),
                MAPYC = row["MAPYC"].ToString().Trim()
            };
            return ban;

        }
        public bool Update_ban(BanAnDTO ban)
        {
            Da1.NonQuery("update BanAn set sochongoi =" + ban.SOCHONGOI + "where maban= '" + ban.MABAN + "'");
            return true;
        }
        /*create proc[dbo].[updateBA] (@ma varchar(10), @sochongoi int, @MaPYC varchar(10) )
           as
           begin
             if(@MaPYC like '') SET @MaPYC = 'null' 
             if(@sochongoi = '') set @sochongoi = 7
             update BANAN set SOCHONGOI = @sochongoi, MAPYC = @MaPYC where MABAN = @ma
          end*/
        public bool XoaBA(BanAnDTO ban)
        {
            Da1.NonQuery("delete BANAN where MABAN='" + ban.MABAN + "'");
            return true;
        }
        public bool ThemBA(BanAnDTO ban)
        {
            Da1.NonQuery("proc_insertBA '" + ban.MABAN + "', '" + ban.SOCHONGOI + "',null");
            return true;
        }
        /* create proc[dbo].[proc_insertBA] (@Ma nvarchar(10),@sochongoi int, @mapyc nvarchar(10))
           as
           begin
               if(@MaPYC like '') SET @MaPYC = 'null'
               insert into BANAN(MABAN, SOCHONGOI, MAPYC)
               values(@Ma, @sochongoi, @mapyc)
           end*/

    }
}
