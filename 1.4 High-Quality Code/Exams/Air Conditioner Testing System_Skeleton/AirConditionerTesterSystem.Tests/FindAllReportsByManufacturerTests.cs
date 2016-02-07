namespace AirConditionerTesterSystem.Tests
{
    using System;
    using System.Linq;
    using System.Text;

    using AirConditionerTesterSystem.Execution;
    using AirConditionerTesterSystem.Utility;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindAllReportsByManufacturerTests
    {
        [TestMethod]
        public void TestFindAllReportsByManufacturer_NoReports_ShouldReturnNoReportsMessage()
        {
            var commandExecutor = new CommandExecutor();

            var message = commandExecutor.FindAllReportsByManufacturer("Toshiba");

            Assert.AreEqual("No reports.", message);
        }

        [TestMethod]
        public void TestFindAllReportsByManufacturer_OneReport_ShouldReturnProperReport()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
            commandExecutor.TestAirConditioner(Manufacturer, Model);
            var report = commandExecutor.FindAllReportsByManufacturer("Toshiba");
            var mark = commandExecutor.Database.AirConditioners.First().HasPassedTest ? "Passed" : "Failed";
            var expectedReport = new StringBuilder();
            expectedReport.AppendFormat("Reports from {0}:", Manufacturer)
                .AppendLine()
                .AppendLine("Report")
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Manufacturer: " + Manufacturer)
                .AppendLine("Model: " + Model)
                .AppendLine("Mark: " + mark)
                .Append(Constants.ReportDelimiter);

            Assert.AreEqual(expectedReport.ToString(), report);
        }

        [TestMethod]
        public void TestFindAllReportsByManufacturer_MultipleReports_ShouldReturnProperReports()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Model2 = "Z6000";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model2, Rating, PowerUsage);
            commandExecutor.TestAirConditioner(Manufacturer, Model);
            commandExecutor.TestAirConditioner(Manufacturer, Model2);
            var reports = commandExecutor.FindAllReportsByManufacturer("Toshiba");
            var mark = commandExecutor.Database.AirConditioners.First().HasPassedTest ? "Passed" : "Failed";
            var expectedReport = new StringBuilder();
            expectedReport.AppendFormat("Reports from {0}:", Manufacturer)
                .AppendLine()
                .AppendLine("Report")
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Manufacturer: " + Manufacturer)
                .AppendLine("Model: " + Model)
                .AppendLine("Mark: " + mark)
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Report")
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Manufacturer: " + Manufacturer)
                .AppendLine("Model: " + Model2)
                .AppendLine("Mark: " + mark)
                .Append(Constants.ReportDelimiter);
               
            Assert.AreEqual(expectedReport.ToString(), reports, "Reports are not equal.");
        }

        [TestMethod]
        public void TestFindAllReportsByManufacturer_MultipleReports_ShouldOrderByModel()
        {
            const string Manufacturer = "Toshiba";
            const string Model = "Z550";
            const string Model2 = "A6000";
            const string Rating = "A";
            const int PowerUsage = 20;
            var commandExecutor = new CommandExecutor();

            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model, Rating, PowerUsage);
            commandExecutor.RegisterStationaryAirConditioner(Manufacturer, Model2, Rating, PowerUsage);
            commandExecutor.TestAirConditioner(Manufacturer, Model);
            commandExecutor.TestAirConditioner(Manufacturer, Model2);
            var reports = commandExecutor.FindAllReportsByManufacturer("Toshiba");
            var mark = commandExecutor.Database.AirConditioners.First().HasPassedTest ? "Passed" : "Failed";
            var expectedReport = new StringBuilder();
            expectedReport.AppendFormat("Reports from {0}:", Manufacturer)
                .AppendLine()
                .AppendLine("Report")
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Manufacturer: " + Manufacturer)
                .AppendLine("Model: " + Model2)
                .AppendLine("Mark: " + mark)
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Report")
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Manufacturer: " + Manufacturer)
                .AppendLine("Model: " + Model)
                .AppendLine("Mark: " + mark)
                .Append(Constants.ReportDelimiter);

            Assert.AreEqual(expectedReport.ToString(), reports, "Reports are not ordered by model.");
        }
    }
}
