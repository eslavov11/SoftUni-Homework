using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Estate : IEstate
    {
        protected Estate(EstateType type, string name, double area, string location, bool isFurnished)
        {
            this.Name = name;
            this.Type = type;
            this.Area = area;
            this.Location = location;
            this.IsFurnished = isFurnished;
        }

        protected Estate(EstateType type)
        {
            this.Type = type;
        }

        public string Name { get; set; }
        
        public EstateType Type { get; set; }

        public double Area { get; set; }

        public string Location { get; set; }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            string furnitured = this.IsFurnished ? "Yes" : "No";
            return  
                $"{this.GetType().Name}: Name =" +
                   $" {this.Name}, Area = {this.Area}," +
                   $" Location = {this.Location}, " +
                   $"Furnitured = {furnitured}";
        }
    }
}
