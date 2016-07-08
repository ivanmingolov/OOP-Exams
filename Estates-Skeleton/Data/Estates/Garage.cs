namespace Estates.Data.Estates
{
    using Interfaces;

    public class Garage : Estate, IGarage
    {
        private static readonly EstateType EstateType = EstateType.Garage;

        public Garage() : base(EstateType)
        {
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Width: {this.Width}, Height: {this.Height}";
        }
    }
}
