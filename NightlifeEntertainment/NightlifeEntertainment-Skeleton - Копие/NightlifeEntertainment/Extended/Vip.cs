
using System;

namespace NightlifeEntertainment.Extended
{
    public class Vip: Ticket
    {
        private static decimal VipTicketIndex = 1.5M;

        public Vip(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException(
                    "There is no performance for this ticket.");
            }

            decimal price = VipTicketIndex * this.Performance.BasePrice;
            return price;
        }
    }
}
