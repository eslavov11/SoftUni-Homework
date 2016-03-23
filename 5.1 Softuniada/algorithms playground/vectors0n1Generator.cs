using System;
using System.Linq;

class GenerateZeroAndOne
{
    private static int[] arr;

    static void Main()
    {
        // Usage: input 3 -> output: 000 001 010 011 100 101 110 111
        int n = int.Parse(Console.ReadLine());
        arr = new int[n];
        GenerateNums(n-1);
    }

    static void GenerateNums(int n)
    {
        if (n < 0)
        {
            PrintNumber(arr);
            return;
        }

        for (int i = 0; i < 2; i++)
        {
            arr[n] = i;
            GenerateNums(n - 1);
        }
    }

    static void PrintNumber(int[] arr)
    {
        Console.WriteLine(string.Join("", arr.Reverse()));
    }
}
