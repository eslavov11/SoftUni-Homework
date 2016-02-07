namespace AirConditionerTesterSystem.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AirConditionerTesterSystem.Exceptions;
    using AirConditionerTesterSystem.Interfaces;
    using AirConditionerTesterSystem.Models.AirConditioners.VehicleAirConditioners;

    using Data;
    using Models;
    using Models.AirConditioners;
    using Utility;

    public class CommandExecutor
    {
        private readonly IDatabase database;
        private Command command;
        private string commandMessage;

        public CommandExecutor()
        {
            this.database = new AirConditionerTesterSystemData();
        }

        public CommandExecutor(IDatabase database)
        {
            this.database = database;
        }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public string Execute(Command engineCommand)
        {
            this.command = engineCommand;

            switch (this.command.Name)
            {
                case "RegisterStationaryAirConditioner":
                    this.ValidateParametersCount(4);
                    this.commandMessage = this.RegisterStationaryAirConditioner(
                        this.command.Parameters[0],
                        this.command.Parameters[1],
                        this.command.Parameters[2],
                        int.Parse(this.command.Parameters[3]));
                    break;
                case "RegisterCarAirConditioner":
                    this.ValidateParametersCount(3);
                    this.commandMessage = this.RegisterCarAirConditioner(
                        this.command.Parameters[0],
                        this.command.Parameters[1],
                        int.Parse(this.command.Parameters[2]));
                    break;
                case "RegisterPlaneAirConditioner":
                    this.ValidateParametersCount(4);
                    this.commandMessage = this.RegisterPlaneAirConditioner(
                        this.command.Parameters[0],
                        this.command.Parameters[1],
                        int.Parse(this.command.Parameters[2]),
                        this.command.Parameters[3]);
                    break;
                case "TestAirConditioner":
                    this.ValidateParametersCount(2);
                    this.commandMessage = this.TestAirConditioner(
                        this.command.Parameters[0],
                        this.command.Parameters[1]);
                    break;
                case "FindAirConditioner":
                    this.ValidateParametersCount(2);
                    this.commandMessage = this.FindAirConditioner(
                        this.command.Parameters[0],
                        this.command.Parameters[1]);
                    break;
                case "FindReport":
                    this.ValidateParametersCount(2);
                    this.commandMessage = this.FindReport(this.command.Parameters[0], this.command.Parameters[1]);
                    break;
                case "Status":
                    this.ValidateParametersCount(0);
                    this.commandMessage = this.Status();
                    break;
                case "FindAllReportsByManufacturer":
                    this.ValidateParametersCount(1);
                    this.commandMessage = this.FindAllReportsByManufacturer(this.command.Parameters[0]);
                    break;
                default:
                    throw new ArgumentException(Constants.InvalidCommand);
            }

            return this.commandMessage;
        }

        public string RegisterStationaryAirConditioner(
            string manufacturer,
            string model, 
            string energyEfficiencyRating,
            int powerUsage)
        {
            AirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);

            if (this.Database.AirConditioners.Any(ac => ac.Manufacturer == manufacturer && ac.Model == model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            this.Database.AddAirConditioner(airConditioner);

            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            AirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);

            if (this.Database.AirConditioners.Any(ac => ac.Manufacturer == manufacturer && ac.Model == model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            this.Database.AddAirConditioner(airConditioner);

            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }

        /// <summary>
        /// Registers plane air conditioner to the database.
        /// </summary>
        /// <param name="manufacturer">The air conditioner manufacturer.</param>
        /// <param name="model">The air conditioner model.</param>
        /// <param name="volumeCoverage">The air conditioner volume coverage.</param>
        /// <param name="electricityUsed">The air conditioner electricity used.</param>
        /// <returns>Message whether the air conditioner was registered successfuly 
        /// or throws exception if error occures.</returns>
        /// <exception cref="DuplicateEntryException">An entry for the given model already exists.</exception>
        public string RegisterPlaneAirConditioner(
            string manufacturer,
            string model,
            int volumeCoverage,
            string electricityUsed)
        {
            AirConditioner airConditioner = new PlaneAirConditioner(
                manufacturer, model, volumeCoverage, electricityUsed);

            if (this.Database.AirConditioners.Any(ac => ac.Manufacturer == manufacturer && ac.Model == model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            this.Database.AddAirConditioner(airConditioner);

            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }

        public virtual string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.Database.GetAirConditioner(manufacturer, model);

            if (airConditioner == null)
            {
                throw new NonExistantEntryException(Constants.NonExistandEntry);
            }

            if (this.Database.Reports.Any(report => report.Manufacturer == manufacturer && 
                report.Model == airConditioner.Model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            airConditioner.Test();
            var hasPassedTest = airConditioner.HasPassedTest;
            this.Database.AddReport(new Report(airConditioner.Manufacturer, airConditioner.Model, hasPassedTest));

            return string.Format(Constants.Test, model, manufacturer);
        }

        /// <summary>
        /// Finds the air conditioner by manufacturer and model.
        /// </summary>
        /// <param name="manufacturer">The air conditioner manufacturer.</param>
        /// <param name="model">The air conditioner model.</param>
        /// <returns>The air conditioner as string.</returns>
        /// <exception cref="NonExistantEntryException">Thrown if there is no such air conditioner.</exception>
        public string FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.Database.GetAirConditioner(manufacturer, model);

            if (airConditioner == null)
            {
                throw new NonExistantEntryException(Constants.NonExistandEntry);
            }

            return airConditioner.ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            IReport report = this.Database.GetReport(manufacturer, model);

            if (report == null)
            {
                throw new NonExistantEntryException(Constants.NonExistandEntry);
            }

            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            var reports = this.Database.GetReportsByManufacturer(manufacturer).ToList();

            if (reports.Count == 0)
            {
                return Constants.NoReports;
            }

            reports = reports.OrderBy(report => report.Model).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));

            return reportsPrint.ToString();
        }

        /// <summary>
        /// Calculates the percentage of tested air conditioners.
        /// </summary>
        /// <returns>The percentage of tested air conditioners as string.</returns>
        public string Status()
        {
            int reports = this.Database.GetReportsCount();
            double airConditioners = this.Database.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;

            if (double.IsNaN(percent))
            {
                percent = 0;
            }

            return string.Format(Constants.Status, percent);
        }

        private void ValidateParametersCount(int count)
        {
            if (this.command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }
    }
}
