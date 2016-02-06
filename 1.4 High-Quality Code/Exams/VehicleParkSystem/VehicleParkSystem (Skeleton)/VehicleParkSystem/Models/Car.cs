namespace VehicleParkSystem.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    using VehicleParkSystem.Interfaces;

    public class Car : IVehicle
    {
        private string licensePlate;

        private string owner;

        private decimal regularRate;

        private decimal overtimeRate;

        private int hours;

        public Car(string licensePlate, string owner, int hours)
        {
            this.RegularRate = 2;
            this.OvertimeRate = 3.5M;
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = hours;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The regular rate must be non-negative."));
                }

                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The overtime rate must be non-negative."));
                }

                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.hours;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.hours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", this.GetType().Name, 
                this.LicensePlate, this.Owner);

            return vehicle.ToString();
        }
    }
}