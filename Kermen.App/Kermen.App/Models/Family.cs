namespace Kermen.App.Models
{
    using ElectricItems;
    using Interfaces;
    using Persons;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Family : IFamily
    {
        private int numberOfRooms;
        private decimal roomElectricityCost;

        public Family(int numberOfRooms, decimal roomElectricityCost, ICollection<Person> familyMembers, ICollection<ElectricItem> electricItems = null)
        {
            this.NumberOfRooms = numberOfRooms;
            this.RoomElectricityCost = roomElectricityCost;
            this.FamilyMembers = familyMembers;
            this.ElectricItems = electricItems;
            this.Wallet = new Wallet();
        }

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

                if (this.ElectricItems != null)
                {
                    totalElectricityCost += this.ElectricItems.Sum(electricItem => electricItem.ElectricityCost);
                }

                return totalElectricityCost;
            }
        }

        public Wallet Wallet { get; }

        public int MembersCount => this.FamilyMembers.Count;

        private ICollection<Person> FamilyMembers { get; }

        private ICollection<ElectricItem> ElectricItems { get; }

        private int NumberOfRooms
        {
            get
            {
                return this.numberOfRooms;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.NumberOfRooms), $"{nameof(this.NumberOfRooms)} cannot be negative number.");
                }

                this.numberOfRooms = value;
            }
        }

        private decimal RoomElectricityCost
        {
            get
            {
                return this.roomElectricityCost;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.RoomElectricityCost), $"{nameof(this.RoomElectricityCost)} cannot be negative number.");
                }

                this.roomElectricityCost = value;
            }
        }
    }
}
