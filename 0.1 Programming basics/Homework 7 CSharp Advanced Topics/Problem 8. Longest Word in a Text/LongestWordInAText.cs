using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestWordInText
{
    class LongestWordInText
    {
        static void Main()
        {
            Console.Write("please input a string: ");
            string input = Console.ReadLine();
            input = input.Replace('.', ' ');
            var strings = input.Split(' ');
            int maxSize = 0; string maxItem = "";
            foreach (var item in strings)
            {
                if (item.Length > maxSize)
                {
                    maxSize = item.Length; maxItem = item;
                }
            }
            Console.WriteLine("the longest word is: \"{0}\"", maxItem);
        }
    }
}