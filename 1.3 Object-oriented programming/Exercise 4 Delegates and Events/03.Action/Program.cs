using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Action
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>()
            {
                "Ivan", "Georgi", "Dimitar"
            };
            names.ForEach(Console.WriteLine);
        }
    }
}
