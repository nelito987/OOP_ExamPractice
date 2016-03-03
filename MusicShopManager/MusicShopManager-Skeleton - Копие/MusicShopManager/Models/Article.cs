using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Article :IArticle
    {
        private string make;
        private string model;
        private decimal price;

        protected Article(string make, string model, decimal price)
        {
            this.make = make;
            this.model = model;
            this.price = price;
        }

        public string Make
        {
            get { return this.make; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(ErrorMessage.StringCannotBeNullOrEmpty, "Article name"));
                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(ErrorMessage.StringCannotBeNullOrEmpty, "Article model"));
                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                Validator.CheckIfPositive(value, string.Format(ErrorMessage.MustBePositive, "Article price"));
                this.price = value;
            }
        }

        public override string ToString()
        {
            var article = new StringBuilder();
            article.AppendFormat("= {0} {1} =", this.Make, this.Model)
                .AppendLine()
                .AppendFormat("Price: ${0:F2}", this.Price)
                .AppendLine();
            return article.ToString();
        }
    }
}
