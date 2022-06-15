using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoMDI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string Title)
        {
            InitializeComponent();
            this.Text = Title;
        }

        public string Content { get => richTextBox1.Text; set => richTextBox1.Text = value; }
        public Font TextFont { get => richTextBox1.Font; set => richTextBox1.Font = value; }

        public Color TextColor { get => richTextBox1.ForeColor; set => richTextBox1.ForeColor = value; }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            Form1 parent = (Form1)this.MdiParent;
            this.TextFont = parent.MyFont;
            this.TextColor = parent.MyColor;
        }


    }
}
