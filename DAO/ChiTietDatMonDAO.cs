using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class ChiTietDatMonDAO
    {
        private static ChiTietDatMonDAO instance;

        internal static ChiTietDatMonDAO Instance
        {
            get { if (instance == null) instance = new ChiTietDatMonDAO(); return instance; }
            private set { instance = value; }
        }

        private ChiTietDatMonDAO() { }

        public List<ChiTietDatMon> getChiTietDatMon(string mapyc)
        {
            List<ChiTietDatMon> ctList = new List<ChiTietDatMon>();

            DataTable data = DataProvider.Instance.executeQuery("select * from CHITIETDATMON where MAPYC = '" +mapyc+"'");
            foreach (DataRow item in data.Rows)
            {
                ChiTietDatMon ct = new ChiTietDatMon(item);
                ctList.Add(ct);
            }
            return ctList;
        }
        public void insertCTDatMon(string mapyc,string mama, int soluong)
        {
            DataProvider.Instance.executeNonQuery("exec [dbo].[ThemCTDatMon] @mapyc , @mama , @soluong", new object[] { mapyc, mama, soluong });
        }

        public int kiemTraCTDatMon(string mapyc)
        {
            
            int data = (int)DataProvider.Instance.executeScalar("select count(*) from CHITIETDATMON where MAPYC = '" + mapyc + "'");
            return data;
        }
    }
}
