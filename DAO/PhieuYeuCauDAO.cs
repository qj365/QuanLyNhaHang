using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    public class PhieuYeuCauDAO
    {
        private static PhieuYeuCauDAO instance;

        internal static PhieuYeuCauDAO Instance
        {
            get { if (instance == null) instance = new PhieuYeuCauDAO(); return instance; }
            private set { instance = value; }
        }

        private PhieuYeuCauDAO() { }

        public string getPycByMaban(string maban)
        {
            DataTable data = DataProvider.Instance.executeQuery("select * from BANAN where MABAN = '"+maban+"' and MAPYC is not null");
            if(data.Rows.Count > 0)
            {
                PhieuYeuCau pyc = new PhieuYeuCau(data.Rows[0]);
                return pyc.Mapyc;
            }
            return "-1";
        }
    }
}
