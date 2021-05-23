using QuanLyKhachHang.DTO;
using System;
using System.Data;

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

        public string getMaxMaHD()
        {
            return DataProvider.Instance.executeScalar("select max(mahd) from hoadon").ToString();
        }
        public HoaDon getHoaDon(string mahd)
        {
            DataTable data = DataProvider.Instance.executeQuery("select * from hoadon where mahd = '"+mahd+"'");
            HoaDon hd = new HoaDon(data.Rows[0]);
            return hd;
        }

        


        public DataTable GetListHD(DateTime ngaydau, DateTime ngaycuoi)
        {
            string query = string.Format("select h.MAHD, h.NGAYLAP, t.HOTEN,kh.TENKH, k.PHANTRAM, h.TONGTIEN  from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where (h.NGAYLAP between '{0}' and '{1}') and h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH", ngaydau, ngaycuoi);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public DataTable GetAllHD()
        {
            return DataProvider.Instance.executeQuery("select h.MAHD, h.NGAYLAP, t.HOTEN,kh.TENKH, k.PHANTRAM, h.TONGTIEN from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where  h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH");
        }

        public Boolean DeleteHDByKM(string makm)
        {
            string query = string.Format("delete HOADON where MAKM='{0}'", makm);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public Boolean DeleteHDByNV(string username)
        {
            string query = string.Format("delete HOADON where MAKM='{0}'", username);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public Boolean DeleteHD(string mahd)
        {
            string query = string.Format("delete HOADON where MAHD='{0}'", mahd);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public DataTable SearchHD(string mahd, string nguoilap, string ngaydau, string ngaycuoi)
        {
            string query = string.Format("select h.MAHD, h.NGAYLAP, t.HOTEN, kh.TENKH, k.PHANTRAM, h.TONGTIEN  from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where (h.MAHD like '%'+'{0}'+'%' or '{0}'='') and (t.HOTEN like N'%'+N'{1}'+N'%' or N'{1}'='') and (h.NGAYLAP between '{2}' and '{3}') and h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH", mahd, nguoilap, ngaydau, ngaycuoi);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public DataTable SearchListHDBy(string mahd, string nguoilap)
        {
            string query = string.Format("select h.MAHD, h.NGAYLAP, t.HOTEN,kh.TENKH, k.PHANTRAM, h.TONGTIEN from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where (h.MAHD like '%' + '{0}' +'%' or '{0}'='' ) and (t.HOTEN like N'%' + N'{1}' +N'%' or N'{1}'='' ) and h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH", mahd, nguoilap);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public DataTable SearchListHDByND(string mahd, string nguoilap, string ngaydau)
        {
            string query = string.Format("select h.MAHD, h.NGAYLAP, t.HOTEN,kh.TENKH, k.PHANTRAM, h.TONGTIEN from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where (h.MAHD like '%' + '{0}' +'%' or '{0}'='' ) and (t.HOTEN like N'%' + N'{1}' +N'%' or N'{1}'='' ) and (h.NGAYLAP >= '{2}' ) and h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH", mahd, nguoilap, ngaydau);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

    }
}
