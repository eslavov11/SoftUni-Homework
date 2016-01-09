using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class StarsInTheCube
{
    static Dictionary<char, int> found = new Dictionary<char, int>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[,,] cube = new char[n, n, n];
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Replace(" ", "").Split('|');
            for (int j = 0; j < n; j++)
            {
                string token = tokens[j];
                for (int k = 0; k < n; k++)
                {
                    cube[j, i, k] = token[k];
                }
            }
        }

        for (int i = 0; i < n-2; i++)
        {
            for (int j = 1; j < n-1; j++)
            {
                for (int k = 1; k < n-1; k++)
                {
                    if (cube[i, j, k] != cube[i + 1, j, k] || cube[i, j, k] != cube[i + 1, j, k] ||
                        cube[i, j, k] != cube[i + 1, j, k - 1] || cube[i, j, k] != cube[i + 1, j - 1, k] ||
                        cube[i, j, k] != cube[i + 1, j, k + 1] || cube[i, j, k] != cube[i + 1, j + 1, k] ||
                        cube[i, j, k] != cube[i + 2, j, k]) continue;
                    if (!found.ContainsKey(cube[i,j,k]))
                    {
                        found.Add(cube[i,j,k],0);
                    }
                    found[cube[i, j, k]]++;
                    //Console.Write(cube[i,j,k]);
                }
                //Console.WriteLine();
            }
            //Console.WriteLine();
            //Console.WriteLine();
        }

        Console.WriteLine(found.Sum(x => x.Value));

        foreach (var star in found.OrderBy(x => x.Key))
        {
            Console.WriteLine(star.Key + " -> " + star.Value);
        }
    }
}