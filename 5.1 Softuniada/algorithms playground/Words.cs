using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static HashSet<string> words = new HashSet<string>();
    private static int count = 0;

    static void GenPermutations(StringBuilder input, int index)
    {
        if (index == input.Length)
        {
            if (CheckForMatch(input)) ++count;
        }
        else
        {
            for (int i = index; i < input.Length; i++)
            {
                char temp = input[i];
                input[i] = input[index];
                input[index] = temp;
                GenPermutations(input, index + 1);
                temp = input[i];
                input[i] = input[index];
                input[index] = temp;
            }
        }
    }

    static void Main(string[] args)
    {
        StringBuilder input = new StringBuilder().Append(Console.ReadLine());
        GenPermutations(input, 0);
        Console.WriteLine(count);
    }

    private static bool CheckForMatch(StringBuilder sb)
    {
        char first = sb[0];
        for (int i = 1; i < sb.Length; i++)
        {
            if (first == sb[i]) return false;
            first = sb[i];
        }
        if (words.Contains(sb.ToString()))
        {
            return false;
        }
        words.Add(sb.ToString());
        return true;
    }
}