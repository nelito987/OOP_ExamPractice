
using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste: Product, IToothpaste
    {
        private const int IngredientNameMinLenght = 4;
        private const int IngredientNameMaxLenght = 12;
        private readonly IList<string> ingredients;
        //private string ingredients;

        public Toothpaste(string name, string brand, decimal price, 
            GenderType gender, IList<string> ingredients) 
            : base(name, brand, price, gender)
        {
            this.ValidateIngredients(ingredients);
            this.ingredients = ingredients;
        }


        public string Ingredients
        {
            get { return string.Join(", ", this.ingredients); }
        }

        private void ValidateIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfNull(ingredient, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ingredient));
                Validator.CheckIfStringLengthIsValid(ingredient, IngredientNameMaxLenght, IngredientNameMinLenght,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", IngredientNameMinLenght, IngredientNameMaxLenght ));
            }
        }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendFormat("  * Ingredients: {0}", this.Ingredients);
            return sb.ToString();
        }
    }
}
