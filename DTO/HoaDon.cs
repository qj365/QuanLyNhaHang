using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class HoaDon
    {
        public HoaDon(string mahd, DateTime ngaylap, int tongtien, string username, string mapyc, string makm )
        {
            Mahd = mahd;
            Ngaylap = ngaylap;
            Tongtien = tongtien;
            Username = username;
            Mapyc = mapyc;
            Makm = makm;
        }

        public HoaDon(DataRow row)
        {
            Mahd = row["MAHD"].ToString();
            Ngaylap = (DateTime)row["NGAYLAP"];
            Tongtien = (int)row["TONGTIEN"];
            Username = row["USERNAME"].ToString();
            Mapyc = row["MAPYC"].ToString();
            Makm = row["MAKM"].ToString();
        }

        private string mahd;
        private DateTime ngaylap;
        private int tongtien;
        private string username;
        private string mapyc;
        private string makm;

        public string Mahd { get => mahd; set => mahd = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public string Username { get => username; set => username = value; }
        public string Mapyc { get => mapyc; set => mapyc = value; }
        public string Makm { get => makm; set => makm = value; }
    }
}
