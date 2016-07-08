namespace Kermen.App.Models.Persons
{
    using Items;
    using System.Collections.Generic;
    using System.Linq;

    public class Child : Person
    {
        private const decimal ChildIncomeMoney = 0m;

        public Child(ICollection<Food> foods, ICollection<Toy> toys)
        {
            this.Foods = foods;
            this.Toys = toys;
        }

        public override decimal IncomeMoney => ChildIncomeMoney;

        public override decimal ExpensesMoney
        {
            get
            {
                var expensesMoney = 0m;

                expensesMoney += this.Foods.Sum(food => food.Price);
                expensesMoney += this.Toys.Sum(toy => toy.Price);

                return expensesMoney;
            }
        }

        private ICollection<Food> Foods { get; }

        private ICollection<Toy> Toys { get; }
    }
}
