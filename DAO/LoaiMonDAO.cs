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
        
    }
}
