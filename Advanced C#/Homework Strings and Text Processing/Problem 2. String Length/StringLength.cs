using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.String_Length
{
    class StringLength
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string of maximum 20 characters: ");
            string input = Console.ReadLine().PadRight(20, '*');
            Console.WriteLine(input);
        }
    }
}
