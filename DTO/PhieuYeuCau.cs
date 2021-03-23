using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class PhieuYeuCau
    {
        private string mapyc;
        private DateTime? ngaylap;
        private string username;
        private string makh;

        public PhieuYeuCau (string mapyc, DateTime? ngaylap, string username, string makh)
        {
            Mapyc = mapyc;
            Ngaylap = ngaylap;
            Username = username;
            Makh = makh;
        }
        public PhieuYeuCau(DataRow row)
        {
            Mapyc = row["mapyc"].ToString();
            //Ngaylap = (DateTime?)row["ngaylap"];
            var ngaylapTemp = row["Ngaylap"];
            if (ngaylapTemp.ToString() != "")
                Ngaylap = (DateTime?)ngaylapTemp;
            Username = row["username"].ToString();
            Makh = row["makh"].ToString();
        }

        public string Mapyc { get => mapyc; set => mapyc = value; }
        public DateTime? Ngaylap { get => ngaylap; set => ngaylap = value; }
        public string Username { get => username; set => username = value; }
        public string Makh { get => makh; set => makh = value; }
    }
}
