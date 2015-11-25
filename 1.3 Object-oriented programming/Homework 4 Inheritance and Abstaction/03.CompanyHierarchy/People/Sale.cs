using _03.CompanyHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.People
{
    public class Sale : ISale
    {
        private decimal price;
        private string productName;

        public DateTime date
        {
            get; set;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value cannot be a negative number");
                }
                this.price = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product's name cannot be empty");
                }
                this.productName = value;
            }
        }
    }
}
