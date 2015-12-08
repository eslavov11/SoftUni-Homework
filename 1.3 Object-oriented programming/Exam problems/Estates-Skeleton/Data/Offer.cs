using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Offer : IOffer
    {
        protected Offer(OfferType type, IEstate estate)
        {
            this.Type = type;
            this.Estate = estate;
        }

        protected Offer(OfferType type)
        {
            this.Type = type;
        }

        public OfferType Type { get; set; }
        public IEstate Estate { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name.Substring(0, this.GetType().Name.Length - 5)}: Estate = {this.Estate.Name}, Location = {this.Estate.Location}, Price = ";
        }
    }
}
