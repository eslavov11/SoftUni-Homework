
using System.ComponentModel.Design;
using Empires.Interfaces;
using Empires.UserInterface;

namespace Empires.Core.Engines
{
    public class EmpireEngine : IEngine
    {
        private readonly IUserInterface ui;
        private readonly ICommandExecutor commandExecutor;

        public EmpireEngine()
        {
            this.ui = new ConsoleUserInterface();
            this.commandExecutor = new EmpiresCommandExecutor();

        }
        
        public void Run()
        {
            var commandLine = ui.ReadLine();

            while (commandLine != CommandList.End)
            {
                ICommand command = new Command(commandLine);
                string commandOutput = this.commandExecutor.ExecuteCommand(command);

                if (!string.IsNullOrEmpty(commandOutput))
                {
                    ui.WriteLine(commandOutput);
                }
                commandLine = ui.ReadLine();
            }
        }
    }
}
