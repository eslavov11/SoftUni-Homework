#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    double r;
    scanf("%lf", &r);
    printf("Perimeter: %.2f\n", (2 * r * 3.141592));
    printf("Area: %.2f\n", (r * r * 3.141592));
    return (EXIT_SUCCESS);
}


