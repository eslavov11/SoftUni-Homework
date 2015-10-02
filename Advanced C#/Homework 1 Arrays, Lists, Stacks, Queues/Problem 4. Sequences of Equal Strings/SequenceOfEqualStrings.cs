using System;
class SequenceOfEqualStrings
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string[] arr = text.Split(' ');
        string word = arr[0];
        string[] words = new string[arr.Length];
        words[0] = word;
        int[] count = new int[arr.Length];
        for (int i = 0, j= 0,h=1; i < arr.Length; i++)
        {
            if (word != arr[i])
            {
                word = arr[i];
                words[h] = arr[i];
                j++;
                h++;
                count[j]++;
            }
            else
            {
                count[j]++;
            }
        }
        int m = 0;
        foreach (var item in words)
        {
            if (count[m]==0)
            {
                break;
            }
            for (int i = 0; i < count[m]; i++)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            m++;
        }
    }
}
