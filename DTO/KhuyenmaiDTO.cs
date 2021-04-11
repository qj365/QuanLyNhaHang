using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    class KhuyenMaiDTO
    {
        public KhuyenMaiDTO(string makm, DateTime ngaybatdau, DateTime ngayketthuc, decimal phantram)
        {
            Makm = makm;
            Ngaybatdau = ngaybatdau;
            Ngayketthuc = ngayketthuc;
            Phantram = phantram;
        }

        public KhuyenMaiDTO(DataRow row)
        {
            Makm = row["MAKM"].ToString();
            Ngaybatdau = (DateTime)row["NGAYBATDAU"];
            Ngayketthuc = (DateTime)row["NGAYKETTHUC"];
            Phantram = (decimal)row["PHANTRAM"];
        }
        
        private string makm;
        public string Makm
        {
            get => makm;
            set => makm = value;
        }

        private DateTime ngaybatdau;
        public DateTime Ngaybatdau
        {
            get => ngaybatdau;
            set => ngaybatdau = value;
        }

        private DateTime ngayketthuc;
        public DateTime Ngayketthuc
        {
            get => ngayketthuc;
            set => ngayketthuc = value;
        }

        private decimal phantram;
        public decimal Phantram
        {
            get => phantram;
            set => phantram = value;
        }
        
    }
}

