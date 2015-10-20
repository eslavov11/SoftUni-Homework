#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    float a,b;
    scanf("%f", &a);
    scanf("%f", &b);
    if (a == 0 || b == 0) 
    {
        printf("0\n");
    }
    else if((a<0 && b>0) || (a>0 && b<0))
    {
        printf("-\n");
    }
    else
    {
        printf("+\n");
    }

    return (EXIT_SUCCESS);
}

