using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.BankOfKurtovoKonare.Customers;

namespace _02.BankOfKurtovoKonare.Accounts
{
    public class MortgageAccount : IAccount
    {
        public MortgageAccount(Customer custromer, decimal balance, decimal interestRate)
            : base(custromer, balance, interestRate)
        {
        }

        public override decimal Interest(int months)
        {
            if (base.Customer is IndividualCustomer) 
            {
                if (months <= 6)
                {
                    return 0;
                } // else
                return base.Interest(months);
            }

            // else if customer is ComapnyCustomer
            if (months <= 12)
            {
                return base.Interest(months) / 2;
            } // else
            return base.Interest(months);
        }
    }
}
