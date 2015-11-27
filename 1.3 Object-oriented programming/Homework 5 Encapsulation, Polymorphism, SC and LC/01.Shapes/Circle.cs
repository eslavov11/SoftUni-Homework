using _01.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public double CalculateArea()
        {
            var area = Math.PI * this.Radius * this.Radius;
            return area;
        }

        public double CalculatePerimeter()
        {
            var perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }
    }
}
