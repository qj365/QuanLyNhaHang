using System;
using System.Collections.Generic;
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
    }
}
