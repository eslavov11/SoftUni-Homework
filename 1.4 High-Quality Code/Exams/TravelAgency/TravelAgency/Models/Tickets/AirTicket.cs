namespace TravelAgency.Models.Tickets
{
    public class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string from, string to, string airline, string dateAndTime, string price)
        {
            this.FlightNumber = flightNumber;
            this.From = from;
            this.To = to;
            this.Company = airline;
            this.DateAndTime = Ticket.ParseDateTime(dateAndTime);
            this.Price = decimal.Parse(price);
        }

        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
        }

        public string FlightNumber { get; set; }

        public override string Type
        {
            get
            {
                return "air";
            }
        }

        public override string Key
        {
            get
            {
                return this.Type + ";;" + this.FlightNumber;
            }
        }
    }
}