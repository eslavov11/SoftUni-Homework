using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_13.Binary_to_Decimal_Number
{
    class BinaryToDecimalNumber
    {
        static void Main(string[] args)
        {
            string binaryNumber = Console.ReadLine();
            ulong result = 0;
            for (int i = binaryNumber.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (binaryNumber[i] == '1')
                {
                    result += (ulong)Math.Pow(2, j);
                }
            }
            Console.WriteLine(result);
        }
    }
}
