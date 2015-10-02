using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Comparer
{
    class NumberComparer
    {
        static void Main(string[] args)
        {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine(((a + b) + Math.Abs(a - b))/2); 
        }
    }
}
