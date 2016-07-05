namespace FurnitureManufacturer.Models.Furnitures
{
    using Interfaces;
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const bool InitialConvertedState = false;
        private const decimal ConvertedStateHeight = 0.10m;

        private readonly decimal InitialHeight;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = InitialConvertedState;
            this.InitialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;

            this.Height = this.IsConverted ? ConvertedStateHeight : this.InitialHeight;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, State: {(this.IsConverted ? "Converted" : "Normal")}";
        }
    }
}
