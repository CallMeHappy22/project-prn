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
    public partial class BookingGUI : Form
    {
        public int RoomID { get; set; }
        public int ShowID { get; set; }

        private CinemaContext cinemaContext;

        public BookingGUI(int roomID, int showID)
        {
            RoomID = roomID;
            ShowID = showID;
            cinemaContext = new CinemaContext();

            InitializeComponent();
            initBokkingPanel();
            bindGrid();
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

            string seatStatus = getSeatStatus(ShowID);
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

        private void bindGrid()
        {
            dataGridView1.Columns.Clear();

            cinemaContext = new CinemaContext();
            List<Booking> listBooking = cinemaContext.Bookings.ToList().Where(b => b.ShowId == ShowID).ToList();
            dataGridView1.DataSource = listBooking;

            labCount.Text = "Number of bookings: " + listBooking.Count;

            int count = dataGridView1.Columns.Count;

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Details",
                Text = "Details",
                UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Insert(count, btnEdit);
            count = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(count, btnDelete);

            dataGridView1.Columns["BookingID"].Visible = false;
            dataGridView1.Columns["ShowID"].Visible = false;
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateBookingGUI f = new CreateBookingGUI(RoomID, ShowID);
            DialogResult dr = f.ShowDialog();

            if (dr == DialogResult.OK)
            {
                bindGrid();
                initBokkingPanel();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["Details"] != null && e.ColumnIndex == dataGridView1.Columns["Details"].Index && e.RowIndex >= 0)
            {
                BookingDetailsGUI f = new BookingDetailsGUI(RoomID, ShowID, new Booking()
                {
                    Name = dataGridView1[dataGridView1.Columns["Name"].Index, e.RowIndex].Value.ToString(),
                    SeatStatus = dataGridView1[dataGridView1.Columns["SeatStatus"].Index, e.RowIndex].Value.ToString().Trim(),
                    Amount = decimal.Parse(dataGridView1[dataGridView1.Columns["Amount"].Index, e.RowIndex].Value.ToString())
                });
                DialogResult dr = f.ShowDialog();
            }

            if (dataGridView1.Columns["Delete"] != null && e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int bookingID = (int)dataGridView1.Rows[e.RowIndex].Cells["BookingID"].Value;

                DialogResult dr = MessageBox.Show("Do you sure to delete ?", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    cinemaContext.Bookings.Remove(cinemaContext.Bookings.Find(bookingID));
                    cinemaContext.SaveChanges();
                    bindGrid();
                    initBokkingPanel();
                }
            }
        }
    }
}
