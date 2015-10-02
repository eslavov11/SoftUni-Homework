using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Bigger_Number
{
    class BiggerNumber
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int max = GetMax(num1, num2);
            Console.WriteLine(max);
        }

        private static int GetMax(int num1, int num2)
        {
            int max = num1;
            if (max<num2)
            {
                max = num2;
            }
            return max;
        }
    }
}
