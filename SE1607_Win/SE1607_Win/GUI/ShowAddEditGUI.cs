//using SE1607_Win.DAL;
//using SE1607_Win.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE1607_Win.Models;

namespace SE1607_Win.GUI
{
    public partial class ShowAddEditGUI : Form
    {
        int add, id;
        CinemaContext context;
        //ADD: add = 1, id is roomId, EDIT: add = 0, id is showId
        public ShowAddEditGUI(int add, int id, CinemaContext context)
        {
            InitializeComponent();
            this.context = context;
            this.add = add;
            this.id = id;

            //cboRoomId.DataSource = RoomDAO.GetInstance().GetDataTable();
            cboRoomId.DataSource = context.Rooms.ToList<Room>();
            cboRoomId.DisplayMember = "Name";
            cboRoomId.ValueMember = "RoomId";
            
            cboFilmId.DataSource = context.Films.ToList<Film>();
            cboFilmId.DisplayMember = "Title";
            cboFilmId.ValueMember = "FilmId";

            //EDIT
            if(add == 0)
            {
                Show show = context.Shows.Find(id);
                cboRoomId.SelectedValue = show.RoomId;
                dtpShowDate.Value = show.ShowDate??DateTime.Now;

                cboFilmId.SelectedValue = show.FilmId;
                txtPrice.Text = show.Price.ToString();
                
                bool[] slots = new bool[9];
                List<Show> shows = context.Shows
                    .Where(s => s.ShowDate == show.ShowDate
                    && s.RoomId == show.RoomId
                    && s.ShowId != show.ShowId)
                    .ToList<Show>();
                foreach (Show s in shows)
                    slots[(int) s.Slot - 1] = true;
                for (int i = 0; i < slots.Length; i++)
                    if (slots[i] == false) cboSlot.Items.Add(i + 1);
                
                cboSlot.Text = show.Slot.ToString();

            }
            // ADD
            else
            {
                cboRoomId.SelectedValue = id;
                dtpShowDate.Value = DateTime.Now;

                bool[] slots = new bool[9];
                List<Show> shows = context.Shows
                    .Where(s => s.ShowDate == DateTime.Now.Date
                    && s.RoomId == id)
                    .ToList<Show>();
                foreach (Show s in shows)
                    slots[(int)s.Slot - 1] = true;
                for (int i = 0; i < slots.Length; i++)
                    if (slots[i] == false) cboSlot.Items.Add(i + 1);

                cboSlot.SelectedIndex = 0;
            }    


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // EDIT
            if(add == 0)
            {
                try
                {
                    Show show = context.Shows.Find(id);
                    show.RoomId = (int) cboRoomId.SelectedValue;
                    show.ShowDate = dtpShowDate.Value;
                    show.FilmId = (int) cboFilmId.SelectedValue;
                    show.Price = decimal.Parse(txtPrice.Text);
                    show.Slot = int.Parse(cboSlot.Text);
                    context.Shows.Update(show);
                    context.SaveChanges();
                    MessageBox.Show("That show is edited!");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }   
            // ADD
            else
            {
                try
                {
                    Show show = new Show();
                    show.RoomId = (int)cboRoomId.SelectedValue;
                    show.ShowDate = dtpShowDate.Value;
                    show.FilmId = (int)cboFilmId.SelectedValue;
                    show.Price = decimal.Parse(txtPrice.Text);
                    show.Slot = int.Parse(cboSlot.Text);
                    context.Shows.Add(show);
                    context.SaveChanges();
                    MessageBox.Show("That show is added!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }    
        }
    }
}
