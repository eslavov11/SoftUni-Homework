namespace VehicleParkSystem.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VehicleParkSystem.Data;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;

    public class VehiclePark : IVehiclePark
    {
        private readonly Layout layout;
        private readonly VehicleParkSystemData data;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.data = new VehicleParkSystemData(numberOfSectors);
        }

        public string InsertCar(Car car, int sector, int place, DateTime time)
        {
            if (sector > this.layout.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.VehiclesBySectorAndPlace.ContainsKey(
                string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.VehiclesByLicensePlate.ContainsKey(car.LicensePlate))
            {
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park",
                    car.LicensePlate);
            }

            this.data.SectorAndPlaceByVehicle[car] = string.Format("({0},{1})", sector, place);
            this.data.VehiclesBySectorAndPlace[string.Format("({0},{1})", sector, place)] = car;
            this.data.VehiclesByLicensePlate[car.LicensePlate] = car;
            this.data.TimesByVehicles[car] = time;
            this.data.VehiclesByOwner[car.Owner].Add(car);
            this.data.PlacesTakenInSectors[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", car.GetType().Name, sector, place);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime time)
        {
            if (sector > this.layout.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.VehiclesBySectorAndPlace.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.VehiclesByLicensePlate.ContainsKey(motorbike.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", motorbike.LicensePlate);
            }

            this.data.SectorAndPlaceByVehicle[motorbike] = string.Format("({0},{1})", sector, place);
            this.data.VehiclesBySectorAndPlace[string.Format("({0},{1})", sector, place)] = motorbike;
            this.data.VehiclesByLicensePlate[motorbike.LicensePlate] = motorbike;
            this.data.TimesByVehicles[motorbike] = time;
            this.data.VehiclesByOwner[motorbike.Owner].Add(motorbike);

            //TODO: should be --
            this.data.PlacesTakenInSectors[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", motorbike.GetType().Name, sector, place);
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime time)
        {
            if (sector > this.layout.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.VehiclesBySectorAndPlace.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.VehiclesByLicensePlate.ContainsKey(truck.LicensePlate))
            {
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park",
                    truck.LicensePlate);
            }

            this.data.SectorAndPlaceByVehicle[truck] = string.Format("({0},{1})", sector, place);
            this.data.VehiclesBySectorAndPlace[string.Format("({0},{1})", sector, place)] = truck;
            this.data.VehiclesByLicensePlate[truck.LicensePlate] = truck;
            this.data.TimesByVehicles[truck] = time;
            this.data.VehiclesByOwner[truck.Owner].Add(truck);
            this.data.PlacesTakenInSectors[sector - 1]++;
            // TODO: available places ++
            return string.Format("{0} parked successfully at place ({1},{2})", truck.GetType().Name, sector, place);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal money)
        {
            var vehicle = (this.data.VehiclesByLicensePlate.ContainsKey(licensePlate)) ?
                this.data.VehiclesByLicensePlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format(
                    "There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var start = this.data.TimesByVehicles[vehicle];
            int endd = (int)Math.Round((endTime - start).TotalHours);
            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString())
                .AppendLine()
                .AppendFormat("at place {0}", this.data.SectorAndPlaceByVehicle[vehicle])
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate))
                .AppendLine()
                .AppendFormat(
                    "Overtime rate: ${0:F2}",
                    (endd > vehicle.ReservedHours ?
                    (endd - vehicle.ReservedHours) * vehicle.OvertimeRate :
                    0))
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat(
                    "Total: ${0:F2}",
                    (vehicle.ReservedHours * vehicle.RegularRate
                     + (endd > vehicle.ReservedHours ?
                     (endd - vehicle.ReservedHours) * vehicle.OvertimeRate :
                     0)))
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", money)
                .AppendLine()
                .AppendFormat(
                    "Change: ${0:F2}",
                    money
                    - ((vehicle.ReservedHours * vehicle.RegularRate)
                       + (endd > vehicle.ReservedHours ?
                       (endd - vehicle.ReservedHours) * vehicle.OvertimeRate :
                       0)))
                .AppendLine()
                .Append(new string('*', 20));

            //DELETE
            int sector =
                int.Parse(
                    this.data.SectorAndPlaceByVehicle[vehicle].Split(
                        new[] { "(", ",", ")" },
                        StringSplitOptions.RemoveEmptyEntries)[0]);
            this.data.VehiclesBySectorAndPlace.Remove(this.data.SectorAndPlaceByVehicle[vehicle]);
            this.data.SectorAndPlaceByVehicle.Remove(vehicle);
            this.data.VehiclesByLicensePlate.Remove(vehicle.LicensePlate);
            this.data.TimesByVehicles.Remove(vehicle);
            this.data.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            this.data.PlacesTakenInSectors[sector - 1]--;
            //END OF DELETE

            return ticket.ToString();
        }

        // TODO does this work?
        public string GetStatus()
        {
            var places =
                this.data.PlacesTakenInSectors.Select(
                    (vehiclesParked, sectorNumber) =>
                    string.Format(
                        "Sector {0}: {1} / {2} ({3}% full)",
                        sectorNumber + 1,
                        vehiclesParked,
                        this.layout.PlacesPerSector,
                        Math.Round((double)vehiclesParked / this.layout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicleByLincensePlate(string licensePlate)
        {
            var vehicle = (this.data.VehiclesByLicensePlate.ContainsKey(licensePlate)) ?
                this.data.VehiclesByLicensePlate[licensePlate] :
                null;
            if (vehicle == null)
            {
                return string.Format(
                    "There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return this.Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            // TODO: Bottleneck here..
            if (!this.data.VehiclesBySectorAndPlace.Values.Where(v => v.Owner == owner).Any())
            {
                return string.Format("No vehicles by {0}", owner);
            }

            // BOTTLENECK
            var found = this.data.VehiclesBySectorAndPlace.Values.ToList();
            var res = found;
            foreach (var f in found)
            {
                res = res.Where(v => v.Owner == owner).ToList();
            }

            return string.Join(Environment.NewLine, this.Input(res));

        }

        private string Input(IEnumerable<IVehicle> carros)
        {
            return string.Join(
                Environment.NewLine,
                carros.Select(
                    vehicle => string.Format("{0}{1}Parked at {2}",
                                                vehicle.ToString(),
                                                Environment.NewLine,
                                                this.data.SectorAndPlaceByVehicle[vehicle])));
        }
    }
}