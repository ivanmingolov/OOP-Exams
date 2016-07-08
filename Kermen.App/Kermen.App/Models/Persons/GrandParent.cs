namespace Kermen.App.Models.Persons
{
    using System;

    public class GrandParent : Person
    {
        private const decimal GrandParentExpenses = 0m;

        private decimal pension;

        public GrandParent(decimal pension)
        {
            this.Pension = pension;
        }

        public override decimal IncomeMoney => this.Pension;

        public override decimal ExpensesMoney => GrandParentExpenses;

        private decimal Pension
        {
            get { return this.pension; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Pension), $"{nameof(this.Pension)} cannot be negative number.");
                }

                this.pension = value;
            }
        }
    }
}
