namespace Kermen.App.Interfaces
{
    using Core.Utilities;

    public interface ICommandDispatcher
    {
        string Dispatch(CommandArgs commandArgs, IDatabase database);
    }
}
