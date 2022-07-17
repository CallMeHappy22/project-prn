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
    internal class FilmsDAO
    {
        public static List<Films> getAllFilm()
        {
            string sql = @"SELECT * FROM dbo.Films";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Films> list = new List<Films>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Films(
                   Convert.ToInt32(dr[0]),
                   Convert.ToInt32(dr[1]),
                   dr[2].ToString(),
                   dr[3].ToString(),
                   dr[4].ToString())
                    );
            }
            return list;
        }
        public static Films getFilmDetail(int id)
        {
            string sql = @"SELECT * FROM dbo.Films WHERE FilmID = @id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Films(
                   Convert.ToInt32(dr[0]),
                   Convert.ToInt32(dr[1]),
                   dr[2].ToString(),
                   dr[3].ToString(),
                   dr[4].ToString()
                    );
        }
        public static List<Films> getFilms(int RoomId, string showDate)
        {
            string sql = @"SELECT DISTINCT(Title),Shows.FilmID FROM dbo.Shows INNER JOIN dbo.Films ON Films.FilmID = Shows.FilmID WHERE RoomID = @roleId AND ShowDate =@dob;";
            SqlParameter parameter = new SqlParameter("@roleId", SqlDbType.Int);
            parameter.Value = RoomId;
            SqlParameter parameter1 = new SqlParameter("@dob", SqlDbType.Date);
            parameter1.Value = showDate;
            DataTable dt = DAO.GetDataBySql(sql, parameter, parameter1);
            List<Films> list = new List<Films>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Films(

                        dr[0].ToString(),
                         Convert.ToInt32(dr[1]))
                    );
            }
            return list;
        }
    }
}
