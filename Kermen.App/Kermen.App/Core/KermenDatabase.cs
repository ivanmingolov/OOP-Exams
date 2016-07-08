namespace Kermen.App.Core
{
    using Interfaces;
    using Models.Interfaces;
    using System.Collections.Generic;

    public class KermenDatabase : IDatabase
    {
        public KermenDatabase()
        {
            this.Families = new List<IFamily>();
        }

        public ICollection<IFamily> Families { get; }
    }
}