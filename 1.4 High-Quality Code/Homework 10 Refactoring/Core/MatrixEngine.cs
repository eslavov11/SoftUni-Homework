namespace Matrix.Core
{
    using Interfaces;
    using UserInterface;

    public class MatrixEngine : IEngine
    {
        private readonly IUserInterface userInterface;

        public MatrixEngine()
        {
            this.userInterface = new ConsoleUserInterface();
        }

        public void Run()
        {
            this.userInterface.Write("Enter a positive number: ");
            string input = this.userInterface.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                this.userInterface.WriteLine("You haven't entered a correct positive number.");
                this.userInterface.Write("Enter a positive number: ");
                input = this.userInterface.ReadLine();
            }

            int matrixSize = int.Parse(input);

            var generatedMatrix = this.GenerateMatrix(matrixSize);

            this.PrintMatrix(matrixSize, generatedMatrix);
        }

        public ulong[,] GenerateMatrix(int matrixSize)
        {
            ulong[,] matrix = new ulong[matrixSize, matrixSize];
            ulong index = 1;
            int row = 0, column = 0, deltaX = 1, deltaY = 1;
            while (true)
            {
                //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[row, column] = index;

                if (!CanFindNextCell(matrix, row, column))
                {
                    break;
                } // prekusvame ako sme se zadunili

                while ((row + deltaX >= matrixSize ||
                    row + deltaX < 0 ||
                    column + deltaY >= matrixSize ||
                    column + deltaY < 0 ||
                    matrix[row + deltaX, column + deltaY] != 0))
                {
                    ModifyCellDirection(ref deltaX, ref deltaY);
                }

                row += deltaX;
                column += deltaY;
                index++;
            }

            //this.PrintMatrix(matrixSize, matrix);

            FindNextCell(matrix, out row, out column);

            if (row != 0 && column != 0)
            {
                // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                deltaX = 1;
                deltaY = 1;

                while (CanFindNextCell(matrix, row, column))
                {
                    while (row + deltaX >= matrixSize ||
                           row + deltaX < 0 ||
                           column + deltaY >= matrixSize ||
                           column + deltaY < 0 ||
                           matrix[row + deltaX, column + deltaY] != 0)
                    {
                        ModifyCellDirection(ref deltaX, ref deltaY);
                    }

                    row += deltaX;
                    column += deltaY;
                    index++;

                    matrix[row, column] = index;
                }
            }

            return matrix;
        }

        public void PrintMatrix(int matrixSize, ulong[,] matrix)
        {
            for (int p = 0; p < matrixSize; p++)
            {
                for (int q = 0; q < matrixSize; q++)
                {
                    this.userInterface.Write("{0,3}", matrix[p, q]);
                }

                this.userInterface.WriteLine();
            }
        }

        private static void ModifyCellDirection(ref int deltaX, ref int deltaY)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirectionIndex = 0;
            for (int count = 0; count < 8; count++)
            {
                if (directionX[count] == deltaX &&
                    directionY[count] == deltaY)
                {
                    currentDirectionIndex = count;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                deltaX = directionX[0];
                deltaY = directionY[0];
                return;
            }

            deltaX = directionX[currentDirectionIndex + 1];
            deltaY = directionY[currentDirectionIndex + 1];
        }

        private static bool CanFindNextCell(ulong[,] matrix, int x, int y)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (x + directionX[i] >= matrix.GetLength(0) || x + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (y + directionY[i] >= matrix.GetLength(0) || y + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[x + directionX[i], y + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindNextCell(ulong[,] matrix, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(0); column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        x = row;
                        y = column;
                        return;
                    }
                }
            }
        }
    }
}
