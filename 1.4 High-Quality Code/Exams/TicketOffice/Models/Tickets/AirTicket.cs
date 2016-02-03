namespace TicketOffice.Models.Tickets
{
    using System;

    public class AirTicket : Ticket
    {
        public string nnn { get; set; }

        public AirTicket(string nnn, string from, string to, string airline, string dt, string pp)
        {
            this.nnn = nnn;
            this.From = from;
            this.To = to;

            this.Company = airline;
            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);
            this.Price = price;
        }

        public AirTicket(string nnn)
        {
            this.nnn = nnn;
        }

        public override string Type
        {
            get
            {
                return "Flight";
            }
        }

        public override string property2
        {
            get
            {
                return this.Type + ";;" + this.nnn;
            }
        }
    }
}