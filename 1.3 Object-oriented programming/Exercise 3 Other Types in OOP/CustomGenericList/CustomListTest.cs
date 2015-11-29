using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericList
{
    class CustomListTest
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            list.Add(-55555);
            list.Add(1000);
            list.Add(55481000);
            list.Add(5);
            list.Add(1000);
            Console.WriteLine(list.Min);
            list.Remove(1000);
            list[1] = 50;

            Console.WriteLine(list);
        }
    }
}
