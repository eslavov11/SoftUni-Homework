namespace VehicleParkSystem.Data
{
    using System;
    using System.Collections.Generic;

    using VehicleParkSystem.Interfaces;

    using Wintellect.PowerCollections;

    public class VehicleParkSystemData
    {
        public VehicleParkSystemData(int numberOfSectors)
        {
            this.SectorAndPlaceByVehicle = new Dictionary<IVehicle, string>();
            this.VehiclesBySectorAndPlace = new Dictionary<string, IVehicle>();
            this.VehiclesByLicensePlate = new Dictionary<string, IVehicle>();
            this.TimesByVehicles = new Dictionary<IVehicle, DateTime>();
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false);
            this.PlacesTakenInSectors = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> SectorAndPlaceByVehicle { get; set; }

        public Dictionary<string, IVehicle> VehiclesBySectorAndPlace { get; set; }

        public Dictionary<string, IVehicle> VehiclesByLicensePlate { get; set; }

        public Dictionary<IVehicle, DateTime> TimesByVehicles { get; set; }

        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; set; }

        public int[] PlacesTakenInSectors { get; set; }
    }
}