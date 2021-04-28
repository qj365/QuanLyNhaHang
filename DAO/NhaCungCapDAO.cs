using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        internal static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            private set { instance = value; }
        }

        private NhaCungCapDAO() { }

        public string getTenNCCbyMaNCC(string mancc)
        {
            string data = DataProvider.Instance.executeScalar("select TENNCC from NHACUNGCAP where MANCC = '" + mancc + "'").ToString();
            return data;
        }
        public DataTable getNCCList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from NHACUNGCAP");
            return table;
        }
        public DataTable timKiemNCC(string mancc, string tenncc)
        {
            string query = string.Format("SELECT * FROM NHACUNGCAP WHERE(MANCC LIKE '%' + N'{0}' + '%' OR N'{0}' = '') AND(TENNCC LIKE N'%' + N'{1}' + N'%' OR N'{1}' = '')", mancc, tenncc);
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }

        public List<NhaCungCap> getListNCC()
        {
            List<NhaCungCap> tableList = new List<NhaCungCap>();
            DataTable data = DataProvider.Instance.executeQuery("select * from nhacungcap");
            foreach (DataRow item in data.Rows)
            {
                NhaCungCap table = new NhaCungCap(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public DataTable timNCCbangTen(string tenncc)
        {
            DataTable data = DataProvider.Instance.executeQuery("select * from NHACUNGCAP where TENNCC = '"+tenncc+"'");
            return data;
        }
    }
}
