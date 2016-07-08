namespace Estates.Data.Offers
{
    using Interfaces;
    public class RentOffer : Offer, IRentOffer
    {
        private static readonly OfferType OfferType = OfferType.Rent;

        public RentOffer() : base(OfferType)
        {
        }

        public decimal PricePerMonth { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Price = {this.PricePerMonth}";
        }
    }
}
