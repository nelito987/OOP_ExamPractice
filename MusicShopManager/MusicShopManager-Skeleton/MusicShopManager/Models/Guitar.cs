
using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Guitar: Instrument, IGuitar
    {
        private const int DefaultNumberOfStrings = 6;

        private string bodyWood;
        private string fingerboardWood;

        protected Guitar(
            string make, 
            string model, 
            decimal price, 
            string color, 
            string bodyWood, 
            string fingerBoardWood) 
            : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerBoardWood;
            //this.NumberOfStrings = numberOfStrings;
        }

        public string BodyWood
        {
            get { return this.bodyWood; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, String.Format(ErrorMessage.StringCannotBeNullOrEmpty, "Guitar bodywood"));
                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fingerboardWood; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, String.Format(ErrorMessage.StringCannotBeNullOrEmpty, "Fingerborad wood"));
                this.fingerboardWood = value;
            }
        }

        public virtual int NumberOfStrings
        {
            get { return DefaultNumberOfStrings; }
        }

        public override string ToString()
        {
            //var output = new StringBuilder(base.ToString());
            //output.AppendLine("Strings: " + this.NumberOfStrings);
            //output.AppendLine("Body wood: " + this.BodyWood);
            //output.Append("Fingerboard wood: " + this.FingerboardWood);
            //return output.ToString();

            var guitar = new StringBuilder();
            guitar
                .Append(base.ToString())
                .AppendFormat("Strings: {0}", this.NumberOfStrings)
                .AppendLine()
                .AppendFormat("Body wood: {0}", this.BodyWood)
                .AppendLine()
                .AppendFormat("Fingerboard wood: {0}", this.FingerboardWood)
                .AppendLine();
            return guitar.ToString();
        }
    }
}
