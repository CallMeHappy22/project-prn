using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SE1616_Group5_Ass3.Models
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
        [Range(0, 999.999)]
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public int? Slot { get; set; }

        public virtual Film Film { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
