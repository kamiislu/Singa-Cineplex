using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ====================================================================
// Student Number : S10223421, S10223527
// Student Name : Syahmi Mirhan Bin Zulkiflee, Luismika Lim Chieng Hee
// Module Group : T02
// ====================================================================

namespace SingaCineplex
{
    class Movie
    {
        private string title;
        private int duration;
        private string classification;
        private DateTime openingDate;
        private List<string> genreList;
        private List<Screening> screeningList;
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Classification { get; set; }
        public DateTime OpeningDate { get; set; }
        public List<string> GenreList { get; set; } = new List<string>();
        public List<Screening> ScreeningList { get; set; } = new List<Screening>();
        public Movie() { }
        public Movie(string t, int dur, string c, DateTime opDate, List<string> gList)
        {
            Title = t;
            Duration = dur;
            Classification = c;
            OpeningDate = opDate;
            GenreList = gList;
        }
        public void AddGenre(string g)
        {
            GenreList.Add(g);
        }
        public void AddScreening(Screening s)
        {
            ScreeningList.Add(s);
        }
        public override string ToString()
        {
            return "Title: " + Title + "\tDuration: " + Duration + "\tClassification: " + Classification + "\tOpening Date: "
                + OpeningDate + "\tGenre List: " + GenreList;
        }
    }
}
