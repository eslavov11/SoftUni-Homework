using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Predicates
{
    public static class Extentions
    {
        public static T FirstOrDef<T>(this IEnumerable<T> collection, Func<T, bool> select)
        {
            foreach (var element in collection)
            {
                if (select(element))
                {
                    return element;
                }
            }
            return default(T);
        }
    }
}
