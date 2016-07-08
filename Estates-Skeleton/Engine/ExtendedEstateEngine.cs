namespace Estates.Engine
{
    using Interfaces;
    using System.Linq;

    public class ExtendedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.FindRentsByLocation(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.FindRentsByPrice(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
            }
            return base.ExecuteCommand(cmdName, cmdArgs);
        }

        private string FindRentsByLocation(string location)
        {
            var rentsInGivenLocation =
                this.Offers.Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                    .OrderBy(o => o.Estate.Name);

            return this.FormatQueryResults(rentsInGivenLocation);
        }

        private string FindRentsByPrice(decimal minPrice, decimal maxPrice)
        {
            var rentsInGivenPriceRange =
                this.Offers.Where(o => o.Type == OfferType.Rent)
                    .Cast<IRentOffer>()
                    .Where(o => o.PricePerMonth >= minPrice && o.PricePerMonth <= maxPrice)
                    .OrderBy(o => o.PricePerMonth)
                    .ThenBy(o => o.Estate.Name);

            return this.FormatQueryResults(rentsInGivenPriceRange);
        }
    }
}
