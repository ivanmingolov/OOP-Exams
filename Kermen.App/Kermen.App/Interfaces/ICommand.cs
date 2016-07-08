namespace Kermen.App.Interfaces
{
    using Core.Utilities;

    public interface ICommand
    {
        string Execute(CommandArgs commandArgs);
    }
}
