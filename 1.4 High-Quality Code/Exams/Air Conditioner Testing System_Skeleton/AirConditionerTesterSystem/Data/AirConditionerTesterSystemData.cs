namespace AirConditionerTesterSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models.AirConditioners;

    public class AirConditionerTesterSystemData : IDatabase
    {
        public AirConditionerTesterSystemData()
        {
            this.AirConditioners = new HashSet<AirConditioner>();
            this.Reports = new HashSet<IReport>();
            this.ReportsByManufacturer = new Dictionary<string, HashSet<IReport>>();
            this.AirConditionersByManufacturer = new Dictionary<string, HashSet<AirConditioner>>();
        }

        public HashSet<AirConditioner> AirConditioners { get; set; }

        public HashSet<IReport> Reports { get;  set; }

        public IDictionary<string, HashSet<IReport>> ReportsByManufacturer { get; set; }

        public IDictionary<string, HashSet<AirConditioner>> AirConditionersByManufacturer { get; set; }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            this.AirConditioners.Add(airConditioner);

            if (!this.AirConditionersByManufacturer.ContainsKey(airConditioner.Manufacturer))
            {
                this.AirConditionersByManufacturer.Add(airConditioner.Manufacturer, new HashSet<AirConditioner>());
            }

            this.AirConditionersByManufacturer[airConditioner.Manufacturer].Add(airConditioner);
        }

        public void RemoveAirConditioner(AirConditioner airConditioner)
        {
            this.AirConditioners.Remove(airConditioner);
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            if (!this.AirConditionersByManufacturer.ContainsKey(manufacturer))
            {
                return null;
            }

            // PERFORMANCE: Searching for air conditioner from list with linq(foreach)
            // replaced with dictionary.
            var airConditionerByManufacturer = this.AirConditionersByManufacturer[manufacturer];

            return airConditionerByManufacturer.FirstOrDefault(ac => ac.Model == model);
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditioners.Count;
        }

        public void AddReport(IReport report)
        {
            this.Reports.Add(report);

            if (!this.ReportsByManufacturer.ContainsKey(report.Manufacturer))
            {
                this.ReportsByManufacturer.Add(report.Manufacturer, new HashSet<IReport>());
            }

            this.ReportsByManufacturer[report.Manufacturer].Add(report);
        }

        public void RemoveReport(IReport report)
        {
            this.Reports.Remove(report);
        }

        public IReport GetReport(string manufacturer, string model)
        {
            if (!this.ReportsByManufacturer.ContainsKey(manufacturer))
            {
                return null;
            }
            
            var reportsByManufacturer = this.ReportsByManufacturer[manufacturer];

            return reportsByManufacturer.FirstOrDefault(report => report.Model == model);
        }

        public int GetReportsCount()
        {
            return this.Reports.Count;
        }

        public HashSet<IReport> GetReportsByManufacturer(string manufacturer)
        {
            if (!this.ReportsByManufacturer.ContainsKey(manufacturer))
            {
                return new HashSet<IReport>();
            }

            // PERFORMANCE: Searching for reports from list with linq(foreach)
            // replaced with dictionary.
            return this.ReportsByManufacturer[manufacturer];
        }
    }
}
