using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class LoaiMonDAO
    {
        private static LoaiMonDAO instance;

        internal static LoaiMonDAO Instance
        {
            get { if (instance == null) instance = new LoaiMonDAO(); return instance; }
            private set { instance = value; }
        }
        private LoaiMonDAO() { }

        public List<LoaiMon> getListLoaiMon()
        {
            List<LoaiMon> list = new List<LoaiMon>();

            string query = "select * from LOAIMON";

            DataTable data = DataProvider.Instance.executeQuery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiMon category = new LoaiMon(item);
                list.Add(category);
            }

            return list;
        }
        public bool InsertFoodCategory(string maloai, string tenloai)
        {
            string query = string.Format("THEMLOAIMON '{0}','{1}'", maloai, tenloai);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public bool UpdateFoodCategory(string maloai, string tenloai)
        {
            string query = string.Format("SUALOAIMON '{0}','{1}'", maloai, tenloai);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public bool DeleteFoodCategory(string maloai, string tenloai)
        {
            string query = string.Format("Delete from LOAIMON where MALOAI = '{0}'", maloai);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public DataTable SearchFoodCategory(string malm)
        {
            string query = string.Format("SELECT * FROM LOAIMON WHERE(MALOAI LIKE '%' + '{0}' + '%' OR '{0}' = '') ", malm);
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }
    }
}
