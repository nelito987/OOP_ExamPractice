using System;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer(OfferType offertype)
            : base(offertype)
        {
            //this.PricePerMonth = pricePerMonth;
        }

        public decimal PricePerMonth
        {
            get { return this.pricePerMonth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Rent price cannot be negative");
                }
                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            StringBuilder rentOffer = new StringBuilder(base.ToString());
            rentOffer.Append(", Price = " + this.PricePerMonth);
            return rentOffer.ToString();
        }
    }
}
