using QuanLyKhachHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class NguyenLieuDAONew
    {
        private static NguyenLieuDAONew instance;

        internal static NguyenLieuDAONew Instance
        {
            get { if (instance == null) instance = new NguyenLieuDAONew(); return instance; }
            private set { instance = value; }
        }
        private NguyenLieuDAONew() { }

        public List<NguyenLieu> getListNguyenLieu()
        {
            List<NguyenLieu> tableList = new List<NguyenLieu>();
            DataTable data = DataProvider.Instance.executeQuery("select * from nguyenlieu");
            foreach (DataRow item in data.Rows)
            {
                NguyenLieu table = new NguyenLieu(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public NguyenLieu timNLTheoMa(string manl)
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from nguyenlieu where manl = '" + manl + "'");
            NguyenLieu nl = new NguyenLieu(table.Rows[0]);
            return nl;
        }
        public NguyenLieu timNLtheoTen(string tennl)
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from nguyenlieu where tennl = N'" + tennl + "'");
            NguyenLieu nl = new NguyenLieu(table.Rows[0]);
            return nl;
        }

        public int maNLtontai(string manl)
        {
            int data = (int)DataProvider.Instance.executeScalar("select count(*) from nguyenlieu where manl = '"+manl+"'");
            return data;
        }

        public void themSLNguyenLieu(string manl,int sl)
        {
            DataProvider.Instance.executeNonQuery("exec themNL  @manl , @sl", new object[] { manl, sl});
        }

    }
}
