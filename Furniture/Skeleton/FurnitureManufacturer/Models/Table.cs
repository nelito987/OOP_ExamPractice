using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class Table : Furniture, ITable
    {
        public Table(string model, string material, decimal price, decimal height, decimal lenght, decimal width) 
            : base(model, material, price, height)
        {
            this.Length = lenght;
            this.Width = width;
        }

        public decimal Length { get; }
        public decimal Width { get; }

        public decimal Area
        {
            get { return this.Length*this.Width; }
        }

        public override string ToString()
        {
            return base.ToString() + 
                string.Format(", Length: {0}, Width: {1}, Area: {2}",
                this.Length, this.Width, this.Area);
        }
    }
}
