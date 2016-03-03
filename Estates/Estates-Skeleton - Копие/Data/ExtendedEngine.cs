using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Engine;
using Estates.Interfaces;

namespace Estates.Data
{
    class ExtendedEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocation(cmdArgs[0]);
                //break;
                case "find-rents-by-price":
                    return this.ExecuteRentsByPrice(cmdArgs[0], cmdArgs[1]);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByLocation(string location)
        {
            var rentsByLocation = this.Offers
                .Where(x => x.Estate.Location == location && x.Type == OfferType.Rent)
                .OrderBy(x => x.Estate.Name);
            return FormatQueryResults(rentsByLocation);
        }

        private string ExecuteRentsByPrice(string minPrice, string maxPrice)
        {
            decimal minP = decimal.Parse(minPrice);
            decimal maxP = decimal.Parse(maxPrice);

            var rentsByPrice = this.Offers
                .Where(x => x.Type == OfferType.Rent)
                .Where(x => ((RentOffer)x).PricePerMonth >= minP &&
                            ((RentOffer)x).PricePerMonth <= maxP)
                .OrderBy(x => ((RentOffer)x).PricePerMonth)
                .ThenBy(x => ((RentOffer)x).Estate.Name);
            return FormatQueryResults(rentsByPrice);
        }
    }
}
