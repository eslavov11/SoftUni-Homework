using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Furniture model cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Model's length cannot be less than 3 symbols!");
                }

                this.model = value;
            }
        }

        public string Material { get; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less or equal to zero!");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less or equal to zero!");
                }

                this.height = value;
            }
        }
    }
}
