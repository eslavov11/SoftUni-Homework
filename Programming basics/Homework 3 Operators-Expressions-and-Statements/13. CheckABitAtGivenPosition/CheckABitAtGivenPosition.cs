using System;

class CheckABitAtGivenPosition
{
    static void Main()
    {
        // Input
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        // Main Logic
        int nRightP = n >> p;
        int result = nRightP & 1;
        bool isTheBitOne = false;
        if (result == 1)
        {
            isTheBitOne = true;
        }

        // Output
        Console.WriteLine(isTheBitOne);
    }
}
