using P1.Point_3D;
using System.Collections.Generic;
using System.IO;

namespace P3.Paths
{
    static class Storage
    {
        private static StreamReader readPoints;
        private static StreamWriter writePoints = new StreamWriter(@"../../points.txt");

        public static List<Point3D> LoadPaths()
        {
            try
            {
                 readPoints = new StreamReader(@"../../points.txt");
            }
            catch (FileNotFoundException)
            {
            }
            
            List<Point3D> listPoint = new List<Point3D>();
            using (readPoints)
            {
                string points = readPoints.ReadLine();
                while (points != null)
                {
                    string[] get = points.Split(' ');
                    listPoint.Add(new Point3D(float.Parse(get[0]), float.Parse(get[1]), float.Parse(get[2])));
                    points = readPoints.ReadLine();
                }
            }
            return listPoint;
        }

        public static void SavePaths(List<Point3D> listPoint)
        {
            using (writePoints)
            {
                foreach (var item in listPoint)
                {
                    writePoints.WriteLine(item.X + " " + item.Y + " " + item.Z);
                }
            }
        }
    }
}
