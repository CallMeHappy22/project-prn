using PRN211_M1_ADO.DAL;
using PRN211_M1_ADO.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRN211_M1_ADO.GUI
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            List<Member> list = MemberDAO.GetInstance().GetList();
            Member member = list.Where(m => m.Name == txtUserName.Text
                && m.Password == txtPassword.Text)
                .FirstOrDefault();
            if(member != null)
            {
                Settings.UserName = member.Name;
                Settings.UserID = member.MemberId;
            }
            else
            {
                Settings.UserName = "";
                Settings.UserID = -1;
            }
        }
    }
}
