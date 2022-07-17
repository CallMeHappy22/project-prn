using PRN211_M1_ADO.DAL;
using PRN211_M1_ADO.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRN211_M1_ADO.GUI
{
    public partial class BidAddGUI : Form
    {
        public BidAddGUI(int itemID)
        {
            InitializeComponent();
            Item item = ItemDAO.GetInstance().GetByID(itemID);
            txtItemName.Text = item.ItemName;
            txtDescription.Text = item.ItemDescription;
            txtSellerID.Text = MemberDAO.GetInstance().GetList()
                .Find(m => m.MemberId == item.SellerId).Name;

            txtItemTypeID.Text = ItemTypeDAO.GetInstance().GetList()
                .Find(it => it.ItemTypeId == item.ItemTypeId).ItemTypeName;

            txtCurrentPrice.Text = item.CurrentPrice.ToString();
            txtMinimumBidIncrement.Text = item.MinimumBidIncrement.ToString();
            txtEndDateTime.Text = item.EndDateTime.ToString("dd/MM/yyyy HH:mm");
            
            txtBidDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            TimeSpan ts = item.EndDateTime - DateTime.Now;
            txtBidPrice.Text = (item.CurrentPrice + item.MinimumBidIncrement).ToString();

            txtTimeRemaining.Text = $"Days: {ts.Days}, Hours: {ts.Hours}, Minutes: {ts.Minutes}";
        }
    }
}
