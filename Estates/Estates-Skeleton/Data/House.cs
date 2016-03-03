using System;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class House : Estate, IHouse
    {
        private int floors;

        public int Floors
        {
            get { return this.floors; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Floors must be in range [0...10]");
                }
                this.floors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendFormat(", Floors: {0}", this.Floors);
            return output.ToString();
        }
    }
}
