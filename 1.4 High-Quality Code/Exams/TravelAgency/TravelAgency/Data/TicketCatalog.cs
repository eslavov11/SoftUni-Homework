namespace TravelAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Enums;
    using Interfaces;
    using Models.Tickets;
    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly Dictionary<string, Ticket> ticketsByKey;
        private readonly MultiDictionary<string, Ticket> ticketsByFromTo;
        private readonly OrderedMultiDictionary<DateTime, Ticket> ticketsByDateTime;
        private int airTicketsCount;
        private int busTicketsCount;
        private int trainTicketsCount;

        public TicketCatalog()
        {
            this.ticketsByKey = new Dictionary<string, Ticket>();
            this.ticketsByFromTo = new MultiDictionary<string, Ticket>(true);
            this.ticketsByDateTime = new OrderedMultiDictionary<DateTime, Ticket>(true);
        }

        public static string ReadTickets(IEnumerable<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);

            sortedTickets.Sort();
            string result = string.Empty;

            // PERFORMANCE: Unnecessary loop
            return string.Join(" ", sortedTickets);
        }

        public int GetTicketsCount(string type)
        {
            var typeName = type[0].ToString().ToUpper() + type.Substring(1, type.Length);
            TicketType ticketType = (TicketType)Enum.Parse(typeof(TicketType), typeName);

            switch (ticketType)
            {
                case TicketType.Air:
                    return this.airTicketsCount;
                case TicketType.Bus:
                    return this.busTicketsCount;
                case TicketType.Train:
                    return this.trainTicketsCount;
                default:
                    return default(int);
            }
        }

        public string AddTicket(Ticket ticket)
        {
            string key = ticket.Key;
            if (this.ticketsByKey.ContainsKey(key))
            {
                return "Duplicate ticket";
            }

            this.ticketsByKey.Add(key, ticket);
            string fromToKey = ticket.FromToKey;
            this.ticketsByFromTo.Add(fromToKey, ticket);
            this.ticketsByDateTime.Add(ticket.DateAndTime, ticket);

            return "Ticket added";
        }

        public string DeleteTicket(Ticket ticket)
        {
            string key = ticket.Key;
            if (!this.ticketsByKey.ContainsKey(key))
            {
                return "Ticket does not exist";
            }

            ticket = this.ticketsByKey[key];
            this.ticketsByKey.Remove(key);
            string fromToKey = ticket.FromToKey;
            this.ticketsByFromTo.Remove(fromToKey, ticket);
            this.ticketsByDateTime.Remove(ticket.DateAndTime, ticket);

            return "Ticket deleted";
        }

        public string AddAirTicket(
            string flightNumber,
            string from,
            string to,
            string airline,
            string dateTime,
            string price)
        {
            AirTicket ticket = new AirTicket(flightNumber, from, to, airline, dateTime, price);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            AirTicket ticket = new AirTicket(flightNumber);

            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, string dateTime, string price, string studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateTime, price, studentPrice);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string from, string to, string dateTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateTime);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(string from, string to, string travelCompany, string dateTime, string price)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateTime, price);

            if (this.ticketsByKey.ContainsKey(ticket.Key))
            {
                return "Duplicate ticket";
            }

            this.ticketsByKey.Add(ticket.Key, ticket);
            string fromToKey = ticket.FromToKey;
            this.ticketsByFromTo.Add(fromToKey, ticket);
            this.ticketsByDateTime.Add(ticket.DateAndTime, ticket);
            this.busTicketsCount++;

            return "Ticket added";
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, string dateTime)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateTime);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = Ticket.CreateFromToKey(from, to);
            if (!this.ticketsByFromTo.ContainsKey(fromToKey))
            {
                return "Not found";
            }
            
            var ticketsFound = this.ticketsByFromTo[fromToKey];

            // PERFORMANCE: Dictionary was searched with foreach, instead of by key, which is way more faster
            // operation.
            string ticketsAsString = ReadTickets(ticketsFound);

            return ticketsAsString;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            // Do not toch! It work!!! I spend 10 hours of fix buggy here
            var ticketsFound = this.ticketsByDateTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count <= 0)
            {
                return "Not found";
            }

            string ticketsAsString = ReadTickets(ticketsFound);

            return ticketsAsString;
        }

        public string AddAirTicket(
            string flightNumber,
            string from,
            string to,
            string airline,
            DateTime dateTime,
            decimal price)
        {
            return this.AddAirTicket(flightNumber, from, to, airline, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
        }

        string ITicketCatalog.DeleteAirTicket(string flightNumber)
        {
            return this.DeleteAirTicket(flightNumber);
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

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            return this.AddBusTicket(
                from,
                to,
                travelCompany,
                dateTime.ToString("dd.MM.yyyy HH:mm"),
                price.ToString());
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            return this.DeleteBusTicket(from, to, travelCompany, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public int GetTicketsCount(TicketType type)
        {
            switch (type)
            {
                case TicketType.Air:
                    return this.airTicketsCount;
                case TicketType.Bus:
                    return this.busTicketsCount;
                case TicketType.Train:
                    return this.trainTicketsCount;
                default:
                    return default(int);
            }
        }
    }
}