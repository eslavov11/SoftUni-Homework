namespace AirConditionerTesterSystem.Interfaces
{
    using System.Collections.Generic;

    using AirConditionerTesterSystem.Models.AirConditioners;

    public interface IDatabase
    {
        HashSet<AirConditioner> AirConditioners { get; set; }

        HashSet<IReport> Reports { get; set; }

        void AddAirConditioner(AirConditioner airConditioner);

        void RemoveAirConditioner(AirConditioner airConditioner);

        AirConditioner GetAirConditioner(string manufacturer, string model);

        int GetAirConditionersCount();

        void AddReport(IReport report);

        void RemoveReport(IReport report);

        IReport GetReport(string manufacturer, string model);

        int GetReportsCount();

        HashSet<IReport> GetReportsByManufacturer(string manufacturer);
    }
}
