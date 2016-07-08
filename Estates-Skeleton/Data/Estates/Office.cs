namespace Estates.Data.Estates
{
    using Interfaces;

    public class Office : Estate, IOffice
    {
        private static readonly EstateType EstateType = EstateType.Office;

        public Office() : base(EstateType)
        {
        }

        public int Rooms { get; set; }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Rooms: {this.Rooms}, Elevator: {(this.HasElevator ? "Yes" : "No")}";
        }
    }
}
