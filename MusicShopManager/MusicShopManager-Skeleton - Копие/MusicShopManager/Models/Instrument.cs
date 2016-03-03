
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Instrument: Article, IInstrument
    {
        private string color;
        //protected bool isElectronic = false;

        protected Instrument(string make, string model, decimal price, string color) 
            : base(make, model, price)
        {
            this.Color = color;
            //this.IsElectronic = isElectronic;
        }

        public string Color
        {
            get { return this.color; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(ErrorMessage.StringCannotBeNullOrEmpty, "Instrument color"));
                this.color = value;
            }
        }

        public virtual bool IsElectronic { get; private set; }

        public override string ToString()
        {
            //var output = new StringBuilder();
            //output.AppendFormat("= {0} {1} =", this.Make, this.Model).AppendLine();
            //output.AppendFormat("Price: ${0:F2}", this.Price).AppendLine();
            //output.AppendLine("Color: " + this.Color);
            //output.AppendFormat("Electronic: {0}", this.IsElectronic ? "yes" : "no").AppendLine();
            //
            //return output.ToString();

            var instrument = new StringBuilder();
            instrument
                .Append(base.ToString())
                .AppendFormat("Color: {0}", this.Color)
                .AppendLine()
                .AppendFormat("Electronic: {0}", this.IsElectronic ? "yes" : "no")
                .AppendLine();
            return instrument.ToString();
        }
    }
}
