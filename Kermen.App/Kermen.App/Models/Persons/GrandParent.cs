namespace Kermen.App.Models.Persons
{
    public class GrandParent : Person
    {
        private const decimal GrandParentExpenses = 0m;

        public GrandParent(decimal pension)
        {
            this.Pension = pension;
        }

        public override decimal IncomeMoney => this.Pension;

        public override decimal ExpensesMoney => GrandParentExpenses;

        private decimal Pension { get; }
    }
}
