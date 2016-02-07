namespace AirConditionerTesterSystem.Execution
{
    using System;

    using AirConditionerTesterSystem.Data;
    using AirConditionerTesterSystem.Exceptions;
    using AirConditionerTesterSystem.Interfaces;
    using AirConditionerTesterSystem.UI;
    using AirConditionerTesterSystem.Utility;

    public class Engine
    {
        private readonly CommandExecutor ac;
        private readonly ConsoleUserInterface userInterface;
        private Command command;

        public Engine(ConsoleUserInterface userInterface)
        {
            this.ac = new CommandExecutor();
            this.userInterface = userInterface;
        }

        public void Run()
        {
            while (true)
            {
                string line = this.userInterface.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.command = new Command(line);
                    string commandMessage = this.ac.Execute(this.command);

                    this.userInterface.WriteLine(commandMessage);
                }
                catch (DuplicateEntryException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
                catch (NonExistantEntryException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.userInterface.result);
        }
    }
}
