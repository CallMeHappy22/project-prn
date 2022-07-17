using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinQGUI
{
    public partial class Form1 : Form
    {

        List<Food> foodList;
        void LoadFood()
        {
            foodList = new List<Food>();
            foodList.Add(new Food("Chicken","55555"));
            foodList.Add(new Food("Beef", "9999"));
            foodList.Add(new Food("Fish","8888"));
            cbData.DataSource = foodList;
            cbData.DisplayMember = "Name";

        }
        public Form1()
        {
            InitializeComponent();
            LoadFood();
        }

        private void cbResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Food> result = new List<Food>();
            //foreach (Food item in foodList)
            //{
            //    if(item.name == txbKey.Text)
            //    {
            //        result.Add(item);
            //    }
            //}
           var result2 = foodList.Select(p => p.price).ToList();
            cbResult.DataSource = result2;
            cbResult.DisplayMember = "Name";
        }
    }

    public class Food
    {
        public string name { get; set; }
        public string price { get; set; }   

        public Food(string name, string price)
        {
            this.name = name;
            this.price = price;
        }

        public Food()
        {
        }
    }
}
