using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_M1_ADO.DTL
{
    public class Member
    {
        public int MemberId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Password { get; set; }
    }
}
