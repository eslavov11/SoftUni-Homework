using System;

class PointInACircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double r = 2;
        bool isInsideACircle = false;

        if ((x * x) + (y * y) <= r * r)
        {
            isInsideACircle = true;
        }
        
        Console.WriteLine("The points x : {0} and y : {1} are inside the circle : {2}", x, y, isInsideACircle);
    }
}
