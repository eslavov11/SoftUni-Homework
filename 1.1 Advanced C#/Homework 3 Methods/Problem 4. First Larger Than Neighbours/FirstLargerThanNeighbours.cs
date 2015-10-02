using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.First_Larger_Than_Neighbours
{
    class FirstLargerThanNeighbours
    {
        static void Main(string[] args)
        {
            Console.Write("Type in the elements of the array (each separated by space):");
            string[] numbers = Console.ReadLine().Split(' ');
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsLargerThanNeighbours(numbers, i))
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("-1");
        }
        private static bool IsLargerThanNeighbours(string[] numbers, int i)
        {
            bool isLarger = false;
            try
            {
            if (i == numbers.Length - 1 && Convert.ToInt32(numbers[i]) > Convert.ToInt32(numbers[i - 1]))
            {
                isLarger = true;
            }
            else if (i == 0 && Convert.ToInt32(numbers[i]) > Convert.ToInt32(numbers[i +1]))
            {
                isLarger = true;
            }
            else if (Convert.ToInt32(numbers[i]) > Convert.ToInt32(numbers[i + 1]) &&
                Convert.ToInt32(numbers[i]) > Convert.ToInt32(numbers[i - 1]))
            {
                isLarger = true;
            }
            }
            catch (Exception)
            {
            }
            return isLarger;
        }
    }
}
