using System;
using System.Linq;
using System.Collections.Generic;


class PerfectGirlfriend
{
    static List<string> daysOfWeek = new List<string> {
                              "",
                              "Monday",
                              "Tuesday",
                              "Wednesday",
                              "Thursday",
                              "Friday",
                              "Saturday",
                              "Sunday",
                          };

    static void Main()
    {
        string input = Console.ReadLine();
        int dates = 0;

        while (input != "Enough dates!")
        {
            string[] tokens = input.Split('\\');
            int day = daysOfWeek.IndexOf(tokens[0]);
            int numberSum = 0;
            foreach (var digit in tokens[1])
            {
                numberSum += digit - 48;
            }
            string bra = tokens[2];
            int braSize = int.Parse(bra.Substring(0, bra.Length - 1));
            int totalBra = braSize * bra[bra.Length - 1];
            string name = tokens[3];
            int nameSum = name[0] * name.Length;
            int total = (day + numberSum + totalBra) - nameSum;
            if (total >= 6000)
            {
                Console.WriteLine("{0} is perfect for you.", name);
                dates++;
            }
            else Console.WriteLine("Keep searching, {0} is not for you.", name);

            input = Console.ReadLine();
        }
        Console.WriteLine(dates);
    }
}
// Wednesday\0896123456\85B\Lilly