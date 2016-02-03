namespace TravelAgency.Interfaces
{
    using System;

    using TravelAgency.Enums;

    public interface ITicketCatalog
    {
        // TODO: document this method
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        // TODO: document this method
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        // TODO: document this method
        string FindTickets(string from, string to);

        // TODO: document this method
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}