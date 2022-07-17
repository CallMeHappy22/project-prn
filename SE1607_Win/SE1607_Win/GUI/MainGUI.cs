using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE1607_Win.GUI
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Do you want to delete?", "Confirm", 
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Form2 f = new Form2();
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
                MessageBox.Show("You press OK");
            else
                MessageBox.Show("You press Cancel");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(f);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginToolStripMenuItem.Text.StartsWith("Login"))
            {
                LoginGUI f = new LoginGUI();
                DialogResult dr = f.ShowDialog();
            }
            else
            {
                Settings.UserName = "";
                MessageBox.Show("You are logged out");            
            }
        }

        private void MainGUI_Activated(object sender, EventArgs e)
        {
            if (Settings.UserName == "")
                loginToolStripMenuItem.Text = "Login";
            else
                loginToolStripMenuItem.Text = $"Logout ({Settings.UserName})";
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGUI f = new ShowGUI();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(f);
        }
    }
}
