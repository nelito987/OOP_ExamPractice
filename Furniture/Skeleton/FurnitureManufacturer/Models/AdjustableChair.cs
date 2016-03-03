using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal heightToSet)
        {
            if (heightToSet <= 0)
            {
                throw new AggregateException("Height cannot be zero or negative");
            }
            this.Height = heightToSet;
        }
    }
}
