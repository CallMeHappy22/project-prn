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
    public partial class BookingDetailsGUI : Form
    {
        public int RoomID { get; set; }
        public int ShowID { get; set; }

        public Booking Booking { get; set; }

        private CinemaContext cinemaContext;
        public BookingDetailsGUI(int roomID, int showID, Booking booking)
        {
            RoomID = roomID;
            ShowID = showID;
            Booking = booking;
            cinemaContext = new CinemaContext();
            InitializeComponent();
            initBokkingPanel();

            txtName.Text = Booking.Name;
            txtAmount.Text = Booking.Amount.ToString();
        }

        private void initBokkingPanel()
        {
            panel1.Enabled = false;
            panel1.Controls.Clear();

            cinemaContext = new CinemaContext();
            Room room = cinemaContext.Rooms.Find(RoomID);

            int height = room.NumberRows.Value;
            int width = room.NumberCols.Value;

            int startButtonPoint = (panel1.Width - width * 20) / 2;

            string seatStatus = Booking.SeatStatus;
            int indexSeatStatus = 0;
            for (int i = 0; i < width; i++)
            {
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
                    }

                    indexSeatStatus++;

                    panel1.Controls.Add(checkbox);
                }
            }
        }
    }
}
