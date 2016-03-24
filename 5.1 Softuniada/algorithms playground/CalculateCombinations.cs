using System;
using System.Linq;

class CalculateCombinations
{
    static int size;
    static int[] arr;

    private static int count = 0;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()),
            k = int.Parse(Console.ReadLine());
        size = n;
        arr = new int[k];

        GenerateCombination(1, k - 1);

        Console.WriteLine("\r\nTotal count: " + count);
    }

    static void GenerateCombination(int startNum, int index)
    {
        if (index < 0)
        {
            count++; 
            Console.WriteLine(string.Join("", arr.Reverse()));
            return;
        }

        for (int i = startNum; i <= size; i++)
        {
            arr[index] = i;
            GenerateCombination(i+1, index - 1);
        }
    }
}
