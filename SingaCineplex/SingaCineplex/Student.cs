using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingaCineplex
{
    class Student:Ticket
    {
        public string LevelOfStudy { get; set; }

        public Student() : base() { }
        public Student(Screening screen, string l):base()
        {
            LevelOfStudy = l;
            Screening = screen;
        }
        public override double CalculatePrice()
        {
            if((Screening.ScreeningDateTime - Screening.Movie.OpeningDate).Days <= 7)
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
                if(Screening.ScreeningType == "3D")
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

    }
}
