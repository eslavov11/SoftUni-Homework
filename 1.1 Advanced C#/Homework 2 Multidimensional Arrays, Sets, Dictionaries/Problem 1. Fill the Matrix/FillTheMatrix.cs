using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Fill_the_Matrix
{
    class FillTheMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            int num = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[j,i]=num;
                    num++;
                }
            }


            int[,] arr2 = new int[n, n];
            int num2 = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0, h = n - 1; j < n; j++, h--)
                {
                    if (i%2==0)
                    {
                        arr2[j, i] = num2;
                    }
                    else
                    {
                        arr2[h, i] = num2;
                    }
                    num2++;
                }
            }

            Console.WriteLine("Matrix 1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Matrix 2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr2[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
