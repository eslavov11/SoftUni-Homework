using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        public Shampoo(
            string name, string brand, decimal price, GenderType genderType, uint milliliters, UsageType usage)
            : base(name, brand, price, genderType)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public override decimal Price 
        {
            get { return base.Price * this.Milliliters; }
        }

        public uint Milliliters { get; }

        public UsageType Usage { get; }


        public override string Print()
        {
            return $"  * Quantity: {this.Milliliters} ml" +
                   Environment.NewLine +
                   $"  * Usage: {this.Usage}";
        }
    }
}
