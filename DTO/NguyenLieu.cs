using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class NguyenLieu
    {
        private string manl;
        private string tennl;
        private string dvt;
        private int dongia;
        private int soluong;

        public string Manl { get => manl; set => manl = value; }
        public string Tennl { get => tennl; set => tennl = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public int Soluong { get => soluong; set => soluong = value; }

        public NguyenLieu(DataRow row)
        {
            Manl = row["manl"].ToString();
            Tennl = row["tennl"].ToString();
            Dvt = row["dvt"].ToString();
            Dongia = (int)row["dongia"];
            Soluong = (int)row["soluong"];
        }
    }
}
