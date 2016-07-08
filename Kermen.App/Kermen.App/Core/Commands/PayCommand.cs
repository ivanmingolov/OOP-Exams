namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Utilities;

    public class PayCommand : Command
    {
        public PayCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            foreach (var family in this.Database.Families)
            {
                var totalIncomeMoney = family.TotalIncomeMoney;

                family.Wallet.Add(totalIncomeMoney);
            }

            return null;
        }
    }
}
