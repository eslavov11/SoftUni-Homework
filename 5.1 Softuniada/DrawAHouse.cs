using System;

class DrawAHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int startingDots = n - 1;
        int innerSpaces = 1;
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                Console.WriteLine(new string('.', startingDots) + "*" + new string('.', startingDots));
                startingDots--;
            }
            else if (i == n-1)
            {
                Print(n);
            }
            else
            {
                Console.WriteLine(new string('.', startingDots) + 
                    "*" +
                    new string(' ', innerSpaces) +
                    "*" + new string('.', startingDots));
                innerSpaces += 2;
                startingDots--;
            }
        }
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            if (i == 0 || i == n - 1)
            {
                Console.WriteLine("+" + new string('-', n*2-3) + "+");
            }
            else
            {
                Console.WriteLine("|" + new string(' ', n * 2 - 3) + "|");
            }
        }
    }

    private static void Print(int n)
    {
        for (int i = 0; i < 2*n-1; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write('*');
            }
            else
            {
                Console.Write(' ');
            }
        }
    }
}