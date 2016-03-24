using System;

class LabyrinthExit
{
    private static readonly char[,] labyrinth = 
    {
        { ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', '*', '*', ' ', '*', ' '},
        { ' ', ' ', '*', ' ', ' ', ' '},
        { ' ', '*', '*', '*', '*', ' '},
        { ' ', ' ', ' ', ' ', ' ', 'e'},
    };

    static void Main()
    {
        FindPath(0, 0);
    }

    static void FindPath(int row, int col)
    {
        if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
        {
            // Stepping outside of the labyrinth.
            return;
        }

        if (labyrinth[row, col] == 'e')
        {
            Console.WriteLine("Exit found");
            PrintLabyrinth();
            return;
        }

        if (labyrinth[row, col] == 'x' || labyrinth[row, col] == '*')
        {
            // Already visited or wall.
            return;
        }

        // Marking visited path
        labyrinth[row, col] = 'x';

        // Recursive call for every direction.
        FindPath(row + 1, col);
        FindPath(row - 1, col);
        FindPath(row, col + 1);
        FindPath(row, col - 1);
        
        // Clearing visited path after visiting every other
        labyrinth[row, col] = ' ';
    }

    static void PrintLabyrinth()
    {
        for (int i = 0; i < labyrinth.GetLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                Console.Write(labyrinth[i,j]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
