using System;

class ModifyBitAtGivenPosition
{
    static void Main()
    {
        // Input
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine()); ;
        int v = int.Parse(Console.ReadLine());

        int mask = 0;
        int result = 0;

        // Main Logic
        if (v == 0)
        {
            mask = ~(1 << p);
            result = n & mask;
            Console.WriteLine(result);
        }
        else
        {
            mask = 1 << p;
            result = n | mask;
            Console.WriteLine(result);
        }
    }
}
