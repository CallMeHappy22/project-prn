using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1616_Win.DAL
{
    public class DAO
    {
        string strConn;
        public DAO()
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

                // strConn = conf["ConnectionStrings:DbConnection"];
                strConn = conf.GetConnectionString("DbConnection");
        }

        public DataTable GetDataTable(string sql)
        {

            //create object connection
            SqlConnection conn = new SqlConnection(strConn);

            //create object command
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = conn;

            //create DataAdapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Insert, Update, delete depend cmd
        public void Update(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(strConn);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        public static SqlConnection GetConnection()
        {
            string ConnentionStr = _configuration.GetConnectionString("DbConnection");
            return new SqlConnection(ConnentionStr);
        }
        public static int ExecuteBySql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            if (parameters != null || parameters.Length != 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            cmd.Connection.Open();
            int count = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return count;
        }
        public static DataTable GetDataBySql(string sql, params SqlParameter[] parameters)
            // params chi duoc chuyen vao 1 lan va phai o sau cung
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if (parameters != null || parameters.Length != 0)
            {

                command.Parameters.AddRange(parameters);
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }
    }
}
