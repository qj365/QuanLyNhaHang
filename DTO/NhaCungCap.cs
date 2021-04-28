using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class NhaCungCap
    {
        private string mancc;
        private string tenncc;
        private string diachi;
        private string sdt;

        public string Mancc { get => mancc; set => mancc = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Tenncc { get => tenncc; set => tenncc = value; }

        public NhaCungCap(string mancc, string tenncc, string diachi,string sdt)
        {
            Mancc = mancc;
            Tenncc = tenncc;
            Diachi = diachi;
            Sdt = sdt;
        }
        public NhaCungCap(DataRow row)
        {
            Mancc = row["mancc"].ToString();
            Tenncc = row["tenncc"].ToString();
            Diachi = row["diachi"].ToString();
            Sdt = row["sdt"].ToString();
        }
    }
}
