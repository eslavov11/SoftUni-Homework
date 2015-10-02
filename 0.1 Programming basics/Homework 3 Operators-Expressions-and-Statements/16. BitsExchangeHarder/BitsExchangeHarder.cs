using System;
using System.Text;

class BitsExchangeHarder
{
    static void Main()
    {
        // Input
        long number = long.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        double numberInDecimal = 0;

        // Main Logic
        // Turning the number into Binary system
        long[] numberInBin = new long[32];
        for (long i = 0; i < numberInBin.Length; i++)
        {
            if (number == 0)
            {
                break;
            }
            numberInBin[i] = number % 2;
            number = number / 2;
        }
        // Printing the initial number in binary system
        for (long i = numberInBin.Length - 1; i >= 0; i--)
        {
            Console.Write(numberInBin[i]);
        }
        // Making the change
        for (long i = 0; i < k; i++)
        {
            long temp = 0;
            temp = numberInBin[p];
            numberInBin[p] = numberInBin[q];
            numberInBin[q] = temp;
            p++;
            q++;
        }
        Console.WriteLine();
        for (long i = numberInBin.Length - 1; i >= 0; i--)
        {
            Console.Write(numberInBin[i]);
            numberInDecimal += (Math.Pow(2, i) * numberInBin[i]);
        }

        // Output
        Console.WriteLine();
        Console.WriteLine(numberInDecimal);
    }
}
