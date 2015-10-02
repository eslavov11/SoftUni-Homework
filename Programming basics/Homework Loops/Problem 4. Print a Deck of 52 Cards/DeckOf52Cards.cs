using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Print_a_Deck_of_52_Cards
{
    class DeckOf52Cards
    {
        static void Main(string[] args)
        {
            char[] suits = { '♣', '♦', '♦', '♠' };
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (i)
                    {
                        case 1:
                            Console.Write("A" + suits[j] + " ");
                            break;
                        case 2:
                            Console.Write("2" + suits[j] + " ");
                            break;
                        case 3:
                            Console.Write("3" + suits[j] + " ");
                            break;
                        case 4:
                            Console.Write("4" + suits[j] + " ");
                            break;
                        case 5:
                            Console.Write("5" + suits[j] + " ");
                            break;
                        case 6:
                            Console.Write("6" + suits[j] + " ");
                            break;
                        case 7:
                            Console.Write("7" + suits[j] + " ");
                            break;
                        case 8:
                            Console.Write("8" + suits[j] + " ");
                            break;
                        case 9:
                            Console.Write("9" + suits[j] + " ");
                            break;
                        case 10:
                            Console.Write("10" + suits[j] + " ");
                            break;
                        case 11:
                            Console.Write("J" + suits[j] + " ");
                            break;
                        case 12:
                            Console.Write("Q" + suits[j] + " ");
                            break;
                        case 13:
                            Console.Write("K" + suits[j] + " ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
//2♣ 2♦ 2♦ 2♠
