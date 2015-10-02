using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Numbers_from_1_to_N
{
    class NumbersFrom1ToN
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write((i+1) + " ");
            }
            Console.WriteLine();
        }
    }
}
