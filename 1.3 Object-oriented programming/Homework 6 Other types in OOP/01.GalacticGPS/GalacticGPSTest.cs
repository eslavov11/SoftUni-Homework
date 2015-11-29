using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GalacticGPS
{
    class GalacticGPSTest
    {
        static void Main(string[] args)
        {
            Location location = new Location(90, 180, Planet.Earth);
            Console.WriteLine(location);
        }
    }
}
