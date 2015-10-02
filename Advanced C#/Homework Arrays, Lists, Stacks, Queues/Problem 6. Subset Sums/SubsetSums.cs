using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{

    static int n;
    static int max;
    static int[] set;
    static List<int> subset;
    static byte[] binary;
    static int flag;
    static void Main()
    {
        max = int.Parse(Console.ReadLine());
        set = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).Distinct().ToArray();
        n = set.Length;
        subset = new List<int>(n);
        binary = new byte[n];
        flag = 0;
        int size = 2 << (n - 1);
        for (int i = 0; i < size; i++)
        {
            if (i != 0)
                Printsubset();
            BinaryIncrement();
        }
        if (flag == 0)
            Console.WriteLine("No matching subsets");
    }
    static void BinaryIncrement()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (binary[i] == 0)
            {
                binary[i] = 1;
                return;
            }
            binary[i] = 0;
        }
    }
    static void Printsubset()
    {
        subset.Clear();
        for (int i = n - 1; i >= 0; i--)
        {
            if (binary[i] == 1)
                subset.Add(set[n - 1 - i]);
        }
        if (subset.Sum() == max)
        {
            Console.WriteLine(String.Join(" + ", subset));
            flag = 1;
        }
    }
}