#include <stdio.h>
#include <stdlib.h>

void fill_matrix(int rows, int cols, int matrix[][cols]);
int cell_product(int rows, int cols, 
                        int firstMatrix[][cols], int secondMatrix[][rows]);

int main()
{
    int rows, cols;
    if (scanf("%d %d", &rows, &cols) != 2)
    {
        printf("Invalid input!");
        return 1;
    }
    
    int firstMatrix[rows][cols], secondMatrix[cols][rows], resultMatrix[rows][rows];
    
    fill_matrix(rows, cols, firstMatrix);
    fill_matrix(cols, rows, secondMatrix);
    
    printf("\n");
    int i, j, k;
    for (i = 0; i < rows; i++)
    {
        for (j = 0; j < rows; j++)
        {
            resultMatrix[i][j] = 0;
            for (k = 0; k < cols; k++)
            {
                resultMatrix[i][j] += firstMatrix[i][k] * secondMatrix[k][j];
            }
            printf("%-5d", resultMatrix[i][j]);
        }
        printf("\n");
    }
    
    return 0;
}

void fill_matrix(int rows, int cols, int matrix[][cols])
{
    int i, j;
    for (i = 0; i < rows; i++)
    {
        for (j = 0; j < cols; j++)
        {
            scanf("%d", &matrix[i][j]);
        }
    }
}