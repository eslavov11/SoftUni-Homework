#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    float a,b,c;
    scanf("%f", &a);
    scanf("%f", &b);
    scanf("%f", &c);
    printf("Average: %.5f\n", (float)((a+b+c)/3));
    return (EXIT_SUCCESS);
}

