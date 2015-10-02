using System;

class OddOrEvenInt
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool isOdd = true;
        
        if (n % 2 == 0)
        {
            isOdd = false;
        }
        
        Console.WriteLine("Is odd? : {0}", isOdd);
    }
}
