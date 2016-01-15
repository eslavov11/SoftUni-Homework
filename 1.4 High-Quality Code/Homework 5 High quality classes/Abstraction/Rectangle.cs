namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double height;
        private double width;

        public Rectangle()
            : this(0, 0)
        {
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
