namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Models;
    using Models.ElectricItems;
    using Models.Persons;
    using System.Collections.Generic;
    using Utilities;

    public class AddOldCoupleCommand : Command
    {
        public AddOldCoupleCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            var firstGrandParentPension = commandArgs.Args[0];
            var secondGrandParentPension = commandArgs.Args[1];
            var tvElectricityCost = commandArgs.Args[2];
            var fridgeElectricityCost = commandArgs.Args[3];
            var stoveElectricityCost = commandArgs.Args[4];

            var firstGrandParent = new GrandParent(firstGrandParentPension);
            var secondGrandParent = new GrandParent(secondGrandParentPension);

            var familyMembers = new List<Person> { firstGrandParent, secondGrandParent };

            var tv = new Tv(tvElectricityCost);
            var fridge = new Fridge(fridgeElectricityCost);
            var stove = new Stove(stoveElectricityCost);

            var electricItems = new List<ElectricItem> { tv, fridge, stove };

            var family = new Family(KermenConstants.OldCoupleNumberOfRooms, KermenConstants.OldCoupleRoomElectricityCost, familyMembers, electricItems);

            this.Database.Families.Add(family);

            return null;
        }
    }
}
