namespace AirConditionerTesterSystem.Tests
{
    using AirConditionerTesterSystem.Data;
    using AirConditionerTesterSystem.Execution;
    using AirConditionerTesterSystem.Models.AirConditioners.VehicleAirConditioners;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class TestAirConditionerTests
    {
        // [TestMethod]
        public void TestTestAirController_ValidData_ShouldReturnSuccessMessage()
        {
            var carAirConditioner = new CarAirConditioner("Toshiba", "Z99", 9);
            var mockedData = new Mock<AirConditionerTesterSystemData>();
            mockedData.Setup(data => data.GetAirConditioner(null, null))
                .Returns(carAirConditioner);

            var commandExecutor = new CommandExecutor(mockedData.Object);
            var message = commandExecutor.TestAirConditioner(null, null);
            var expectedMessage = "Air Conditioner model Z99 from Toshiba tested successfully.";

            // throw new OutOfTimeException
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
