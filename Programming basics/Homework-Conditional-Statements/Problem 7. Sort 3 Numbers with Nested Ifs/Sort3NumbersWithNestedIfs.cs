using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Sort_3_Numbers_with_Nested_Ifs
{
    class Sort3NumbersWithNestedIfs
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            if (a >= b && a >= c && b>=c)
            {
                Console.WriteLine(a + " " + b + " " + c);
            }
            else if (a >= b && a >= c && b <= c)
            {
                Console.WriteLine(a + " " + c + " " + b);
            }
            else if (b >= a && b >= c && a >= c)
            {
                Console.WriteLine(b + " " + a + " " + c);
            }
            else if (b >= a && b >= c && a <= c)
            {
                Console.WriteLine(b + " " + c + " " + a);
            }
            else if (c >= a && c >= b && a <= b)
            {
                Console.WriteLine(c + " " + b + " " + a);
            }
            else
            {
                Console.WriteLine(c + " " + a + " " + b);
            }
        }
    }
}
