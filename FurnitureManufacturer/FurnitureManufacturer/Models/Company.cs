namespace FurnitureManufacturer.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Company : ICompany
    {
        private const int MinNameLength = 5;
        private const int RegistrationNumberLength = 10;

        private IList<IFurniture> furnitures;
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), "Name cannot be null or emty.");
                }

                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException($"Name length should be at least {MinNameLength} characters long.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            set
            {
                if (value.Length != RegistrationNumberLength)
                {
                    throw new ArgumentException($"Registration number name should be exactly {this.registrationNumber} digits long.");
                }

                if (!ContainsOnlyDigits(value))
                {
                    throw new ArgumentException("Number of registration should contains only digits.");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            var indexOfFurniture = this.furnitures.IndexOf(furniture);

            if (indexOfFurniture == -1)
            {
                return;
            }

            this.furnitures.RemoveAt(indexOfFurniture);
        }

        public IFurniture Find(string model)
        {
            var furniture = this.furnitures.FirstOrDefault(f => string.Equals(f.Model, model, StringComparison.CurrentCultureIgnoreCase));

            return furniture;
        }

        public string Catalog()
        {
            var output = new StringBuilder();

            output.Append($"{this.Name} - {this.RegistrationNumber} - " +
                          $"{(this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no")} " +
                          $"{(this.Furnitures.Count != 1 ? "furnitures" : "furniture")}");

            if (this.Furnitures.Count > 0)
            {
                var orderFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(p => p.Model);

                output.AppendLine();
                output.Append(string.Join(Environment.NewLine, orderFurnitures.Select(f => f.ToString())));
            }

            return output.ToString();
        }

        private static bool ContainsOnlyDigits(string item)
        {
            return item.All(char.IsDigit);
        }
    }
}
