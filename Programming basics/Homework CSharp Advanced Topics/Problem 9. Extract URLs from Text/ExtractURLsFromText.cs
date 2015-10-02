using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractURLsFromText
{
    class ExtractURLsFromText
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter text with at least one url: ");
            string input = Console.ReadLine();
            string[] text = input.Split();
            List<string> results = new List<string>();
            foreach (string link in text)
            {
                if (link.Last() == '.')
                {
                    int len = link.Length - 1;
                    string link1 = link.Substring(0, len);
                    if (!results.Contains(link1) && (link1.Length > 6))
                    {
                        if (link1.Substring(0, 7) == "http://" || (link1.Substring(0, 4) == "www."))
                        {
                            results.Add(link1);
                        }
                    }
                }
                else
                {
                    if (!results.Contains(link) && (link.Length > 6))
                    {
                        if (link.Substring(0, 7) == "http://" || (link.Substring(0, 4) == "www."))
                        {
                            results.Add(link);
                        }
                    }
                }

            }
            foreach (string link in results)
            {
                Console.WriteLine("{0} ", link);
            }
        }
    }
}