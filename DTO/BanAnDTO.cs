using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    class BanAnDTO
    {
        private string maban;
        private string mapyc;
        private int sochongoi;

        public BanAnDTO(string maban, string mapyc, int sochongoi)
        {
            MABAN = maban;
            MAPYC = mapyc;
            SOCHONGOI = sochongoi;
        }
        public BanAnDTO(DataRow row)
        {
            MABAN = row["MABAN"].ToString();
            MAPYC = row["MAPYC"].ToString();
            SOCHONGOI = int.Parse(row["SOCHONGOI"].ToString());
        }
        public string MABAN { get => maban; set => maban = value; }
        public string MAPYC { get => mapyc; set => mapyc = value; }
        public int SOCHONGOI { get => sochongoi; set => sochongoi = value; }
    }
}
