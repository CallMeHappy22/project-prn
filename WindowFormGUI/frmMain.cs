using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }
        private void Font1_DoubleClick(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            this.Text = "i was becoeme a hero.";
        }
    }
}
