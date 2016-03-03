
using System;

namespace NightlifeEntertainment.Extended
{
    public class StudentTicket : Ticket
    {
        private static decimal studentTicketIndex = 0.8M;
        public StudentTicket(IPerformance performance) 
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException(
                    "There is no performance for this ticket.");
            }

            decimal price = studentTicketIndex*this.Performance.BasePrice;
            return price;
        }
    }
}
