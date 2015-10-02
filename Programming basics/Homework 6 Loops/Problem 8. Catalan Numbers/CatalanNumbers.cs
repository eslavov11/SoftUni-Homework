using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Catalan_Numbers
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            uint nFactorial = 1;
            uint nPlusOneFactorial = 1;
            uint nTimesTwoFactorial = 1;
            for (byte i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }
            for (byte i = 1; i <= n+1; i++)
            {
                nPlusOneFactorial *= i;
            }
            for (byte i = 1; i <= n*2; i++)
            {
                nTimesTwoFactorial *= i;
            }
            Console.WriteLine(nTimesTwoFactorial/(nPlusOneFactorial*nFactorial));
        }
    }
}
// (2n)!/(n+1)!n!