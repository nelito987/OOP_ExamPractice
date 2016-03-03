using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures = new List<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Company name cannot be null or empty");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentException("Company name lenght cannot be less than 5");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            set
            {
                string pattern = @"\d{10}";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Registration number must be 10 digits extactly.");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures);}
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            IFurniture result = this.Furnitures
                .FirstOrDefault(f => f.Model.ToLower() == model.ToLower());

            return result;
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();
            catalog.AppendFormat("{0} - {1} - {2} {3}",
                this.Name, 
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count > 0)
            {
                var sortedFurnitures =
                    this.Furnitures
                    .OrderBy(x => x.Price)
                    .ThenBy(y => y.Model);
                //vdonchev
                //.ToList()
                //  .ForEach(f => catalog.Append($"{Environment.NewLine}{f}"));
                
                //var sortedFurnitures =
                //   from f in this.Furnitures
                //   orderby f.Price ascending, f.Model ascending
                //   select f;
                
                foreach (var furniture in sortedFurnitures)
                {
                    catalog.AppendFormat("\n" + furniture);
                }
            }

            return catalog.ToString();
        }
    }
}
