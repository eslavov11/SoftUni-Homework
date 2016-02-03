namespace TicketOffice.Models.Tickets
{
    using System;

    public class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string ccc, string dt, string pp)
        {
            this.From = from;
            this.To = to;
            this.Company = ccc;
            DateTime dateAndTime = ParseDateTime(dt);

            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);
            this.Price = price;
        }

        public BusTicket(string from, string to, string ccc, string dt)
        {
            this.From = from;
            this.To = to;
            this.Company = ccc;

            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
        }

        public override string Type
        {
            get
            {
                return "Bus";
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