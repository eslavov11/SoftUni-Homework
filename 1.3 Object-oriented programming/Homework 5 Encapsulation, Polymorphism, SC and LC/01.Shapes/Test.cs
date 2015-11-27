using _01.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Test
    {
        static void Main(string[] args)
        {
            IShape[] shapes = new IShape[]
            {
                new Rectangle(5.4, 5),
                new Circle(5),
                new Rhombus(4),
                new Rectangle(2, 5)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name);
                Console.WriteLine("Area: " + shape.CalculateArea());
                Console.WriteLine("Perimeter: " + shape.CalculatePerimeter());
                Console.WriteLine();
            }
        }
    }
}
