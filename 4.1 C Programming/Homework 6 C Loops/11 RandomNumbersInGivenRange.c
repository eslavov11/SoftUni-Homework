#include <stdio.h>
#include <stdlib.h>
/*
 * Write a program that enters 3 integers n, min and max (min ≤ max) 
 * and prints n random numbers in the range [min...max].
 */
int main() 
{
    int n, min, max;
    if (scanf("%d %d %d", &n, &min, &max) != 3)
    {
        printf("Invalid input!");
        return 1;
    }
    else
    {
        int i;
        for (i = n; i > 0; i--)
        {
            int random = (rand() % (max + 1 - min)) + min;
            printf("%d ", random);
        }
    }
    
    return 0;
}