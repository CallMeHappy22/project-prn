using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1607_Win.DAL
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
            //strConn = conf["ConnectionStrings:DbConnection"];
            strConn = conf.GetConnectionString("DbConnection");

        }

        public DataTable GetDataTable(string sql)
        {
            SqlConnection conn = new SqlConnection(strConn);
            
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = conn;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        // Insert, Update, Delete depend on cmd
        public void Update(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(strConn);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
