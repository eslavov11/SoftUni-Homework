using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Tables
{
    class Table : Furniture, ITable
    {
        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length { get; }
        public decimal Width { get; }

        public decimal Area
        {
            get { return Length * Width; }
        }

        public override string ToString()
        {
            return
                $"Type: {this.GetType().Name}," +
                $" Model: {this.Model}, " +
                $"Material: {FormatMaterial(this.Material)}, " +
                $"Price: {this.Price}, " +
                $"Height: {this.Height}, " +
                $"Length: {this.Length}, " +
                $"Width: {this.Width}, " +
                $"Area: {this.Area}";
        }

        private static string FormatMaterial(string material)
        {
            return material[0].ToString().ToUpper() + material.Substring(1);
        }
    }
}
