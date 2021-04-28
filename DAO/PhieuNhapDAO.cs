using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;

        internal static PhieuNhapDAO Instance
        {
            get { if (instance == null) instance = new PhieuNhapDAO(); return instance; }
            private set { instance = value; }
        }

        private PhieuNhapDAO() { }

        public void themPN(int tongtien, string mancc, string username)
        {
            DataProvider.Instance.executeNonQuery("exec ThemPhieuNhap @tongtien , @mancc , @username ", new object[] { tongtien, mancc, username });
        }
        public void themCTPN(string mapn , string  manl ,int  dongia  ,int  soluong , int thanhtien)
        {
            DataProvider.Instance.executeNonQuery("exec ThemCTPhieuNhap @mapn , @manl , @dongia , @soluong , @thanhtien ", new object[] { mapn, manl,dongia, soluong, thanhtien });
        }
        public string getMaxPhieuNhap()
        {
            string max = DataProvider.Instance.executeScalar("select max(mapn) from phieunhap").ToString();
            return max;
        }


        public string TongChi(int index)
        {
            string q = "";
            switch (index)
            {
                case 0:
                    q = "select sum(tongtien) from PhieuNhap where CONVERT(date, ngaylap) between DATEADD(day, -7, CAST(GETDATE() AS date)) and CAST(GETDATE()-1 AS date)";
                    break;
                case 1:
                    q = "select sum(tongtien) from PhieuNhap where CONVERT(date, ngaylap) = DATEADD(day, -1, CONVERT(date, getdate()))";
                    break;
                case 2:
                    q = "select sum(tongtien) from PhieuNhap where CONVERT(date, ngaylap) = CONVERT(date, getdate())";
                    break;
                case 3:
                    q = "select sum(tongtien) from PhieuNhap where CONVERT(date, ngaylap) between" +
                            " CONVERT(date, dateadd(d, -(day(getdate() - 1)), getdate())) and convert(date, getdate())";
                    break;
                case 4:
                    q = "select sum(tongtien) from PhieuNhap where CONVERT(date, ngaylap) between"
                               + " CONVERT(date, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) and"
                               + " CONVERT(date, DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE()) - 1, -1))";
                    break;
            }
            string count = DataProvider.Instance.executeScalar(q).ToString();
            if (count == "")
                return "0";
            return count;

        }

        public List<DateTime> dsNgay(int index)
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from [dbo].Ngay("+index+")");
            List<DateTime> lst = new List<DateTime>();
            foreach (DataRow item in table.Rows)
            {
                DateTime date = (DateTime)item["ngay"];
                lst.Add(date);
            }
            return lst;
        }

        public string tongChiNgay(string ngay)
        {
            string dt = DataProvider.Instance.executeScalar("select sum(tongtien) from phieunhap where CONVERT(date, ngaylap) = '" + ngay + "'").ToString();
            if (dt == "")
                return "0";
            return dt;
        }
    }
}
