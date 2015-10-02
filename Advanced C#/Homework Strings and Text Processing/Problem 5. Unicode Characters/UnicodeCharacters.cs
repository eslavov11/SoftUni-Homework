using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Unicode_Characters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(GetEscapeSequence(input[i]));
            }
            Console.WriteLine();
        }
        public static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4");
        }
    }
}
