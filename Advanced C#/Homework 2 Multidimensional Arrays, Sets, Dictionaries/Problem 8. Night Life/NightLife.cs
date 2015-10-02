using System;
using System.Collections.Generic;
class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLifeDictionary =
                            new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        string[] eventTokens;
        string city = String.Empty;
        string venue = String.Empty;
        string performer = String.Empty;
        string eventInformation = Console.ReadLine();

        while (eventInformation != "END")
        {
            eventTokens = eventInformation.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            city = eventTokens[0];
            venue = eventTokens[1];
            performer = eventTokens[2];

            if (!nightLifeDictionary.ContainsKey(city))
            {
                nightLifeDictionary[city] = new SortedDictionary<string, SortedSet<string>>();
            }
            if (!nightLifeDictionary[city].ContainsKey(venue))
            {
                nightLifeDictionary[city][venue] = new SortedSet<string>();
            }
            nightLifeDictionary[city][venue].Add(performer);

            eventInformation = Console.ReadLine();
        }

        foreach (var cityPair in nightLifeDictionary)
        {
            Console.WriteLine(cityPair.Key);
            foreach (var venuePair in cityPair.Value)
            {
                Console.WriteLine("->{0}: {1}", venuePair.Key, String.Join(", ", venuePair.Value));
            }
        }
    }
}