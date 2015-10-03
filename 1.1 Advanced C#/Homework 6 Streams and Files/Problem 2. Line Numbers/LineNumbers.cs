using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem_2.Line_Numbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("textInput.txt"); // files in bin/debug
            StreamWriter writer = new StreamWriter("textOutput.txt");
            using (reader)
            {
                using (writer)
                {
                    int i = 1;
                    string input = reader.ReadLine();
                    while (input != null)
                    {
                        writer.WriteLine(i + "." + input);
                        input = reader.ReadLine();
                        i++;
                    }
                }
            }
        }
    }
}
