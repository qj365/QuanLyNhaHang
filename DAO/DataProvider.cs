using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DAO
{
    class DataProvider
    {
        private static DataProvider instance;

        static string connectionStr = @"Data Source=.\sqlexpress;Initial Catalog=QUANLYNHAHANG;Integrated Security=True";
        private static readonly SqlConnection con = new SqlConnection(connectionStr);
        //asdasdasd
        internal static DataProvider Instance 
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        public DataProvider() { }

        public DataTable executeQuery(string q, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    string[] listPara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();

            }
            return data;
        }

        public int executeNonQuery(string q, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(q, connection);

                if (parameter != null)
                {
                    string[] listPara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object executeScalar(string q, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    string[] listPara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();

            }
            return data;
        }
        internal void NonQuery(string sql, params SqlParameter[] pr)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            if (sql.Trim().Contains(' '))
                cmd.CommandType = CommandType.Text;
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
                pr.ToList().ForEach(x => cmd.Parameters.Add(x));
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Query(string sql, params SqlParameter[] pr)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            con.Open();
            if (sql.Trim().Contains(' '))
                da = new SqlDataAdapter(sql, con);
            else
            {
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                pr.ToList().ForEach(x => cmd.Parameters.Add(x));
                da = new SqlDataAdapter(cmd);
            }
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public String LaySTT(int autoNum)
        {
            if (autoNum < 10)
                return "000" + autoNum;

            else if (autoNum >= 10 && autoNum < 100)
                return "00" + autoNum;

            else if (autoNum >= 100 && autoNum < 1000)
                return "0" + autoNum;

            else if (autoNum >= 1000 && autoNum < 10000)
                return "" + autoNum;

            else
                return "";
        }
    }
}
