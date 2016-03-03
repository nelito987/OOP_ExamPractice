using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    class SaleOffer : Offer, ISaleOffer
    {
        private decimal price;

        public SaleOffer(OfferType offertype)
            : base(offertype)
        {
            this.Price = price;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Sell price must be positive number");
                }

                this.price = value;
            }
        }


        public override string ToString()
        {
            StringBuilder saleOffer = new StringBuilder(base.ToString());
            saleOffer.Append(", Price = " + this.Price);
            return saleOffer.ToString();
        }
    }
}
