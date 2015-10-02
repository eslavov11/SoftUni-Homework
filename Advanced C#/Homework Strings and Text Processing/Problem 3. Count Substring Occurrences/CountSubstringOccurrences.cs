using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Count_Substring_Occurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string compare = Console.ReadLine().ToLower();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string temp = "";
                for (int j = i; j < compare.Length+i; j++)
                {
                    try
                    {
                        temp += input[j];
                    }
                    catch (Exception)
                    {
                    }
                    if (compare == temp)
                    {
                        count++;                        
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
