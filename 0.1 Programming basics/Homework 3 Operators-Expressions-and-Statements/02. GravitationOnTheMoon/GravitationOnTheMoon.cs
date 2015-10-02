using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Write("Your weight in kilos : ");
        double weight = double.Parse(Console.ReadLine());
        Console.WriteLine("On the moon your weight will be {0} kilos", weight * 0.17);
    }
}
