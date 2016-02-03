namespace TravelAgency
{
    using System.Globalization;
    using System.Threading;

    using Core;
    using Data;
    using Interfaces;
    using UserInterface;

    public class TicketCatalogMain
    {
        public static void Main()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";

            Thread.CurrentThread.CurrentCulture = culture;

            TicketCatalog ticketCatalog = new TicketCatalog();
            IUserInterface userInterface = new ConsoleUserInterface();
            IEngine engine = new TicketCatalogEngine(ticketCatalog, userInterface);

            engine.Run();
        }
    }
}