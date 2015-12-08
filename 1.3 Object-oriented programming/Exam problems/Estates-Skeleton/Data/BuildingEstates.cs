using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class BuildingEstates : Estate, IBuildingEstate
    {
        protected BuildingEstates(
            EstateType type,
            string name,
            double area, 
            string location, 
            bool isFurnished,
            int rooms,
            bool hasElevator)
            : base(type, name, area, location, isFurnished)
        {
            this.HasElevator = hasElevator;
            this.Rooms = rooms;
        }

        protected BuildingEstates(EstateType type)
            : base(type)
        {
        }

        public int Rooms { get; set; }
        public bool HasElevator { get; set; }

        public override string ToString()
        {
            string elevator = this.HasElevator ? "Yes" : "No";
            return base.ToString() + $", Rooms: {this.Rooms}, Elevator: {elevator}";
        }
    }
}
