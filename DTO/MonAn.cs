using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class MonAn
    {
        public MonAn(string mama, string tenmon, string dvt, int dongia, string tenloaimon)
        {
            Mama = mama;
            Tenmon = tenmon;
            Dvt = dvt;
            Dongia = dongia;
            Tenloaimon = tenloaimon;
        }

        public MonAn(DataRow row)
        {
            Mama = row["mama"].ToString();
            Tenmon = row["tenmonan"].ToString();
            Dvt = row["dvt"].ToString();
            Dongia = (int)row["dongia"];
            Tenloaimon = row["maloai"].ToString();
        }
        private string mama;
        private string tenmon;
        private string dvt;
        private int dongia;
        private string tenloaimon;

        public string Mama { get => mama; set => mama = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public string Tenloaimon { get => tenloaimon; set => tenloaimon = value; }
    }
}
