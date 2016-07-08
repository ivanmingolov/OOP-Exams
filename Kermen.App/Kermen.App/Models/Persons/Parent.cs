namespace Kermen.App.Models.Persons
{
    public class Parent : Person
    {
        private const decimal ParentExpensesMoney = 0m;

        public Parent(decimal salary)
        {
            this.Salary = salary;
        }

        public override decimal IncomeMoney => this.Salary;

        public override decimal ExpensesMoney => ParentExpensesMoney;

        private decimal Salary { get; }
    }
}
