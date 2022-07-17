using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_M1_ADO.DTL
{
    public class Bid
    {
        public int BidId { get; set; }
        public int ItemId { get; set; }
        public int BidderId { get; set; }

        public DateTime BidDateTime { get; set; }

        public double BidPrice { get; set; }
    }
}
