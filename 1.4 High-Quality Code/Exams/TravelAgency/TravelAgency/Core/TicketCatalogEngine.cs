namespace TravelAgency.Core
{
    using Data;
    using Interfaces;

    public class TicketCatalogEngine : IEngine
    {
        private readonly TicketCatalog ticketCatalog;
        private readonly IUserInterface userInterface;
        private readonly CommandExecutor commandExecutor;

        public TicketCatalogEngine(TicketCatalog ticketCatalog, IUserInterface userInterface)
        {
            this.ticketCatalog = ticketCatalog;
            this.userInterface = userInterface;
            this.commandExecutor = new CommandExecutor(this.ticketCatalog);
        }

        public void Run()
        {
            string commandLine = this.userInterface.ReadLine();

            while (commandLine != null)
            {
                commandLine = commandLine.Trim();
                string commandResult = this.commandExecutor.Execute(commandLine);
                if (commandResult != null)
                {
                    this.userInterface.WriteLine(commandResult);
                }

                commandLine = this.userInterface.ReadLine();
            }
        }
    }
}
