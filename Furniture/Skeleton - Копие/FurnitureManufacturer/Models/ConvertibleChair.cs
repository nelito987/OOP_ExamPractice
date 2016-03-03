using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private decimal initialHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.isConverted = false;
            //this.initialHeight = height;
        }

        public bool IsConverted
        {
            get { return this.isConverted; }
        }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.initialHeight = this.Height;
                this.Height = 0.10m;
            }
            else
            {
                this.Height = this.initialHeight;
            }

            this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            StringBuilder convertibleChair = new StringBuilder(base.ToString());
            convertibleChair.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");

            return convertibleChair.ToString();
        }
    }
}
