using System;
class SortArrayOfNumbers
{
    static void Main()
    {
        string numbers = Console.ReadLine();
        string[] arr = numbers.Split(' ');
        int[] intArr = Array.ConvertAll<string, int>(arr, int.Parse);
        Array.Sort(intArr);
        for (int i = 0; i < intArr.Length; i++)
        {
            Console.Write(intArr[i] + " ");
        }
        Console.WriteLine();
    }
}