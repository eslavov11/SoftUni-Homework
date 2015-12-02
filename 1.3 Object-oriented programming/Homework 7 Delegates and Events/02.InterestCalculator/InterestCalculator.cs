using System;

namespace _02.InterestCalculator
{
    public delegate decimal CalculateInterest(decimal sum, decimal interest, byte years);

    public class InterestCalculator
    {
        public InterestCalculator(decimal balance, decimal interest, byte years, CalculateInterest interestMethod)
        {
            this.Balance = balance;
            this.Interest = interest;
            this.Years = years;
            this.InterestMethod = interestMethod;
        }

        public decimal Balance { get; private set; }

        public decimal Interest { get; private set; }

        public byte Years { get; private set; }

        public CalculateInterest InterestMethod { get;}

        public override string ToString()
        {
            return $"{InterestMethod(this.Balance, this.Interest, this.Years):F4}";
        }
    }
}
