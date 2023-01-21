using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingaCineplex
{
    class SeniorCitizen:Ticket
    {
        public int YearOfBirth { get; set; }

        public SeniorCitizen() : base() { }
        public SeniorCitizen(Screening screen, int y):base()
        {
            YearOfBirth = y;
            Screening = screen;
        }
        public override double CalculatePrice()
        {
            if ((Screening.ScreeningDateTime - Screening.Movie.OpeningDate).Days <= 7)
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
            else
            {
                if (Screening.ScreeningType == "3D")
                {
                    if (Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Monday ||
                    Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Tuesday ||
                    Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Wednesday ||
                    Screening.ScreeningDateTime.DayOfWeek == DayOfWeek.Thursday)
                    {
                        double price = 8;
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
                        double price = 7;
                        return price;
                    }
                    else
                    {
                        double price = 12.5;
                        return price;
                    }
                }
            }
        }
        public override string ToString()
        {
            return "Year of birth: " + YearOfBirth;
        }
    }
}
