using System;
using System.Collections.Generic;

#nullable disable

namespace SE1607_Win.Models
{
    public partial class Show
    {
        public Show()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ShowId { get; set; }
        public int RoomId { get; set; }
        public int FilmId { get; set; }
        public DateTime? ShowDate { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public int? Slot { get; set; }

        public virtual Film Film { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
