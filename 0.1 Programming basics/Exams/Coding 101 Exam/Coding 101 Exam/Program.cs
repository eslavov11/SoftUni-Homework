using System;

class Program
{
    static void Main()
    {
        double height = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine()) - 1;
        int tablesPerRow = Convert.ToInt32(Math.Floor(width / 0.7));
        int rows = Convert.ToInt32(Math.Floor(height / 1.2));
        Console.WriteLine(tablesPerRow * rows - 3);
    }
}

