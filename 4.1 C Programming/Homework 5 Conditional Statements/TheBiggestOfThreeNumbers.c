#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv) 
{
    float a,b,c;
    scanf("%f", &a);
    scanf("%f", &b);
    scanf("%f", &c);
    if (a > b && a > c) 
    {
        printf("%.1f\n", a);
    }
    else if (b > a && b > c) 
    {
        printf("%.1f\n", b);
    }
    else
    {
        printf("%.1f\n", c);
    }
    
    return (EXIT_SUCCESS);
}

