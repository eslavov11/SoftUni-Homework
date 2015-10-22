#include <stdio.h>

/*
 * Using loops write a program that converts an integer number to its 
 * binary representation. The input is entered as long. The output should 
 * be a variable of type string.
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
        char binary[50];
        int i;
        
        if (decimal == 0)
        {
            printf("0");
        }
        else
        {
            for (i = 0; i < 50; i++)
            {
                binary[i] = '\0';
            }
        
            for (i = 49; i >= 0; i--)
            {
                if (decimal == 0)
                {
                    break;
                }

                binary[i] = decimal % 2 == 1 ? '1' : '0';
                decimal /= 2;
            }
        
            for (i = 0; i < 50; i++)
            {
                printf("%c", binary[i]);
            }
        }
    }

    return 0;
}