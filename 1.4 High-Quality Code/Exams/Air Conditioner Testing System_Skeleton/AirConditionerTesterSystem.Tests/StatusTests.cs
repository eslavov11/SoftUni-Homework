namespace AirConditionerTesterSystem.Tests
{
    using AirConditionerTesterSystem.Execution;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatusTests
    {
        [TestMethod]
        public void TestStatus_NoAirConditioners_TestedAirConditionersPercentageShouldBeZero()
        {
            var commandExecutor = new CommandExecutor();

            var message = commandExecutor.Status();
            var expectedMessage = "Jobs complete: 0.00%";

            Assert.AreEqual(expectedMessage, message, "Status should be zero percent.");
        }

        [TestMethod]
        public void TestStatus_OneAirConditionerNoReports_TestedAirConditionersPercentageShouldBeZero()
        {
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterCarAirConditioner("Toshiba", "B50", 9);
            var message = commandExecutor.Status();
            var expectedMessage = "Jobs complete: 0.00%";

            Assert.AreEqual(expectedMessage, message, "Status should be zero percent.");
        }

        [TestMethod]
        public void TestStatus_TestedAirConditioner_TestedAirConditionersPercentageShouldBeOneHundred()
        {
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterCarAirConditioner("Toshiba", "B50", 9);
            commandExecutor.TestAirConditioner("Toshiba", "B50");
            var message = commandExecutor.Status();
            var expectedMessage = "Jobs complete: 100.00%";

            Assert.AreEqual(expectedMessage, message, "Status should be zero percent.");
        }

        [TestMethod]
        public void TestStatus_OneUntestedAirConditioner_TestedAirConditionersPercentageShouldBeFifty()
        {
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterCarAirConditioner("Toshiba", "B50", 9);
            commandExecutor.RegisterCarAirConditioner("Toshiba2", "B50", 9);
            commandExecutor.TestAirConditioner("Toshiba", "B50");
            var message = commandExecutor.Status();
            var expectedMessage = "Jobs complete: 50.00%";

            Assert.AreEqual(expectedMessage, message, "Status should be zero percent.");
        }

        [TestMethod]
        public void TestStatus_OneUntestedOfThreeAirConditioners_OutputShouldBeRoundedTwoDecimalPlaces()
        {
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterCarAirConditioner("Toshiba", "B50", 9);
            commandExecutor.RegisterCarAirConditioner("Toshiba2", "B50", 9);
            commandExecutor.RegisterCarAirConditioner("Toshiba3", "B50", 9);
            commandExecutor.TestAirConditioner("Toshiba", "B50");
            commandExecutor.TestAirConditioner("Toshiba2", "B50");
            var message = commandExecutor.Status();
            var expectedMessage = "Jobs complete: 66.67%";

            Assert.AreEqual(expectedMessage, message, "Status should be zero percent.");
        }
    }
}
