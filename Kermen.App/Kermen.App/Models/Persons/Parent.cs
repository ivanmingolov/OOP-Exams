namespace Kermen.App.Models.Persons
{
    using System;

    public class Parent : Person
    {
        private const decimal ParentExpensesMoney = 0m;

        private decimal salary;

        public Parent(decimal salary)
        {
            this.Salary = salary;
        }

        public override decimal IncomeMoney => this.Salary;

        public override decimal ExpensesMoney => ParentExpensesMoney;

        private decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Salary), $"{nameof(this.Salary)} cannot be nagative number.");
                }

                this.salary = value;
            }
        }
    }
}
