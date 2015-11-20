using static System.Console;
using P1.Point_3D;
using System;

namespace P2.DistanceCalculator
{
    class DistanceCalculator
    {
        public static double Calculate(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(
                (p2.X - p1.X) *
                (p2.X - p1.X) +
                (p2.Y - p1.Y) *
                (p2.Y - p1.Y) +
                (p2.Z - p1.Z) *
                (p2.Z - p1.Z));
        }
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(3.2f, 7.4f, 33);
            Point3D point2 = new Point3D(66.4f, 32.1f, 15f);
            WriteLine(DistanceCalculator.Calculate(point1, point2));
        }
    }
}
