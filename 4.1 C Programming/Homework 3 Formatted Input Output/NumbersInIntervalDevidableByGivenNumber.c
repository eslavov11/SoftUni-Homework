
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int start, end, count = 0;
    scanf("%d", &start);    
    scanf("%d", &end);
    for (; start <= end; start++)
    {
        if (start % 5 == 0)
        {
            count++;
        }

    }
    printf("%d\n", count);
    return (EXIT_SUCCESS);
}

