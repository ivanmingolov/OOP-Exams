namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Utilities;

    public abstract class Command : ICommand
    {
        protected readonly IDatabase Database;

        protected Command(IDatabase database)
        {
            this.Database = database;
        }

        public abstract string Execute(CommandArgs commandArgs);
    }
}
