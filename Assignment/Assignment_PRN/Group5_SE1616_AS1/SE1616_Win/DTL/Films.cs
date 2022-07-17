using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1616_Win.DTL
{
    internal class Films
    {
        public int FilmID { get; set; }
        public int GenreID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string CountryCode { get; set; }

        public Films(int filmID, int genreID, string title, string year, string countryCode)
        {
            FilmID = filmID;
            GenreID = genreID;
            Title = title;
            Year = year;
            CountryCode = countryCode;
        }

        public Films( string title, int filmID)
        {
            FilmID = filmID;
            Title = title;
        }

        public Films()
        {
        }
    }
}
