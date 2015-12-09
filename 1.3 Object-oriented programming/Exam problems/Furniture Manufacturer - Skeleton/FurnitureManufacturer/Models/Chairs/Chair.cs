using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Chairs
{
    public class Chair : Furniture, IChair
    {
        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; }

        public override string ToString()
        {
            return
                $"Type: {this.GetType().Name}, " +
                $"Model: {this.Model}, " +
                $"Material: {FormatMaterial(this.Material)}," +
                $" Price: {this.Price}, " +
                $"Height: {this.Height}, " +
                $"Legs: {this.NumberOfLegs}";
        }

        private static string FormatMaterial(string material)
        {
            return material[0].ToString().ToUpper() + material.Substring(1);
        }
    }
}
