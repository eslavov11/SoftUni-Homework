namespace AirConditionerTesterSystem.Models.AirConditioners.VehicleAirConditioners
{
    using System;

    using AirConditionerTesterSystem.Utility;

    public abstract class VehicleAirConditioner : AirConditioner
    {
        private int volumeCovered;

        protected VehicleAirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(manufacturer, model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public override void Test()
        {
        }

        public override string ToString()
        {
            var print = "Volume Covered: " + this.VolumeCovered + Environment.NewLine;

            return base.ToString() + print;
        }
    }
}
