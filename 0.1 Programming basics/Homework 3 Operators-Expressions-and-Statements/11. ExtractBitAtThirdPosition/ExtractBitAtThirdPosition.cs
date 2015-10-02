using System;

class ExtractBitAtThirdPosition
{
    static void Main()
    {
        // Input
        int p = 3;
        int n = int.Parse(Console.ReadLine());
        
        // Main Logic
        int nRightP = n >> p;
        int bit = nRightP & 1;

        // Output
        Console.WriteLine(bit);
    }
}
