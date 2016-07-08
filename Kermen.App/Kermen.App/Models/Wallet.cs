namespace Kermen.App.Models
{
    using System;

    public class Wallet
    {
        public decimal Money { get; private set; }

        public void Add(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(money), "Cannot add negative money to wallet.");
            }

            this.Money += money;
        }

        public void Remove(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(money), "Cannot add negative money to wallet.");
            }

            if (this.Money - money < 0)
            {
                throw new InvalidOperationException("Cannot remove money that are more than you have.");
            }

            this.Money -= money;
        }
    }
}
