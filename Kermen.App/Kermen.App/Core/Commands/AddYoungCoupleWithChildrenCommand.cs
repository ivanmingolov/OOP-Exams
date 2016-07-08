namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Models;
    using Models.ElectricItems;
    using Models.Items;
    using Models.Persons;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public class AddYoungCoupleWithChildrenCommand : Command
    {
        public AddYoungCoupleWithChildrenCommand(IDatabase database) : base(database)
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

            var children = GetChildren(commandArgs);

            var familyMembers = new List<Person>(children) { firstParent, secondParent };

            var tv = new Tv(tvElectricityCost);
            var fridge = new Fridge(fridgeElectricityCost);
            var laptop = new Laptop(laptopElectricityCost);

            var electricItems = new List<ElectricItem> { tv, fridge, laptop, laptop };

            var family = new Family(
                KermenConstants.YoungCoupleWithChildrenNumberOfRooms,
                KermenConstants.YoungCoupleWithChildrenRoomElectricityCost,
                familyMembers,
                electricItems);

            this.Database.Families.Add(family);

            return null;
        }

        private static IEnumerable<Child> GetChildren(CommandArgs commandArgs)
        {
            var children = new List<Child>();
            var childrenInfo = commandArgs.Args.Skip(5).ToArray();
            foreach (var childPropertiesCount in commandArgs.ChildrenPropertiesCount)
            {
                var foods = new List<Food>();
                var toys = new List<Toy>();
                for (int i = 0; i < childPropertiesCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        var food = new Food(childrenInfo[i]);

                        foods.Add(food);
                    }
                    else
                    {
                        var toy = new Toy(childrenInfo[i]);

                        toys.Add(toy);
                    }
                }
                childrenInfo = childrenInfo.Skip(childPropertiesCount).ToArray();
                var child = new Child(foods, toys);

                children.Add(child);
            }

            return children;
        }
    }
}
