using SE1616_Win.DTL;
using SE1616_Win.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE1616_Win.GUI
{
    public partial class ShowAddEditGUI : Form
    {
       
        public ShowAddEditGUI()
        {
            InitializeComponent();
        }
        public void Show_Load(int id,int roomId)
        {          
            textBox2.Text = id.ToString();
            //Regex regex = new Regex(@"^[a-zA-Z0-9\-]*$");
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            DateTime dob = ShowDAO.getShowDetail(id).ShowDate;
            dateTimePicker1.Value=dob;
            Dictionary<string, string> filmsSource = new Dictionary<string, string>();
            Dictionary<string, string> roomsSource = new Dictionary<string, string>();
            Dictionary<string, string> slotSource = new Dictionary<string, string>();
            List<Films> listFilms = FilmsDAO.getFilms(roomId,dob.ToString("yyyy-MM-dd"));
            foreach (Films f in listFilms)
            {
                filmsSource.Add(f.FilmID.ToString(), f.Title.ToString());
            }
            List<int> listSlot = ShowDAO.getSlot(roomId, dob.ToString("yyyy-MM-dd"));
            comboBox2.DataSource = listSlot;
            List<Rooms> listRooms = RoomsDAO.getAllRoom();
            foreach (Rooms r in listRooms)
            {
                roomsSource.Add(r.RoomID.ToString(), r.Name.ToString());
            }
            comboBox3.DataSource = new BindingSource(filmsSource, null);

            comboBox1.DataSource = new BindingSource(roomsSource, null);

            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";

            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            textBox1.Text = ShowDAO.getDetailPrice(id).ToString();
        }

       public void addShow()
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\-]*$");
            Dictionary<string, string> filmsSource = new Dictionary<string, string>();
            Dictionary<string, string> roomsSource = new Dictionary<string, string>();
            Dictionary<string, string> slotSource = new Dictionary<string, string>();
            List<Films> listFilms = FilmsDAO.getAllFilm();
            foreach (Films f in listFilms)
            {
                filmsSource.Add(f.FilmID.ToString(), f.Title.ToString());
            }
            List<Rooms> listRooms = RoomsDAO.getAllRoom();
            foreach (Rooms r in listRooms)
            {
                roomsSource.Add(r.RoomID.ToString(), r.Name.ToString());
            }
            comboBox3.DataSource = new BindingSource(filmsSource, null);

            comboBox1.DataSource = new BindingSource(roomsSource, null);

            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";

            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int slot = Convert.ToInt32(comboBox2.Text);
            int filmId = Convert.ToInt32(((KeyValuePair<string, string>)comboBox3.SelectedItem).Key);
            int price = Convert.ToInt32(textBox1.Text);
           
           
            if(textBox2.Text != "")
            {
                int showId = Convert.ToInt32(textBox2.Text);
                ShowGUI sg = new ShowGUI();
                
                ShowDAO.UpdateShow(slot, filmId, price, showId);
                MessageBox.Show("That show is edited!");
                
            }
            else
            {
                int roomId = Convert.ToInt32(((KeyValuePair<string, string>)comboBox1.SelectedItem).Key);
                DateTime dob = dateTimePicker1.Value;
                int slotSelected = Convert.ToInt32(comboBox2.Text);
                int filmIdSelected = Convert.ToInt32(((KeyValuePair<string, string>)comboBox3.SelectedItem).Key);
                int priceSelected = Convert.ToInt32(textBox1.Text);
                ShowDAO.AddShow(roomId, slotSelected, filmIdSelected, priceSelected, dob.ToString("yyyy-MM-dd"));
                MessageBox.Show("A new show is added!");
                ShowGUI sgu = new ShowGUI();
                
            }
             
            
            
           
           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ShowAddEditGUI_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
