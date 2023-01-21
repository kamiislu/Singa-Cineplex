using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingaCineplex
{
    class Order
    {
        private int orderNo;
        public int OrderNo { get; set; }
        private DateTime orderDateTime;
        public DateTime OrderDateTime { get; set; }
        private double amount;
        public double Amount { get; set; }
        private string status;
        public string Status { get; set; }
        private List<Ticket> ticketList;
        public List<Ticket> TicketList { get; set; }
        

        public Order() { }
        public Order(int n, DateTime d)
        {
            orderNo = n;
            orderDateTime = d;
        }
        public void AddTicket (Ticket t)
        {
            ticketList.Add(t);
        }
        public override string ToString()
        {
            return "Order No: " + OrderNo + " Order Date and Time: " + OrderDateTime + " Amount: " + Amount
                + " Status: " + Status;
        }
    }
}
