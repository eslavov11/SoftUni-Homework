namespace AirConditionerTesterSystem.Models
{
    using System.Data;
    using System.Text;
    using AirConditionerTesterSystem.Interfaces;
    using AirConditionerTesterSystem.Utility;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, bool hasPassedTest)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.HasPassedTest = hasPassedTest;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public bool HasPassedTest { get; set; }

        public override string ToString()
        {
            string mark = string.Empty;
            if (this.HasPassedTest)
            {
                mark = "Passed";
            }
            else if (!this.HasPassedTest)
            {
                mark = "Failed";
            }

            var result = new StringBuilder();

            result.AppendLine("Report")
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Manufacturer: " + this.Manufacturer)
                .AppendLine("Model: " + this.Model)
                .AppendLine("Mark: " + mark)
                .Append(Constants.ReportDelimiter);

            return result.ToString();
        }
    }
}
