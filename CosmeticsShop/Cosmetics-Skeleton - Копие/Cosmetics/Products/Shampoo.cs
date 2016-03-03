
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;
        //private UsageType usage;

        public Shampoo(string name, string brand, decimal price, 
            GenderType gender, uint milliliters, UsageType usage) 
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                this.milliliters = value;
            }
        }

        public UsageType Usage { get; private set; }

        public override decimal Price
        {
            get { return base.Price*this.Milliliters; }
        }

        public override string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.Print());
            output.AppendFormat("  * Quantity: {0} ml", this.Milliliters).AppendLine();
            output.AppendFormat("  * Usage: {0}", this.Usage);

            return output.ToString();
        }
    }
}
