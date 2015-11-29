using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GalacticGPS
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
        : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }

            set
            {
                if (value < 0 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude should be in range [0..90] degrees!");
                }
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }

            set
            {
                if (value < 0 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude should be in range [0..180] degrees!");
                }
                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get
            {
                return this.planet;
            }

            set
            {
                this.planet = value;
            }
        }

        public override string ToString()
        {
            return 
                String.Format($"Planet: {this.Planet} Latitude: {this.Latitude} deg. Longitude: {this.Longitude} deg.");
        }
    }
}
