#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    int a, i = 1, decimal = 0;
    float b,c;
    scanf("%d", &a);
    scanf("%f", &b);
    scanf("%f", &c);
    int aAsBinary = 0;
    
    decimal = a;
        while (decimal > 0)
        {
            int reminder;
            reminder = decimal % 2;
            decimal = decimal / 2;
            aAsBinary += reminder * i;
            i *= 10;       
        }
    
    printf("|%-10x|%010d|%10.2f|%-10.3f|\n", a, aAsBinary, b, c);
    return (EXIT_SUCCESS);
}
