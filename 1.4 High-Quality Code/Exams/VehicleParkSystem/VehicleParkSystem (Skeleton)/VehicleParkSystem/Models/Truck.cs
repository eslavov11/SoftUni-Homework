namespace VehicleParkSystem.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    using VehicleParkSystem.Interfaces;

    public class Truck : IVehicle
    {
        private string licenseplate;
        private string person;
        private decimal regularrate;
        private decimal morerate;
        private int reservedHours;

        public Truck(string licensePlate, string owner, int reservedHours)
        {
            this.RegularRate = (decimal)((double)4.75f);
            this.OvertimeRate = 6.2M;
            this.LicensePlate = licensePlate;
            this.Owner = owner;
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
                return this.regularrate;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));
                }
                this.regularrate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.morerate;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));
                }

                this.morerate = value;
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