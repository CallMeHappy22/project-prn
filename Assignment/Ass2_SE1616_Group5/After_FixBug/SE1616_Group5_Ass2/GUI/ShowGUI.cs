using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ass2_SE1616_Group5.Models;
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
    public partial class ShowGUI : Form
    {
        private CinemaContext cinemaContext;
        public ShowGUI()
        {
            InitializeComponent();
            cinemaContext = new CinemaContext();
            List<Show> dt = cinemaContext.Shows.ToList();
            bindGrid(dt);
            bindSearch();
        }

        void bindSearch()
        {
            List<Film> dt = cinemaContext.Films.ToList();
            dt.Insert(0, new Film() { 
                FilmId = 0,
                GenreId = 0,
                Title = "All",
                Year = 0,
                CountryCode = "VN"
            });

            cboFilm.DataSource = dt;
            cboFilm.DisplayMember = "Title";
            cboFilm.ValueMember = "FilmID";

            cboRoom.DataSource = cinemaContext.Rooms.ToList();
            cboRoom.DisplayMember = "Name";
            cboRoom.ValueMember = "RoomID";
        }
        void bindGrid(List<Show> listShow)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = listShow;

            labNumShow.Text = "The number of shows: " + listShow.Count;
            
            if (Settings.UserName.Equals("admin"))
            {
                btnAdd.Visible = true;
                int count = dataGridView1.Columns.Count;

                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };

                dataGridView1.Columns.Insert(count, btnEdit);
                count = dataGridView1.Columns.Count;
                dataGridView1.Columns.Insert(count, btnDelete);
            } else
            {
                btnAdd.Visible = false;
            }

            DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
            {
                Name = "Booking",
                Text = "Booking",
                UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Insert(dataGridView1.Columns.Count, btnBooking);

            dataGridView1.Columns["showid"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns["Edit"] != null && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int showId = (int) dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                Show show = cinemaContext.Shows.Find(showId);

                ShowAddEditGUI f = new ShowAddEditGUI(show);
                DialogResult dr = f.ShowDialog();

                cinemaContext = new CinemaContext();
                List<Show> listShow = cinemaContext.Shows.ToList();
                bindGrid(listShow);
            }

            if (dataGridView1.Columns["Delete"] != null && e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                try
                {
                    int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;

                    DialogResult dr = MessageBox.Show("Do you sure to delete ?", "Warning", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Show show = cinemaContext.Shows.Find(showId);
                        cinemaContext.Shows.Remove(show);
                        cinemaContext.SaveChanges();
                    }
                    cinemaContext = new CinemaContext();
                    List<Show> listShow = cinemaContext.Shows.ToList();
                    bindGrid(listShow);
                }
                catch(Exception ex)
                {
                  Console.WriteLine(ex.Message);
                }
            }

            if (dataGridView1.Columns["Booking"] != null && e.ColumnIndex == dataGridView1.Columns["Booking"].Index && e.RowIndex >= 0)
            {
                int roomID = (int)dataGridView1.Rows[e.RowIndex].Cells["RoomID"].Value;
                int showID = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;

                BookingGUI f = new BookingGUI(roomID, showID);
                DialogResult dr = f.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddEditGUI showAddEditGUI = new ShowAddEditGUI(new Show() 
            { 
                ShowId = 0,
                FilmId = (int)cboFilm.SelectedValue,
                RoomId = (int)cboRoom.SelectedValue,
                ShowDate = dtpShowDate.Value
            });
            DialogResult dr = showAddEditGUI.ShowDialog();
            if (dr == DialogResult.OK)
            {
                cinemaContext = new CinemaContext();
                List<Show> listShow = cinemaContext.Shows.ToList();
                bindGrid(listShow);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cinemaContext = new CinemaContext();
            List<Show> listShow = cinemaContext.Shows.ToList();
            if ((int)cboFilm.SelectedValue != 0)
            {
                var listShowByDateAndRoomAndFilm = listShow.Where(s => s.ShowDate == dtpShowDate.Value.Date && s.RoomId == (int)cboRoom.SelectedValue && s.FilmId == (int)cboFilm.SelectedValue);
                bindGrid(listShowByDateAndRoomAndFilm.ToList());
            } else
            {
                var listShowByDateAndRoomAndFilm = listShow.Where(s => s.ShowDate == dtpShowDate.Value.Date && s.RoomId == (int)cboRoom.SelectedValue);
                bindGrid(listShowByDateAndRoomAndFilm.ToList());
            }
            
        }
    }
}
