namespace Kermen.App.Core
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;
    using Utilities;

    public class KermenCommandDispatcher : ICommandDispatcher
    {
        public string Dispatch(CommandArgs commandArgs, IDatabase database)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.Name == commandArgs.CommandName);

            var command = Activator.CreateInstance(commandType, database);
            var action = commandType.GetMethod("Execute");
            var parameters = new object[] { commandArgs };

            var result = action.Invoke(command, parameters) as string;

            return result;
        }
    }
}
