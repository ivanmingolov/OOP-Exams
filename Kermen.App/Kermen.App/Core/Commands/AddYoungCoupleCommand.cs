namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Models;
    using Models.ElectricItems;
    using Models.Persons;
    using System.Collections.Generic;
    using Utilities;

    public class AddYoungCoupleCommand : Command
    {
        public AddYoungCoupleCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            var firstParentSalary = commandArgs.Args[0];
            var secondParentSalary = commandArgs.Args[1];
            var tvElectricityCost = commandArgs.Args[2];
            var fridgeElectricityCost = commandArgs.Args[3];
            var laptopElectricityCost = commandArgs.Args[4];

            var firstParent = new Parent(firstParentSalary);
            var secondParent = new Parent(secondParentSalary);

            var familyMembers = new List<Person> { firstParent, secondParent };

            var tv = new Tv(tvElectricityCost);
            var fridge = new Fridge(fridgeElectricityCost);
            var laptop = new Laptop(laptopElectricityCost);

            var electricItems = new List<ElectricItem> { tv, fridge, laptop, laptop };

            var family = new Family(KermenConstants.YoungCoupleNumberOfRooms, KermenConstants.YoungCoupleRoomElectricityCost, familyMembers, electricItems);

            this.Database.Families.Add(family);

            return null;
        }
    }
}
