using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceMatrix_4
{
    class SequenceMatrix_4
    {
        static string[,] matrix;
        static string currentString = String.Empty;

        static void LongestSequence()
        {
            int longestSeq = 0;
            string maxRepeatable = String.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentString = matrix[i, j];
                    int rowCount = CountRow(i, j);
                    int colCount = CountCol(i, j);
                    int diagCount = CountDiagonal(i, j);
                    int temp = Math.Max(Math.Max(rowCount, colCount), diagCount);
                    if (temp > longestSeq)
                    {
                        longestSeq = temp;
                        maxRepeatable = currentString;
                    }
                }
            }
            PrintResult(longestSeq, maxRepeatable);
        }
        static int CountRow(int i, int j)
        {
            int counter = 1;
            for (int a = j + 1; a < matrix.GetLength(1); a++)
            {
                if (matrix[i, a] == currentString)
                {
                    counter++;
                }
            }
            return counter;
        }
        static int CountCol(int i, int j)
        {
            int counter = 1;
            for (int a = i + 1; a < matrix.GetLength(0); a++)
            {
                if (matrix[a, j] == currentString)
                {
                    counter++;
                }
            }
            return counter;
        }
        static int CountDiagonal(int i, int j)
        {
            int counter = 1;
            int diagonal = (matrix.GetLength(0) < matrix.GetLength(1)) ? matrix.GetLength(0) : matrix.GetLength(1);
            for (int a = j + 1; a < diagonal; a++)
            {
                if (matrix[a, a] == currentString)
                {
                    counter++;
                }
            }
            return counter;
        }
        static void PrintResult(int count, string word)
        {
            for (int a = 0; a < matrix.GetLength(0); a++)
            {
                for (int b = 0; b < matrix.GetLength(1); b++)
                {
                    Console.Write("|{0,4}|", matrix[a, b]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("longest sequence is:");
            for (int c = 0; c < count; c++)
            {
                Console.Write("{0},", word);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            matrix = new string[row, col];

            for (int a = 0; a < row; a++)
            {
                for (int b = 0; b < col; b++)
                {
                    Console.Write("Enter [{0}, {1}] element: ", a, b);
                    matrix[a, b] = Console.ReadLine();
                }
            }
            LongestSequence();
        }
    }
}