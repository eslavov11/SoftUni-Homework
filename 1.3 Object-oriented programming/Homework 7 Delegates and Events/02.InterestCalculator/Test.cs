using System;

namespace _02.InterestCalculator
{
    class Test
    {

        static void Main(string[] args)
        {
            Console.WriteLine(new InterestCalculator(2500, 7.2m, 15, GetSimpleInterest));
        }

        public const int MonthsInYear = 12;

        public static decimal GetSimpleInterest(decimal balance, decimal interestRate, byte years)
        {
            decimal interestMultiplier = 1 + (interestRate * years);
            decimal balanceWithInterest = balance * interestMultiplier;

            return decimal.Round(balanceWithInterest, 4);
        }

        private static decimal GetCompoundInterest(decimal balance, decimal interestRate, byte years)
        {
            decimal interestMultiplierBase = 1 + (interestRate / MonthsInYear);
            int interestMultiplierPower = years * MonthsInYear;

            decimal interestMultiplier = 1;
            for (int i = 0; i < interestMultiplierPower; i++)
            {
                interestMultiplier *= interestMultiplierBase;
            }

            decimal balanceWithInterest = balance * interestMultiplier;

            return decimal.Round(balanceWithInterest, 4);
        }
    }
}
