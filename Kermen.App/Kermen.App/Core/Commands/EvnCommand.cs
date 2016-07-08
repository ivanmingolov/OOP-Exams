namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using System.Linq;
    using Utilities;

    public class EvnCommand : Command
    {
        public EvnCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            var totalConsumption = this.Database.Families.Sum(family => family.TotalBillsCost);

            return $"Total consumption: {totalConsumption:f1}";
        }
    }
}
