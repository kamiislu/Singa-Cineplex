using System;

namespace SingaCineplex
{
    class Adult : Ticket
    {
        public bool PopcornOffer { get; set; }

        public Adult() : base() { }
        public Adult(Screening screen, bool p)
        {
            Screening = screen;
            PopcornOffer = p;
        }

        public override double CalculatePrice()
        {
            if (Screening.ScreeningType == "3D")
            {
                if (Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Monday ||
                Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Tuesday ||
                Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Wednesday ||
                Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Thursday)
                {
                    double price = 11;
                    return price;
                }
                else
                {
                    double price = 14;
                    return price;
                }
            }
            else
            {
                if (Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Monday ||
                Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Tuesday ||
                Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Wednesday ||
                Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Thursday)
                {
                    double price = 8.5;
                    return price;
                }
                else
                {
                    double price = 12.5;
                    return price;
                }
            }
        }
        public override string ToString()
        {
            if (PopcornOffer == true)   
            {
                return "Poprcorn offer included";
            }
            else
            {
                return "Popcorn order not included";
            }
        }
    }
}
