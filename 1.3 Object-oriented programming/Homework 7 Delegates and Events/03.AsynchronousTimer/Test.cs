﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AsynchronousTimer
{
    public class Test
    {
        public static void PrintGreenNumberOnConsole(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(number);
        }

        public static void PrintRedNumberOnConsole(int num)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(num);
        }

        public static void MakeSound(int num)
        {
            Console.ResetColor();
            Console.Beep();
        }

        static void Main()
        {
            AsyncTimer printGreen = new AsyncTimer(PrintGreenNumberOnConsole, 7, 2000);
            printGreen.ExecuteAction();

            AsyncTimer printRed = new AsyncTimer(PrintRedNumberOnConsole, 10, 1000);
            printRed.ExecuteAction();

            AsyncTimer beep = new AsyncTimer(MakeSound, 10, 1500);
            beep.ExecuteAction();
        }
    }
}
