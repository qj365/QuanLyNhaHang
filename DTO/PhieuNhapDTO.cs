using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    class PhieuNhapDTO
    {
        private string mapn;
        private DateTime ngaylap;
        private int tongtien;
        private string mancc;
        private string username;

        public PhieuNhapDTO(string mapn, string mancc, int tongtien, string username, DateTime ngaylap)
        {
            MaPN = mapn;
            NgayLap = ngaylap;
            TongTien = tongtien;
            MaNCC = mancc;
            UserName = username;
        }
        public PhieuNhapDTO(DataRow row)
        {
            MaPN = row["MaPN"].ToString();
            NgayLap = DateTime.Parse(row["NgayLap"].ToString());
            TongTien = int.Parse(row["TongTien"].ToString());
            MaNCC = row["MaNCC"].ToString();
            UserName = row["UserName"].ToString();

        }
        public string MaPN { get => mapn; set => mapn = value; }
        public DateTime NgayLap { get => ngaylap; set => ngaylap = value; }
        public int TongTien { get => tongtien; set => tongtien = value; }
        public string MaNCC { get => mancc; set => mancc = value; }
        public string UserName { get => username; set => username = value; }

    }
}
