
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Meal : Recipe, IMeal
    {
        protected Meal(string name, decimal price, int calories, 
            int quantityPerServing, int timeToPrepare,
            bool isVegan) 
            : base(name, price, calories, quantityPerServing, 
                  MetricUnit.Grams, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; private set; }

        public virtual void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            //var sb = new StringBuilder();
            //
            //if (this.IsVegan == true)
            //{
            //    sb.Append("[VEGAN] ");
            //}
            //
            //sb.Append(base.ToString());
            //return sb.ToString().TrimEnd();
            //
            if (this.IsVegan == false)
            {
                return base.ToString();
            }
            
            var sb = new StringBuilder();
            sb.Append("[VEGAN] ");
            sb.Append(base.ToString());
            return sb.ToString();
        }
    }
}
