namespace Methods
{
    using System;
    using System.Linq;

    using Interfaces;
    using UI;

    public class Methods
    {
        private static IUserInterface userInterface = new ConsoleUserInterface();

        private Methods()
        {
            userInterface = new ConsoleUserInterface();
        }

        public static double CalcTriangleArea(double a, double b, double c)
        {
            EnsureSidesPositive(a, b, c);

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string DigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: 
                    throw new ArgumentOutOfRangeException(nameof(number), "Invalid number");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Invalid elements length.");
            }

            int maxValue = elements.Max();

            return maxValue;
        }

        public static void PrintNumberFormat(object number, string format)
        {
            switch (format)
            {
                case "f":
                    userInterface.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    userInterface.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    userInterface.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("The specified format was not recognized.", nameof(format));
            }
        }

        public static double CalcDistance(
            double x1,
            double y1,
            double x2,
            double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1));

            return distance;
        }

        public static void Main()
        {
            userInterface.WriteLine(CalcTriangleArea(3, 4, 5));

            userInterface.WriteLine(DigitToWord(5));

            userInterface.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberFormat(1.3, "f");
            PrintNumberFormat(0.75, "%");
            PrintNumberFormat(2.30, "r");


            double x1 = 3;
            double y1 = -1;
            double x2 = 3;
            double y2 = 2.5;

            bool horizontal = y1 == y2;
            bool vertical = x1 == x2;

            userInterface.WriteLine(CalcDistance(x1, y1, x2, y2));
            userInterface.WriteLine("Horizontal? " + horizontal);
            userInterface.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            

            Student stella = new Student(
                "Stella", 
                "Markova", 
                "From Vidin, gamer, high results, born at 03.11.1993");

            userInterface.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella.OtherInfo));
        }

        private static void EnsureSidesPositive(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }
        }
    }
}
