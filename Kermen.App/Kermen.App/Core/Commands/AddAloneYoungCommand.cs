namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Models;
    using Models.ElectricItems;
    using Models.Persons;
    using System.Collections.Generic;
    using Utilities;

    public class AddAloneYoungCommand : Command
    {
        public AddAloneYoungCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            var parentSalary = commandArgs.Args[0];
            var laptopElectricityCost = commandArgs.Args[1];

            var firstParent = new Parent(parentSalary);

            var familyMembers = new List<Person> { firstParent };

            var laptop = new Laptop(laptopElectricityCost);

            var electricItems = new List<ElectricItem> { laptop };

            var family = new Family(KermenConstants.AloneYoungNumberOfRooms, KermenConstants.AloneYoungRoomElectricityCost, familyMembers, electricItems);

            this.Database.Families.Add(family);

            return null;
        }
    }
}
