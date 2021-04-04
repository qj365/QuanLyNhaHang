using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class HoaDonDAO
    {
        private static HoaDonDAO instance;

        internal static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set { instance = value; }
        }

        private HoaDonDAO() { }
    }
}
