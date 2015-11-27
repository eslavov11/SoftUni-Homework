using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(double sideA) 
            : base(sideA, sideA)
        {
        }

        public override double CalculateArea()
        {
            return SideA * SideA;
        }

        public override double CalculatePerimeter()
        {
            return SideA * 4;
        }
    }
}
