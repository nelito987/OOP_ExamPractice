
using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Drum: Instrument, IDrums
    {
        private int width;
        private int height;

        public Drum(string make, string model, decimal price, string color, int width, int height) 
            : base(make, model, price, color)
        {
            this.Width = width;
            this.Height = height;
            //this.IsElectronic = false;

        }

        public int Width
        {
            get { return this.width; }
            set
            {
                Validator.CheckIfPositive(value, String.Format(ErrorMessage.MustBePositive, "Drum width"));
                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                Validator.CheckIfPositive(value, String.Format(ErrorMessage.MustBePositive, "Drum heigth"));
                this.height = value;
            }
        }
        //public override bool IsElectronic { get; }

        public override string ToString()
        {
            //var output = new StringBuilder(base.ToString());
            //output.AppendFormat("Size: {0}cm x {1}cm", this.Width, this.Height);
            //return output.ToString();

            var drums = new StringBuilder();
            drums
                .Append(base.ToString())
                .AppendFormat("Size: {0}cm x {1}cm", this.Width, this.Height)
                .AppendLine();
            return drums.ToString();
        }
    }
}
