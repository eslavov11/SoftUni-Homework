using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected Instrument(string make, string model, decimal price, string color) 
            : base(make, model, price)
        {
            this.Color = color;
        }

        public string Color
        {
            get { return this.color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The color is required.");
                }
                this.color = value;
            }
        }

        public bool IsElectronic { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Color: {this.Color}"  + Environment.NewLine + 
                "Electronic: " + (this.IsElectronic
                ? "yes"
                : "no");
        }
    }
}
