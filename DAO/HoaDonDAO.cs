using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable SearchHD(string mahd, string nguoilap, string ngaydau, string ngaycuoi)
        {
            string query = string.Format("select h.MAHD, h.NGAYLAP, t.HOTEN, kh.TENKH, k.PHANTRAM, h.TONGTIEN  from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where (MAHD like '%'+'{0}'+'%' or '{0}'='') and (HOTEN like N'%'+N'{1}'+N'%' or '{1}'='') and (h.NGAYLAP between '{2}' and '{3}') and h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH", mahd, nguoilap, ngaydau, ngaycuoi);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public DataTable SearchListHDBy(string mahd, string nguoilap)
        {
            string query = string.Format("select h.MAHD, h.NGAYLAP, t.HOTEN,kh.TENKH, k.PHANTRAM, h.TONGTIEN from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where (MAHD like '%' + '{0}' +'%' or '{0}'='' ) and (HOTEN like N'%' + N'{1}' +N'%' or N'{1}'='' ) and h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH", mahd, nguoilap);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

        public DataTable SearchListHDByND(string mahd, string nguoilap, string ngaydau)
        {
            string query = string.Format("select h.MAHD, h.NGAYLAP, t.HOTEN,kh.TENKH, k.PHANTRAM, h.TONGTIEN from HOADON h, TAIKHOAN t, KHUYENMAI k, KHACHHANG kh, PHIEUYEUCAU p where (MAHD like '%' + '{0}' +'%' or '{0}'='' ) and (HOTEN like N'%' + N'{1}' +N'%' or N'{1}'='' ) and (h.NGAYLAP >= '{2}' ) and h.MAKM = k.MAKM and h.USERNAME = t.USERNAME and h.MAPYC = p.MAPYC and p.MAKH = kh.MAKH", mahd, nguoilap, ngaydau);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }

    }
}
