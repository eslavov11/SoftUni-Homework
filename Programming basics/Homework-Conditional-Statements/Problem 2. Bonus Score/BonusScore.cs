using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Bonus_Score
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            if (n>0 && n<4)
            {
                Console.WriteLine(n*10);
            }
            else if (n > 3 && n < 7)
            {
                Console.WriteLine(n * 100);
            }
            else if (n > 6 && n < 10)
            {
                Console.WriteLine(n * 1000);
            }
            else 
                Console.WriteLine("invalid score");


        }
    }
}
//•	If the score is between 1 and 3, the program multiplies it by 10.
//•	If the score is between 4 and 6, the program multiplies it by 100.
//•	If the score is between 7 and 9, the program multiplies it by 1000.
//•	If the score is 0 or more than 9, the program prints “invalid score”.
