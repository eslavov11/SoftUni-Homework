using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private IList<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        } 

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company's name cannot be null or empty!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Company's length cannot be less than 5 symbols!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            set
            {
                
                if (value.Length != 10 || WrongRegistrationNumberFormat(value))
                {
                    throw new ArgumentOutOfRangeException("Registration number must be exactly 10 digits long!");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(
                $"{this.Name} - {this.RegistrationNumber} - " +
                $"{(this.furnitures.Count != 0 ? this.furnitures.Count.ToString() : "no")} " +
                $"{(this.furnitures.Count != 1 ? "furnitures" : "furniture")}")
                .Append(
                string.Join(
                    Environment.NewLine, furnitures
                    .OrderBy(x => x.Price)
                    .ThenBy(x => x.Model)));

            return result.ToString();
        }

        private bool WrongRegistrationNumberFormat(string value)
        {
            foreach (var symbol in value)
            {
                if (!char.IsDigit(symbol))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
