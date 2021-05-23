using System.Collections.Generic;
using System.Data;
using QuanLyKhachHang.DTO;

namespace QuanLyKhachHang.DAO
{
    class NguyenLieuDAO
    {

        private static NguyenLieuDAO instance;

        internal static NguyenLieuDAO Instance
        {
            get { if (instance == null) instance = new NguyenLieuDAO(); return instance; }
            private set { instance = value; }
        }

        private NguyenLieuDAO() { }

        public DataTable getNguyeLieuList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from NguyenLieu");
            return table;
        }
        public DataTable TimNguyenLieu(string ten)
        {
            string query = string.Format("SELECT * FROM NguyenLieu WHERE(TenNL LIKE N'%" + ten + "%' OR '" + ten + "' = '')");
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }

        public List<NguyenLieuDTO> loadNguyenLieuList()
        {
            List<NguyenLieuDTO> tableList = new List<NguyenLieuDTO>();
            DataTable data = DataProvider.Instance.executeQuery("select * from NguyenLieu");
            foreach (DataRow item in data.Rows)
            {
                NguyenLieuDTO table = new NguyenLieuDTO(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool ThemNguyenLieu(string ma, string ten, string dvt, int dongia, int soluong)
        {
            string query = string.Format("[dbo].[proc_insertNL] N'{0}',N'{1}',N'{2}',{3},{4}", ma, ten, dvt, dongia, soluong);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        /*create proc[dbo].[proc_insertNL] (@ma nchar (10),@ten nvarchar(50), @dvt nvarchar(30), @dongia int, @soluong int)
           as
           begin
               insert into NGUYENLIEU(MANL, TENNL, DVT, DONGIA, SoLuong)
               values(@Ma, @ten, @dvt, @dongia, @soluong)
           end*/
        public bool SuaNL(string ma, string ten, string dvt, int dongia, int soluong)
        {
            string query = string.Format("[dbo].[updateNL] N'{0}',N'{1}',N'{2}',{3},{4}", ma, ten, dvt, dongia, soluong);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        /* create proc[dbo].[updateNL] (@ma nchar (10), @ten nvarchar(50), @dvt nvarchar(30), @dongia int, @soluong int )
           as
           begin
             update NGUYENLIEU set DVT = @dvt, DONGIA = @dongia, TenNL = @ten, SoLuong = @soluong where MaNL = @ma
          end*/
        public bool XoaNL(string ma)
        {
            string ten = "Nguyên Liệu Này Đã Xóa";
            string dvt = "";
            int dongia = 0;
            int soluong = 0;
            string query = string.Format("[dbo].[updateNL] N'{0}',N'{1}',N'{2}',{3},{4}", ma, ten, dvt, dongia, soluong);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }


        /*#region cái cũ
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
        create proc[dbo].[updateNL] (@ma char (10), @dvt nvarchar(30), @dongia int )
           as
           begin
             update NGUYENLIEU set DVT = @dvt, DONGIA = @dongia where Ma = @ma
          end
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
        create proc[dbo].[proc_insertNL] (@ma char (10),@ten nvarchar(50), @dvt nvarchar(30), @dongia int)
           as
           begin
               insert into NGUYENLIEU(MANL, TENNL, DVT, DONGIA)
               values(@Ma, @ten, @dvt, @dongia)
           end

#endregion*/
    }
}
