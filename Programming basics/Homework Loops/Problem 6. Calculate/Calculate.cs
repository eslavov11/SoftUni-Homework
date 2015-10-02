using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Calculate
{
    class Calculate
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            byte k = byte.Parse(Console.ReadLine());
            ulong nResult = 1;
            ulong kResult = 1;
            for (byte i = 1; i <= n; i++)
            {
                nResult *= i;
            }
            for (byte i = 1; i <= k; i++)
            {
                kResult *= i;
            }
            Console.WriteLine(nResult / kResult);
        }
    }
}
// n! / k! 