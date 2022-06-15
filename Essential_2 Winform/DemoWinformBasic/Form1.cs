using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWinformBasic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
          
            string s = textBox1.Text;
            decimal n;
            if(decimal.TryParse(s,out n))
            {
                textBox1.BackColor = Color.Green;
            }
            else
            {
                textBox1.BackColor = Color.Red;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            //DialogResult result = form.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    MessageBox.Show("Hello......................................");
            //}
            //else
            //{
            //    MessageBox.Show("Bye");
            //}
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            MessageBox.Show(checkBox1.CheckState.ToString());
        }

      private void button2_click()
        {

        }
    }
}
