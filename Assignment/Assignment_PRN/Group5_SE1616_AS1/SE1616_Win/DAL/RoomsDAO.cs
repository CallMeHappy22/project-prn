using SE1616_Win.DAL;
using Microsoft.Data.SqlClient;
using SE1616_Win.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1616_Win.DAL
{
    internal class RoomsDAO
    {
        public static List<Rooms> getAllRoom()
        {
            string sql = @"SELECT * FROM dbo.Rooms";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Rooms> list = new List<Rooms>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Rooms(
                    Convert.ToInt32(dr[0]),
                    dr[1].ToString(),
                    Convert.ToInt32(dr[2]),
                    Convert.ToInt32(dr[3]))
                    );
            }
            return list;
        }
        public static Rooms getSRoomDetail(int id)
        {
            string sql = @"SELECT * FROM dbo.Rooms WHERE RoomID = @id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Rooms(
                    Convert.ToInt32(dr[0]),
                    dr[1].ToString(),
                    Convert.ToInt32(dr[2]),
                    Convert.ToInt32(dr[3])
                    );
        }

    }
}
