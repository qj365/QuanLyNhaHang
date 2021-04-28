﻿using System.Data;

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
            string q = "select * from TAIKHOAN where USERNAME = '" + @user + "' and PASSWORD = '" + @pass + "'";
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
        public void doiMK(string user, string pass)
        {
            string q = "update TAIKHOAN set PASSWORD = '" + @pass + "' where USERNAME = '" + @user + "'";
            DataProvider.Instance.executeNonQuery(q, new object[] { user, pass });
        }

    }
}
