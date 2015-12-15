using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShopManager.Interfaces;
using MusicShopManager.Models;

namespace MusicShop.Models
{
    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private const int DefaultAcousticGuitarStrings = 6;

        public AcousticGuitar(string make, string model,
            decimal price, string color, string bodyWood, string fingerBodyWood, 
            bool caseIncluded, StringMaterial stringMaterial) 
            : base(make, model, price, color, bodyWood, fingerBodyWood)
        {
            this.StringMaterial = stringMaterial;
            this.CaseIncluded = caseIncluded;
            base.NumberOfStrings = DefaultAcousticGuitarStrings;
            this.IsElectronic = false;
        }

        public bool CaseIncluded { get; }

        public StringMaterial StringMaterial { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Case included: "  + (this.CaseIncluded ? "yes" : "no") + Environment.NewLine +
                $"String material: " + this.StringMaterial;
        }
    }
}
