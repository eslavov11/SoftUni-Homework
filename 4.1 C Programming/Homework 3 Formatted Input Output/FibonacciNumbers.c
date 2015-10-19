#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    int a = 0, b = 1, temp, i, n;
    scanf("%d", &n);
            
    for (i = 0; i < n; i++)
    {
        if (i%2==0)
        {
            printf("%d ", a);
            if (i != n-1) 
            {
                 printf("%d ", b);
            }
        }
        temp = a + b;
        a = b;
        b = temp;
    }
    printf("\n");
    return (EXIT_SUCCESS);
}
//10 | 0 1 1 2 3 5 8 13 21 34
