#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    float a,b;
    scanf("%f", &a);
    scanf("%f", &b);
    if (a>b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    printf("%.2f %.2f\n",a,b);
    return (EXIT_SUCCESS);
}

