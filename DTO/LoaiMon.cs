using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class LoaiMon
    {
        public LoaiMon(string malm, string tenlm)
        {
            Malm = malm;
            Tenlm = tenlm;
        }

        public LoaiMon(DataRow row)
        {
            Malm = row["maloai"].ToString();
            Tenlm = row["tenloaimon"].ToString();
        }

        private string malm;
        private string tenlm;

        public string Malm { get => malm; set => malm = value; }
        public string Tenlm { get => tenlm; set => tenlm = value; }
    }
}
