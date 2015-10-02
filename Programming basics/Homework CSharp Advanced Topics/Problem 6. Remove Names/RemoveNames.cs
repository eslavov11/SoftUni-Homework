using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNames
{
    class RemoveNames
    {
        static void Main()
        {
            Console.Write("enter main list: ");
            string mainList = Console.ReadLine();
            Console.Write("enter replace list: ");
            string replaceList = Console.ReadLine();

            List<string> firstList = new List<string>(mainList.Split());
            List<string> secondList = new List<string>(replaceList.Split());
            foreach (var item in secondList)
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    if (item == firstList[i])
                    {
                        firstList.RemoveAt(i); i--;
                    }
                }
            }
            foreach (var item in firstList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}