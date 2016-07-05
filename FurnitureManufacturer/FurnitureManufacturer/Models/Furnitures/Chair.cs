namespace FurnitureManufacturer.Models.Furnitures
{
    using Interfaces;
    public class Chair : Furniture, IChair
    {
        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; }

        public override string ToString()
        {
            return $"{base.ToString()}, Legs: {this.NumberOfLegs}";
        }
    }
}
