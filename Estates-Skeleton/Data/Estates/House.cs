namespace Estates.Data.Estates
{
    using Interfaces;

    public class House : Estate, IHouse
    {
        private static readonly EstateType EstateType = EstateType.House;

        public House() : base(EstateType)
        {
        }

        public int Floors { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Floors: {this.Floors}";
        }
    }
}
