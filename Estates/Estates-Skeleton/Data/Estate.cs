using System;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Estate : IEstate
    {
        private string name;
        //private EstateType type;
        private double area;
        private string location;
        //private bool isFurnished;

        //protected Estate(string name, EstateType type, double area, string location, bool isFurnished)
        //{
        //    this.Name = name;
        //    this.Type = type;
        //    this.Area = area;
        //    this.Location = location;
        //    this.IsFurnished = isFurnished;
        //}

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Estate name cannot be null or empty!");
                }

                this.name = value;
            }
        }
        public EstateType Type { get; set; }

        public double Area
        {
            get { return this.area; }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("Area must be in range [0...10000");
                }
                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Location cannot be null or empty!");
                }

                this.location = value;
            }
        }
        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}", this.GetType().Name, this.Name,
                this.Area, this.Location, this.IsFurnished ? "Yes" : "No");

            return output.ToString();
        }
    }
}
