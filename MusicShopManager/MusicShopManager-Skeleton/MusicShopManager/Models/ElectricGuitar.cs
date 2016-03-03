
using System;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class ElectricGuitar: Guitar, IElectricGuitar
    {
        private int numberOFAdapters;
        private int numberOfFrets;
        //private const bool ElGuitarIsElectirc = true;

        public ElectricGuitar(
            string make, 
            string model, 
            decimal price, 
            string color, 
            string bodyWood, 
            string fingerBoardWood,
            int numberOfAdapters,
            int numberOfFrets) 
            : base(make, model, price, color, bodyWood, fingerBoardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
            //this.IsElectronic = ElGuitarIsElectirc;
        }

        public int NumberOfAdapters
        {
            get { return this.numberOFAdapters; }
            set
            {
                Validator.CheckIfNegative(value, string.Format(ErrorMessage.MustBeNonNegative, "Number of adapters"));
                this.numberOFAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this.numberOfFrets; }
            set
            {
                Validator.CheckIfPositive(value, String.Format(ErrorMessage.MustBePositive, "Number of frets"));
                this.numberOfFrets = value;
            }
        }

        public override bool IsElectronic
        {
            get { return true; }
        }


        public override string ToString()
        {
            //var output = new StringBuilder(base.ToString());
            //output.AppendLine("Adapters: " + this.numberOFAdapters);
            //output.Append("Frets: " + this.NumberOfFrets);
            //return output.ToString();

            var electricGuitar = new StringBuilder();
            electricGuitar
                .Append(base.ToString())
                .AppendFormat("Adapters: {0}", this.NumberOfAdapters).AppendLine()
                .AppendFormat("Frets: {0}", this.NumberOfFrets).AppendLine();
            return electricGuitar.ToString();
        }
    }
}
