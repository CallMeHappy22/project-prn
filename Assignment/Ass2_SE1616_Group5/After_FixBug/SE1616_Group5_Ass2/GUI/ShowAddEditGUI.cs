using Ass2_SE1616_Group5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2_SE1616_Group5.GUI
{
    public partial class ShowAddEditGUI : Form
    {
        int add;
        Show currentShow;
        private CinemaContext cinemaContext;
        public ShowAddEditGUI(Show show)
        {
            InitializeComponent();
            cinemaContext = new CinemaContext();
            currentShow = show;
            if (show.ShowId == 0) add = 1;
            else add = 0;

            if(add == 0)
            {
                dtpShowDate.Value = show.ShowDate.Value;
                cboRoomId.DataSource = cinemaContext.Rooms.ToList();
                cboRoomId.DisplayMember = "Name";
                cboRoomId.ValueMember = "RoomId";
                cboRoomId.SelectedValue = show.RoomId;

                List<Show> listShow = cinemaContext.Shows.ToList();
                var listShowByIdAndDate = listShow.Where(s => s.RoomId == show.RoomId && s.ShowDate.Value == show.ShowDate.Value);

                List<int> availSlot = new List<int>() { 1,2,3,4,5,6,7,8,9};
                
                foreach(Show s in listShowByIdAndDate)
                {
                    availSlot.Remove(s.Slot.Value);
                }
                
                availSlot.Add(show.Slot.Value);
                cboSlot.DataSource = availSlot;
                cboSlot.SelectedItem = show.Slot;

                cboFilmId.DataSource = cinemaContext.Films.ToList();
                cboFilmId.DisplayMember = "Title";
                cboFilmId.ValueMember = "FilmID";
                cboFilmId.SelectedValue = show.FilmId;

                txtPrice.Text = show.Price.ToString();
            }

            if (add == 1)
            {
                dtpShowDate.Value = show.ShowDate.Value;
                cboRoomId.DataSource = cinemaContext.Rooms.ToList();
                cboRoomId.DisplayMember = "Name";
                cboRoomId.ValueMember = "RoomId";
                cboRoomId.SelectedValue = show.RoomId;
                
                List<Show> listShow = cinemaContext.Shows.ToList();
                var listShowByIdAndDate = listShow.Where(s => s.RoomId == show.RoomId && s.ShowDate.Value == show.ShowDate.Value);

                List<int> availSlot = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                foreach (Show s in listShowByIdAndDate)
                {
                    availSlot.Remove(s.Slot.Value);
                }

                cboSlot.DataSource = availSlot;

                cboFilmId.DataSource = cinemaContext.Films.ToList();
                cboFilmId.DisplayMember = "Title";
                cboFilmId.ValueMember = "FilmID";
                cboFilmId.SelectedValue = show.FilmId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Show newShow = new Show() {
                ShowId = currentShow.ShowId,
                RoomId = (int)cboRoomId.SelectedValue,
                FilmId = (int)cboFilmId.SelectedValue,
                ShowDate = dtpShowDate.Value,
                Price = decimal.Parse(txtPrice.Text),
                Status = true,
                Slot = int.Parse(cboSlot.Text)
            };

            if (add == 0)
            {
                Show show = cinemaContext.Shows.Find(currentShow.ShowId);
                show.RoomId = (int)cboRoomId.SelectedValue;
                show.FilmId = (int)cboFilmId.SelectedValue;
                show.ShowDate = dtpShowDate.Value;
                show.Price = decimal.Parse(txtPrice.Text);
                show.Status = true;
                show.Slot = int.Parse(cboSlot.Text);
                cinemaContext.SaveChanges();
                MessageBox.Show("That show is edited!");
            }
            if (add == 1)
            {
                cinemaContext.Shows.Add(newShow);
                cinemaContext.SaveChanges();
                MessageBox.Show("A new show is added!");
            }

        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (decimal.Parse(txtPrice.Text) < 0) { txtPrice.Text = "0"; }
            } catch (Exception) {
                txtPrice.Text = "0";
            }
        }
    }
}
