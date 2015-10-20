#include <stdio.h>
#include <stdlib.h>
#define format "%f %f %f\n"
int main(int argc, char** argv) 
{
    float a,b,c;
    scanf("%f", &a);
    scanf("%f", &b);
    scanf("%f", &c);
    
    if (a >= b && a >= c && b >= c) {
        printf(format, a,b,c);
    }
    else if (a > b && a > c && c > b) {
        printf(format, a,c,b);
    }
    else if (b > a && b > c && a > c) {
        printf(format, b,a,c);
    }
    else if (b > a && b > c && c > a) {
        printf(format, b,c,a);
    }
    else if (c > a && c > b && b > a) {
        printf(format, c,b,a);
    }
    else  {
        printf(format, c , a, b);
    }
    return (EXIT_SUCCESS);
}

