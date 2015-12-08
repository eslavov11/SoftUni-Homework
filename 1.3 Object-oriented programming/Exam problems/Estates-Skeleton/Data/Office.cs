using Estates.Interfaces;

namespace Estates.Data
{
    public class Office : BuildingEstates, IOffice
    {
        public Office(
            EstateType type, 
            string name,
            double area,
            string location,
            bool isFurnished,
            int rooms,
            bool hasElevator)
            : base(type, name, area, location, isFurnished, rooms, hasElevator)
        {
        }

        public Office(
            EstateType type)
            : base(type)
        {
        }
    }
}
