using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double sideA, double sideB) 
            : base(sideA, sideB)
        {
        }

        public override double CalculateArea()
        {
            return this.SideA * this.SideB;
        }

        public override double CalculatePerimeter()
        {
            return this.SideA * 2 + this.SideB * 2;
        }
    }
}
