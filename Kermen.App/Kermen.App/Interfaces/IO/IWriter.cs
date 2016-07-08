namespace Kermen.App.Interfaces.IO
{
    public interface IWriter
    {
        void WriteLine(string message);

        void WriteLine(string formant, params object[] args);
    }
}
