using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11.Random_Numbers_in_Given_Range
{
    class RandomNumbersInGivenRange
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.Write(rnd.Next(min,max) + " ");
            }
            Console.WriteLine();
        }
    }
}
