using _02.BankOfKurtovoKonare.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare.Customers
{
    public abstract class Customer : ICustomer
    {
        private uint id;

        public Customer(uint id)
        {
            this.Id = id;
        }

        public uint Id
        {
            get
            {
                return id;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid id");
                }
                id = value;
            }
        }
    }
}
