using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DemoMDI
{
    public partial class Form1 : Form
    {
        private Font myFont;
        private Color myColor;

        private int count = 0;

        public Font MyFont { get => myFont; set => myFont = value; }
        public Color MyColor { get => myColor; set => myColor = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void fDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2("New  File"+ count);
            form.TextFont = MyFont;
            form.TextColor = MyColor;
            count++;
           form.MdiParent = this;
            form.Show();
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void casToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void hozirontialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 child = (Form2)this.ActiveMdiChild;

            string content = child.Content;

            saveFileDialog1.Filter = "All file|*.*|Text files|*.txt";
            DialogResult result = saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(content);
                writer.Close();
            }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All file|*.*|Text files|*.txt";
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                StringReader stringReader = new StringReader(path);
                StringBuilder sb = new StringBuilder();
                string line = null;
                while ((line = stringReader.ReadLine()) != null)
                {
                    sb.Append(line);
                    sb.Append("\n");
                }
                Form2 child = new Form2(path);
                child.MdiParent = this;
                child.Content = sb.ToString();
                child.Show();

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                MyFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MyColor = colorDialog1.Color;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }
    }
}
