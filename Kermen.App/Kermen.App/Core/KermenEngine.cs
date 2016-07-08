namespace Kermen.App.Core
{
    using Interfaces;
    using Interfaces.IO;
    using System;

    public class KermenEngine : IEngine
    {
        private readonly IDatabase database;
        private readonly IUserInterface userInterface;
        private readonly ICommandParser commandParser;
        private readonly ICommandDispatcher commandDispatcher;

        public KermenEngine(IDatabase database, IUserInterface userInterface, ICommandParser commandParser, ICommandDispatcher commandDispatcher)
        {
            this.database = database;
            this.userInterface = userInterface;
            this.commandParser = commandParser;
            this.commandDispatcher = commandDispatcher;
            this.IsRunning = true;
        }

        private bool IsRunning { get; set; }

        public void Run()
        {
            var count = 1;
            do
            {
                try
                {
                    var line = this.userInterface.ReadLine();

                    var commandArgs = this.commandParser.Parse(line);

                    var dispatchResult = this.commandDispatcher.Dispatch(commandArgs, this.database);

                    if (!string.IsNullOrEmpty(dispatchResult))
                    {
                        this.userInterface.WriteLine(dispatchResult);
                    }

                    if (dispatchResult == "end")
                    {
                        this.IsRunning = false;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                    this.IsRunning = false;
                }

                if (count % 3 == 0)
                {
                    var commandArgs = this.commandParser.Parse("Pay");

                    this.commandDispatcher.Dispatch(commandArgs, this.database);
                }

                count++;
            }
            while (this.IsRunning);
        }
    }
}
