namespace VehicleParkSystem.Execution
{
    using System;

    using VehicleParkSystem.Interfaces;

    public class VehicleParkSystemEngine : IEngine
    {
        private readonly CommandExecutor commandExecutor;

        public VehicleParkSystemEngine(CommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public VehicleParkSystemEngine()
            : this(new CommandExecutor())
        {
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine.Trim();
                if (string.IsNullOrEmpty(commandLine))
                {
                    continue;
                }

                try
                {
                    var command = new CommandExecutor.Command(commandLine);
                    string commandResult = this.commandExecutor.Execute(command);
                    Console.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}