namespace Kermen.App.Models
{
    using System;

    public class Wallet
    {
        public decimal Money { get; private set; }

        public void Add(decimal money)
        {
            this.Money += money;
        }

        public void Remove(decimal money)
        {
            if (this.Money - money < 0)
            {
                throw new InvalidOperationException("Cannot remove money that are more than you have.");
            }

            this.Money -= money;
        }
    }
}
