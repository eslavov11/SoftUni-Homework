namespace TravelAgency.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TravelAgency.Data;
    using TravelAgency.Interfaces;

    [TestClass]
    public class TicketCatalogTests
    {
        [TestMethod]
        public void TestAddAirTicket_InitializaOne_ShouldReturnSuccessMessage()
        {
            ITicketCatalog ticketCatalog = new TicketCatalog();
            var result = ticketCatalog.AddAirTicket("01", "Varna", "Sofia", "Bulgaria", DateTime.Now, 120);

            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void TestAddAirTicket_InitializaDuplicates_ShouldReturnDuplicateMessage()
        {
            ITicketCatalog ticketCatalog = new TicketCatalog();
            ticketCatalog.AddAirTicket("01", "Varna", "Sofia", "Bulgaria", DateTime.Now, 120);
            var result = ticketCatalog.AddAirTicket("01", "Varna", "Sofia", "Bulgaria", DateTime.Now, 120);

            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void TestDeleteAirTicket_InitializaOne_ShouldReturnSuccessMessage()
        {
            ITicketCatalog ticketCatalog = new TicketCatalog();
            ticketCatalog.AddAirTicket("01", "Varna", "Sofia", "Bulgaria", DateTime.Now, 120);
            var message = ticketCatalog.DeleteAirTicket("01");

            Assert.AreEqual("Ticket deleted", message);
        }

        [TestMethod]
        public void TestDeleteAirTicket_InvalidTicket_ShouldReturnErrorMessage()
        {
            ITicketCatalog ticketCatalog = new TicketCatalog();
            var message = ticketCatalog.DeleteAirTicket("01");

            Assert.AreEqual("Ticket does not exist", message);
        }

        [TestMethod]
        public void TestDeleteAirTicket_AlreadyDeletedTicket_ShouldReturnErrorMessage()
        {
            ITicketCatalog ticketCatalog = new TicketCatalog();
            ticketCatalog.AddAirTicket("01", "Varna", "Sofia", "Bulgaria", DateTime.Now, 120);
            ticketCatalog.DeleteAirTicket("01");

            var message = ticketCatalog.DeleteAirTicket("01");

            Assert.AreEqual("Ticket does not exist", message);
        }
    }
}
