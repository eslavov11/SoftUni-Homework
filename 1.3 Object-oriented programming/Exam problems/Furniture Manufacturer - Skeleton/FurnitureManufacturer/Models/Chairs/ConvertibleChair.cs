using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Chairs
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private decimal initialChairHeight;


        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.initialChairHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.IsConverted = false;
                base.Height = initialChairHeight;
            }
            else
            {
                this.initialChairHeight = base.Height;
                this.IsConverted = true;
                base.Height = 0.10m;
            }
        }

        public override string ToString()
        {
            return
                $"Type: {this.GetType().Name}, " +
                $"Model: {this.Model}, " +
                $"Material: {FormatMaterial(this.Material)}, " +
                $"Price: {this.Price}, " +
                $"Height: {this.Height}, " +
                $"Legs: {this.NumberOfLegs}, " +
                $"State: {(this.IsConverted ? "Converted" : "Normal")}";
        }

        private string FormatMaterial(string material)
        {
            return material[0].ToString().ToUpper() + material.Substring(1);
        }
    }
}
