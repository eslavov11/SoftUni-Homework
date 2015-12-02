using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Func
{
    public static class Extentions
    {
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> conditionFunc)
        {
            var resultCollection = new List<T>();
            foreach (T element in collection)
            {
                if (conditionFunc(element))
                {
                    resultCollection.Add(element);
                }
            }
            return resultCollection;
        }
    }
}
