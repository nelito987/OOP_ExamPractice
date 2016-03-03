using System;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    class Garage : Estate, IGarage
    {
        private int height;
        private int width;

        public int Height
        {
            get { return this.height; }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("Height of the garage must be in range [0...500]");
                }
                this.height = value;
            }
        }

        public int Width
        {
            get { return this.width; }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("Width of the garage must be in range [0...500]");
                }
                this.width = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendFormat(", Width: {0}, Height: {1}", this.Width, this.Height);
            return output.ToString();
        }
    }
}
