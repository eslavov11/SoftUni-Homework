namespace TravelAgency.Models.Tickets
{
    using System;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, string dt, string pp, string studentpp)
        {
            this.From = from;
            this.To = to;
            DateTime dateAndTime = ParseDateTime(dt);

            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);

            this.Price = price;
            decimal studentPrice = decimal.Parse(studentpp);

            this.StudentPrice = studentPrice;
        }

        public TrainTicket(string from, string to, string dt)
        {
            this.From = from;
            this.To = to;
            DateTime dateAndTime = ParseDateTime(dt);

            this.DateAndTime = dateAndTime;
        }

        public decimal StudentPrice { get; set; }

        public override string Type
        {
            get
            {
                return "train";
            }
        }

        public override string Key
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
            }
        }
    }
}