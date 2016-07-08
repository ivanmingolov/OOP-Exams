namespace Kermen.App.Models.ElectricItems
{
    public abstract class ElectricItem
    {
        protected ElectricItem(decimal electricityCost)
        {
            this.ElectricityCost = electricityCost;
        }

        public decimal ElectricityCost { get; }
    }
}
