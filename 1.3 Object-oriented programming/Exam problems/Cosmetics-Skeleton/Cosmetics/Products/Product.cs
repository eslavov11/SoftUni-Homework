using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private const int MinProductNameLength = 3;
        private const int MaxProductNameLength = 10;
        private const int MinBrandNameLength = 2;
        private const int MaxBrandNameLength = 10;

        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType genderType)
        {
            this.Name = name;
            this.Brand = brand;
            this.Gender = genderType;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    MaxProductNameLength,
                    MinProductNameLength,
                    $"Product name must be between {MinProductNameLength} and " +
                    $"{MaxProductNameLength} symbols long!");
                //if (value.Length < MinProductNameLength || value.Length > MaxProductNameLength)
                //{
                    //throw new ArgumentOutOfRangeException(
                        //$"Product name must be between {MinProductNameLength} and {MaxProductNameLength} symbols long!");
                //}
                this.name = value;
            }
        }
        
        public string Brand {
            get { return this.brand; }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    MaxBrandNameLength,
                    MinBrandNameLength,
                    $"Product brand must be between {MinBrandNameLength} and " +
                    $"{MaxBrandNameLength} symbols long!");
                this.brand = value;
            }
        }

        public virtual decimal Price { get; }
        public GenderType Gender { get; }

        public abstract string Print();
    }
}
