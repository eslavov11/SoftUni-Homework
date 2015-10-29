#include <stdio.h>
#include <stdlib.h>

void fill_matrix(int rows, int cols, int matrix[][cols]);

int main() 
{
    int rows, cols;
    if (scanf("%d %d", &rows, &cols) != 2)
    {
        printf("Invalid input!");
        return 1;
    }
    
    int firstMatrix[rows][cols];
    int secondMatrix[rows][cols];
    int resultMatrix[rows][cols];
    
    fill_matrix(rows, cols, firstMatrix);
    fill_matrix(rows, cols, secondMatrix);
    
    printf("\n");
    int i, j;
    for (i = 0; i < rows; i++)
    {
        for (j = 0; j < cols; j++)
        {
            resultMatrix[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
            printf("%-3d", resultMatrix[i][j]);
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