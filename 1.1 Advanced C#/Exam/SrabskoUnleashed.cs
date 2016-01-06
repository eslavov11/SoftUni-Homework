using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //Lepa Brena @Sunny Beach 25 3500
        var srubskoData = new Dictionary<string, Dictionary<string, long>>(); // Tuple<long,long>
        string pattern = @"^(.+[A-Za-z]+)\s@(.+[A-Za-z]+)\s(\d+)\s(\d+)$";
        string input = Console.ReadLine();

        while (input != "End")
        {
            if (Regex.IsMatch(input, pattern))
            {

                string venue = Regex.Replace(input, pattern, "$2");
                string singer = Regex.Replace(input, pattern, "$1");
                long ticketPrice = Convert.ToInt64(Regex.Replace(input, pattern, "$3"));
                long ticketsCount = Convert.ToInt64(Regex.Replace(input, pattern, "$4"));

                if (!srubskoData.ContainsKey(venue))
                {
                    srubskoData.Add(venue, new Dictionary<string, long>());
                }
                if (!srubskoData[venue].ContainsKey(singer))
                {
                    srubskoData[venue][singer] = 0;
                }
                srubskoData[venue][singer] += (ticketPrice * ticketsCount);

            }
            input = Console.ReadLine();
        }
       foreach (var venue in srubskoData)
       {
           Console.WriteLine(venue.Key);
           foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
           {
               Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
           }
       }
    }
}

