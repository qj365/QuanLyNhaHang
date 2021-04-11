using QuanLyKhachHang.DTO;
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

        public List<KhachHang> loadKhachHangList()
        {
            List<KhachHang> tableList = new List<KhachHang>();
            DataTable data = DataProvider.Instance.executeQuery("select * from khachhang");
            foreach (DataRow item in data.Rows)
            {
                KhachHang table = new KhachHang(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public KhachHang timKHTheoMa(string makh)
        {

            DataTable table = DataProvider.Instance.executeQuery("select * from khachhang where makh = '"+makh+"'");
            KhachHang kh = new KhachHang(table.Rows[0]);
            return kh;
        }
        public int kiemTraKH(string makh)
        {
            int data = (int)DataProvider.Instance.executeScalar("select count(*) from khachhang where makh = '" + makh + "'");
            return data;
        }
    }
}
