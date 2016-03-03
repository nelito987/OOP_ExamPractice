
using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Salad: Meal, ISalad
    {
        public Salad(
            string name,
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            bool containPasta)
            : base(name, price, calories, quantityPerServing,  
                  timeToPrepare, true)
        {
            this.ContainsPasta = containPasta;
        }

        public bool ContainsPasta { get; private set; }

       //public override void ToggleVegan()
       //{
       //    throw new InvalidOperationException("The salad is only vegan!");
       //}

        public override string ToString()
        {
           //var pasta = this.ContainsPasta ? "yes" : "no";
           //var output = new StringBuilder(base.ToString());
           //output.AppendFormat("Contains pasta: {0}", pasta).AppendLine();
           //return output.ToString().TrimEnd();

            var containsPasta = this.ContainsPasta ? "yes" : "no";
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Contains pasta: {0}", containsPasta).AppendLine();
            return sb.ToString();
        }
    }
}
