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

namespace MenuSetUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if(DialogResult.OK == result)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = colorDialog1.ShowDialog();
            if(DialogResult.OK == rs)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*)|*.*|Text files(*.txt)|*.txt";
            DialogResult rs = openFileDialog1.ShowDialog();
            if(rs == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                StringBuilder sb = new StringBuilder();
                string[] lines = File.ReadAllLines(file);
                foreach (string s in lines)
                {
                    sb.Append(s);
                    sb.Append("\n");
                }
                richTextBox1.Text = sb.ToString();
            
            }
        }

        private void showMessageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Xin chao !!");
            //  MessageBox.Show(this, "Bich Ngoc Bui", "Bye");
            MessageBox.Show("My Best Friend", "Bye", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information,MessageBoxDefaultButton.Button1
                );
        }

        private void showForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
