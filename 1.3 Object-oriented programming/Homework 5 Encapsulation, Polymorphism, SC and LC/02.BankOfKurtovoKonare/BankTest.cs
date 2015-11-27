using _02.BankOfKurtovoKonare.Accounts;
using _02.BankOfKurtovoKonare.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare
{
    class BankTest
    {
        static void Main(string[] args)
        {
            IList<IAccount> accounts = new List<IAccount>();
            accounts.Add(
                new LoanAccount(
                    new IndividualCustomer(115, "Georgi", "Stoyanov"),
                    1500.2m,
                    4.3m));

            accounts.Add(
                new MortgageAccount(
                    new CompanyCustomer(110, "Software University"),
                    150000m,
                    14m));

            accounts.Add(
                new DepositAccount(
                    new IndividualCustomer(115, "Valeri", "Troyanov"),
                    -300m,
                    12m));

            Console.WriteLine(accounts[0].Interest(3));
        }
    }
}
