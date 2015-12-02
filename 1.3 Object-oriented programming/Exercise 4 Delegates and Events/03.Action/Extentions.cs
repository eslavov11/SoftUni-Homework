using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Action
{
    public static class Extentions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action )
        {
            foreach (var element in collection)
            {
                action(element);
            }   
        }
    }
}
