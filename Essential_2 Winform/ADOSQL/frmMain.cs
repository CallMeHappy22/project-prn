using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADOSQL
{
    public partial class frmMain : Form
    {
        private SqlConnection conn;
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("server=ANDREWVU\\ANDREWVU;uid=sa;pwd=sa;database=NorthWind");
                conn.Open();
                iblMessage.ForeColor = Color.Green;
                iblMessage.Text = "Connect Successful!";
            }catch(Exception ex)
            {
                iblMessage.ForeColor = Color.Red;
                iblMessage.Text = "Connect fail!";
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if(conn != null) { 
                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Customers]", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string fullname = reader.GetString(2) +" "+reader.GetString(9);
                    richTextBox1.AppendText(fullname);
                    richTextBox1.AppendText("\n");
                }
            }
            else
            {
                iblMessage.ForeColor = Color.Red;
                iblMessage.Text = "Connect fail!";
            }
            

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (conn != null)
            {
                string name = txtName.Text;
                int lastSpaceIndex = name.LastIndexOf(" ");
                string firstName = name.Substring(0, lastSpaceIndex);
                string lastName = name.Substring(lastSpaceIndex, name.Length-lastSpaceIndex);
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Customers](");
                sb.Append("'" + name + "',");
                sb.Append("'" + "" + "'");
                SqlCommand command = new SqlCommand(sb.ToString(),conn);
                command.ExecuteNonQuery();
            }
            else
            {
                iblMessage.ForeColor = Color.Red;
                iblMessage.Text = "Connect fail!";
           }
        }
    }
}
