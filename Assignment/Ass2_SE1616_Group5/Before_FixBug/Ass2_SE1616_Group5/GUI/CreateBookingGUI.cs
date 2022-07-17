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
    public partial class CreateBookingGUI : Form
    {
        private List<List<CheckBox>> listSeat;

        public int ShowID { get; set; }
        public int RoomID { get; set; }
        public decimal ShowPrice { get; set; }

        private CinemaContext cinemaContext;
        public CreateBookingGUI(int roomID, int showID)
        {
            InitializeComponent();
            cinemaContext = new CinemaContext();
            ShowID = showID;
            RoomID = roomID;

            ShowPrice = cinemaContext.Shows.Find(showID).Price.Value;
            initBokkingPanel();
        }

        private void initBokkingPanel()
        {
            listSeat = new List<List<CheckBox>>();


            Room room = cinemaContext.Rooms.Find(RoomID);

            int height = room.NumberRows.Value;
            int width = room.NumberCols.Value;

            int startButtonPoint = (panel1.Width - width * 20) / 2;

            string seatStatus = getSeatStatus(ShowID);
            int indexSeatStatus = 0;
            for (int i = 0; i < width; i++)
            {
                listSeat.Add(new List<CheckBox>());

                for (int j = 0; j < height; j++)
                {
                    CheckBox checkbox = new CheckBox()
                    {
                        Width = 20,
                        Height = 20,
                        Location = new Point(i * 20 + startButtonPoint, j * 20)
                    };

                    if (seatStatus.Length > 0 && seatStatus[indexSeatStatus] == 49)
                    {
                        checkbox.Checked = true;
                        checkbox.Enabled = false;
                    }
                    indexSeatStatus++;

                    checkbox.CheckedChanged += Checkbox_CheckedChanged;

                    listSeat[i].Add(checkbox);
                    panel1.Controls.Add(checkbox);
                }
            }
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked && ((CheckBox)sender).Enabled) txtAmount.Text = (decimal.Parse(txtAmount.Text) + ShowPrice).ToString();
            if (!((CheckBox)sender).Checked && ((CheckBox)sender).Enabled) txtAmount.Text = (decimal.Parse(txtAmount.Text) - ShowPrice).ToString();
        }

        private string getSeatStatus(int showID)
        {
            List<Booking> listBooking = cinemaContext.Bookings.ToList().Where(b => b.ShowId == showID).ToList();
            string result = "";

            if (listBooking.Count <= 0) return result;

            for (int i = 0; i < listBooking[0].SeatStatus.Length; i++)
            {
                bool check = false;
                foreach (Booking book in listBooking)
                {
                    char c = book.SeatStatus[i];
                    if (c == 49)
                    {
                        check = true;
                    }
                }

                if (check) result += "1"; else result += "0";
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            string seatStatus = "";

            foreach (List<CheckBox> listCheckBox in listSeat)
            {
                foreach (CheckBox checkbox in listCheckBox)
                {
                    if (checkbox.Checked && checkbox.Enabled == true)
                    {
                        seatStatus += "1";
                    }
                    else
                    {
                        seatStatus += "0";
                    }
                }
            }

            if (seatStatus.IndexOf("1") < 0)
            {
                MessageBox.Show("Please select at least one seat");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (name.Length == 0)
            {
                MessageBox.Show("Please enter your name");
                this.DialogResult = DialogResult.None;
                return;
            }

            Booking booking = new Booking()
            {
                ShowId = ShowID,
                Name = name,
                SeatStatus = seatStatus,
                Amount = amount
            };

            cinemaContext.Bookings.Add(booking);
            cinemaContext.SaveChanges();
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (decimal.Parse(txtAmount.Text) < 0) { txtAmount.Text = "0"; };
            }
            catch (Exception)
            {
                txtAmount.Text = "0";
            }
        }
    }
}
