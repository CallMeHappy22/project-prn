using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SE1616_Win.DTL;
using SE1616_Win.DAL;
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

namespace SE1616_Win.GUI
{
    public partial class ShowGUI : Form
    {
        public ShowGUI()
        {
            InitializeComponent();          
        }
        

        private void addBt_Load(object sender, EventArgs e)
        {
            List<Show> ln = ShowDAO.getAllShow();
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "RoomId";
            dataGridView1.Columns[1].HeaderText = "FilmId";
            dataGridView1.Columns[2].HeaderText = "ShowDate";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].HeaderText = "Slot";
            dataGridView1.Columns[5].Visible = false;

            //Neu username !=null thi hien thi ra booking, edit,delete
            if(Settings.UserName != "")
            {
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                {
                    button.Name = "Booking";
                    button.HeaderText = "Booking";
                    button.Text = "Booking";
                    button.UseColumnTextForButtonValue = true; //dont forget this line
                    this.dataGridView1.Columns.Add(button);
                }
                DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
                {
                    button1.Name = "Edit";
                    button1.HeaderText = "Edit";
                    button1.Text = "Edit";
                    button1.UseColumnTextForButtonValue = true; //dont forget this line
                    this.dataGridView1.Columns.Add(button1);
                }
                DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
                {
                    button2.Name = "Delete";
                    button2.HeaderText = "Delete";
                    button2.Text = "Delete";
                    button2.UseColumnTextForButtonValue = true; //dont forget this line
                    this.dataGridView1.Columns.Add(button2);
                }
                
            }
            else
            {
                button1.Visible = false;
            }


            foreach (Show show in ln)
            {
                
                dataGridView1.Rows.Add(new string[] {show.RoomID.ToString()
                    ,show.FilmID.ToString(),show.ShowDate.ToString("yyyy-MM-dd"),show.Price.ToString(),
                    show.Slot.ToString(),show.ShowID.ToString() });
            }

            totalRow.Text = ShowDAO.getAllShow().Count.ToString();

            Dictionary<string, string> filmsSource = new Dictionary<string, string>();
            Dictionary<string, string> roomsSource = new Dictionary<string, string>();
            List<Films> listFilms = FilmsDAO.getAllFilm();
            foreach (Films f in listFilms)
            {
                filmsSource.Add(f.FilmID.ToString(), f.Title.ToString());
            }

            List<Rooms> listRooms = RoomsDAO.getAllRoom() ;
            foreach (Rooms r in listRooms)
            {
                roomsSource.Add(r.RoomID.ToString(),r.Name.ToString());
            }
            comboBox1.DataSource = new BindingSource(filmsSource, null);

            comboBox2.DataSource = new BindingSource(roomsSource, null);

            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
        }

        /*string SubjectID = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
        string InstructorID = ((KeyValuePair<string, string>)listBox1.SelectedItem).Key;*/


        //Cell click edit, delete, booking...
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells[5].Value.ToString());
                if (e.ColumnIndex == 6)
                {
                    
                    MessageBox.Show($"{id}");

                }else if (e.ColumnIndex == 7)
                {
                   
                    int Roomid = Convert.ToInt32(row.Cells[0].Value.ToString());
                    ShowAddEditGUI sa = new ShowAddEditGUI();
                    sa.Show_Load(id,Roomid);
                    
                    sa.ShowDialog();
                    dataGridView1.Rows.Clear();
                    List<Show> ln = ShowDAO.getAllShow();
                    foreach (Show show in ln)
                    {

                        dataGridView1.Rows.Add(new string[] {show.RoomID.ToString()
                                ,show.FilmID.ToString(),show.ShowDate.ToString("yyyy-MM-dd"),show.Price.ToString(),
                                show.Slot.ToString(),show.ShowID.ToString() });
                    }
                    MainGUI m = new MainGUI();
                    m.showToolStripMenuItem_Click();

                }
                else if (e.ColumnIndex == 8) {
                    DialogResult dr = MessageBox.Show("Do you want to delete?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(dr == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Clear();
                        ShowDAO.getDeleteShow(id);
                        List<Show> ln = ShowDAO.getAllShow();
                        foreach (Show show in ln)
                        {

                            dataGridView1.Rows.Add(new string[] {show.RoomID.ToString()
                                ,show.FilmID.ToString(),show.ShowDate.ToString("yyyy-MM-dd"),show.Price.ToString(),
                                show.Slot.ToString(),show.ShowID.ToString() });
                        }
                        MainGUI m = new MainGUI();
                        m.showToolStripMenuItem_Click();
                    }
                    
                    
                
                }
            }
        }

        //Button Search
        private void searchBt_Click(object sender, EventArgs e)
        {
            
            DateTime dob = dateTimePicker1.Value;
            int filmID = Convert.ToInt32(((KeyValuePair<string, string>)comboBox1.SelectedItem).Key);
            int roomId = Convert.ToInt32(((KeyValuePair<string, string>)comboBox2.SelectedItem).Key);
            dataGridView1.Rows.Clear();
            totalRow.Text = ShowDAO.getAllShow(filmID, roomId, dob.ToString("yyyy-MM-dd")).Count.ToString();
            List<Show> ln = ShowDAO.getAllShow(filmID, roomId,  dob.ToString("yyyy-MM-dd"));
            foreach (Show show in ln)
            {

                dataGridView1.Rows.Add(new string[] {show.RoomID.ToString()
                    ,show.FilmID.ToString(),show.ShowDate.ToString("yyyy-MM-dd"),show.Price.ToString(),
                    show.Slot.ToString(),show.ShowID.ToString() });
            }
            MainGUI m = new MainGUI();
            m.showToolStripMenuItem_Click();
        }

        //Button Search
        private void button1_Click(object sender, EventArgs e)
        {

            ShowAddEditGUI sa = new ShowAddEditGUI();
            sa.addShow();
            sa.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
