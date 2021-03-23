using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class Table
    {   
        public Table(string maban, int socho, string mapyc = null)
        {
            Maban = maban;
            Socho = socho;
            Mapyc = mapyc;
        }

        public Table(DataRow row)
        {
            Maban = row["maban"].ToString();
            Socho = (int)row["sochongoi"];
            Mapyc = row["mapyc"].ToString();
        }

        private string maban;
        private int socho;
        private string mapyc;
        public string Maban { get => maban; set => maban = value; }
        public int Socho { get => socho; set => socho = value; }
        public string Mapyc { get => mapyc; set => mapyc = value; }
    }
}
