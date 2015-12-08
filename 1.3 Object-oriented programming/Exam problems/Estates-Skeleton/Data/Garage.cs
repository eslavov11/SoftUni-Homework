using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Garage : Estate, IGarage
    {
        public Garage(EstateType type, string name, double area, string location, bool isFurnished, int width, int height)
            : base(type, name, area, location, isFurnished)
        {
            this.Width = width;
            this.Height = height;
        }

        public Garage(EstateType type)
            : base(type)
        {
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Width: {this.Width}, Height: {this.Height}";
        }
    }
}
