namespace Estates.Data.Offers
{
    using Interfaces;
    public abstract class Offer : IOffer
    {
        protected Offer(OfferType type)
        {
            this.Type = type;
        }

        public OfferType Type { get; set; }
        public IEstate Estate { get; set; }

        public override string ToString()
        {
            return $"{this.Type}: Estate = {this.Estate.Name}, Location = {this.Estate.Location}";
        }
    }
}
