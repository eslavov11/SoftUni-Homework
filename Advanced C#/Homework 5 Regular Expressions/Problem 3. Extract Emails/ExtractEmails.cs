using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_3.Extract_Emails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string pattern = @"[A-Za-z][A-Za-z0-9-_\.]{1,}@[a-z\-]{1,}\.([a-z]{1,}|[a-z]{1,}\.[a-z]{1,})";
            Regex regex = new Regex(pattern);
            string[] input = Console.ReadLine().Split(' ');
            foreach (var item in input)
            {
                if (regex.IsMatch(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
