using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Longest_Area_in_Array
{
    class LongestAreaInArray
    {
        static void Main(string[] args)
        {
            uint n;
            string lastString = "", longestSeqString = "";
            uint longestSequence = 1, currentSequence = 0;
            Console.WriteLine("Numer of strings = ");
            CheckInput(out n);
            string[] strings = new string[n];
            for (uint i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the {0} element of the array:", i);
                strings[i] = Console.ReadLine();
                if (lastString == strings[i])
                {
                    currentSequence++;
                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                        longestSeqString = strings[i];
                    }
                }
                else
                {
                    currentSequence = 1;
                }
                lastString = strings[i];
            }

            Console.WriteLine(longestSequence);

            for (int i = 1; i <= longestSequence; i++)
            {
                Console.WriteLine(longestSeqString);
            }
        }

        static void CheckInput(out uint number)
        {
            while (!uint.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input, try again!");
            }
        }
    }
}
