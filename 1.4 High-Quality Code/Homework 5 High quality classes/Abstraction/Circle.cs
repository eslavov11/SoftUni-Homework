namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle()
        {
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public virtual double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = value;
            }
        }
    }
}
