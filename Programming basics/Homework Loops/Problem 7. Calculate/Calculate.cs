using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Calculate
{
    class Calculate
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            byte k = byte.Parse(Console.ReadLine());
            uint nFactorial = 1;
            uint kFactorial = 1;
            uint nMinusKFactorial = 1;
            for (byte i = 1; i <= n-k; i++)
            {
                nMinusKFactorial *= i;
            }
            for (byte i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }
            for (byte i = 1; i <= k; i++)
            {
                kFactorial *= i;
            }
            Console.WriteLine(nFactorial/(kFactorial * nMinusKFactorial));
        }
    }
}
//N! / (K! * (N-K)!)