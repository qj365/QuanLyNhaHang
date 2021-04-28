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

        public static string MaPYC { get => maPYC; set => maPYC = value; }
    }
}
