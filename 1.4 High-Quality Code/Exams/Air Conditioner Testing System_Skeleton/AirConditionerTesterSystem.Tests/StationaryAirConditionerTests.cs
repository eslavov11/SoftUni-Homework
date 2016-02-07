namespace AirConditionerTesterSystem.Tests
{
    using System;
    using System.Linq;

    using AirConditionerTesterSystem.Enums;
    using AirConditionerTesterSystem.Exceptions;
    using AirConditionerTesterSystem.Execution;
    using AirConditionerTesterSystem.Models.AirConditioners;
    using AirConditionerTesterSystem.Utility;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StationaryAirConditionerTests
    {
        // var stationaryAirConditioner = new StationaryAirConditioner("Toshiba", "Z550", "A", 20);
        [TestMethod]
        public void TestStationaryAirConditioner_SingleAirConditioner_ShouldReturnSuccessMessage()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();
            var expectedMessage = string.Format(Constants.Register, Model, Manufacturer);

            var message = commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);

            Assert.AreEqual(expectedMessage, message, "Messages differ.");
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void TestStationaryAirConditioner_DuplicateAirConditioner_ShouldThrow()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;

            var commandExecutor = new CommandExecutor();
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStationaryAirConditioner_IncorrectEfficiencyRating_ShouldThrow()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string IncorrectRating = "Z";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, IncorrectRating, PowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStationaryAirConditioner_InvalidManufacturerName_ShouldThrow()
        {
            string incorrectManufacturer = new string('A', Constants.ManufacturerMinLength - 1);
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();
            commandExecutor.RegisterStationaryAirConditioner(incorrectManufacturer, Model, Rating, PowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStationaryAirConditioner_InvalidModelName_ShouldThrow()
        {
            const string Manufacturer = "Toshiba";
            string incorrectModel = new string('A', Constants.ModelMinLength - 1);
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, incorrectModel, Rating, PowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStationaryAirConditioner_ZeroPowerUsage_ShouldThrow()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "Z";
            const int PowerUsage = 0;
            var commandExecutor = new CommandExecutor();
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStationaryAirConditioner_NegativePowerUsage_ShouldThrow()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "Z";
            const int PowerUsage = -1;
            var commandExecutor = new CommandExecutor();
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
        }

        [TestMethod]
        public void TestStationaryAirConditioner_SingleAirConditioner_AirConditionersCountShouldBeOne()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);

            Assert.AreEqual(
                1, 
                commandExecutor.Database.AirConditioners.Count,
                "Manufacturers differ.");
        }

        [TestMethod]
        public void TestStationaryAirConditioner_SingleAirConditioner_ManufacturersShouldBeEqual()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);

            Assert.AreEqual(
                Manufacturer, 
                commandExecutor.Database.AirConditioners.First().Manufacturer,
                "Manufacturers differ.");
        }

        [TestMethod]
        public void TestStationaryAirConditioner_SingleAirConditioner_ModelsShouldBeEqual()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);

            Assert.AreEqual(
                Model, 
                commandExecutor.Database.AirConditioners.First().Model,
                "Models differ.");
        }

        [TestMethod]
        public void TestStationaryAirConditioner_SingleAirConditioner_RatingsShouldBeEqual()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
            var expectedRaiting = (int)Enum.Parse(typeof(EnergyEfficiencyRating), Rating);

            Assert.AreEqual(
                expectedRaiting,
                (commandExecutor.Database.AirConditioners.First() as StationaryAirConditioner).EnergyRating,
                "Ratings differ.");
        }

        [TestMethod]
        public void TestStationaryAirConditioner_SingleAirConditioner_PowerUsageShouldBeEqual()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);

            Assert.AreEqual(
                PowerUsage,
                (commandExecutor.Database.AirConditioners.First() as StationaryAirConditioner).PowerUsage,
                "Power usages differ.");
        }
    }
}
