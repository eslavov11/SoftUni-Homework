using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.BankOfKurtovoKonare.Customers;

namespace _02.BankOfKurtovoKonare.Accounts
{
    public class LoanAccount : IAccount
    {
        public LoanAccount(Customer custromer, decimal balance, decimal interestRate) 
            : base(custromer, balance, interestRate)
        {
        }

        public override decimal Interest(int months)
        {
            if (base.Customer is IndividualCustomer)
            {
                return base.Interest(months - 3);
            }
            return base.Interest(months - 2);
        }
    }
}
