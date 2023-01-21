using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingaCineplex
{
    class Screening
    {
        private int screeningNo;
        private DateTime screeningDateTime;
        private string screeningType;
        private int seatsRemaining;
        private Cinema cinema;
        private Movie movie;
        public int ScreeningNo { get; set; }
        public DateTime ScreeningDateTime { get; set; }
        public string ScreeningType { get; set; }
        public int SeatsRemaining { get; set; }
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }
        public Screening() { }
        public Screening(int sNo, DateTime sDT, string sT, Cinema c, Movie m) 
        {
            ScreeningNo = sNo;
            ScreeningDateTime = sDT;
            screeningType = sT;
            Cinema = c;
            Movie = m;
        }
        public override string ToString()
        {
            return "Screening Number: " + ScreeningNo + "\tDate and time of Screening: " + ScreeningDateTime + "\tType of Screening: " + screeningType +
                "\tCinema: " + Cinema + "\tMovie: " + Movie;
        }

    }
}
