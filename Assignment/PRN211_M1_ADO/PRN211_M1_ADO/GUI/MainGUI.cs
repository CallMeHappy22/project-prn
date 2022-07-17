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
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            if(mi.Text == "Login")
            {
                LoginGUI f = new LoginGUI();
                f.ShowDialog();
            }
            else
            {
                Settings.UserName = "";
                Settings.UserID = -1;
                toolStripContainer1.ContentPanel.Controls.Clear();
                MessageBox.Show("You are logout");
            
            }
        }

        private void MainGUI_Activated(object sender, EventArgs e)
        {
            if(Settings.UserName != "")
            {
                loginToolStripMenuItem.Text = $"Logout ({Settings.UserName})";
                bidToolStripMenuItem.Enabled = true;
                itemToolStripMenuItem.Enabled = true;
                toolStripButtonBid.Enabled = true;
                toolStripButtonItem.Enabled = true;
            }
            else
            {
                loginToolStripMenuItem.Text = "Login";
                bidToolStripMenuItem.Enabled = false;
                itemToolStripMenuItem.Enabled = false;
                toolStripButtonBid.Enabled = false;
                toolStripButtonItem.Enabled = false;
            }
        }

        private void bidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BidGUI f = new BidGUI();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(f);
        }
    }
}
