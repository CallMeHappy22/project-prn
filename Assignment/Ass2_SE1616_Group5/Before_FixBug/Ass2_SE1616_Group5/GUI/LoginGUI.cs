using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2_SE1616_Group5.GUI
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name, pass;
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            name = conf["User:Name"];
            pass = conf["User:Password"];
            //MessageBox.Show($"Name = {name}, Pass = {pass}");
            if (txtName.Text == name && txtPassword.Text == pass)
            {
                Settings.UserName = name;
                MessageBox.Show("You are logged in as administrator");
            }
            else
                MessageBox.Show("Don't have that user");

        }
    }
}
