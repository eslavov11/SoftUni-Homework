using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Predicates
{
    class Test
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("asfasf");
            list.Add("Bogo");
            list.Add("asdfa");
            Console.WriteLine(list.FirstOrDef(x => x == "Bogdo"));
        }
    }
}
