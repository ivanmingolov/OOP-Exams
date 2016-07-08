namespace Kermen.App.Models.ElectricItems
{
    using System;

    public abstract class ElectricItem
    {
        private decimal electricityCost;

        protected ElectricItem(decimal electricityCost)
        {
            this.ElectricityCost = electricityCost;
        }

        public decimal ElectricityCost
        {
            get
            {
                return this.electricityCost;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.ElectricityCost), $"{nameof(this.ElectricityCost)} cannot be negative number.");
                }

                this.electricityCost = value;
            }
        }
    }
}
