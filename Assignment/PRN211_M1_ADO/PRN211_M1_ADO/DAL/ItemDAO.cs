using PRN211_M1_ADO.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_M1_ADO.DAL
{
    public class ItemDAO:DAO
    {
        static ItemDAO instance;
        ItemDAO() { }
        static ItemDAO() => instance = new ItemDAO();
        public static ItemDAO GetInstance() => instance;

        public Item GetByID(int id)
        {
            Item item;
            try
            {
                DataTable dt = GetDataTable("Select * from items where itemID = " 
                        + id);
                DataRow row = dt.Rows[0];
                item = new Item
                    {
                        ItemId = (int)row["ItemId"],
                        ItemName = row["ItemName"].ToString(),
                        ItemDescription = row["ItemDescription"].ToString(),
                        ItemTypeId = (int)row["ItemTypeId"],
                        SellerId = (int)row["sellerId"],
                        CurrentPrice = (double)row["currentPrice"],
                        MinimumBidIncrement = (double)row["minimumBidIncrement"],
                        EndDateTime = (DateTime)row["EndDateTime"]
                    };
                return item;             
            }
            catch
            {
                return null;
            }
        }
        public List<Item> GetList()
        {
            List<Item> list = new List<Item>();
            try
            {
                DataTable dt = GetDataTable("Select * from items");
                foreach (DataRow row in dt.Rows)
                {
                    Item item = new Item
                    {
                        ItemId = (int)row["ItemId"],
                        ItemName = row["ItemName"].ToString(),
                        ItemDescription = row["ItemDescription"].ToString(),
                        ItemTypeId = (int)row["ItemTypeId"],
                        SellerId = (int)row["sellerId"],
                        CurrentPrice = (double)row["currentPrice"],
                        MinimumBidIncrement = (double)row["minimumBidIncrement"],
                        EndDateTime = (DateTime)row["EndDateTime"]
                    };
                    list.Add(item);
                }// foreach
            }
            catch
            {
                return null;
            }
            return list;
        }

    }
}
