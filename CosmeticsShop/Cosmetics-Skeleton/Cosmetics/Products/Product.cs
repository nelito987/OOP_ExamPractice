
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private const int MinNameLenght = 3;
        private const int MaxNameLenght = 10;
        private const string CategoryName = "Product name";
        private const int MinBrandLenght = 2;
        private const int MaxBrandLenght = 10;
        private const string BrandName = "Product brand";

        private string name;
        private string brand;
        private decimal price;
        private GenderType genderType;

        protected Product(string name, string brand, 
            decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, CategoryName));
                Validator.CheckIfStringLengthIsValid(value, MaxNameLenght, MinNameLenght, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, CategoryName, MinNameLenght, MaxNameLenght));

                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, BrandName));
                Validator.CheckIfStringLengthIsValid(value, MaxBrandLenght, MinBrandLenght, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, BrandName, MinBrandLenght, MaxBrandLenght));

                this.brand = value;
            }
        }
        public virtual decimal Price { get; }
        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("- {0} - {1}:", this.Brand, this.Name).AppendLine();
            output.AppendFormat("  * Price: ${0:F2}", this.Price).AppendLine();
            output.AppendFormat("  * For gender: {0}", this.Gender);

            return output.ToString();
        }
    }
}
