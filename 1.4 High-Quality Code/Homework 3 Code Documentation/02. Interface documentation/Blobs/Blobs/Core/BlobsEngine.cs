namespace Blobs.Core
{
    using Interfaces;
    using Commands;
    using UserInterface;
    using System;
    using Exceptions;

    public class BlobsEngine : IEngine
    {
        private readonly IUserInterface userInterface;
        private readonly ICommandExecutor commandExecutor;

        public BlobsEngine()
        {
            this.userInterface = new ConsoleUserInterface();
            this.commandExecutor = new BlobsCommandExecutor();

        }

        public void Run()
        {
            var commandLine = userInterface.ReadLine();

            while (true)
            {
                ICommand command = new Command(commandLine);
                string commandOutput = string.Empty;
                try
                {
                    commandOutput = this.commandExecutor.Execute(command);
                }
                catch (BlopException ex)
                {
                    userInterface.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    userInterface.WriteLine(ex.Message);
                }

                if (!string.IsNullOrEmpty(commandOutput))
                {
                    userInterface.WriteLine(commandOutput);
                }
                
                commandLine = userInterface.ReadLine();
            }
        }

    }
}
