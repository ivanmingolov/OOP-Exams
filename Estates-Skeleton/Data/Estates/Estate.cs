namespace Estates.Data.Estates
{
    using Interfaces;

    public abstract class Estate : IEstate
    {
        protected Estate(EstateType type)
        {
            this.Type = type;
        }

        public string Name { get; set; }
        public EstateType Type { get; set; }
        public double Area { get; set; }
        public string Location { get; set; }
        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            return
                $"{this.GetType().Name}: Name = {this.Name}, Area = {this.Area}, Location = {this.Location}, Furnitured = {(this.IsFurnished ? "Yes" : "No")}";
        }
    }
}
