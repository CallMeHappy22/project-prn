using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGraphic
{
    public partial class Form1 : Form
    {
        private Point p1;
        private Point p2;
        private int type;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            type = 1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            type = 2;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            type = 3;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            p2 =  new Point(e.X, e.Y);
            Graphics g =  this.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            Rectangle rect = new Rectangle(p1, new Size(p2.X - p1.X,p2.Y-p1.Y));
            switch (type)
            {
                case 1:
                    g.DrawLine(pen,p1, p2);
                    break;
              case 2:
                    g.DrawRectangle(pen, rect);
                    break;
                case 3:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }
    }
}
