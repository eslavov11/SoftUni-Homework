namespace AirConditionerTesterSystem.Models.AirConditioners.VehicleAirConditioners
{
    using System;
    using AirConditionerTesterSystem.Enums;
    using AirConditionerTesterSystem.Utility;

    public class PlaneAirConditioner : VehicleAirConditioner
    {
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
            : base(manufacturer, model, volumeCoverage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
            this.Type = AirConditionerType.Plane;
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override void Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (this.ElectricityUsed / sqrtVolume < Constants.MinPlaneElectricity)
            {
                this.HasPassedTest = true;
            }
            else
            {
                this.HasPassedTest = false;
            }
        }

        public override string ToString()
        {
            var result = "Electricity Used: " + 
                this.ElectricityUsed +
                Environment.NewLine + 
                Constants.ReportDelimiter;

            return base.ToString() + result;
        }
    }
}
