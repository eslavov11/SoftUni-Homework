using System;
using System.Text.RegularExpressions;
class SeriesOfletters
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = "";
        string replaceChar = "";
        for (int i = 0; i < input.Length; i++)
        {
            pattern = input[i] + "+";
            replaceChar = input[i].ToString();
            Regex regex = new Regex(pattern);
            input = regex.Replace(input, replaceChar);
        }
        Console.WriteLine(input);
    }
}