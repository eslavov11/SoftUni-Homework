#include <stdio.h>

/*
 * Using loops write a program that converts an integer number to its 
 * hexadecimal representation. The input is entered as long. The output 
 * should be a variable of type string.
 */
int main() 
{
    long long decimal;
    if (scanf("%lld", &decimal) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    else
    {
        if (decimal == 0)
        {
            printf("0");
            return 0;
        }
        char hex[50];
        long long i, rest;
        int j;
        char digit[10] = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        
        for (i = 0; i < 50; i++)
        {
            hex[i] = '\0';
        }
        
        for (i = decimal, j = 0; i > 0; i /= 16, j++)
        {
            
            rest = i % 16;
            switch (rest)
            {
                case 10:
                    hex[j] = 'A';
                    break;
                case 11:
                    hex[j] = 'B';
                    break;
                case 12:
                    hex[j] = 'C';
                    break;
                case 13:
                    hex[j] = 'D';
                    break;
                case 14:
                    hex[j] = 'E';
                    break;
                case 15:
                    hex[j] = 'F';
                    break;
                default:
                    hex[j] = digit[rest];
                    break;
            }
            
        }
        
        for (i = 49; i >= 0; i--)
        {
            if (hex[i] != '\0')
            {
                printf("%c", hex[i]);
            }
        }
        printf("\n");
    }
    return 0;
}