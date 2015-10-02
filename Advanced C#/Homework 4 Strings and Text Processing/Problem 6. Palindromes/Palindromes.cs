using System;
class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] words = text.Split(' ', ',', '?', '!', '.');

        for (int i = 0; i < words.Length; i++)
        {
            int count = 0;
            for (int j = 0, h = words[i].Length - 1; j < h; j++, h--)
            {
                char[] temp = words[i].ToCharArray();
                if (temp[j] == temp[h])
                {
                    count++;
                }
            }
            if (count == words[i].Length / 2)
            {
                Console.Write(words[i] + " ");
            }
        }
        Console.WriteLine();
    }
}
