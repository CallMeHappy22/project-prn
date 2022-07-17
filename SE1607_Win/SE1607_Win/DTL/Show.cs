using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1607_Win.DTL
{
    public class Show
    {
        public int ShowId { get; set; }
        public int RoomId { get; set; }
        public int FilmId { get; set; }
        public DateTime ShowDate { get; set; }
        public int Slot { get; set; }
        public bool Status { get; set; }

        public Decimal Price { get; set; }
    }
}
