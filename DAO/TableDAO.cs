using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class TableDAO
    {
        private static TableDAO instance;

        internal static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set { instance = value; }
        }

        public static int tableHeight = 100;
        public static int tableWeight = 100;

        private TableDAO() { }
        public List<Table> loadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.executeQuery("select * from BANAN");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public string getMaBanbyPYC(string mapyc)
        {
            return DataProvider.Instance.executeScalar("select maban from banan where mapyc = '"+mapyc+"'").ToString();
        }
    }
}
