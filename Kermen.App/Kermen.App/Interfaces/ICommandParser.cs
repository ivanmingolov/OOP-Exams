namespace Kermen.App.Interfaces
{
    using Core.Utilities;

    public interface ICommandParser
    {
        CommandArgs Parse(string line);
    }
}
