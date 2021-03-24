using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class DoiTacDAO
    {
        private static DoiTacDAO instance;

        internal static DoiTacDAO Instance
        {
            get { if (instance == null) instance = new DoiTacDAO(); return instance; }
            private set { instance = value; }
        }

        private DoiTacDAO() { }


        public string getTenMonByMaMon(string mamon)
        {
            string data = DataProvider.Instance.executeScalar("select TENMONAN from MONAN where MAMA = '" + mamon + "'").ToString();
            return data;
        }
    }
}
