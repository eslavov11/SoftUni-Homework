using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare.Customers
{
    public class CompanyCustomer : Customer
    {
        private string companyName;

        public CompanyCustomer(uint id, string comanyName) : base(id)
        {
            this.CompanyName = comanyName;
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("companyName", "Wrong company name!");
                }
                this.companyName = value;
            }
        }
    }
}
