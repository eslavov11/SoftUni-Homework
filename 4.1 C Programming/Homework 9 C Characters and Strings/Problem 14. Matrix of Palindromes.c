#include <stdio.h>
#include <stdlib.h>

int main() 
{
    int rows, cols;
    if (scanf("%d %d", &rows, &cols) != 2)
    {
        printf("Invalid input!");
        return 1;
    }
    
    int i;
    for (i = 0; i < rows; i++)
    {
        char letter = 'a' + i;
        int j;
        for (j = 0; j < cols; j++)
        {
            printf("%c%c%c ", letter, letter + j, letter);
        }
        
        printf("\n");
    }
    
    return 0;
}