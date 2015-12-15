using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Drums : Instrument, IDrums
    {
        private int height;
        private int width;

        public Drums(string make, string model, decimal price, string color, int width, int height) 
            : base(make, model, price, color)
        {
            this.IsElectronic = false;
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be positive.");
                }
                this.width = value;
            }
        }
        public int Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height must be positive.");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +  Environment.NewLine + $"Size: {this.Width}cm x {this.Height}cm";

        }
    }
}
