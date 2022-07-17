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
    public partial class BidGUI : Form
    {
        public BidGUI()
        {
            InitializeComponent();
            bindGrid();
            
        }

        private void bindGrid()
        {
            BindingSource source = new BindingSource();
            source.DataSource = ItemDAO.GetInstance().GetList()
                .Where(i => i.EndDateTime >= DateTime.Now)
                .ToList<Item>();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = source;
            int count = dataGridView1.Columns.Count;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            DataGridViewButtonColumn btnBid = new DataGridViewButtonColumn { 
                Text = "Bid",
                Name = "Bid",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnBid);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["Bid"].Index)
            {
                int itemID = (int) dataGridView1.Rows[e.RowIndex].Cells["itemID"].Value;
                //MessageBox.Show($"itemID = {itemID}");
                BidAddGUI f = new BidAddGUI(itemID);
                f.ShowDialog();                

            }
        }
    }
}
