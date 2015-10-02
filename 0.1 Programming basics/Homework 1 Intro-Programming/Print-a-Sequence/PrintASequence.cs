using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_a_Sequence
{
    class PrintASequence
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 11; i++)
            {
                if (i%2!=0)
                {
                    Console.Write("-" + i + ",");
                }
                else
                {
                    Console.Write(i + ",");
                }
            }
            Console.WriteLine();
        }
    }
}
