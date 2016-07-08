namespace Kermen.App.Interfaces
{
    using Models.Interfaces;
    using System.Collections.Generic;

    public interface IDatabase
    {
        ICollection<IFamily> Families { get; }
    }
}
