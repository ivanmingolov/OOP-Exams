namespace Kermen.App.Models.Items
{
    using System;

    public abstract class Item
    {
        private decimal price;

        protected Item(decimal price)
        {
            this.Price = price;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Price), $"{nameof(this.Price)} cannot be negative number.");
                }

                this.price = value;
            }
        }
    }
}
