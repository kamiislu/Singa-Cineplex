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
    class Cinema
    {
        private string name;
        private int hallNo;
        private int capacity;
        public string Name { get; set; }
        public int HallNo { get; set; }
        public int Capacity { get; set; }
        public Cinema() { }
        public Cinema(string n, int hall, int cap)
        {
            Name = n;
            HallNo = hall;
            Capacity = cap;
        }
        public override string ToString()
        {
            return "Name: " + Name + "\tHall Number: " + HallNo + "\tCapacity: " + Capacity;
        }

    }
}
