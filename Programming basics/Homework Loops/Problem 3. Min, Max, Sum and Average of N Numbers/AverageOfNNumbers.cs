using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Min__Max__Sum_and_Average_of_N_Numbers
{
    class AverageOfNNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (max < num)
                {
                    max = num;
                }
                if (min > num)
                {
                    min = num;
                }
            }
            Console.WriteLine("min: " + min);
            Console.WriteLine("max: " + max);
            Console.WriteLine("sum: " + sum);
            Console.WriteLine("avg: " + sum/n);
        }
    }
}
