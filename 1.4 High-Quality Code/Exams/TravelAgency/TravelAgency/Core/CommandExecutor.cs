namespace TravelAgency.Core
{
    using System;
    using Data;

    using TravelAgency.Models.Tickets;

    public class CommandExecutor
    {
        private readonly TicketCatalog ticketCatalog;

        public CommandExecutor(TicketCatalog ticketCatalog)
        {
            this.ticketCatalog = ticketCatalog;
        }

        public string Execute(string commandLine)
        {
            if (commandLine == string.Empty)
            {
                return null;
            }

            int firstSpaceIndex = commandLine.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string mainCommand = commandLine.Substring(0, firstSpaceIndex);
            string commandMessage;

            string allParameters = commandLine.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(
                new char[] { ';' },
                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            switch (mainCommand)
            {
                case "AddAir":
                    
                    commandMessage = this.ticketCatalog.AddAirTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3],
                        parameters[4],
                        parameters[5]);
                    break;
                case "DeleteAir":
                    commandMessage = this.ticketCatalog.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    commandMessage = this.ticketCatalog.AddTrainTicket(
                        parameters[0], 
                        parameters[1],
                        parameters[2],
                        parameters[3],
                        parameters[4]);
                    break;
                case "DeleteTrain":
                    commandMessage = this.ticketCatalog.DeleteTrainTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2]);
                    break;
                case "AddBus":
                    commandMessage = this.ticketCatalog.AddBusTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2],
                        parameters[3], 
                        parameters[4]);
                    break;
                case "DeleteBus":
                    commandMessage = this.ticketCatalog.DeleteBusTicket(
                        parameters[0],
                        parameters[1], 
                        parameters[2], 
                        parameters[3]);
                    break;
                case "FindTickets":
                    commandMessage = this.ticketCatalog.FindTickets(
                        parameters[0],
                        parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    var startDateTime = Ticket.ParseDateTime(parameters[0]);
                    var endDateTime = Ticket.ParseDateTime(parameters[1]);
                    commandMessage = this.ticketCatalog.FindTicketsInInterval(
                        startDateTime,
                        endDateTime);
                    break;
                default:
                    commandMessage = "Invalid command!";
                    break;
            }

            return commandMessage;
        }
    }
}
