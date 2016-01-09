using System;
using System.Collections.Generic;
using System.Linq;

class StarClusters
{
    static readonly Dictionary<string, Dictionary<Star,int>> clusters = new Dictionary<string, Dictionary<Star, int>>();


    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(' ');

            Star star = new Star
            {
                X = int.Parse(tokens[1]
                    .Replace("(", "")
                    .Replace(",", "")),

                Y = int.Parse(tokens[2]
                    .Replace(")", ""))
            };
            clusters.Add(tokens[0], new Dictionary<Star, int>());
            clusters[tokens[0]].Add(star, 0);
        }

        string input = Console.ReadLine();

        while (input != "end")
        {
            string[] stars = input.Replace(") (", ", ")
                .Replace(")", "")
                .Replace("(", " ")
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            stars[0] = stars[0].TrimStart();
            for (int i = 0; i < stars.Length - 1; i += 2)
            {
                var star = new Star
                {
                    X = int.Parse(stars[i]),
                    Y = int.Parse(stars[i + 1])
                };

                int deltaX = int.MaxValue;
                int deltaY = int.MaxValue;

                int index = 0;

                foreach (var cluster in clusters)
                {

                    if (Math.Abs(star.X - cluster.Value.First().Key.X) >= deltaX || 
                        Math.Abs(star.Y - cluster.Value.First().Key.Y) >= deltaY)
                        continue;

                    deltaX = Math.Abs(star.X - cluster.Value.First().Key.X);
                    deltaY = Math.Abs(star.Y - cluster.Value.First().Key.Y);
                }

                foreach (var cluster in clusters)
                {
                    if (Math.Abs(star.X - cluster.Value.First().Key.X) == deltaX ||
                        Math.Abs(star.Y - cluster.Value.First().Key.Y) == deltaY)
                    {
                        clusters[clusters.Keys.ElementAt(index)][cluster.Value.First().Key]++;
                    }

                    index++;

                }
            }

            input = Console.ReadLine();

            
        }

        foreach (var cluster in clusters.OrderBy(x => x.Key))
        {
            Console.WriteLine(cluster.Key + $" ({cluster.Value.First().Key.X}, {cluster.Value.First().Key.Y}) -> {cluster.Value.First().Value} stars");
        }
    }

    struct Star
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}