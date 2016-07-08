namespace Kermen.App.Core.Utilities
{
    public class CommandArgs
    {
        public CommandArgs(string commandName, decimal[] args, int[] childrenPropertiesCount = null)
        {
            this.CommandName = commandName;
            this.Args = args;
            this.ChildrenPropertiesCount = childrenPropertiesCount;
        }

        public string CommandName { get; set; }

        public decimal[] Args { get; set; }

        public int[] ChildrenPropertiesCount { get; set; }
    }
}
