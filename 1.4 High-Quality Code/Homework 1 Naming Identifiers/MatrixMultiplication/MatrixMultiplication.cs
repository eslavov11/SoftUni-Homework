namespace MatrixMultiplication
{
    using System;

    public class MatrixMultiplication
    {
        public static void Main()
        {
            var matrixOne = new double[,]
            {
                { 1, 3 },
                { 5, 7 }
            };
            var matrixTwo = new double[,]
            {
                { 4, 2 },
                { 1, 5 }
            };

            var multipliedMatrix = MultiplyMatrices(matrixOne, matrixTwo);

            for (int row = 0; row < multipliedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < multipliedMatrix.GetLength(1); col++)
                {
                    Console.Write(multipliedMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static double[,] MultiplyMatrices(double[,] matrixOne, double[,] matrixTwo)
        {
            if (matrixOne.GetLength(1) != matrixTwo.GetLength(0))
            {
                throw new ArgumentException(
                    "Rows of the first matrix must be the same count as the cols of the second matrix");
            }

            var matrixOneRows = matrixOne.GetLength(1);
            var multipliedMatrix = new double[matrixOne.GetLength(0), matrixTwo.GetLength(1)];

            for (int rows = 0; rows < multipliedMatrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < multipliedMatrix.GetLength(1); cols++)
                {
                    for (int firstMatrixRow = 0; firstMatrixRow < matrixOneRows; firstMatrixRow++)
                    {
                        multipliedMatrix[rows, cols] += 
                            matrixOne[rows, firstMatrixRow] * matrixTwo[firstMatrixRow, cols];
                    }
                }
            }

            return multipliedMatrix;
        }
    }
}