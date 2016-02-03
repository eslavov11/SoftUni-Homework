namespace TicketOffice.Models.Tickets
{
    using System;
    using System.Globalization;

    public abstract class Ticket : IComparable<Ticket>
    {
        public abstract string Type { get; }

        public virtual string From { get; set; }

        public virtual string To { get; set; }

        public virtual string Company { get; set; }

        public virtual DateTime DateAndTime { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal SpecialPrice { get; set; }

        public abstract string property2 { get; }

        public override string ToString()
        {
            string input = "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + "|" + this.Type.ToLower() + "|"
                           + String.Format("{0:f2}", this.Price) + "]";
            return input;
        }

        public string FromToKey
        {
            get
            {
                return CreateFromToKey(this.From, this.To);
            }
        }

        public static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }

        public static DateTime ParseDateTime(string dt)
        {
            DateTime result = DateTime.ParseExact(dt, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }

        public int CompareTo(Ticket otherTicket)
        {
            int nateeja = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (nateeja == 0)
            {
                nateeja = this.Type.CompareTo(otherTicket.Type);
            }
            if (nateeja == 0)
            {
                nateeja = this.Price.CompareTo(otherTicket.Price);
            }
            return nateeja;
        }
    }
}