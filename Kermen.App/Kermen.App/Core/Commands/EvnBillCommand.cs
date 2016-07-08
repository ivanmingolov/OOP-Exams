namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public class EvnBillCommand : Command
    {
        public EvnBillCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            var familiesToMigrate = new List<IFamily>();
            foreach (var family in this.Database.Families)
            {
                try
                {
                    var totalBillsCost = family.TotalBillsCost;

                    family.Wallet.Remove(totalBillsCost);
                }
                catch (InvalidOperationException)
                {
                    familiesToMigrate.Add(family);
                }
            }

            foreach (var family in familiesToMigrate)
            {
                this.Database.Families.Remove(family);
            }

            return $"Total population: {this.Database.Families.Sum(family => family.MembersCount)}";
        }
    }
}
