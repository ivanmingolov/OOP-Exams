namespace Kermen.App.Models.Items
{

    public abstract class Item
    {
        protected Item(decimal price)
        {
            this.Price = price;
        }

        public decimal Price { get; }
    }
}
