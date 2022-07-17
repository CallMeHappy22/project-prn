using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2_SE1616_Group5.GUI
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "SE1616 Group 5, Nguyễn Như Kiên, Vũ Phúc Thành, Nguyễn Bá Lộc, Phạm Phú Sơn";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!loginToolStripMenuItem.Text.Equals("Login"))
            {
                Settings.UserName = "";
                MessageBox.Show("You are log out!");
            } else
            {
                LoginGUI f = new LoginGUI();
                DialogResult dr = f.ShowDialog();
            }

            if (toolStripContainer1.ContentPanel.Controls.Count > 0) showToolStripMenuItem.PerformClick();
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
