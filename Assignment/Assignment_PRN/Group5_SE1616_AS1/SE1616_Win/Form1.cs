using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE1616_Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("You want to delete?", "Confirm", 
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Form2 f = new Form2();
            //DialogResult dr = f.ShowDialog();
            //if (dr == DialogResult.OK)
            //    MessageBox.Show("You press OK");
            //else
            //    MessageBox.Show("You press Cancel");
            Form2 f = new Form2();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(f);
        }
    }
}
