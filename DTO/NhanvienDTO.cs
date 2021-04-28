using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    class NhanVienDTO
    {
        public NhanVienDTO(string manv, string tennv, string diachi, string gioitinh, string sdt, string chucvu, DateTime ngaysinh, DateTime ngayvaolam, decimal luong)
        {
            Manv = manv;
            Tennv = tennv;
            Ngaysinh = ngaysinh;
            Diachi = diachi;
            Gioitinh = gioitinh;
            SDT = sdt;
            Chucvu = chucvu;
            Luong = luong;
            Ngayvaolam = ngayvaolam;
        }

        public NhanVienDTO(DataRow row)
        {
            Manv = row["MANV"].ToString();
            Tennv = row["TENNV"].ToString();
            Ngaysinh = (DateTime)row["NGAYSINH"];
            Diachi = row["DIACHI"].ToString();
            Gioitinh = row["GIOITINH"].ToString();
            SDT = row["SDT"].ToString();
            Chucvu = row["CHUCVU"].ToString();
            Luong = (decimal)row["LUONG"];
            Ngayvaolam = (DateTime)row["NGAYVAOLAM"];
        }

        private string manv;
        public string Manv
        {
            get => manv;
            set => manv = value;
        }

        private string tennv;
        public string Tennv
        {
            get => tennv;
            set => tennv = value;
        }

        private DateTime ngaysinh;
        public DateTime Ngaysinh
        {
            get => ngaysinh;
            set => ngaysinh = value;
        }

        private string diachi;
        public string Diachi
        {
            get => diachi;
            set => diachi = value;
        }

        private string gioitinh;
        public string Gioitinh
        {
            get => gioitinh;
            set => gioitinh = value;
        }

        private string sdt;
        public string SDT
        {
            get => sdt;
            set => sdt = value;
        }

        private string chucvu;
        public string Chucvu
        {
            get => chucvu;
            set => chucvu = value;
        }

        private decimal luong;
        public decimal Luong
        {
            get => luong;
            set => luong = value;
        }

        private DateTime ngayvaolam;
        public DateTime Ngayvaolam
        {
            get => ngayvaolam;
            set => ngayvaolam = value;
        }
    }
}
