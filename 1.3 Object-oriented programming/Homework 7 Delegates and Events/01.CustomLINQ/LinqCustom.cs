using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CustomLINQ
{
    public static class LinqCustom
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> condition)
        {
            var resultCollection = new List<T>();
            foreach (var element in collection)
            {
                if (!condition(element))
                {
                    resultCollection.Add(element);
                }
            }
            return resultCollection;
        }

        public static TSelector Max<TSource, TSelector>(
            this IEnumerable<TSource> collection,
            Func<TSource, TSelector> selector)
            where TSelector : IComparable<TSelector>
        {
            TSelector max = selector(collection.First());
            foreach (var element in collection)
            {
                
                if (selector(element).CompareTo(max) == 1)
                {
                    max = selector(element);
                }
            }
            return max;
        }
    }
}
