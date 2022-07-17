using PRN211_M1_ADO.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_M1_ADO.DAL
{
    public class ItemTypeDAO:DAO
    {
        static ItemTypeDAO instance;
        ItemTypeDAO() { }
        static ItemTypeDAO() => instance = new ItemTypeDAO();
        public static ItemTypeDAO GetInstance() => instance;

        public List<ItemType> GetList()
        {
            DataTable dt;
            dt = GetDataTable("Select * from itemTypes");
            List<ItemType> list = new List<ItemType>();
            foreach(DataRow row in dt.Rows)
            {
                try
                {
                    ItemType itemType = new ItemType
                    {
                        ItemTypeId = (int)row["itemTypeID"],
                        ItemTypeName = row["itemTypeName"].ToString()
                    };
                    list.Add(itemType);
                }
                catch { }
            }
            return list;
        }
    }
}
