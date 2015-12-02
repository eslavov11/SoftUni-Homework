using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Func
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new int[]
            {
                5,6,7,8,15, 45
            };

            var biggerThanSeven = list.TakeWhile(x => x > 7);
            foreach (var VARIABLE in biggerThanSeven)
            {
                Console.WriteLine(VARIABLE);
            }

        }
    }
}
