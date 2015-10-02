using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_Perimeter_and_Area
{
    class CirclePerimeterAndArea
    {
        static void Main(string[] args)
        {
            Console.Write("Radius = ");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("Perimeter: {0}", (2 * r * Math.PI).ToString("#.##"));
            Console.WriteLine("Area: {0}", (r * r * Math.PI).ToString("#.##"));
        }
    }
}
