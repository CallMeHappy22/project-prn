using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1616_Win.DTL
{
    internal class Show
    {
        public int ShowID { get; set; }
        public int RoomID { get; set; }
        public int FilmID { get; set; }
        public DateTime ShowDate { get; set; }
        public bool Status { get; set; }
        public int Slot { get; set; }
        public decimal Price { get; set; }

        

        public Show()
        {
        }

        public Show(int showId, int roomId, int filmId, DateTime showDate, bool status, int slot, decimal price)
        {
            ShowID = showId;
            RoomID = roomId;
            FilmID = filmId;
            ShowDate = showDate;
            Status = status;
            Slot = slot;
            Price = price;
        }  
        

    }
}
