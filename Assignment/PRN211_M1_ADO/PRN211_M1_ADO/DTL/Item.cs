using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_M1_ADO.DTL
{
    public class Item
    {
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int SellerId { get; set; }

        public double MinimumBidIncrement { get; set; }

        public DateTime EndDateTime { get; set; }

        public double CurrentPrice { get; set; }
    }
}
