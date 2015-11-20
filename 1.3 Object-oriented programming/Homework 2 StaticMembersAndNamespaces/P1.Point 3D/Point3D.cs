using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Point_3D
{
    public class Point3D
    {
        private float x;
        private float y;
        private float z;
        private static readonly Point3D startingPoint = new Point3D(0, 0, 0);


        public Point3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float X { get { return this.x; } set { this.x = value; } }
        public float Y { get { return this.y; } set { this.y = value; } }
        public float Z { get { return this.z; } set { this.z = value; } }

        internal static Point3D StartingPoint
        {
            get
            {
                return startingPoint;
            }
        }

        static void Main(string[] args)
        {
            Point3D p1 = new Point3D(3.2f, 8.4f, 15);
            WriteLine(p1);
            WriteLine(Point3D.StartingPoint);
        }

        public override string ToString()
        {
            return this.X + "\ny: " + this.Y + "\nz: " + this.Z + "\n";
        }
    }
}
