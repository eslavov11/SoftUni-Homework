namespace AirConditionerTesterSystem.Models.AirConditioners
{
    using System;
    using System.Reflection.Emit;
    using System.Text;

    using AirConditionerTesterSystem.Enums;
    using AirConditionerTesterSystem.Utility;

    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;
        private int energyRating;

        public StationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
            : base(manufacturer, model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            try
            {
                this.EnergyRating = (int)Enum.Parse(typeof(EnergyEfficiencyRating), energyEfficiencyRating);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Energy efficiency rating must be between \"A\" and \"E\".");
            }

            this.PowerUsage = powerUsage;
            this.Type = AirConditionerType.Stationary;
        }

        public int EnergyRating
        {
            get
            {
                return this.energyRating;
            }

            set
            {
                this.energyRating = value;
            }
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Power Usage must be a positive integer.");
                }

                this.powerUsage = value;
            }
        }

        public override void Test()
        {
            if (this.PowerUsage / 100 <= (int)this.EnergyRating)
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
            var print = new StringBuilder();

            print.AppendLine("Required energy efficiency rating: " + (EnergyEfficiencyRating)this.EnergyRating)
                 .AppendLine("Power Usage(KW / h): " +
                     this.PowerUsage)
                 .Append(Constants.ReportDelimiter);

            return base.ToString() + print;
        }
    }
}
