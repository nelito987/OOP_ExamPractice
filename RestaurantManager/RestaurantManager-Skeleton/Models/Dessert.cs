
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Dessert : Meal, IDessert
    {
        public Dessert(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            //MetricUnit unit, 
            int timeToPrepare, 
            bool isVegan)
            //bool withSugar) 
            : base(name, price, calories, quantityPerServing,  
                  timeToPrepare, isVegan)
        {
            this.WithSugar = true;
        }

        public bool WithSugar { get; private set; }
        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            //var sugar = WithSugar ? "Yes" : "No";
            //var sb = new StringBuilder();
            //if (!this.WithSugar)
            //{
            //    sb.Append("[NO SUGAR] ");
            //}
            //sb.AppendLine(base.ToString());
            //
            //return sb.ToString().TrimEnd();

            if (this.WithSugar)
            {
                return base.ToString();
            }

            var sb = new StringBuilder();
            sb.Append("[NO SUGAR] ");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
