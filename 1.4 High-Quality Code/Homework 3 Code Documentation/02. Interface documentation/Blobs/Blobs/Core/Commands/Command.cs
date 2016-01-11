namespace Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Command : ICommand
    {
        public Command(string commandLine)
        {
            string[] commandTokens = commandLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            this.Name = commandTokens[0];
            if (commandTokens.Length > 1)
            {
                this.Parameters = commandTokens.Skip(1).ToArray();
            }
        }

        public string Name { get; private set; }

        public IList<string> Parameters { get; }
    }
}