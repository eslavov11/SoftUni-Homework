using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinLists
{
    class JoinLists
    {
        static void Main()
        {
            Console.Write("enter first list of integers: ");
            string first = Console.ReadLine();
            var numbers1 = Array.ConvertAll(first.Split(' '), int.Parse).ToList();

            Console.Write("enter second list of integers: ");
            string second = Console.ReadLine();
            var numbers2 = Array.ConvertAll(second.Split(' '), int.Parse).ToList();
            numbers1.AddRange(numbers2);

            numbers1.Sort();
            for (int i = 0; i < numbers1.Count; i++)
            {
                if (i == numbers1.Count - 1)
                {
                    break;
                }
                else
                {
                    if (numbers1[i] == numbers1[i + 1])
                    {
                        numbers1.RemoveAt(i); i--;
                    }
                }
            }

            foreach (var item in numbers1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }
    }
}