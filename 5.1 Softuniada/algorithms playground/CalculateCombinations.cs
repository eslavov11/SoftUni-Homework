using System;
using System.Linq;

class CalculateCombinations
{
    static int size;
    static int[] arr;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine()),
            k = int.Parse(Console.ReadLine());
        size = n;
        arr = new int[k];

        GenerateCombination(1, k - 1);
    }

    static void GenerateCombination(int previous, int index)
    {
        if (index < 0)
        {
            Console.WriteLine(string.Join("", arr.Reverse()));
            return;
        }

        for (int i = previous; i <= size; i++)
        {
            arr[index] = i;
            GenerateCombination(previous, index - 1);
            previous++;
        }
    }
}
