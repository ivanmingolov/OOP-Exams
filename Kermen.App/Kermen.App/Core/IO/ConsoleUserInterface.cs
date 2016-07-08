namespace Kermen.App.Core.IO
{
    using Interfaces.IO;
    using System;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string formant, params object[] args)
        {
            Console.WriteLine(formant, args);
        }
    }
}
