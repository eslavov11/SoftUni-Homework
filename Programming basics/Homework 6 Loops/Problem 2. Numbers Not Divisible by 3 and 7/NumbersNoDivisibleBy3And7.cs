using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Numbers_Not_Divisible_by_3_and_7
{
    class NumbersNoDivisibleBy3And7
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
