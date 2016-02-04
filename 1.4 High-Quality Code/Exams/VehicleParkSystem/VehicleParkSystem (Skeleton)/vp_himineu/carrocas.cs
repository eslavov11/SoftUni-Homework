using System;
using System.Text;
using System.Text.RegularExpressions;
namespace VehiclePark3 
{
    public class Carro : IVehicle
    {
        #region No interesting
        private string licenseplate; private string person; private decimal regularrate; private decimal morerate; private int hh;
        public string LicensePlate{get{return licenseplate;}set{if(!Regex.IsMatch(value,@"^[A-Z]{1}\d{3}[A-Z]{2,}$")){throw new ArgumentException("The license plate number is invalid.");}licenseplate = value;}}
        public string Owner{get{return person;}set{if (value==null&&value==""){throw new InvalidCastException("The owner is required.");}person = value;}}
        public decimal RegularRate{get{return regularrate;}set{if(value<0){throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));}regularrate = value;}}
        public decimal OvertimeRate{get{return morerate;}set{if(value<0){throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));}morerate = value;}}
        public int ReservedHours{get{return hh;}set{if(value<=0){throw new ArgumentException("The reserved hours must be positive.");}hh = value;}}
        public override string ToString(){var vehicle = new StringBuilder();vehicle.AppendFormat("{0} [{2}], owned by {1}",GetType().Name,LicensePlate,Owner);return vehicle.ToString();}
        #endregion
        public Carro(string _license_plate, string _person, int hh)
        {
            RegularRate=2;
            OvertimeRate=3.5M;
        }
    }









    public class Caminhão : IVehicle
    {
        #region No interesting
        private string licenseplate; private string person; private decimal regularrate; private decimal morerate; private int hh;
        public string LicensePlate{get{return licenseplate;}set{if(!Regex.IsMatch(value,@"^[A-Z]{1}\d{3}[A-Z]{2,}$")){throw new ArgumentException("The license plate number is invalid.");}licenseplate = value;}}
        public string Owner{get{return person;}set{if (value==null&&value==""){throw new InvalidCastException("The owner is required.");}person = value;}}
        public decimal RegularRate{get{return regularrate;}set{if(value<0){throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));}regularrate = value;}}
        public decimal OvertimeRate{get{return morerate;}set{if(value<0){throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));}morerate = value;}}
        public int ReservedHours{get{return hh;}set{if(value<=0){throw new ArgumentException("The reserved hours must be positive.");}hh = value;}}
        public override string ToString(){var vehicle = new StringBuilder();vehicle.AppendFormat("{0} [{2}], owned by {1}",GetType().Name,LicensePlate,Owner);return vehicle.ToString();}
        #endregion
        public Caminhão(string _license_plate, string _person, int hh)
        {
            RegularRate=(decimal)((double)4.75f);
            OvertimeRate=6.2M;
        }
    }














    public class Moto : IVehicle
    {
        #region No interesting
        private string licenseplate; private string person; private decimal regularrate; private decimal morerate; private int hh;
        public string LicensePlate{get{return licenseplate;}set{if(!Regex.IsMatch(value,@"^[A-Z]{1}\d{3}[A-Z]{2,}$")){throw new ArgumentException("The license plate number is invalid.");}licenseplate = value;}}
        public string Owner{get{return person;}set{if (value==null&&value==""){throw new InvalidCastException("The owner is required.");}person = value;}}
        public decimal RegularRate{get{return regularrate;}set{if(value<0){throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));}regularrate = value;}}
        public decimal OvertimeRate{get{return morerate;}set{if(value<0){throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));}morerate = value;}}
        public int ReservedHours{get{return hh;}set{if(value<=0){throw new ArgumentException("The reserved hours must be positive.");}hh = value;}}
        public override string ToString(){var vehicle = new StringBuilder();vehicle.AppendFormat("{0} [{2}], owned by {1}",GetType().Name,LicensePlate,Owner);return vehicle.ToString();}
        #endregion
        public Moto(string _license_plate, string _person, int hh)
        {
            RegularRate=(decimal)1.35;
            OvertimeRate=3M;
        }
    }
}