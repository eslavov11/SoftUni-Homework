using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        private const int DefaultBassGuitarStrings = 4;


        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerBodyWood)
            : base(make, model, price, color, bodyWood, fingerBodyWood)
        {
            this.IsElectronic = true;
            this.NumberOfStrings = DefaultBassGuitarStrings;
        }
    }
}
