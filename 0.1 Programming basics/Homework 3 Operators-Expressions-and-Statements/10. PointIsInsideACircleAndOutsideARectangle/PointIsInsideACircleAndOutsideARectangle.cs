using System;

class PointIsInsideACircleAndOutsideARectangle
{
    static void Main()
    {
        // Input
        double pointX = double.Parse(Console.ReadLine());
        double pointY = double.Parse(Console.ReadLine());
        double pointXforCircle = Math.Abs(pointX - 1);
        double pointYforCircle = Math.Abs(pointY - 1);
        double radius = 1.5;
        
        // Main Logic
        bool inRectangle = false;
        bool inCircle = false;
        if (((pointXforCircle * pointXforCircle) + (pointYforCircle * pointYforCircle)) <= radius * radius)
        {
            inCircle = true;
        }
        else if ((pointX >= -1 && pointX <= 5) && (pointY >= -1 && pointY <= 1))
        {
            inRectangle = true;
        }

        // Output
        if (inRectangle == false && inCircle == true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }

}
