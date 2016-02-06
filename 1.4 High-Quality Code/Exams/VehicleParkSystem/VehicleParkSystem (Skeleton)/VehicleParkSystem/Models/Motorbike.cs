namespace VehicleParkSystem.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    using VehicleParkSystem.Interfaces;

    public class Motorbike : IVehicle
    {
        private string licenseplate;
        private string person;
        private decimal regularRate;
        private decimal overtimeRate;
        private int reservedHours;

        public Motorbike(string licensePlate, string owner, int reservedHours)
        {
            this.RegularRate = (decimal)1.35;
            this.OvertimeRate = 3M;
            this.Owner = owner;
            this.LicensePlate = licensePlate;
            this.ReservedHours = reservedHours;
        }

        public string LicensePlate
        {
            get
            {
                return this.licenseplate;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licenseplate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.person;
            }

            set
            {
                if (value == null && value == "")
                {
                    throw new InvalidCastException("The owner is required.");
                }

                this.person = value;
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
                    throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));
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
                    throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));
                }

                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.reservedHours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", this.GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }

    }
}