using System;
using P1.Point_3D;
using System.Collections.Generic;

namespace P3.Paths
{
    class Path3D
    {
        private static List<Point3D> points = new List<Point3D>();

        static void Main(string[] args)
        {
            points.Add(new Point3D(2, 3, 4));
            points.Add(new Point3D(5, 6, 8));
            Storage.SavePaths(points);

        }
    }
}
