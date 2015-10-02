using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.The_Biggest_of_Five_Numbers
{
    class TheBiggestOfFiveNumbers
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());
            if (a > b && a > c && a > d && a > e)
            {
                Console.WriteLine(a);
            }
            else if (b > a && b > c && b > d && b > e)
            {
                Console.WriteLine(b);
            }
            else if (c > a && c > b && c > d && c > e)
            {
                Console.WriteLine(c);
            }
            else if (d > b && d > c && d > a && d > e)
            {
                Console.WriteLine(d);
            }
            else
            {
                Console.WriteLine(e);
            }
        }
    }
}
