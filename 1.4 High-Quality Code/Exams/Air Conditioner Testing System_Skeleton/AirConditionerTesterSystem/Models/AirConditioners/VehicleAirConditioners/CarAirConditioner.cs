namespace AirConditionerTesterSystem.Models.AirConditioners.VehicleAirConditioners
{
    using System;
    using AirConditionerTesterSystem.Enums;
    using AirConditionerTesterSystem.Utility;

    public class CarAirConditioner : VehicleAirConditioner
    {
        public CarAirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(manufacturer, model, volumeCoverage)
        {
            this.Type = AirConditionerType.Car;
        }

        public override void Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (sqrtVolume < Constants.MinCarVolume)
            {
                this.HasPassedTest = false;
            }
            else
            {
                this.HasPassedTest = true;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Constants.ReportDelimiter;
        }
    }
}
