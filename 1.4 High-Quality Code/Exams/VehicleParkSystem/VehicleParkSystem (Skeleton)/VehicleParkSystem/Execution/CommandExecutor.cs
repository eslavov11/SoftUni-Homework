namespace VehicleParkSystem.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;

    public class CommandExecutor
    {
        public class Command : ICommand
        {
            public string Name { get; set; }

            public IDictionary<string, string> Parameters { get; set; }

            public Command(string commandLine)
            {
                this.Name = commandLine.Substring(0, commandLine.IndexOf(' '));
                this.Parameters =
                    new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(
                        commandLine.Substring(commandLine.IndexOf(' ') + 1));
            }
        }

        public VehiclePark VehiclePark { get; set; }

        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch (command.Name)
            {
                case "SetupPark":
                    this.VehiclePark = new VehiclePark(int.Parse(command.Parameters["sectors"]), int.Parse(command.Parameters["placesPerSector"]));
                    return "Vehicle park created";
                case "Park":
                    switch (command.Parameters["type"])
                    {
                        case "car":
                            return this.VehiclePark.InsertCar(
                                    new Car(
                                        command.Parameters["licensePlate"],
                                        command.Parameters["owner"],
                                        int.Parse(command.Parameters["hours"])),
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(
                                        command.Parameters["time"],
                                        null,
                                        System.Globalization.DateTimeStyles.RoundtripKind)); //why round trip kind??
                        case "motorbike":
                            return this.VehiclePark.InsertMotorbike(
                                    new Motorbike(
                                        command.Parameters["licensePlate"],
                                        command.Parameters["owner"],
                                        int.Parse(command.Parameters["hours"])),
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(
                                        command.Parameters["time"],
                                        null,
                                        System.Globalization.DateTimeStyles.RoundtripKind)); //stack overflow says this
                        case "truck":
                            return this.VehiclePark.InsertTruck(
                                    new Truck(
                                        command.Parameters["licensePlate"],
                                        command.Parameters["owner"],
                                        int.Parse(command.Parameters["hours"])),
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(
                                        command.Parameters["time"],
                                        null,
                                        System.Globalization.DateTimeStyles.RoundtripKind)); //I wanna know
                    }
                    break;

                case "Exit":
                    return this.VehiclePark.ExitVehicle(
                        command.Parameters["licensePlate"],
                        DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind),
                        decimal.Parse(command.Parameters["paid"]));
                case "Status":
                    return this.VehiclePark.GetStatus();
                case "FindVehicle":
                    return this.VehiclePark.FindVehicleByLincensePlate(command.Parameters["licensePlate"]);
                case "VehiclesByOwner":
                    return this.VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);
                default:
                    throw new IndexOutOfRangeException("Invalid command.");
            }

            return "";
        }
    }
}