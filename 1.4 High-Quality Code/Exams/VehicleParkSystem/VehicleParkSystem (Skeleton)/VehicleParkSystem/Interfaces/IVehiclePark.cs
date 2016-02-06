namespace VehicleParkSystem.Interfaces
{
    using System;

    using VehicleParkSystem.Models;

    interface IVehiclePark
    {
        // TODO: Documentar esse método
        string InsertCar(Car car, int sector, int placeNumber, DateTime time);

        // TODO: Documentar esse método
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        // TODO: Documentar esse método
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime time);

        // TODO: Documentar esse método
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        // TODO: Documentar esse método
        string GetStatus();

        // TODO: Documentar esse método
        string FindVehicleByLincensePlate(string licensePlate);

        // TODO: Documentar esse método
        string FindVehiclesByOwner(string owner);
    }
}