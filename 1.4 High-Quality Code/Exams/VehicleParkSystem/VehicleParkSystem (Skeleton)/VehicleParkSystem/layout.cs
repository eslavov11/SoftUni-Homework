namespace VehicleParkSystem
{
    using System;

    public class Layout
    {
        public Layout(int numberOfSectors, int placesPerSector)
        {
            if (numberOfSectors <= 0)
            {
                throw new DivideByZeroException("The number of sectors must be positive.");
            }

            this.Sectors = numberOfSectors;

            if (placesPerSector <= 0)
            {
                throw new DivideByZeroException("The number of places per sector must be positive.");
            }

            this.PlacesPerSector = placesPerSector;
        }

        public int Sectors { get; set; }

        public int PlacesPerSector { get; set; }
    }
}