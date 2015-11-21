using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.SquareRoot
{
    class SquareRoot
    {
        private static int squareRootNumber;
        static void Main(string[] args)
        {
            try
            {
                squareRootNumber = int.Parse(ReadLine());
                if (squareRootNumber < 0)
                {
                    throw new System.ArithmeticException();
                }
                System.Console.WriteLine(System.Math.Sqrt(squareRootNumber));
            }
            catch (System.FormatException)
            {
                WriteLine("Number is in the wrong format!");
            }
            catch (System.ArithmeticException)
            {
                System.Console.WriteLine("Number should be positive");
            }
            finally
            {
                WriteLine("Goodbye!");
            }
            
        }
    }
}
