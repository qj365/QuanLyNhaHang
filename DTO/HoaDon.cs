using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class HoaDon
    {
        private string mahd;
        private DateTime? ngaylap;
        private int tongtien;
        private string username;
        private string mapyc;
        private string makm;

        public string Mahd { get => mahd; set => mahd = value; }
        public DateTime? Ngaylap { get => ngaylap; set => ngaylap = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public string Username { get => username; set => username = value; }
        public string Mapyc { get => mapyc; set => mapyc = value; }
        public string Makm { get => makm; set => makm = value; }
    }
}
