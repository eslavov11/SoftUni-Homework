using System;
using _02.BankOfKurtovoKonare.Customers;
using _02.BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare.Accounts
{
    public class DepositAccount : IAccount, IWithdrawable
    {
        public DepositAccount(Customer custromer, decimal balance, decimal interestRate) 
            : base(custromer, balance, interestRate)
        {
        }

        public decimal Withdraw
        {
            get;
            private set;
        }

        public override decimal Interest(int months)
        {
            if (base.Balance < 1000 && base.Balance > 0)
            {
                return 0;
            }

            return base.Interest(months);
        }
    }
}
