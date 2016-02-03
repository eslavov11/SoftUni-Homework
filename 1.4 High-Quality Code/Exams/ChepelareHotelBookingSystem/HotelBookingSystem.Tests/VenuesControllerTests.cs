namespace HotelBookingSystem.Tests
{
    using System;
    using System.Linq;
    using System.Security.Policy;

    using ChepelareHotelBookingSystem.Controllers;
    using ChepelareHotelBookingSystem.Data;
    using ChepelareHotelBookingSystem.Enums;
    using ChepelareHotelBookingSystem.Models;
    using ChepelareHotelBookingSystem.Utilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VenuesControllerTests
    {
        [TestMethod]
        public void TestAll_InitializeValidVenues_ViewShouldNotBeNull()
        {
            // Arrange
            var owner = new User("shefa", "mnMiELud123", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            data.RepositoryWithVenues.Add(new Venue("Hotel1", "SOfia", "Nope", owner));
            data.RepositoryWithVenues.Add(new Venue("Hotel2", "Plovdiv", "AbeImaNqkvo", null));
            data.RepositoryWithVenues.Add(new Venue("Hotel3", "Vraca", "NeMoaGonamerq", owner));

            // Act
            var view = new VenuesController(data, owner).All().Display();

            // Assert
            Assert.IsNotNull(view, "Venues view should not be null.");
        }

        [TestMethod]
        public void TestAll_InitializeNoVenues_ViewShouldHaveNoVenues()
        {
            // Arrange
            var owner = new User("shefa", "mnMiELud123", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, owner);

            // Act
            var view = controller.All().Display();

            // Assert
            Assert.AreEqual("There are currently no venues to show.", view);
        }

        [TestMethod]
        public void TestAll_InitializeOneVenue_ViewShouldBeEqual()
        {
            // Arrange
            string expected = "*[1] Hotel1, located at SOfia" + 
                Environment.NewLine + 
                "Free rooms: 0";
            var owner = new User("shefa", "mnMiELud123", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            data.RepositoryWithVenues.Add(new Venue("Hotel1", "SOfia", "Nope", owner));

            // Act
            var view = new VenuesController(data, owner).All().Display();

            // Assert
            Assert.AreEqual(expected, view);
        }
    }
}
