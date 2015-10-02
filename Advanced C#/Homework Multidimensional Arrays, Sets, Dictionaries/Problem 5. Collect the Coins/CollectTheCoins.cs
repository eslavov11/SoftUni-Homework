using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Collect_the_Coins
{
    class CollectTheCoins
    {
        static void Main(string[] args)
        {
            char[][] arr = new char[4][];
            string input = Console.ReadLine();
            arr[0] = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[0][i] = input[i];
            }
            input = Console.ReadLine();
            arr[1] = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[1][i] = input[i];
            }
            input = Console.ReadLine();
            arr[2] = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[2][i] = input[i];
            }
            input = Console.ReadLine();
            arr[3] = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[3][i] = input[i];
            }
            string commands = Console.ReadLine();
            int walls = 0;
            int coins = 0;
            bool outBound = false;
            for (int i = 0, row = 0, col = 0; i < commands.Length; i++)
            {
                try
                {
                    if (commands[i] == '^')
                    {
                        col--;
                        if (arr[col][row] == '$')
                        {
                            arr[col][row] = ' ';
                            coins++;
                        }
                    }
                    else if (commands[i] == '<')
                    {
                        row--;
                        if (arr[col][row] == '$')
                        {
                            arr[col][row] = ' ';
                            coins++;
                        }
                    }
                    else if (commands[i] == '>')
                    {
                        row++;
                        if (arr[col][row] == '$')
                        {
                            arr[col][row] = ' ';
                            coins++;
                        }
                    }
                    else
                    {
                        outBound = true;
                        col++;
                        if (arr[col][row] == '$')
                        {
                            arr[col][row] = ' ';
                            coins++;
                        }
                    }
                }
                catch (Exception)
                {
                    if (col < 0)
                    {
                        col++;
                    }
                    else if (row<0)
                    {
                        row++;
                    }
                    else if (outBound)
                    {
                        outBound = false;
                        col--;
                    }
                    else
                    {
                        row--;
                    }
                    walls++;
                }
            }
            Console.WriteLine("Coins collected:" + coins);
            Console.WriteLine("Walls hit: " + walls);
        }
    }
}
