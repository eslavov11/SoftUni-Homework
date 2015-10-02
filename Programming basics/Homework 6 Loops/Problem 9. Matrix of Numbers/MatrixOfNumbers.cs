using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_9.Matrix_of_Numbers
{
    class MatrixOfNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < n+i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
//  n	matrix
//  4	1 2 3 4
//      2 3 4 5
//      3 4 5 6
//      4 5 6 7
