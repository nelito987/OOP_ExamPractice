

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Restaurant: IRestaurant
    {
        private string name;
        private string location;
        //private IList<IRecipe> Recipes = new List<IRecipe>();

        public Restaurant(string name, string location)
        {
            this.name = name;
            this.location = location;
            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                    ErrorMessages.IsRequired, "The restaurant name "));

                this.name = value;
            }
        }

        public string Location
        {
            get { return this.location; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                    ErrorMessages.IsRequired, "The restaurant location "));

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes { get; private set; }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("***** {0} - {1} *****", this.Name, this.Location).AppendLine();
            if (this.Recipes.Count == 0)
            {
                output.Append("No recipes... yet");
                return output.ToString();
            }

            output.AppendFormat(this.GetMenuGroup("Drink", "DRINKS"));
            output.AppendFormat(this.GetMenuGroup("Salad", "SALADS"));
            output.AppendFormat(this.GetMenuGroup("MainCourse", "MAIN COURSES"));
            output.AppendFormat(this.GetMenuGroup("Dessert", "DESSERTS"));
            return output.ToString().TrimEnd();
        }

        
        // EBojilova
        private string GetMenuGroup(string groupName, string title)
        {
            var menuGroup = this.Recipes
                .Where(r => r.GetType().Name == groupName)
                .OrderBy(x => x.Name);

            if (menuGroup.Any())
            {
                var sb = new StringBuilder();
                sb.AppendFormat("~~~~~ {0} ~~~~~", title).AppendLine();
                sb.Append(string.Join(String.Empty, menuGroup.Select(x => x.ToString())));
                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
