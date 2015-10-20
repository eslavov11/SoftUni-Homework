#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    double a,b,h;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    printf("height = ");
    scanf("%lf", &h);
    printf("Area: %.2f\n", ((a+b)/2)*h);
    return (EXIT_SUCCESS);
}

