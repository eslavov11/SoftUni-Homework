using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Number_Calculations
{
    class NumberCalculations
    {
        static void Main(string[] args)
        {
            //Write methods to calculate the minimum, maximum, average, sum and product of a given set of numbers.
            //I understand set of numbers as an array so that's how I'm implementing the problem.
            Console.Write("Enter the amount of elements in the array: ");
            int[] numbers = new int[int.Parse(Console.ReadLine())];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Enter element #{0}:", i+1);
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Maximum element: " + GetMax(numbers));
            Console.WriteLine("Minimum element: " + GetMin(numbers));
            Console.WriteLine("Average of elements: {0}" , GetAvg(numbers));
            Console.WriteLine("Sum of elements: " + GetSum(numbers));
            Console.WriteLine("Product of elements: " + GetProduct(numbers));
        }

        private static int GetProduct(int[] numbers)
        {
            int product = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }
            return product;
        }

        private static int GetSum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        private static double GetAvg(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            double avg = (double)sum / (double)numbers.Length;
            return avg;
        }

        private static int GetMin(int[] numbers)
        {
            int min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                }
            }
            return min;
        }

        private static int GetMax(int[] numbers)
        {
            int max = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (max<numbers[i])
                {
                    max = numbers[i];
                }
            }
            return max;
        }
    }
}
