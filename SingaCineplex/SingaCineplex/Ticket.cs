using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingaCineplex
{
    abstract class Ticket
    {
        public Screening Screening;

        public Ticket() { }
        public Ticket(Screening screen)
        {
            Screening = screen;
        }
        public abstract double CalculatePrice();
        public override string ToString()
        {
            return "screen" + Screening;
        }
    }
}
