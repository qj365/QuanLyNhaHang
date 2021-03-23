using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Login(string user,string pass)
        {
            string q = "select * from TAIKHOAN where USERNAME = '" + @user + "' and PASSWORD = '" + @pass + "'";
            DataTable result = DataProvider.Instance.executeQuery(q); 
            return result.Rows.Count>0;
        }
    }
}
