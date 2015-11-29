
using CustomGenericList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>(3);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Insert(1, 40);
            Console.WriteLine(list.Count);
            Console.WriteLine(list);

            System.Reflection.MemberInfo info = typeof(CustomList<>);
            foreach (object attribute in info.GetCustomAttributes(false))
            {
                Console.WriteLine(attribute);
            }
        }
    }
}
