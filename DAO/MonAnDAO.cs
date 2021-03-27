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
    }
}
