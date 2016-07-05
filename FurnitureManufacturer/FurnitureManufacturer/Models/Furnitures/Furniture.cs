namespace FurnitureManufacturer.Models.Furnitures
{
    using Interfaces;
    using System;

    public abstract class Furniture : IFurniture
    {
        private const int MinModelLength = 3;
        private const decimal MinPriceValue = 0m;
        private const decimal MinHeightValue = 0m;

        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.Model), "Model cannot be null or emty.");
                }

                if (value.Length < MinModelLength)
                {
                    throw new ArgumentException($"Model length should be at least {MinModelLength} characters long.");
                }

                this.model = value;
            }
        }

        public MaterialType Material { get; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= MinPriceValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Price), "Price cannot be negative or equal zero.");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= MinHeightValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Model), "Height cannot be negative or equal to zero.");
                }

                this.height = value;
            }
        }

        public override bool Equals(object obj)
        {
            var otherFurniture = (Furniture)obj;

            return this.Model == otherFurniture.Model && this.GetType() == otherFurniture.GetType();
        }

        public override int GetHashCode()
        {
            return this.Model.GetHashCode() ^ this.Material.GetHashCode() ^ this.Height.GetHashCode();
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height}";
        }
    }
}
