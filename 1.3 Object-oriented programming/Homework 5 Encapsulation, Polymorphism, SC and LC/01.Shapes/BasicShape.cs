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
        protected BasicShape(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        protected double SideA { get; private set; }

        protected double SideB { get; private set; }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}
