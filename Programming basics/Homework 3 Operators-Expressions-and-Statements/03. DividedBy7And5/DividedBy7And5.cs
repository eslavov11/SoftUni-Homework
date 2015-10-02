using System;

class DividedBy7And5
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool dividedBy7And5 = false;

        if (number % 5 == 0 && number % 7 == 0 && number != 0)
        {
            dividedBy7And5 = true;
        }
        
        Console.WriteLine("{0} can be divided by 5 & 7 at the same time? : {1}", number, dividedBy7And5);
    }
}
