namespace Kermen.App
{
    using Core;
    using Core.IO;

    public class Startup
    {
        public static void Main()
        {
            var database = new KermenDatabase();
            var useInterface = new ConsoleUserInterface();
            var commandParser = new KermenCommandParser();
            var commandDispatcher = new KermenCommandDispatcher();

            var engine = new KermenEngine(database, useInterface, commandParser, commandDispatcher);
            engine.Run();
        }
    }
}
