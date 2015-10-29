#include <stdio.h>
#include <stdlib.h>

void fill_arr(int *array, int length);

int main() 
{
    int n;
    if (scanf("%d", &n) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    
    int firstVector[n], secondVector[n];
    int i, product = 0;
    fill_arr(firstVector, n);
    fill_arr(secondVector, n);
    for (i = 0; i < n; i++)
    {
        product += firstVector[i] * secondVector[i];
    }
    
    printf("\n%d", product);
    
    return 0;
}

void fill_arr(int *array, int length)
{
    int i;
    for (i = 0; i < length; i++)
    {
        scanf("%d", &array[i]);
    }
}