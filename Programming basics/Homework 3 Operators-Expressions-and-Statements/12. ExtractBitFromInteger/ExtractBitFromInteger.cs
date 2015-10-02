using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        // Input
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        // Main Logic
        int nRightP = n >> p;
        int bit = nRightP & 1;
        
        // Output
        Console.WriteLine(bit);
    }
}
