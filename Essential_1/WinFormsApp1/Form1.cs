using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          Random random = new Random();
            int red = random.Next(0, 255);
            int green = random.Next(0, 255);
            int blue = random.Next(0, 255); 
            Color color = Color.FromArgb(red, green, blue);
            textBox1.BackColor = color;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
