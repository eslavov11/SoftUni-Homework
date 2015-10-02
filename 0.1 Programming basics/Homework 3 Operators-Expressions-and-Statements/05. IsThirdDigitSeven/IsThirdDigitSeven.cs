using System;

class IsThirdDigitSeven
{
    static void Main()
    {
        Console.Write("Please enter a number : ");
        int number = int.Parse(Console.ReadLine());
        bool thirdDigitSeven = false;
        
        if ((number / 100) % 10 == 7)
        {
            thirdDigitSeven = true;
        }
        
        Console.WriteLine("The third digit of number {0} is 7 : {1}", number, thirdDigitSeven);
    }
}
