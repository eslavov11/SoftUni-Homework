using System;

class PrimeNumberCheck
{
    static void Main()
    {
        // Input
        int number;
        string digits;
        do
        {
            Console.Write("Enter a random number to check if it's prime: ");
            digits = Console.ReadLine();
        }
        while (!int.TryParse(digits, out number)); // Check that the input is correct.
        
        // Main Logic
        bool isPrime = true;
        double numberSqrt = Math.Sqrt(number);
        int numberSqrtRound = (int) Math.Round(numberSqrt);
        
        if (number == 0 || number == 1 || number < 0) // By the usual definition of prime for integers, negative integers can not be prime.
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i <= numberSqrtRound; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                }
            }
        }
        // Output
        Console.WriteLine(isPrime);
    }
}
