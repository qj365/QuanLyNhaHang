using System.Collections.Generic;
using System.Data;
using QuanLyKhachHang.DTO;



namespace QuanLyKhachHang.DAO
{
    class BanAnDAO
    {

        private static BanAnDAO instance;

        internal static BanAnDAO Instance
        {
            get { if (instance == null) instance = new BanAnDAO(); return instance; }
            private set { instance = value; }
        }

        private BanAnDAO() { }

        public string getSoChoNgoibySoBan(string ma)
        {
            string data = DataProvider.Instance.executeScalar("select SochoNgoi from BanAN where MaBan = '" + ma + "'").ToString();
            return data;
        }
        public DataTable getBanList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select MaBan, SoChoNgoi from BanAn");
            return table;
        }
        public DataTable TimBan(string ma)
        {
            string query = string.Format("SELECT * FROM BanAn WHERE(MaBan LIKE '%' + '" + ma + "' + '%' OR '" + ma + "' = '')");
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }

        public List<BanAnDTO> loadBanList()
        {
            List<BanAnDTO> tableList = new List<BanAnDTO>();
            DataTable data = DataProvider.Instance.executeQuery("select * from BanAn");
            foreach (DataRow item in data.Rows)
            {
                BanAnDTO table = new BanAnDTO(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool ThemBan(string ma, int sochongoi)
        {
            string query = string.Format("[dbo].[proc_insertBA] '{0}',{1}", ma, sochongoi);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        /*create proc[dbo].[proc_insertBA] (@Ma nvarchar(10),@sochongoi int)
            as
            begin
            insert into BANAN(MABAN, SOCHONGOI, MAPYC)
            values(@Ma, @sochongoi)
            end*/
        public bool SuaBan(string ma, int sochongoi)
        {
            string query = string.Format("[dbo].[updateBA] '{0}',{1}", ma, sochongoi);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        /*create proc[dbo].[updateBA] (@ma varchar(10), @sochongoi int)
            as
            begin
            if (@sochongoi = '') set @sochongoi = 7
            update BANAN set SOCHONGOI = @sochongoi where MABAN = @ma
            end*/
        public bool XoaBan(string ma)
        {
            string query = string.Format("update BanAn set sochongoi = 0 where MaBan='{0}'", ma);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public int kiemTraBan(string ma)
        {
            int data = (int)DataProvider.Instance.executeScalar("select count(*) from BanAn where MaBan = '" + ma + "'");
            return data;
        }

        /*readonly DataProvider Da1 = new DataProvider();

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
        *//*create proc[dbo].[updateBA] (@ma varchar(10), @sochongoi int, @MaPYC varchar(10) )
           as
           begin
             if(@MaPYC like '') SET @MaPYC = 'null' 
             if(@sochongoi = '') set @sochongoi = 7
             update BANAN set SOCHONGOI = @sochongoi, MAPYC = @MaPYC where MABAN = @ma
          end*//*
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
        *//* create proc[dbo].[proc_insertBA] (@Ma nvarchar(10),@sochongoi int, @mapyc nvarchar(10))
           as
           begin
               if(@MaPYC like '') SET @MaPYC = 'null'
               insert into BANAN(MABAN, SOCHONGOI, MAPYC)
               values(@Ma, @sochongoi, @mapyc)
           end*/

    }
}
