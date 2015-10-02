using System;

namespace _11.BankAccountData
{
    class BankAccountData
    {
        struct AccountHolder
        {
            public string firstName; 
            public string middleName;
            public string lastName; 
            public decimal accountBalance; 
            public string bankName;
            public string IBAN; 
            public ulong fristCreditCardNumber;
            public ulong secondCreditCardNumber; 
            public ulong thirdCreditCardNumber;  
        }
        static void Main()
        {
            AccountHolder pecata;

            pecata.firstName = "Pesho";
            pecata.middleName = "Peshov";
            pecata.lastName = "Mironov";
            pecata.accountBalance = 2.40m; // Божков го разори :D
            pecata.bankName = "KTB";
            pecata.IBAN = "BG80 BNBG 9661 1020 3456 78";
            pecata.fristCreditCardNumber = 5205701482692568;
            pecata.secondCreditCardNumber = 4485512488365917;
            pecata.thirdCreditCardNumber = 6011478288711288;

            Console.WriteLine("First name: {0}", pecata.firstName);
            Console.WriteLine("Middle name: {0}",pecata.middleName);
            Console.WriteLine("Last name: {0}",pecata.lastName);
            Console.WriteLine("Account balance: {0}",pecata.accountBalance);
            Console.WriteLine("Bank name: {0}",pecata.bankName);
            Console.WriteLine("IBAN: {0}",pecata.IBAN);
            Console.WriteLine("1st Credit card number: {0}",pecata.fristCreditCardNumber);
            Console.WriteLine("2nd Credit card number: {0}",pecata.secondCreditCardNumber);
            Console.WriteLine("3rd Credit card number: {0}",pecata.thirdCreditCardNumber);
            

            
        }
    }
}
