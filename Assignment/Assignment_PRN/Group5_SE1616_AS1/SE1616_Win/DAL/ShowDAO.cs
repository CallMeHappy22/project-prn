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
    internal class ShowDAO
    {
        public static List<Show> getAllShow()
        {
            string sql = @"SELECT s.RoomID,s.FilmID,s.ShowDate,s.Price,s.Slot,s.ShowID,s.[Status] FROM dbo.Shows AS s";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Show> list = new List<Show>();
         
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Show(
                    (int)row["showId"],
                    (int)row["roomId"],
                    (int)row["filmId"],
                    (DateTime)row["ShowDate"],
                  DBNull.Value.Equals(row["status"])?false : (bool)row["status"],
                   (int)row["slot"],
                   (decimal)row["price"])
                    );
            }
            return list;
        }
        public static List<Show> getAllShow(int filmId, int roomId, string dob)
        {
            string sql = @"SELECT s.RoomID,s.FilmID,s.ShowDate,s.Price,s.Slot,s.ShowID,s.[Status] FROM dbo.Shows AS s  WHERE s.FilmID = @filmID AND s.RoomID = @roomId AND s.ShowDate = @dob";
            SqlParameter parameter = new SqlParameter("@filmID", SqlDbType.Int);
            parameter.Value = filmId;
            SqlParameter parameter1 = new SqlParameter("@roomId", SqlDbType.Int);
            parameter1.Value = roomId;
            SqlParameter parameter2 = new SqlParameter("@dob", SqlDbType.Date);
            parameter2.Value = dob;
            DataTable dt = DAO.GetDataBySql(sql, parameter, parameter1, parameter2);
            List<Show> list = new List<Show>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Show(
                    (int)row["showId"],
                    (int)row["roomId"],
                    (int)row["filmId"],
                    (DateTime)row["ShowDate"],
                   DBNull.Value.Equals(row["status"]) ? false : (bool)row["status"],
                   (int)row["slot"],
                   (decimal)row["price"])
                    );
            }
            return list;
        }
        public static int getTotalShow()
        {
            string sql = @"SELECT COUNT(1) FROM dbo.Shows";
            return DAO.ExecuteBySql(sql);

        }
        public static void getDeleteShow(int ShowID)
        {
            string sql = @"DELETE dbo.Shows WHERE ShowID = @ShowID;";
            SqlParameter parameter = new SqlParameter("@ShowID", SqlDbType.Int);
            parameter.Value = ShowID;
            DAO.ExecuteBySql(sql, parameter);

        }
        public static int getDetailPrice(int id)
        {
            string sql = @"SELECT Price FROM dbo.Shows WHERE ShowID = @id;";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            DataRow dr = dt.Rows[0];
            return Convert.ToInt32(dr[0]);

        }
        public static Show getShowDetail(int id)
        {
            string sql = @"SELECT s.RoomID,s.FilmID,s.ShowDate,s.Price,s.Slot,s.ShowID,s.[Status] FROM dbo.Shows AS s WHERE s.ShowID  =@id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return new Show(
                    (int)row["showId"],
                    (int)row["roomId"],
                    (int)row["filmId"],
                    (DateTime)row["ShowDate"],
                     DBNull.Value.Equals(row["status"]) ? false : (bool)row["status"],
                   (int)row["slot"],
                   (decimal)row["price"]
                    );
        }
        public static List<int> getSlot(int RoomId, string showDate)
        {
            string sql = @"SELECT DISTINCT(Slot) FROM dbo.Shows WHERE RoomID = @roleId AND ShowDate =@dob;";
            SqlParameter parameter = new SqlParameter("@roleId", SqlDbType.Int);
            parameter.Value = RoomId;
            SqlParameter parameter1 = new SqlParameter("@dob", SqlDbType.Date);
            parameter1.Value = showDate;
            DataTable dt = DAO.GetDataBySql(sql, parameter, parameter1);
            List<int> list = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(Convert.ToInt32(dr[0]));
            }
            return list;
        }
        public static void UpdateShow(int slot, int filmId, int price, int showId)
        {
            string sql = @"UPDATE dbo.Shows SET Slot = @slot, FilmID =@filmId,Price=@price WHERE ShowID = @showId;";
            SqlParameter parameter = new SqlParameter("@slot", SqlDbType.Int);
            parameter.Value = slot;
            SqlParameter parameter1 = new SqlParameter("@filmId", SqlDbType.Int);
            parameter1.Value = filmId;
            SqlParameter parameter2 = new SqlParameter("@price", SqlDbType.Int);
            parameter2.Value = price;
            SqlParameter parameter3 = new SqlParameter("@showId", SqlDbType.Int);
            parameter3.Value = showId;
            DAO.ExecuteBySql(sql, parameter, parameter1, parameter2, parameter3);
        }
        public static void AddShow(int roomID, int slot, int filmId, int price, string dob)
        {
            string sql = @"INSERT INTO dbo.Shows
                            VALUES
                            (   @roomId,    -- RoomID - int
                                @filmId,    -- FilmID - int
                                @dob, -- ShowDate - date
                                @price, -- Price - money
                                0, -- Status - bit
                                @slot  -- Slot - int
                                )";
            SqlParameter parameter = new SqlParameter("@roomId", SqlDbType.Int);
            parameter.Value = roomID;
            SqlParameter parameter1 = new SqlParameter("@filmId", SqlDbType.Int);
            parameter1.Value = filmId;
            SqlParameter parameter2 = new SqlParameter("@dob", SqlDbType.Date);
            parameter2.Value = dob;
            SqlParameter parameter3 = new SqlParameter("@price", SqlDbType.Int);
            parameter3.Value = price;
            SqlParameter parameter4 = new SqlParameter("@slot", SqlDbType.Int);
            parameter4.Value = slot;
            DAO.ExecuteBySql(sql, parameter, parameter1, parameter2, parameter3, parameter4);
        }
    }
}
