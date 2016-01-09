using System;

class GroupsOfEqualSum
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        if (a + b == c + d)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (a+b));
        }
        else if (a + c == d + b)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (a + c));
        }
        else if (a + d == c + b)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (a + d));
        }
        else if (a + c == d + b)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (a + c));
        }
        else if (a + b + c == d)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (d));
        }
        else if (a + c + d == b)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (b));
        }
        else if (b + c  + d == a)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (a));
        }
        else if (b + d + a == c)
        {
            Console.WriteLine("Yes" + Environment.NewLine + (c));
        }
        else Console.WriteLine("No");
    }
}