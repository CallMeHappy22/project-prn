using System;
using System.Collections.Generic;

#nullable disable

namespace Ass2_SE1616_Group5.Models
{
    public partial class Film
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string CountryCode { get; set; }
    }
}
