using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.WriteLine(Regex.Replace(Console.ReadLine(),@"<a.+href=('|"")(.+)\1>(.+)<\/a>",@"[URL href=$2]$3[/URL]"));
    }
}