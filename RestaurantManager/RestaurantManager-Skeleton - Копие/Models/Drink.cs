
using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Drink : Recipe, IDrink
    {
        private const int MaxTimeToPrepare = 20;
        private const int MaxCalories = 100;

        public Drink(string name, decimal price, int calories,
            int quantityPerServing, MetricUnit unit, int timeToPrepare,
            bool isCarbonated) 
            : base(name, price, calories, quantityPerServing, MetricUnit.Milliliters, 
                  timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated { get; }

        public override int Calories
        {
            get { return base.Calories; }
            protected set
            {
                if (value > MaxCalories)
                {
                    throw new ArgumentException("The calories in the drinks must not be greater than 100.");
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get { return base.TimeToPrepare; }
            protected set
            {
                if (value > MaxTimeToPrepare)
                {
                    throw new ArgumentException(string.Format("Time To prepare a drink must not be grater than {0}", MaxTimeToPrepare));
                }

                base.TimeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var Carbonated = this.IsCarbonated ? "yes" : "no";
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendFormat("Carbonated: {0}", Carbonated).AppendLine();
            return output.ToString().TrimEnd();
        }
    }
}
