namespace AirConditionerTesterSystem.Models.AirConditioners
{
    using System;
    using System.Text;

    using AirConditionerTesterSystem.Enums;
    using AirConditionerTesterSystem.Utility;

    public abstract class AirConditioner
    {
        private string manufacturer;
        private string model;
        private AirConditionerType type;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }
        
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Model", Constants.ModelMinLength));
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Manufacturer", Constants.ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }

        public AirConditionerType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        public bool HasPassedTest { get; set; }

        public abstract void Test();

        public override string ToString()
        {
            var print = new StringBuilder();
            print.AppendLine("Air Conditioner")
                .AppendLine(Constants.ReportDelimiter)
                .AppendLine("Manufacturer: " + this.Manufacturer)
                .AppendLine("Model: " + this.Model);

            return print.ToString();
        }
    }
}
