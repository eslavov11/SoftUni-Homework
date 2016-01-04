using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
public class Program
{
    public static void Main()
    {
        string patternInt = @"int\s+([a-z][a-zA-z0-9]*)(\s*=\s*\d{1,}\;)?";
        string patternDouble = @"double\s+([a-z][a-zA-z0-9]*)(\s*=\s*\d{1,}\;|\s*=\s*[0-9,.]{1,})?";
        StringBuilder text = new StringBuilder();
        string input = Console.ReadLine();
        while (input != "//END_OF_CODE")
        {
            text.Append(input);
            input = Console.ReadLine();
        }

        MatchCollection matchInt1 = Regex.Matches(text.ToString(), patternInt);
        MatchCollection matchDouble1 = Regex.Matches(text.ToString(), patternDouble);



        string[] matchInt = new string[matchInt1.Count];
        for (int i = 0; i < matchInt1.Count; i++)
        {
            matchInt[i] = matchInt1[i].ToString();
        }

        string[] matchDouble = new string[matchDouble1.Count];
        for (int i = 0; i < matchDouble1.Count; i++)
        {
            matchDouble[i] = matchDouble1[i].ToString();
        }
        Array.Sort(matchInt);
        Array.Sort(matchDouble);
        //var matchInt = matchInt1.ToString().OrderBy(x => x);
        //var matchDouble = matchDouble1.ToString().OrderBy(x => x);

        if (matchDouble1.Count == 0)
        {
            Console.Write("Doubles: None");
        }
        else
        {
            Console.Write("Doubles: ");
        }
        int index = 0;
        foreach (var item in matchDouble)
        {
            if (index < matchDouble1.Count-1)
            {
                Console.Write(Regex.Replace(item.ToString(), patternDouble, @"$1") + ", ");
            }
            else
            {
                Console.Write(Regex.Replace(item.ToString(), patternDouble, @"$1"));
            }
            index++;
        }
        Console.WriteLine();


        if (matchInt1.Count == 0)
        {
            Console.Write("Ints: None");
        }
        else
        {
            Console.Write("Ints: ");
        }
        index = 0;
        foreach (var item in matchInt)
        {
            if (index < matchInt1.Count-1)
            {
                Console.Write(Regex.Replace(item.ToString(), patternInt, @"$1") + ", ");
            }
            else
            {
                Console.Write(Regex.Replace(item.ToString(), patternInt, @"$1"));

            }
            index++;
        }
        Console.WriteLine();


    }
}

