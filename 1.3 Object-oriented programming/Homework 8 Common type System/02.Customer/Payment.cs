using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Customer
{
    public class Payment
    {
        private string productName;
        private decimal price;



        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Invalid product name!");
                }
                productName = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price of product cannot be below zero!", "price");
                }
                price = value;
            }
        }
    }
}
