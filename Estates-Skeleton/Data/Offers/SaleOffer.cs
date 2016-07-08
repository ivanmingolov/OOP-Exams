namespace Estates.Data.Offers
{
    using Interfaces;
    public class SaleOffer : Offer, ISaleOffer
    {
        private static readonly OfferType OfferType = OfferType.Sale;

        public SaleOffer() : base(OfferType)
        {
        }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Price = {this.Price}";
        }
    }
}
