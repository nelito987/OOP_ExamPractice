using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category: ICategory
    {
        private const int MinLenghtName = 2;
        private const int MaxLenghtName = 15;
        private readonly IList<IProduct> products; // = new List<Product>();
        private string name;

        public Category(string name)
        {
            this.products = new List<IProduct>();
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Category name"));
                Validator.CheckIfStringLengthIsValid(value, MaxLenghtName, MinLenghtName,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinLenghtName, MaxLenghtName));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!products.Contains(cosmetics))
            {
                throw new InvalidOperationException(
                    string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }

            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} category - {1} product{2} in total", this.Name, this.products.Count,
                this.products.Count == 1 ? "" : "s").AppendLine();

            if (this.products.Count > 0)
            {
                var sortedCategory = this.products
                    .OrderBy(x => x.Brand)
                    .ThenByDescending(x => x.Price);

                foreach (var product in sortedCategory)
                {
                    output.AppendLine(product.Print());
                }
            }

            return output.ToString();
        }
    }
}

//namespace Cosmetics.Products
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//
//    using Cosmetics.Common;
//    using Cosmetics.Contracts;
//
//    internal class Category : ICategory
//    {
//        private const int MinNameLenght = 2;
//
//        private const int MaxNameLenght = 15;
//
//        private const string CategoryName = "Category name";
//
//        private readonly IList<IProduct> products;
//
//        private string name;
//
//        public Category(string name)
//        {
//            this.Name = name;
//            this.products = new List<IProduct>();
//        }
//
//        public string Name
//        {
//            get
//            {
//                return this.name;
//            }
//
//            private set
//            {
//                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, CategoryName));
//                Validator.CheckIfStringLengthIsValid(
//                    value,
//                    MaxNameLenght,
//                    MinNameLenght,
//                    string.Format(GlobalErrorMessages.InvalidStringLength, CategoryName, MinNameLenght, MaxNameLenght));
//
//                this.name = value;
//            }
//        }
//
//        public void AddCosmetics(IProduct cosmetics)
//        {
//            this.products.Add(cosmetics);
//        }
//
//        public void RemoveCosmetics(IProduct cosmetics)
//        {
//            if (!this.products.Contains(cosmetics))
//            {
//                throw new ArgumentException(
//                    string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
//            }
//
//            this.products.Remove(cosmetics);
//        }
//
//        public string Print()
//        {
//            ////{category name} category – {number of products} products/product in total
//            var sb = new StringBuilder();
//            sb.AppendFormat(
//                "{0} category - {1} product{2} in total",
//                this.Name,
//                this.products.Count,
//                this.products.Count == 1 ? string.Empty : "s");
//            if (this.products.Count > 0)
//            {
//                sb.AppendLine()
//                    .Append(
//                        string.Join(
//                            Environment.NewLine,
//                            this.products.OrderBy(p => p.Brand).ThenByDescending(p => p.Price).Select(p => p.Print())));
//            }
//
//            return sb.ToString();
//        }
//    }
//}