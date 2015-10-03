using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem_1.Odd_Lines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt"); // file in bin/debug
            using (reader)
            {
                int lines = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lines++;
                    if (lines % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
