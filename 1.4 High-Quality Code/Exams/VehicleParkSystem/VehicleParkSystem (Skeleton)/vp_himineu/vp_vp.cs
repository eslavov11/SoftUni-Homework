using Himineu_system;
using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace vp_system_himineu
{
    using System;
    using System.Linq;
    using System.Text;
    using vp_himineu;
    class v : IVehiclePark
    {
        public layout layout;
        public DATA DATA;
        public v(int numberOfSectors, int placesPerSector)
        {
            layout
                    = new layout(
                                  numberOfSectors
                                                  ,
                                                   placesPerSector)
                                                                    ;
            DATA
                 =
                    new DATA(
                              numberOfSectors);
        }
        public string InsertCar(VehiclePark3.Carro carro, int s, int p, DateTime t)
        {
            if (s > layout.sectors) return string.Format("There is no sector {0} in the park", s);
            if (p > layout.places_sec) return string.Format("There is no place {0} in sector {1}", p, s);
            if (DATA.park.ContainsKey(string.Format("({0},{1})", s, p))) return string.Format("The place ({0},{1}) is occupied", s, p);
            if (DATA.números.ContainsKey(carro.LicensePlate)) return string.Format("There is already a vehicle with license plate {0} in the park", carro.LicensePlate);
            DATA.
                carros_inpark[carro] = string.Format("({0},{1})", s, p); ;
            DATA.
                park[string.Format("({0},{1})", s, p)] = carro;
            DATA.
                números[carro.LicensePlate] = carro;
            DATA.
                d[carro] = t;
            DATA.
                ow[carro.Owner].Add(carro);
            DATA.
                count[s - 1]--;
            return string.Format("{0} parked successfully at place ({1},{2})", carro.GetType().Name, s, p);
        }

        public string InsertMotorbike(VehiclePark3.Moto moto, int s, int p, DateTime t)
        {
            if (s > layout.sectors) return string.Format("There is no sector {0} in the park", s);
            if (p > layout.places_sec) return string.Format("There is no place {0} in sector {1}", p, s);
            if (DATA.park.ContainsKey(string.Format("({0},{1})", s, p))) return string.Format("The place ({0},{1}) is occupied", s, p);
            if (DATA.números.ContainsKey(moto.LicensePlate)) return string.Format("There is already a vehicle with license plate {0} in the park", moto.LicensePlate);
            DATA.
                carros_inpark[moto] = string.Format("({0},{1})", s, p);
            DATA.
                park[string.Format("({0},{1})", s, p)] = moto;
            DATA.
                números[moto.LicensePlate] = moto;
            DATA.
                d[moto] = t;
            DATA.
                ow[moto.Owner].Add(moto);
            DATA.
                count[s - 1]++;
            return string.Format("{0} parked successfully at place ({1},{2})", moto.GetType().Name, s, p);
        }

        public string InsertTruck(VehiclePark3.Caminhão caminhão, int s, int p, DateTime t)
        {
            if (s > layout.sectors) return string.Format("There is no sector {0} in the park", s);
            if (p > layout.places_sec) return string.Format("There is no place {0} in sector {1}", p, s);
            if (DATA.park.ContainsKey(string.Format("({0},{1})", s, p))) return string.Format("The place ({0},{1}) is occupied", s, p);
            if (DATA.números.ContainsKey(caminhão.LicensePlate)) return string.Format("There is already a vehicle with license plate {0} in the park", caminhão.LicensePlate);
            DATA.
                carros_inpark[caminhão]
                = 
                                        string.Format("({0},{1})", s, p);
            DATA.
                park[string.Format("({0},{1})", s, p)]
                =
                                        caminhão;
            DATA.
                números[caminhão.LicensePlate] 
                =  
                                        caminhão;
            DATA.
                d[caminhão] 
                =                       t;
            DATA.
                ow
                    [
                        caminhão.Owner
                                        ]
                                            .
                                                Add
                                                    (
                                                        caminhão
                                                                    );
            return string.Format("{0} parked successfully at place ({1},{2})", caminhão.GetType().Name, s, p);
        }

        public string ExitVehicle(string l_pl, DateTime end, decimal money)
        {
            var vehicle = (DATA.números.ContainsKey(l_pl)) ? DATA.números[l_pl] : null;
            if (vehicle == null)
                return string.Format("There is no vehicle with license plate {0} in the park", l_pl);

            var start = DATA.d[vehicle];
            int endd = (int)Math.Round((end - start).TotalHours);
            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20)).AppendFormat("{0}", vehicle.ToString()).AppendLine().AppendFormat("at place {0}", DATA.carros_inpark[vehicle]).AppendLine().AppendFormat("Rate: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate)).AppendLine().AppendFormat("Overtime rate: ${0:F2}", (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)).AppendLine().AppendLine(new string('-', 20)).AppendFormat("Total: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate + (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))).AppendLine().AppendFormat("Paid: ${0:F2}", money).AppendLine().AppendFormat("Change: ${0:F2}", money - ((vehicle.ReservedHours * vehicle.RegularRate) + (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))).AppendLine().Append(new string('*', 20));
            //DELETE
            int sector = int.Parse(DATA.carros_inpark[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            DATA.
                park.Remove(DATA.carros_inpark[vehicle]);
            DATA.
                carros_inpark.Remove(vehicle);
            DATA.
                números.Remove(vehicle.LicensePlate);
            DATA.
                d.Remove(vehicle);
            DATA.
                ow.Remove(vehicle.Owner, vehicle);
            DATA.
                count[sector - 1]--;
            //END OF DELETE
            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = DATA
                                .count
                                        .Select((sssss, iiiii) => string.Format(
                                                                                    "Sector {0}: {1} / {2} ({2}% full)",
                                                                                    iiiii + 1,
                                                                                    sssss,
                                                                                    layout.places_sec,
                                                                                    Math.Round((double)sssss / layout.places_sec * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string l_pl)
        {
            var vehicle = (DATA.números.ContainsKey(l_pl)) ? DATA.números[l_pl] : null;
            if (vehicle == null)
                return string.Format("There is no vehicle with license plate {0} in the park", l_pl);
            else return Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!DATA.park.Values.Where(v=>v.Owner == owner).Any())
                return string.Format("No vehicles by {0}", owner);
            else
            {
                var found = DATA.park.Values.ToList();
                var res = found;
                foreach (var f in found)
                {
                    res = res.Where(v => v.Owner == owner).ToList();
                }
               return string.Join(Environment.NewLine, Input(res));
            }
        }

        private string Input(IEnumerable<IVehicle> carros)
        {
            return string.Join(Environment.NewLine, carros.Select(vehicle => string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, DATA.carros_inpark[vehicle])));
        }
    }
}
namespace Himineu_system
{
    class DATA
    {
        public DATA(int numberOfSectors)
        {
            carros_inpark = new Dictionary<IVehicle, string>(); park = new Dictionary<string, IVehicle>(); números = new Dictionary<string, IVehicle>(); d = new Dictionary<IVehicle, DateTime>(); ow = new MultiDictionary<string, IVehicle>(false); count = new int[numberOfSectors];
        }
        #region Hard Stuff! My boss wrote that
        public Dictionary<IVehicle, string> carros_inpark { get; set; }public Dictionary<string, IVehicle> park { get; set; }public Dictionary<string, IVehicle> números { get; set; }public Dictionary<IVehicle, DateTime> d { get; set; }public MultiDictionary<string, IVehicle> ow { get; set; }public int[] count { get; set; }
        #endregion
    }
}

class layout
{
    public int sectors;
    public int places_sec;
    public layout(int numberOfSectors, int placesPerSector)
    {
        if (numberOfSectors <= 0)
            throw new DivideByZeroException("The number of sectors must be positive.");
        sectors = numberOfSectors;
        if (placesPerSector <= 0)
            throw new DivideByZeroException("The number of places per sector must be positive.");
        places_sec = placesPerSector;
    }
}