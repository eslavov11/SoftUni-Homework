using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Conditional_Statements
{
    class ExchangeIfGreater
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b= double.Parse(Console.ReadLine());
            if (a>b)
            {
                double c = a;
                a = b;
                b = c;
            }
            Console.WriteLine(a + " " + b);
        }
    }
}
