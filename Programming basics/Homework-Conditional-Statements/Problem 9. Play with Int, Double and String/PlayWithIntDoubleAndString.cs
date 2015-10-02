using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_9.Play_with_Int__Double_and_String
{
    class PlayWithIntDoubleAndString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose a type:");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");
            byte choise = byte.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Console.Write("Please enter a int: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.WriteLine(a+1);
                    break;
                case 2:
                    Console.Write("Please enter a double: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.WriteLine(b + 1);
                    break;
                case 3:
                    Console.Write("Please enter a string: ");
                    string c = (Console.ReadLine());
                    Console.WriteLine(c + "*");
                    break;
                default:
                    break;
            }
        }
    }
}
//  Write a program that, depending on the user’s choice, inputs an int, double or string variable.
//  If the variable is int or double, the program increases it by one. If the variable is a string, the 
//  program appends "*" at the end. Print the result at the console. Use switch statement. Example:
//  Please choose a type:
//  1 --> int
//  2 --> double
//  3 --> string
//  Please enter a string:
//  hello*
