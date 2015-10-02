using System;

class FourDigitNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int firstRemainder = number % 10;
        int secondRemainder = (number / 10) % 10;
        int thirdRemainder = (number / 100) % 10;
        int fourthRemainder = (number / 1000) % 10;
        int sumOfDigits = firstRemainder + secondRemainder + thirdRemainder + fourthRemainder;
        
        Console.WriteLine("The sum of all the digits of the number {0} is {1}", number, sumOfDigits);
        Console.WriteLine("Number in reversed order : {0}{1}{2}{3}", firstRemainder, secondRemainder, thirdRemainder, fourthRemainder);
        Console.WriteLine("Number in reversed order : {0}{1}{2}{3}", fourthRemainder, firstRemainder, secondRemainder, thirdRemainder);
        Console.WriteLine("Number in reversed order : {0}{1}{2}{3}", firstRemainder, thirdRemainder, secondRemainder, fourthRemainder);
    }
}
