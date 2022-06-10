using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Double_click
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            BackColor = Color.BlueViolet;
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            BackColor = Color.Green;
            this.Text = "Hello World";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("You choose to close windown");
        }
    }
}
