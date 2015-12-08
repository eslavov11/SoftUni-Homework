using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public class SaleOffer :Offer, ISaleOffer
    {
        public SaleOffer(OfferType type, IEstate estate, decimal price)
            : base(type, estate)
        {
            this.Price = price;
        }

        public SaleOffer(OfferType type)
            : base(type)
        {
        }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return base.ToString() + this.Price;
        }
    }
}
