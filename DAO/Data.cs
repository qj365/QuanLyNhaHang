using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    public static class Data
    {
        private static string maPYC;
        private static string maban;
        private static string tongtienHD;
        private static string tongcongHD;
        private static string chietkhauHD;
        private static string tenNCC;
        public static string MaPYC { get => maPYC; set => maPYC = value; }
        public static string TongtienHD { get => tongtienHD; set => tongtienHD = value; }
        public static string TongcongHD { get => tongcongHD; set => tongcongHD = value; }
        public static string ChietkhauHD { get => chietkhauHD; set => chietkhauHD = value; }
        public static string Maban { get => maban; set => maban = value; }
        public static string TenNCC { get => tenNCC; set => tenNCC = value; }
    }
}
