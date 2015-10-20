#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    double x,y,r=2;
    scanf("%lf", &x);
    scanf("%lf", &y);
    printf((x * x) + (y * y) <= r * r ? "Yes\n" : "No\n");
    return (EXIT_SUCCESS);
}

