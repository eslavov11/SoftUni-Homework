using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Engine
{
    public class ExtendedEstatesEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return ExecuteFindRentsByLocation(cmdArgs[0]);
                case "find-rents-by-price":
                    return ExecuteFindRentsByPrice(cmdArgs);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }
        
        protected override string ExecuteCreateCommand(string[] cmdArgs)
        {
            return base.ExecuteCreateCommand(cmdArgs);
        }

        private string ExecuteFindRentsByLocation(string location)
        {
            var offers = base.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }


        private string ExecuteFindRentsByPrice(string[] cmdArgs)
        {
            decimal minPrice = decimal.Parse(cmdArgs[0]);
            decimal maxPrice = decimal.Parse(cmdArgs[1]);

            var offers = base.Offers
                .Where(o => o.Type == OfferType.Rent
                && (o as IRentOffer).PricePerMonth >= minPrice
                && (o as IRentOffer).PricePerMonth <= maxPrice)
                .OrderBy(o => (o as IRentOffer).PricePerMonth)
                .ThenBy(o => o.Estate.Name);

                
            return FormatQueryResults(offers);
        }
    }
}

        
