using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Matrix_shuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string[,] arr = new string[n1,n2];
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    arr[i, j] = Console.ReadLine();
                }
            }
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    Console.WriteLine();
                    break;
                }
                Console.WriteLine();
                string[] inputs = input.Split(' ');
                if (inputs[0] == "swap" &&  Convert.ToInt32(inputs[1])<n1 && Convert.ToInt32(inputs[2])<n2 && Convert.ToInt32(inputs[3])<n1 
                    && Convert.ToInt32(inputs[4])<n2)
                {
                    int x1 = Convert.ToInt32(inputs[1]);
                    int x2 = Convert.ToInt32(inputs[2]);
                    int y1 = Convert.ToInt32(inputs[3]);
                    int y2 = Convert.ToInt32(inputs[4]);

                    string temp = arr[x1, x2];
                    arr[x1, x2] = arr[y1, y2];
                    arr[y1, y2] = temp;

                    Console.WriteLine("(after swapping {0} and {1}):", arr[x1, x2], arr[y1, y2]);
                    for (int i = 0; i < n1; i++)
                    {
                        for (int j = 0; j < n2; j++)
                        {
                            Console.Write(arr[i,j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                
            }
        }
    }
}
