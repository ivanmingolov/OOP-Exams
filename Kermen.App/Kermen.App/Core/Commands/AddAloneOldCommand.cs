namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Models;
    using Models.ElectricItems;
    using Models.Persons;
    using System.Collections.Generic;
    using Utilities;

    public class AddAloneOldCommand : Command
    {
        public AddAloneOldCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            var grandParentPension = commandArgs.Args[0];

            var grandParent = new GrandParent(grandParentPension);

            var familyMembers = new List<Person> { grandParent };

            var electricItems = new List<ElectricItem>();

            var family = new Family(KermenConstants.AloneOldNumberOfRoom, KermenConstants.AloneOldRoomElectricityCost, familyMembers, electricItems);

            this.Database.Families.Add(family);

            return null;
        }
    }
}
