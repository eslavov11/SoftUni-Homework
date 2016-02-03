namespace TicketOffice.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Interfaces;
    using Models.Tickets;

    using Wintellect.PowerCollections;

    public class TicketRepository : ITicketRepository
    {
        private readonly Dictionary<string, Ticket> ticketsByKey = new Dictionary<string, Ticket>();
        private readonly MultiDictionary<string, Ticket> ticketsByFromTo = new MultiDictionary<string, Ticket>(true);
        private readonly OrderedMultiDictionary<DateTime, Ticket> ticketsByDateTime = new OrderedMultiDictionary<DateTime, Ticket>(true);
        private int airTicketsCount;
        private int busTicketsCount;
        private int trainTicketsCount;

        public string AddTicket(Ticket ticket)
        {
            string key = ticket.property2;
            if (this.ticketsByKey.ContainsKey(key))
            {
                return "Duplicated " + ticket.Type.ToLower();
            }
            this.ticketsByKey.Add(key, ticket);
            string fromToKey = ticket.FromToKey;

            this.ticketsByFromTo.Add(fromToKey, ticket);
            this.ticketsByDateTime.Add(ticket.DateAndTime, ticket);
            return ticket.Type + " created";
        }

        public string DeleteTicket(Ticket ticket)
        {
            string key = ticket.property2;
            if (this.ticketsByKey.ContainsKey(key))
            {
                ticket = this.ticketsByKey[key];
                this.ticketsByKey.Remove(key);
                string fromToKey = ticket.FromToKey;

                this.ticketsByFromTo.Remove(fromToKey, ticket);
                this.ticketsByDateTime.Remove(ticket.DateAndTime, ticket);
                return ticket.Type + " deleted";
            }

            return ticket.Type + " does not exist";
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, string dt, string pp)
        {
            AirTicket ticket = new AirTicket(flightNumber, from, to, airline, dt, pp);

            string result = this.AddTicket(ticket);
            if (result.Contains("created"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string nnn)
        {
            AirTicket ticket = new AirTicket(nnn);

            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }
            return result;
        }

        public string AddTrainTicket(string from, string to, string dt, string pp, string studentpp)
        {
            TrainTicket ticket = new TrainTicket(from, to, dt, pp, studentpp);

            string result = this.AddTicket(ticket);
            if (result.Contains("created"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        string DeleteTrainTicket(string from, string to, string dt)
        {
            TrainTicket ticket = new TrainTicket(from, to, dt);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }
            return result;
        }

        protected string AddBusTicket(string from, string to, string companyName, string dt, string pp)
        {
            BusTicket ticket = new BusTicket(from, to, companyName, dt, pp);
            string key = ticket.property2;
            string result;

            if (this.ticketsByKey.ContainsKey(key))
            {
                result = "Duplicated " + ticket.Type.ToLower();
            }
            else
            {
                this.ticketsByKey.Add(key, ticket);
                string fromToKey = ticket.FromToKey;

                this.ticketsByFromTo.Add(fromToKey, ticket);
                this.ticketsByDateTime.Add(ticket.DateAndTime, ticket);
                result = ticket.Type + " created";
            }

            if (result.Contains("created"))
            {
                this.busTicketsCount++;
            }
            return result;
        }

        private string DeleteBusTicket(string from, string to, string ccc, string dt)
        {
            BusTicket ticket = new BusTicket(from, to, ccc, dt);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }
            return result;
        }

        public static string ReadTickets(ICollection<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);

            sortedTickets.Sort();
            string result = "";

            //PERFORMANCE
            return string.Join(" ", sortedTickets);
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = Ticket.CreateFromToKey(from, to);

            if (this.ticketsByFromTo.ContainsKey(fromToKey))
            {

                // Performance:
                var ticketsFound = this.ticketsByFromTo[fromToKey];

                string ticketsAsString = ReadTickets(ticketsFound);

                return ticketsAsString;
            }
            else
            {
                return "No matches";
            }
        }

        public string findTicketsInInterval(string startDateTimeStr, string endDateTimeStr)
        {
            DateTime startDateTime = Ticket.ParseDateTime(startDateTimeStr);

            DateTime endDateTime = Ticket.ParseDateTime(endDateTimeStr);

            string ticketsAsString = this.FindTicketsInInterval(startDateTime, endDateTime);
            return ticketsAsString;
        }

        public string FindTicketsInInterval2(DateTime startDateTime, DateTime endDateTime)
        {
            //var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;

            var ticketsFound =
                this.ticketsByDateTime.Values.Where(t => t.DateAndTime >= startDateTime)
                    .Where(t => t.DateAndTime <= endDateTime)
                    .ToList();

            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = ReadTickets(ticketsFound);
                return ticketsAsString;
            }
            else
            {
                return "No matches";
            }
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            // Do not toch! It work!!! I spend 10 hours of fix buggy here
            var ticketsFound = this.ticketsByDateTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = ReadTickets(ticketsFound);

                return ticketsAsString;
            }
            else
            {
                return "No matches";
            }
        }

        public string CommandExecutor(string line)
        {
            if (line == "")
            {
                return null;
            }

            int firstSpaceIndex = line.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string cd = line.Substring(0, firstSpaceIndex);
            string cd2 = "Invalid command!";
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            switch (cd)
            {
                case "CreateFlight":
                   
                    cd2 = this.AddAirTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3],
                        parameters[4],
                        parameters[5]);
                    break;
                case "DeleteFlight":
                    cd2 = this.DeleteAirTicket(parameters[0]);
                    break;
                case "CreateTrain":
                    cd2 = this.AddTrainTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;
                case "DeleteTrain":
                    cd2 = this.DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                    break;
                case "CreateBus":
                    cd2 = this.AddBusTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;
                case "DeleteBus":
                    cd2 = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
                    break;
                case "FindTickets":
                    cd2 = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindByDates":
                    cd2 = this.findTicketsInInterval(parameters[0], parameters[1]);
                    break;
            }
            return cd2;
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price)
        {
            return this.AddAirTicket(flightNumber, from, to, airline, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
        }

        string ITicketRepository.DeleteAirTicket(string nnn)
        {
            return this.DeleteAirTicket(nnn);
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            return this.AddTrainTicket(
                from,
                to,
                dateTime.ToString("dd.MM.yyyy HH:mm"),
                price.ToString(),
                studentPrice.ToString());
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            return this.DeleteTrainTicket(from, to, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public string AddBusTicket(string from, string to, string companyName, DateTime dateTime, decimal price)
        {
            return this.AddBusTicket(from, to, companyName, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
        }

        public string DeleteBusTicket(string from, string to, string ccc, DateTime dateTime)
        {
            return this.DeleteBusTicket(from, to, ccc, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public int GetTicketsCount(TicketType type)
        {
            switch (type)
            {
                case TicketType.Flight:
                    return this.airTicketsCount;
                case TicketType.Bus:
                    return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }
    }
}