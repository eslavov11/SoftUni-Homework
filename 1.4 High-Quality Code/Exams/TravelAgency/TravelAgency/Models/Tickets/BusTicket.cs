namespace TravelAgency.Models.Tickets
{
    using System;

    public class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string company, string dt, string pp)
        {
            this.From = from;
            this.To = to;
            this.Company = company;
            DateTime dateAndTime = ParseDateTime(dt);

            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);
            this.Price = price;
        }

        public BusTicket(string from, string to, string company, string dt)
        {
            this.From = from;
            this.To = to;
            this.Company = company;

            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
        }

        public override string Type
        {
            get
            {
                return "bus";
            }
        }

        public override string Key
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
            }
        }
    }
}