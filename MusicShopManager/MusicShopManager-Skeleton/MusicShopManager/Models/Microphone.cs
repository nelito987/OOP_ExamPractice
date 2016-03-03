
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Microphone : Article, IMicrophone
    {
        
        public Microphone(string make, string model, decimal price, bool hasCable) 
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; set; }

        public override string ToString()
        {
            //var output = new StringBuilder();
            //output.AppendFormat("= {0} {1} =", this.Make, this.Model).AppendLine();
            //output.AppendFormat("Price: ${0:F2}",this.Price).AppendLine();
            //output.AppendFormat("Cable: {0}", this.HasCable ? "yes" : "no");
            //
            //return output.ToString();

            var microphone = new StringBuilder();
            microphone
                .Append(base.ToString())
                .AppendFormat("Cable: {0}", this.HasCable ? "yes" : "no")
                .AppendLine();
            return microphone.ToString();
        }
    }
}
