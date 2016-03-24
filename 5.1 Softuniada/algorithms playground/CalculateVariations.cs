using System;
using System.Linq;

class CalculateVariations
{
    static int size;
    static int[] arr;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine()),
            k = int.Parse(Console.ReadLine());
        size = n;
        arr = new int[k];

        GenerateVariation(k - 1);
    }

    static void GenerateVariation(int index)
    {
        if (index < 0)
        {
            Console.WriteLine(string.Join("", arr.Reverse()));
            return;
        }

        for (int i = 1; i <= size; i++)
        {
            arr[index] = i;
            GenerateVariation(index - 1);
        }
    }
}
