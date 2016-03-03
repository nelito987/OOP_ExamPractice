using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Recipe: IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int qtyPerServing;
        private MetricUnit unit;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, 
            int quantityPerServing, MetricUnit unit, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.Unit = unit;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name 
        { 
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                    ErrorMessages.IsRequired,
                    "Recipe name"));

                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                Validator.CheckIfPositive(
                    value,
                    String.Format(
                    ErrorMessages.MustBePositive,
                    "Price"));

                this.price = value;
            }
        }

        public virtual int Calories
        {
            get { return this.calories; }
            protected set
            {
                Validator.CheckIfPositive(
                    value,
                    String.Format(
                    ErrorMessages.MustBePositive,
                    "Calories"));

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get { return this.qtyPerServing; }
            private set
            {
                Validator.CheckIfPositive(
                    value,
                    String.Format(
                    ErrorMessages.MustBePositive,
                    "quantity per serving"));

                this.qtyPerServing = value;
            }
        }
        public MetricUnit Unit { get; private set; }

        public virtual int TimeToPrepare
        {
            get { return this.timeToPrepare; }
            protected set
            {
                Validator.CheckIfPositive(
                    value,
                    String.Format(
                    ErrorMessages.MustBePositive,
                    "time to prepare"));

                this.timeToPrepare = value;
            }
        }

        //EBojilova
        public override string ToString()
        {
            StringBuilder toPrint = new StringBuilder();
            var measurement = this.Unit == MetricUnit.Grams ? "g" : "ml";
            toPrint.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine();
            toPrint.AppendFormat("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, measurement, this.Calories)
                .AppendLine();
            toPrint.AppendFormat("Ready in {0} minutes", this.TimeToPrepare);
            return toPrint.ToString().Trim();
        }
    }
}
