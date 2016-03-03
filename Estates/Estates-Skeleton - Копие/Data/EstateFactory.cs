using Estates.Engine;
using Estates.Interfaces;
using System;


namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ExtendedEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment: return new Apartment();
                case EstateType.Garage: return new Garage();
                case EstateType.House: return new House();
                case EstateType.Office: return new Office();
                default: throw new NotSupportedException("This estate type is not supported.");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent: return new RentOffer(OfferType.Rent);
                case OfferType.Sale: return new SaleOffer(OfferType.Sale);
                default: throw new NotSupportedException("This offer is not supported.");
            }
        }
    }
}
