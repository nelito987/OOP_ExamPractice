using System;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;
        //private bool hasElevator;

        //protected BuildingEstate(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator) 
        //    : base(name, type, area, location, isFurnished)
        //{
        //    this.Rooms = rooms;
        //    this.HasElevator = hasElevator;
        //}

        public int Rooms
        {
            get { return this.rooms; }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Rooms must be in range [0...20]");
                }
                this.rooms = value;
            }
        }
        public bool HasElevator { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendFormat(", Rooms: {0}, Elevator: {1}",
                this.Rooms, this.HasElevator ? "Yes" : "No");

            return output.ToString();
        }
    }
}
