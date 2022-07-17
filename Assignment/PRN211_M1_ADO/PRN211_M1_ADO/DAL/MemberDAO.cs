using PRN211_M1_ADO.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_M1_ADO.DAL
{
    public class MemberDAO:DAO
    {
        static MemberDAO instance;
        MemberDAO() { }
        static MemberDAO() => instance = new MemberDAO();
        public static MemberDAO GetInstance() => instance;

        public List<Member> GetList()
        {
            DataTable dt;
            dt = GetDataTable("SELECT * FROM members");
            List<Member> list = new List<Member>();
            foreach(DataRow row in dt.Rows)
            {
                try
                {
                    Member member = new Member
                    {
                        MemberId = (int)row["memberID"],
                        Name = row["Name"].ToString(),
                        Email = row["Email"].ToString(),
                        Address = row["Address"].ToString(),
                        ExpirationDate = (DateTime)row["ExpirationDate"],
                        Password = row["Password"].ToString()
                    };
                    list.Add(member);
                }
                catch { }
            }
            return list;
        }


    }
}
