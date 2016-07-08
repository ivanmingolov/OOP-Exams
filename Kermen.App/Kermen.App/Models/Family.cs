namespace Kermen.App.Models
{
    using ElectricItems;
    using Interfaces;
    using Persons;
    using System.Collections.Generic;
    using System.Linq;

    public class Family : IFamily
    {
        public Family(int numberOfRooms, decimal roomElectricityCost, ICollection<Person> familyMembers, ICollection<ElectricItem> electricItems = null)
        {
            this.NumberOfRooms = numberOfRooms;
            this.RoomElectricityCost = roomElectricityCost;
            this.FamilyMembers = familyMembers;
            this.ElectricItems = electricItems;
            this.Wallet = new Wallet();

        }

        private int NumberOfRooms { get; }

        private decimal RoomElectricityCost { get; }

        private ICollection<Person> FamilyMembers { get; }

        private ICollection<ElectricItem> ElectricItems { get; }

        public decimal TotalIncomeMoney => this.FamilyMembers.Sum(familyMember => familyMember.IncomeMoney);

        public decimal TotalBillsCost
        {
            get
            {
                var totalBillsCost = 0m;

                totalBillsCost += this.FamilyMembers.Sum(familyMember => familyMember.ExpensesMoney);
                totalBillsCost += this.TotalElectricityCost;

                return totalBillsCost;
            }
        }

        public decimal TotalElectricityCost
        {
            get
            {
                var totalElectricityCost = 0m;

                totalElectricityCost += this.NumberOfRooms * this.RoomElectricityCost;

                // Add Laptop electricity cost if family have more than two parents
                if (this.FamilyMembers.Count(familyMember => familyMember.GetType().Name == "Parent") > 1)
                {
                    totalElectricityCost += this.ElectricItems.First(item => item.GetType().Name == "Laptop").ElectricityCost;
                }

                if (this.ElectricItems != null)
                {
                    totalElectricityCost += this.ElectricItems.Sum(electricItem => electricItem.ElectricityCost);
                }

                return totalElectricityCost;
            }
        }

        public Wallet Wallet { get; }

        public int MembersCount => this.FamilyMembers.Count;
    }
}
