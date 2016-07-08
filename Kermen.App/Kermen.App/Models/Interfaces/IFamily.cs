namespace Kermen.App.Models.Interfaces
{
    public interface IFamily
    {
        decimal TotalIncomeMoney { get; }

        decimal TotalBillsCost { get; }

        decimal TotalElectricityCost { get; }

        Wallet Wallet { get; }

        int MembersCount { get; }
    }
}
