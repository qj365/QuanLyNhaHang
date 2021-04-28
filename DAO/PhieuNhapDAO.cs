using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;

        internal static PhieuNhapDAO Instance
        {
            get { if (instance == null) instance = new PhieuNhapDAO(); return instance; }
            private set { instance = value; }
        }

        private PhieuNhapDAO() { }

        public DataTable getPhieuNhapList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select pn.MaPN, pn.NgayLap, pn.TongTien, ncc.TenNCC, pn.UserName from PhieuNhap pn inner join NhaCungCap ncc on ncc.MaNCC = pn.MaNCC");
            return table;
        }
        public DataTable TimPhieuNhap(string ma, string username, string ncc, DateTime ngaylap)
        {
            int yy = ngaylap.Year;
            int mm = ngaylap.Month;
            int day = ngaylap.Day;
            string query = string.Format("select pn.MaPN, pn.NgayLap, pn.TongTien, ncc.TenNCC, pn.UserName from PhieuNhap pn " +
                "inner join NhaCungCap ncc on ncc.MaNCC = pn.MaNCC WHERE(pn.MaPN LIKE '%" + ma + "%' OR '" + ma + "' = '') AND " +
                "(pn.UserName LIKE N'%" + username + "%' OR '" + username + "' = '') AND (pn.MaNCC LIKE '%" + getMaNCC(ncc) + "%' OR '" + getMaNCC(ncc) + "' = '')");
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }
        public string getMaNCC(string ncc)
        {
            string query = string.Format("select MaNCC from NhaCungCap where TenNCC = N'" + ncc + "'");
            DataTable table = DataProvider.Instance.executeQuery(query);
            string Ma = "";
            int n = table.Rows.Count;
            if (n == 1)
            {
                Ma = table.Rows[0]["MaNCC"].ToString().Trim();
            }

            return Ma;
        }
        public List<PhieuNhapDTO> loadPhieuNhapList()
        {
            List<PhieuNhapDTO> tableList = new List<PhieuNhapDTO>();
            DataTable data = DataProvider.Instance.executeQuery("select * from NguyenLieu");
            foreach (DataRow item in data.Rows)
            {
                PhieuNhapDTO table = new PhieuNhapDTO(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<String> getUserName()
        {
            DataTable table = DataProvider.Instance.executeQuery("Select UserName from TaiKhoan");
            List<String> listTK = new List<string>();
            int n = table.Rows.Count;
            int i;
            if (n == 0) return new List<string>();
            for (i = 0; i < n; i++)
            {
                listTK.Add(table.Rows[i]["UserName"].ToString().Trim());
            }

            return listTK;
        }
        public String getMaNCCNhe(String NCC)
        {
            if (NCC == "") return "";
            DataTable table = DataProvider.Instance.executeQuery("select MaNCC from NhaCungCap where TenNCC = N'" + NCC + "'");
            int n = table.Rows.Count;
            if (n == 1)
            {
                return table.Rows[0]["MaNCC"].ToString().Trim();
            }
            else
                return "";
        }
        public String getNhaCungCap(String Ma)
        {
            if (Ma == "") return "";
            DataTable table = DataProvider.Instance.executeQuery("Select TenNCC from NhaCungCap where MaNCC = '" + Ma + "'");
            int n = table.Rows.Count;
            if (n == 1)
            {
                return table.Rows[0]["TenNCC"].ToString().Trim();
            }

            return "";
        }
        public List<String> getNhaCungCap()
        {
            DataTable table = DataProvider.Instance.executeQuery("Select TenNCC from NhaCungCap");
            List<String> listNCC = new List<string>();
            int n = table.Rows.Count;
            int i;
            if (n == 0) return new List<string>();
            for (i = 0; i < n; i++)
            {
                listNCC.Add(table.Rows[i]["TenNCC"].ToString().Trim());
            }

            return listNCC;
        }
        public bool SuaPN(string ma, DateTime ngaylap, int tongtien, string ncc, string username)
        {
            string mancc = getMaNCCNhe(ncc);
            string query = string.Format("[dbo].[updatePN] N'{0}','{1}', {2}, N'{3}', N'{4}'", ma, ngaylap, tongtien, mancc, username);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        /* alter proc[dbo].[updatePN] (@ma nchar(10),@ngaylap datetime, @tongtien int, @mancc nvarchar(10), @username nvarchar(50) )
            as
            begin
            update PhieuNhap set NgayLap = @ngaylap, TongTien = @tongtien, MaNCC = @mancc, UserName = @username where MaPN = @ma
            end*/
        public bool XoaPN(string ma)
        {
            string query = string.Format("delete PhieuNhap where MaPN='{0}'", ma);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }




        /* #region cái cũ
         readonly DataProvider Da1 = new DataProvider();

         public PhieuNhapDTO[] GetListPhieuNhap()
         {
             DataTable table = Da1.Query("select MaPN, NgayLap, TongTien, MaNCC, UserName from PhieuNhap");

             int n = table.Rows.Count;
             int i;
             if (n == 0) return null;
             PhieuNhapDTO[] list = new PhieuNhapDTO[n];
             for (i = 0; i < n; i++)
             {
                 list[i] = GetListPhieuNhap(table.Rows[i]);
             }
             return list;
         }
         public PhieuNhapDTO GetListPhieuNhap(DataRow row)
         {
             PhieuNhapDTO pn = new PhieuNhapDTO
             {
                 MaPN = row["MaPN"].ToString().Trim(),
                 TongTien = int.Parse((row["TongTien"]).ToString()),
                 MaNCC = getNhaCungCap(row["MaNCC"].ToString().Trim()),
                 NgayLap = DateTime.Parse((row["NgayLap"]).ToString()),
                 UserName = row["UserName"].ToString()
             };
             return pn;

         }
         public bool SuaPhieuNhap(PhieuNhapDTO pn)
         {
             Da1.NonQuery("update PhieuNhap " +
                 "set MaNCC ='" + pn.MaNCC + "', NgayLap ='"+ pn.NgayLap+"', UserName = '"+pn.UserName+"', TongTien = "+pn.TongTien+"" +
                 "where MaPN= '" + pn.MaPN + "'");
             return true;
         }
         create proc[dbo].[updatePN] (@Ma nvarchar(10),@ngaylap datetime, @tongtien int, @mancc nvarchar(10), @username nvarchar(30))
            as
            begin
              update PhieuNhap
              set MaNCC =@mancc, NgayLap =@ngaylap, UserName = @username, TongTien = @tongtien
              where MaPN= @ma
           end
         public bool XoaPhieuNhap(string pn)
         {
             Da1.NonQuery("delete PhieuNhap where MaPN='" + pn + "'");
             return true;
         }
         public String getNguoiLap(String username)
         {
             if (username == "") return "";
             DataTable table = Da1.Query("Select HoTen from TaiKhoan where UserName = '" + username + "'");
             int n = table.Rows.Count;
             if (n == 1)
             {
                 return table.Rows[0]["HoTen"].ToString().Trim();
             }

             return "";
         }
         public List<String> getUserName()
         {
             DataTable table = Da1.Query("Select UserName from TaiKhoan ");
             List<String> listTK = new List<string>();
             int n = table.Rows.Count;
             int i;
             if (n == 0) return new List<string>();
             for (i = 0; i < n; i++)
             {
                 listTK.Add(table.Rows[i]["UserName"].ToString().Trim());
             }

             return listTK;
         }
         public String getUserName(String HoTen)
         {
             if (HoTen == "") return "";
             DataTable table = Da1.Query("Select UserName from TaiKhoan where HoTen = N'" + HoTen + "'");
             int n = table.Rows.Count;
             if (n == 1)
             {
                 return table.Rows[0]["UserName"].ToString().Trim();
             }
             else
                 return "";
         }

         public String getNhaCungCap(String Ma)
         {
             if (Ma == "") return "";
             DataTable table = Da1.Query("Select TenNCC from NhaCungCap where MaNCC = '" + Ma + "'");
             int n = table.Rows.Count;
             if (n == 1)
             {
                 return table.Rows[0]["TenNCC"].ToString().Trim();
             }

             return "";
         }
         public List<String> getNhaCungCap()
         {
             DataTable table = Da1.Query("Select TenNCC from NhaCungCap");
             List<String> listNCC = new List<string>();
             int n = table.Rows.Count;
             int i;
             if (n == 0) return new List<string>();
             for (i = 0; i < n; i++)
             {
                 listNCC.Add(table.Rows[i]["TenNCC"].ToString().Trim());
             }

             return listNCC;
         }
         public String getMaNhaCungCap(String TenNCC)
         {
             if (TenNCC == "") return "";
             DataTable table = Da1.Query("Select MaNCC from NhaCungCap where TenNCC = N'" + TenNCC + "'");
             int n = table.Rows.Count;
             if (n == 1)
             {
                 return table.Rows[0]["MaNCC"].ToString().Trim();
             }
             else
                 return "";
         }
         #endregion*/
    }

}
