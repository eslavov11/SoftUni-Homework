using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2.EnterNumbers
{
    class EnterNumbers
    {
        const int start = 1;
        const int end = 100;

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                string number = Console.ReadLine();
                ReadNumbers(number, start, end);
            }
            Console.WriteLine("Program completed!");
        }

        private static void ReadNumbers(string number, int start, int end)
        {
            try
            {
                int num = int.Parse(number);
                if (num < start || num > end)
                {
                    throw new ArithmeticException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Number is in the wrong format!");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine($"Number cannot be smaller than {start} and greather than {end}");
            }
        }
    }
}
