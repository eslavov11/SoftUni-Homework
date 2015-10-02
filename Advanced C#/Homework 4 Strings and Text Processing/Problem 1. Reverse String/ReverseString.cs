using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Reverse_String
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(ReverseStringBuilder(input));
        }
        public static string ReverseStringBuilder(string input)
        {
            StringBuilder reverse = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverse.Append(input[i]);
            }
            return reverse.ToString();
        }
    }
}
