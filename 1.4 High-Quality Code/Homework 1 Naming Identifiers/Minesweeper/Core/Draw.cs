namespace Minesweeper.Core
{
    using System;
    using System.Collections.Generic;

    public class Draw
    {
        public static void Scoreboard(List<Score> score)
        {
            Console.WriteLine("\nPoints:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, score[i].PlayerName, score[i].CurrentScore);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty leaderboard!\n");
            }
        }

        public static void DrawInnerField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0} ", board[row, col]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }
    }
}
