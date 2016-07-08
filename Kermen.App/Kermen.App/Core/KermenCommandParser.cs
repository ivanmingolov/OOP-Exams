namespace Kermen.App.Core
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Utilities;

    public class KermenCommandParser : ICommandParser
    {
        public CommandArgs Parse(string line)
        {
            CommandArgs commandArgs;
            if (line == "EVN")
            {
                var name = "EvnCommand";

                commandArgs = new CommandArgs(name, null);
            }
            else if (line == "EVN bill")
            {
                var name = "EvnBillCommand";

                commandArgs = new CommandArgs(name, null);
            }
            else if (line == "Democracy")
            {
                var name = "DemocracyCommand";

                commandArgs = new CommandArgs(name, null);
            }
            else if (line == "Pay")
            {
                var name = "PayCommand";

                commandArgs = new CommandArgs(name, null);
            }
            else
            {
                var name = $"Add{line.Substring(0, line.IndexOf('('))}Command";

                var childrenPropertiesCount = new List<int>();
                var childrenMatches = Regex.Matches(line, "Child\\(.+?\\)");
                foreach (Match match in childrenMatches)
                {
                    var value = match.Value;

                    childrenPropertiesCount.Add(Regex.Matches(value, "\\d+").Count);
                }

                line = Regex.Replace(line, "[^\\d\\.]+", " ");

                var args = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

                commandArgs = new CommandArgs(name, args, childrenPropertiesCount.ToArray());
            }

            return commandArgs;
        }
    }
}
