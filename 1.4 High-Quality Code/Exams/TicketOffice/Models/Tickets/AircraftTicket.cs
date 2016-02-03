namespace TicketOffice.Models.Tickets
{
    using System;

    public class AircraftTicket : Ticket
    {
        public AircraftTicket(string from, string to, string boatCompany, string dt, string pp)
        {
            this.From = from;
            this.To = to;
            this.Company = boatCompany;
            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);
            this.Price = price;
        }

        public override string Type
        {
            get
            {
                return "aircraft";
            }
        }

        public override string property2
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
            }
        }
    }
}