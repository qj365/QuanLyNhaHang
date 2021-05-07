using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachHang.DTO;


namespace QuanLyKhachHang.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public static string username;
        public static string hoten;
        public static string phanquyen;
        public bool Login(string user, string pass)
        {
            string q = "select * from TAIKHOAN where USERNAME = @user and PASSWORD = @pass";
            DataTable result = DataProvider.Instance.executeQuery(q, new object[] { user, pass });
            if (result.Rows.Count > 0)
            {
                username = result.Rows[0].Field<string>(0);
                hoten = result.Rows[0].Field<string>(2);
                phanquyen = result.Rows[0].Field<string>(3);
                return true;
            }
            return false;
        }
        public string getNameByUsername(string username)
        {
            string data = DataProvider.Instance.executeScalar("select HOTEN from TAIKHOAN where USERNAME = '" + username + "'").ToString();
            return data;
        }
        public List<TaiKhoan> getListTaiKhoan()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();

            string query = "select USERNAME, HOTEN, PHANQUYEN from TAIKHOAN";

            DataTable data = DataProvider.Instance.executeQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TaiKhoan acc = new TaiKhoan(item);
                list.Add(acc);
            }

            return list;
        }
        public bool InsertAccount(string username, string hoten, string phanquyen)
        {
            string query = string.Format("INSERT INTO TAIKHOAN VALUES ('{0}',' ',N'{1}',N'{2}')", username, hoten, phanquyen);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string username, string hoten, string phanquyen)
        {
            string query = string.Format("UPDATE TAIKHOAN SET HOTEN = N'{0}', PHANQUYEN = N'{1}' WHERE USERNAME = '{2}'", hoten, phanquyen, username);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }

        public DataTable SearchAccount(string username)
        {
            string query = string.Format("SELECT * FROM TAIKHOAN WHERE(USERNAME LIKE '%' + '{0}' + '%' OR '{0}' = '') ", username);
            DataTable table = DataProvider.Instance.executeQuery(query);
            return table;
        }
        public void doiMK(string user, string pass)
        {
            string q = "update TAIKHOAN set PASSWORD = '" + @pass + "' where USERNAME = '" + @user + "'";
            DataProvider.Instance.executeNonQuery(q, new object[] { user, pass });
        }

    }
}
