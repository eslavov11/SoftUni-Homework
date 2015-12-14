using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    class ElectricGuitar : Guitar, IElectricGuitar
    {
        private const int DefaultElectricGuitarStrings = 6;
        private int numberOfFrets;
        private int numberOfAdapters;

        public ElectricGuitar(string make, string model, 
            decimal price, string color, string bodyWood, string fingerBodyWood, int numberOfAdapters, int numberOfFrets) 
            : base(make, model, price, color, bodyWood, fingerBodyWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
            base.NumberOfStrings = DefaultElectricGuitarStrings;
            this.IsElectronic = true;
        }

        public int NumberOfAdapters {
            get { return this.numberOfAdapters; }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("The number of adapters must be positive.");
                }
                this.numberOfAdapters = value;
            }
        }
        public int NumberOfFrets {
            get { return this.numberOfFrets; }
            set
            {
                if (value < 0.0m)
                {
                    throw new ArgumentException("The number of frets must be positive.");
                }
                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"Adapters: {this.NumberOfAdapters}" + Environment.NewLine +
                   $"Frets: {this.NumberOfFrets}";
        }
    }
}
