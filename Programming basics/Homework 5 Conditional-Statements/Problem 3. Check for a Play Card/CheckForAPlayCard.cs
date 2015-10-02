using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Check_for_a_Play_Card
{
    class CheckForAPlayCard
    {
        static void Main(string[] args)
        {
            string cardFace = Console.ReadLine();
            if (cardFace == "2" || cardFace == "3" || cardFace == "4" || cardFace == "5" || cardFace == "6" ||
                cardFace == "7" || cardFace == "8" || cardFace == "9" || cardFace == "10" || cardFace == "J" ||
                cardFace == "Q" || cardFace == "K" || cardFace == "A")
            {
                Console.WriteLine("Yes");
                return;
            }
            Console.WriteLine("No");
        }
    }
}
//  Classical play cards use the following signs to designate the card face:
//  2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints
//  “yes” if it is a valid card sign or “no” otherwise. Examples: