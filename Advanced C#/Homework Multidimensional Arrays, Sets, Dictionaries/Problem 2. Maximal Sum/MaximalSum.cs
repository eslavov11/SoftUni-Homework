using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Maximal_Sum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            string[] n = Console.ReadLine().Split(' ');
            int[,] arr = new int[Convert.ToInt32(n[0]),Convert.ToInt32(n[1])];
            for (int i = 0; i < Convert.ToInt32(n[0]); i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                for (int j = 0; j < nums.Length; j++)
                {
                    arr[i, j] = Convert.ToInt32(nums[j]);
                }
            }

            int[,] sum = new int[3, 3];
            int maxSum = 0;
            for (int i = 0; i < Convert.ToInt32(n[0]); i++)
            {
                for (int j = 0; j < Convert.ToInt32(n[1]); j++)
                {
                    try
                    {
                        if (arr[i, j] + arr[i + 1, j] + arr[i - 1, j] + arr[i, j + 1] + arr[i, j - 1] + arr[i + 1, j + 1] + arr[i - 1, j - 1] + arr[i + 1, j - 1] + arr[i - 1, j + 1] > maxSum)
                        {
                            sum[0, 0] = arr[i-1, j-1];
                            sum[0, 1] = arr[i-1, j];
                            sum[0, 2] = arr[i-1, j+1];
                            sum[1, 0] = arr[i, j-1];
                            sum[1, 1] = arr[i, j];
                            sum[1, 2] = arr[i, j+1];
                            sum[2, 0] = arr[i+1, j-1];
                            sum[2, 1] = arr[i+1, j];
                            sum[2, 2] = arr[i+1, j+1];
                            maxSum = arr[i, j] + arr[i + 1, j] + arr[i - 1, j] + arr[i, j + 1] + arr[i, j - 1] + arr[i + 1, j + 1] + arr[i - 1, j - 1] + arr[i + 1, j - 1] + arr[i - 1, j + 1];
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Max Sum = " + maxSum);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(sum[i,j]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
