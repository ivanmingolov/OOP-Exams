namespace Kermen.App.Models.Persons
{
    using Interfaces;
    public abstract class Person : IPerson
    {
        public abstract decimal IncomeMoney { get; }

        public abstract decimal ExpensesMoney { get; }
    }
}
