namespace NightlifeEntertainment
{
    public class VIPTicket : Ticket
    {
        public VIPTicket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            return base.Performance.BasePrice * 1.5m;
        }
    }
}
