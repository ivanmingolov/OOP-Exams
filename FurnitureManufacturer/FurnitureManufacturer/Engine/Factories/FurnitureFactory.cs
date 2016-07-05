namespace FurnitureManufacturer.Engine.Factories
{
    using Interfaces;
    using Interfaces.Engine;
    using Models;
    using Models.Furnitures;
    using System;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            var material = GetMaterialType(materialType);

            var table = new Table(model, material, price, height, length, width);

            return table;
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            var material = GetMaterialType(materialType);

            var chair = new Chair(model, material, price, height, numberOfLegs);

            return chair;
        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            var material = GetMaterialType(materialType);

            var adjustableChair = new AdjustableChair(model, material, price, height, numberOfLegs);

            return adjustableChair;
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            var material = GetMaterialType(materialType);

            var convertibleChair = new ConvertibleChair(model, material, price, height, numberOfLegs);

            return convertibleChair;
        }

        private static MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}
