#include <stdio.h>
#include <stdlib.h>

int main() 
{
    int dimension;
    if (scanf("%d", &dimension) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    
    int scalar;
    if (scanf("%d", &scalar) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    
    int i;
    int vector[dimension];
    for (i = 0; i < dimension; i++)
    {
        scanf("%d", &vector[i]);
    }
    
    for (i = 0; i < dimension; i++)
    {
        vector[i] *= scalar;
        printf("%d ", vector[i]);
    }
    
    return 0;
}