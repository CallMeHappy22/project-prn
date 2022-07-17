using Microsoft.Data.SqlClient;
using PRN211_M1_ADO.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_M1_ADO.DAL
{
    public class BidDAO:DAO
    {
        static BidDAO instance;
        BidDAO() { }

        static BidDAO() => instance = new BidDAO();

        public static BidDAO GetInstance() => instance;

        public void Add(Bid bid)
        {
            try
            {
                Bid b = GetByID(bid.BidId);
                if (b == null)
                {
                    SqlCommand cmd = new SqlCommand("Insert into Bids(ItemID, BidderID, BidDateTime, BidPrice) " +
                        "Values(@id, @bid, @bt, @price)");
                    cmd.Parameters.AddWithValue("@id", bid.ItemId);
                    cmd.Parameters.AddWithValue("@bid", bid.BidderId);
                    cmd.Parameters.AddWithValue("@bt", bid.BidDateTime);
                    cmd.Parameters.AddWithValue("@price", bid.BidPrice);
                    Update(cmd);
                }
                else
                    throw new Exception("The bid is already exist!");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
        public Bid GetByID(int id)
        {
            Bid bid;
            try
            {
                DataTable dt = GetDataTable("select * from bids where bidID = " + id);
                DataRow row = dt.Rows[0];
                
                bid = new Bid
                    {
                        BidId = (int)row["BidID"],
                        ItemId = (int)row["itemID"],
                        BidderId = (int)row["BidderID"],
                        BidDateTime = (DateTime)row["BidDateTime"],
                        BidPrice = (double)row["BidPrice"]
                    };
                return bid;
            }
            catch
            {
                return null;
            }
        }
        public List<Bid> GetList()
        {
            List<Bid> list = new List<Bid>();
            try
            {
                DataTable dt = GetDataTable("select * from bids");
                foreach(DataRow row in dt.Rows)
                {
                    Bid bid = new Bid
                    {
                        BidId = (int)row["BidID"],
                        ItemId = (int) row["itemID"],
                        BidderId = (int) row["BidderID"],
                        BidDateTime = (DateTime) row["BidDateTime"],
                        BidPrice = (double) row["BidPrice"]
                    };
                    list.Add(bid);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
