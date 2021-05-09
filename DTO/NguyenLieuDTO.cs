using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{

    class NguyenLieuDTO
    {
        private string manl;
        private string tennl;
        private string dvt;
        private int dongia;
        private int soluong;

        public NguyenLieuDTO(string manl, string tennl, int dongia, string dvt, int soluong)
        {
            MANL = manl;
            TENNL = tennl;
            DVT = dvt;
            DONGIA = dongia;
            SOLUONG = soluong;
        }
        public NguyenLieuDTO(DataRow row)
        {
            MANL = row["MANL"].ToString();
            DONGIA = int.Parse(row["DONGIA"].ToString());
            TENNL = row["TENNL"].ToString();
            DVT = row["DVT"].ToString();
            SOLUONG = int.Parse(row["SOLUONG"].ToString());

        }
        public string MANL { get => manl; set => manl = value; }
        public string TENNL { get => tennl; set => tennl = value; }
        public string DVT { get => dvt; set => dvt = value; }
        public int DONGIA { get => dongia; set => dongia = value; }
        public int SOLUONG { get => soluong; set => soluong = value; }
    }
}
