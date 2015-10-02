using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_14.Decimal_to_Binary_Number
{
    class DecimalToBinaryNumber
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            Console.WriteLine("Binary:  {0}", result);
        }
    }
}
