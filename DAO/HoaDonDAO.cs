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

        public string ThanhToan(string mapyc, float km)
        {
            string data = DataProvider.Instance.executeScalar("select [dbo].thanhtoan( '" + mapyc + "', '" + km + "')").ToString();
            return data;
        }

        public string soHoaDon(int index)
        {
            string q = "";
            switch (index)
            {
                case 0:
                    q = "select count(*) from HOADON where CONVERT(date, ngaylap) between DATEADD(day, -7, CAST(GETDATE() AS date)) and CAST(GETDATE()-1 AS date)";
                    break;
                case 1:
                    q = "select count(*) from HOADON where CONVERT(date, ngaylap) = DATEADD(day, -1, CONVERT(date, getdate()))";
                    break;
                case 2:
                    q = "select count(*) from HOADON where CONVERT(date, ngaylap) = CONVERT(date, getdate())";
                    break;
                case 3:
                    q = "select count(*) from HOADON where CONVERT(date, ngaylap) between" +
                            " CONVERT(date, dateadd(d, -(day(getdate() - 1)), getdate())) and convert(date, getdate())";
                    break;
                case 4:
                    q = "select count(*) from HOADON where CONVERT(date, ngaylap) between"
                               + " CONVERT(date, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) and"
                               + " CONVERT(date, DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE()) - 1, -1))";
                    break;
            }
            string count = DataProvider.Instance.executeScalar(q).ToString();
            return count;

        }

        


        public string DoanhThu(int index)
        {
            string q = "";
            switch (index)
            {
                case 0:
                    q = "select sum(tongtien) from HOADON where CONVERT(date, ngaylap) between DATEADD(day, -7, CAST(GETDATE() AS date)) and CAST(GETDATE()-1 AS date)";
                    break;
                case 1:
                    q = "select sum(tongtien) from HOADON where CONVERT(date, ngaylap) = DATEADD(day, -1, CONVERT(date, getdate()))";
                    break;
                case 2:
                    q = "select sum(tongtien) from HOADON where CONVERT(date, ngaylap) = CONVERT(date, getdate())";
                    break;
                case 3:
                    q = "select sum(tongtien) from HOADON where CONVERT(date, ngaylap) between" +
                            " CONVERT(date, dateadd(d, -(day(getdate() - 1)), getdate())) and convert(date, getdate())";
                    break;
                case 4:
                    q = "select sum(tongtien) from HOADON where CONVERT(date, ngaylap) between"
                               + " CONVERT(date, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) and"
                               + " CONVERT(date, DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE()) - 1, -1))";
                    break;
            }
            string count = DataProvider.Instance.executeScalar(q).ToString();
            if (count == "")
                return "0";
            return count;
        }
        
        public string doanhThuNgay(string ngay)
        {
            string dt = DataProvider.Instance.executeScalar("select sum(tongtien) from HOADON where CONVERT(date, ngaylap) = '"+ngay+"'").ToString();
            if (dt == "")
                return "0";
            return dt;
        }
        
    }
}
