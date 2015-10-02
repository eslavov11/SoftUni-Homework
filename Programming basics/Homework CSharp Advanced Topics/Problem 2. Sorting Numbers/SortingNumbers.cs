using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Sorting_Numbers
{
    class SortingNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(nums);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
