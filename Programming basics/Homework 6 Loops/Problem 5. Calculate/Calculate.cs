using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Calculate
{
    class Calculate
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int factorial = 1;
            double sum = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
                sum += factorial/Math.Pow(x, i);
            }
            Console.WriteLine(Math.Round(sum, 5));
        }
    }
}
//Problem 5.	Calculate 1 + 1!/X + 2!/X2 + … + N!/XN