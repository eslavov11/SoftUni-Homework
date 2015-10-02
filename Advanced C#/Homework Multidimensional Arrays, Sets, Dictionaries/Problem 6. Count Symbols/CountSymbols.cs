using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Count_Symbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> letter = new Dictionary<char, int>();
            int count = 0; ;
            for (int i = 0; i < input.Length; i++)
            {
                if (letter.ContainsKey(input[i]) == false)
                {
                    letter.Add(input[i], 1);
                }
                else
                {
                    letter[input[i]]++;
                }
            }
            foreach (var item in letter)
            {
                Console.WriteLine("{0}: {1} time/s",item.Key,item.Value);
            }
        }
    }
}
