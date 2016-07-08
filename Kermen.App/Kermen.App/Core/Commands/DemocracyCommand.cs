namespace Kermen.App.Core.Commands
{
    using Interfaces;
    using Utilities;

    public class DemocracyCommand : Command
    {
        public DemocracyCommand(IDatabase database) : base(database)
        {
        }

        public override string Execute(CommandArgs commandArgs)
        {
            return "end";
        }
    }
}
