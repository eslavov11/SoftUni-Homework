using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StringDisperser
{
    public class Test
    {
        static void Main(string[] args)
        {
            StringDisperser stringDisperser = new StringDisperser("Nakov", "Nasko", "Dancho");

            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();
        }
    }
}
