using System;
using _02.BankOfKurtovoKonare.Customers;
using _02.BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare.Accounts
{
    public abstract class IAccount : IAccountable
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;
        private decimal deposit;

        public IAccount(Customer custromer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public decimal Deposit
        {
            get
            {
                return this.deposit;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Deposit must be a positive number");
                }
                this.deposit = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            protected set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Interest rate must be in range [0..100%]");
                }
                this.interestRate = value;
            }
        }

        public virtual decimal Interest(int months)
        {
            return this.Balance * (1 + this.InterestRate * months);
        }
    }
}
