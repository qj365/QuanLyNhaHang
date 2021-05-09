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
            string query = string.Format("SELECT * FROM KHACHHANG WHERE(MAKH LIKE '%' + N'{0}' + '%' OR N'{0}' = '') AND(TENKH LIKE N'%' + N'{1}' + N'%' OR N'{1}' = '')", makh, tenkh);
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }
            
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

        public KhachHang getKHbyMaHD(string mahd)
        {
            DataTable table = DataProvider.Instance.executeQuery("select KHACHHANG.MAKH, TENKH, SDT from KHACHHANG, PHIEUYEUCAU, HOADON where KHACHHANG.MAKH = PHIEUYEUCAU.MAKH and PHIEUYEUCAU.MAPYC = HOADON.MAPYC and MAHD = '"+mahd+"'");
            KhachHang kh = new KhachHang(table.Rows[0]);
            return kh;
        }
    }
}
