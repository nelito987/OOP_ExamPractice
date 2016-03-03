using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Offer : IOffer
    {
        protected Offer(OfferType offertype)
        {
            this.Type = offertype;
        }

        public OfferType Type { get; set; }
        public IEstate Estate { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}: Estate = {1}, Location = {2}",
                this.Type, this.Estate.Name, this.Estate.Location);
            return output.ToString();
        }
    }
}
