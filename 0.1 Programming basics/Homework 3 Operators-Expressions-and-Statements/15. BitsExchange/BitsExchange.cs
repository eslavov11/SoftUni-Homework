using System;

class BitsExchange
{
    static void Main()
    {
        // Input
        Console.Write("Please enter the number which you want to amend : ");
        long num = long.Parse(Console.ReadLine());
        Console.WriteLine("Initial number : " + Convert.ToString(num, 2).PadLeft(32, '0'));
        
        // Main Logic
        long bit3 = (num >> 3) & 1; // here we determine the value at position 3 
        long bit24 = (num >> 24) & 1; // here we determine the value at position 24
        num = (num & (~(1 << 24))) | (bit3 << 24); // with the first expression the bit at the 24th position is reset to Zero.
        num = (num & (~(1 << 3))) | (bit24 << 3); // with the first expression the bit at the 3th position is reset to Zero
        long bit4 = (num >> 4) & 1;
        long bit25 = (num >> 25) & 1;
        num = num & (~(1 << 25)) | (bit4 << 25);
        num = num & (~(1 << 4)) | (bit25 << 4);
        long bit5 = (num >> 5) & 1;
        long bit26 = (num >> 26) & 1;
        num = num & (~(1 << 26)) | (bit5 << 26);
        num = num & (~(1 << 5)) | (bit26 << 5);
        
        // Output
        Console.WriteLine("Amended number : " + Convert.ToString(num, 2).PadLeft(32, '0'));
        Console.WriteLine("Decimal representation : {0}", num);
    }
}
