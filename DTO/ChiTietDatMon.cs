using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class ChiTietDatMon
    {
        private string mapyc;
        private string mama;
        private int dongia;
        private int soluong;
        private int thanhtien;

        public ChiTietDatMon(string mapyc, string mama, int dongia, int soluong, int thanhtien)
        {
            Mapyc = mapyc;
            Mama = mama;
            Dongia = dongia;
            Soluong = soluong;
            Thanhtien = thanhtien;
        }

        public ChiTietDatMon(DataRow row)
        {
            Mapyc = row["mapyc"].ToString();
            Mama = row["mama"].ToString();
            Dongia = (int)row["dongia"];
            Soluong = (int)row["soluong"];
            Thanhtien = (int)row["thanhtien"];
        }
        public string Mapyc { get => mapyc; set => mapyc = value; }
        public string Mama { get => mama; set => mama = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Thanhtien { get => thanhtien; set => thanhtien = value; }
    }
}
