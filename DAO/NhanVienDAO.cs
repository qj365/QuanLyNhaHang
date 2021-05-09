using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;

        internal static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        private NhanVienDAO() { }

        public DataTable GetListNV()
        {
            DataTable data = DataProvider.Instance.executeQuery("select * from NHANVIEN");
            return data;
        }

        public Boolean ThemNV(string manv, string tennv, DateTime ngaysinh, string diachi, string sdt, string gioitinh, decimal luong, string chucvu)
        {
            string query = string.Format("insert into NHANVIEN(MANV,TENNV,NGAYSINH,SDT,DIACHI,GIOITINH,LUONG,CHUCVU) VALUES (N'{0}',N'{1}','{2}','{3}',N'{4}',N'{5}','{6}',N'{7}') ", manv, tennv, ngaysinh, sdt, diachi, gioitinh, luong, chucvu);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public Boolean SuaNV(string manv, string tennv, DateTime ngaysinh, string diachi, string sdt, string gioitinh, decimal luong, string chucvu)
        {
            string query = string.Format("update NHANVIEN set TENNV=N'{1}', NGAYSINH='{2}', SDT='{3}', DIACHI=N'{4}', GIOITINH=N'{5}', LUONG ='{6}', CHUCVU=N'{7}' where MANV =N'{0}' ", manv, tennv, ngaysinh, sdt, diachi, gioitinh, luong, chucvu);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public Boolean XoaNV(string manv)
        {
            string query = string.Format("delete NHANVIEN where MANV='{0}'", manv);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public DataTable SearchNV(string manv, string tennv)
        {
            string query = string.Format("select * from NHANVIEN where (MANV like N'%' + N'{0}' +N'%' or N'{0}'='') and (TENNV like N'%' + N'{1}' +N'%' or N'{1}'='') ", manv, tennv);
            DataTable data = DataProvider.Instance.executeQuery(query);
            return data;
        }
    }
}
