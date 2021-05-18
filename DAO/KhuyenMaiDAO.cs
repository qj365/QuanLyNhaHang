using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class KhuyenMaiDAO
    {
        private static KhuyenMaiDAO instance;

        internal static KhuyenMaiDAO Instance
        {
            get { if (instance == null) instance = new KhuyenMaiDAO(); return instance; }
            private set { instance = value; }
        }

        private KhuyenMaiDAO() { }

        public DataTable GetListKM()
        {
            DataTable data = DataProvider.Instance.executeQuery("select * from KHUYENMAI");
            return data;
        }

        public Boolean ThemKM(string makm, string ngaybatdau, string ngayketthuc, decimal phantram)
        {
            string query = string.Format("insert into KHUYENMAI VALUES (N'{0}',N'{1}','{2}',N'{3}') ", makm, ngaybatdau, ngayketthuc, phantram);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public Boolean SuaKM(string makm, string ngaybatdau, string ngayketthuc, decimal phantram)
        {
            string query = string.Format("update KHUYENMAI set NGAYBATDAU='{1}',NGAYKETTHUC='{2}',PHANTRAM='{3}' where MAKM=N'{0}'", makm, ngaybatdau, ngayketthuc, phantram);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public Boolean XoaKM(string makm)
        {
            DAO.HoaDonDAO.Instance.DeleteHDByKM(makm);
            string query = string.Format("delete KHUYENMAI where MAKM='{0}'", makm);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public DataTable GetMaKM()
        {
            DataTable data = DataProvider.Instance.executeQuery("select dbo.TAOMAKM()");
            return data;

        }

        public DataTable SearchKM(string ngaybatdau, string ngayketthuc, string makm, string phantram)
        {
            string query = string.Format("select * from KHUYENMAI where (NGAYBATDAU ='{0}') and (NGAYKETTHUC ='{1}') and  (MAKM LIKE '%' + '{2}' + '%' OR '{2}' = '') and (PHANTRAM like '%'+'{3}'+'%' or '{3}'='')", ngaybatdau, ngayketthuc, makm, phantram);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public DataTable SearchKMByNBD(string makm, string phantram, string ngaybatdau)
        {
            string query = string.Format("select * from KHUYENMAI where (MAKM LIKE '%' + '{0}' + '%' OR '{0}' = '') and (PHANTRAM like '%'+'{1}'+'%' or '{1}'='') and (NGAYBATDAU ='{2}')", makm, phantram, ngaybatdau);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public DataTable SearchKMBy(string makm, string phantram)
        {
            string query = string.Format("select * from KHUYENMAI where (MAKM LIKE '%' + '{0}' + '%' OR '{0}' = '') and (PHANTRAM like '%'+'{1}'+'%' or '{1}'='')", makm, phantram);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public List<KhuyenMaiDTO> TimKiemKMChuaHetHan()
        {
            List<KhuyenMaiDTO> list = new List<KhuyenMaiDTO>();
            DataTable table = DataProvider.Instance.executeQuery("select * from KHUYENMAI where NGAYKETTHUC >= GETDATE()");
            foreach (DataRow row in table.Rows)
            {
                KhuyenMaiDTO km = new KhuyenMaiDTO(row);
                list.Add(km);
            }
            return list;
        }
    }
}

