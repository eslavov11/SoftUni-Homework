using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public class RentOffer : Offer, IRentOffer
    {
        public RentOffer(OfferType type, IEstate estate, decimal pricePerMonth)
            : base(type, estate)
        {
            this.PricePerMonth = pricePerMonth;
        }

        public RentOffer(OfferType type)
            : base(type)
        {
        }

        public decimal PricePerMonth { get; set; }

        public override string ToString()
        {
            return base.ToString() + this.PricePerMonth;
        }
    }
}
