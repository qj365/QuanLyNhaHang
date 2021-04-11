using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;

        internal static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }

        private KhachHangDAO() { }

        public string getTenKHbyMaKH(string makh)
        {
            string data = DataProvider.Instance.executeScalar("select TENKH from KHACHHANG where MAKH = '" + makh + "'").ToString();
            return data;
        }
        public DataTable getKHList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from KHACHHANG");
            return table;
        }
        public DataTable timKiemKH(string makh, string tenkh)
        {
            string query = string.Format("SELECT * FROM KHACHHANG WHERE(MAKH LIKE '%' + '{0}' + '%' OR '{0}' = '') AND(TENKH LIKE N'%' + '{1}' + N'%' OR '{1}' = '')", makh, tenkh);
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }
    }
}
