using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Text_Filter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] banned = Console.ReadLine().Split(' ', ',');
            string[] text = Console.ReadLine().Split(' ', ',', '.', '/', '!', '?', '(', ')');
            for (int i = 0; i < text.Length; i++)
            {
                for (int j= 0; j  < banned.Length; j++)
                {
                    if (text[i] == banned[j] && banned[j]!= "")
                    {
                        text[i] = new string('*', text[i].Length);
                    }
                }
            }
            foreach (var item in text)
            {
                Console.Write(item + " ");
            }
        }
    }
}
