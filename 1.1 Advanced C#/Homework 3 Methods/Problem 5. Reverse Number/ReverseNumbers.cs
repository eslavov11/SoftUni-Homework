using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Reverse_Number
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            string reversed = Console.ReadLine();
            Console.WriteLine(GetReversed(reversed));
        }

        private static string GetReversed(string reversed)
        {
            string newNumber = "";
            for (int i = reversed.Length-1; i >= 0; i--)
            {
                newNumber += reversed[i];
            }
            return newNumber;
        }
    }
}
