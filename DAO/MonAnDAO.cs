using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class MonAnDAO
    {
        private static MonAnDAO instance;

        internal static MonAnDAO Instance
        {
            get { if (instance == null) instance = new MonAnDAO(); return instance; }
            private set { instance = value; }
        }

        private MonAnDAO() { }


        public string getTenMonByMaMon(string mamon)
        {
            string data = DataProvider.Instance.executeScalar("select TENMONAN from MONAN where MAMA = '"+mamon+"'").ToString();
            return data;
        }
        public DataTable getMonAnList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from monan");
            return table;
        }
        public List<MonAn> getMonAnByLoaiMon(string maloai)
        {
            List<MonAn> list = new List<MonAn>();
            DataTable table = DataProvider.Instance.executeQuery("select * from monan where maloai = '"+maloai+"'");
            foreach (DataRow row  in table.Rows)
            {
                MonAn monan = new MonAn(row);
                list.Add(monan);
            }
            return list;
        }
        public bool InsertFood(string mama, string tenmonan, string dvt, int dongia, string maloai)
        {
            string query = string.Format("THEMMONAN '{0}','{1}','{2}','{3}','{4}'", mama, tenmonan, dvt, dongia, maloai);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(string mama, string tenmonan, string dvt, int dongia, string maloai)
        {
            string query = string.Format("SUAMONAN '{0}','{1}','{2}','{3}','{4}'", mama, tenmonan, dvt, dongia, maloai);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(string mama)
        {
            string query = string.Format("Delete from MONAN where MAMA = '{0}'", mama);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public DataTable SearchFood(string mama, string tenmonan)
        {
            string query = string.Format("SELECT * FROM MONAN WHERE(MAMA LIKE '%' + '{0}' + '%' OR '{0}' = '') AND(TENMONAN LIKE N'%' + '{1}' + '%' OR '{1}' = '')", mama, tenmonan);
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }

        public DataTable DemSoMonAn(DateTime from, DateTime to)
        {
            string query = "EXEC [dbo].[DEMSOMONAN] @From , @To";
            DataTable table = DataProvider.Instance.executeQuery(query, new object[] {from, to});
            return table;
        }
    }
}
