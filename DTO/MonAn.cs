using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class MonAn
    {
        public MonAn(string mama, string tenmon, string dvt, string dongia, string maloai)
        {
            Mama = mama;
            Tenmon = tenmon;
            Dvt = dvt;
            Dongia = dongia;
            Maloai = maloai;
        }
        private string mama;
        private string tenmon;
        private string dvt;
        private string dongia;
        private string maloai;

        public string Mama { get => mama; set => mama = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public string Dongia { get => dongia; set => dongia = value; }
        public string Maloai { get => maloai; set => maloai = value; }
    }
}
