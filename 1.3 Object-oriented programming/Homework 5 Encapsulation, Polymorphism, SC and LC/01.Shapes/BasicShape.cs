using _01.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public abstract class BasicShape : IShape
    {
        public BasicShape(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        public double SideA { get; private set; }

        public double SideB { get; private set; }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}
