using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Last_Digit_of_Number
{
    class LastDigitOfNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetLastDigitAsAWord(number));
        }

        private static string GetLastDigitAsAWord(int number)
        {
            string result = "";
            switch (number%10)
            {
                case 1:
                     result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
                default:  result = "zero";
                    break;
            }
            return result;
        }
    }
}
