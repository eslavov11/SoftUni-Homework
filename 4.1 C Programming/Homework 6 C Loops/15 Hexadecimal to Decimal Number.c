#include <stdio.h>
#include <string.h>

#define BUFFER_SIZE 50
/*
 * Using loops write a program that converts a hexadecimal integer 
 * number to its decimal form. The input is entered as string. 
 * The output should be a variable of type long.
 */
int main() 
{
    char hexNum[BUFFER_SIZE];
    fgets(hexNum, BUFFER_SIZE, stdin);
    long long decimal = 0, sixteen = 1;
    int i;
    size_t hexLength = strlen(hexNum);
    
    for (i = hexLength - 2; i >= 0; i--)
    {
        int num;
        switch (hexNum[i])
        {
            case 'A':
                num = 10;
                break;
            case 'B':
                num = 11;
                break;
            case 'C':
                num = 12;
                break;
            case 'D':
                num = 13;
                break;
            case 'E':
                num = 14;
                break;
            case 'F':
                num = 15;
                break;
            default:
                num = hexNum[i] - 48;
                break;
        }
        
        decimal += num * sixteen;
        sixteen *= 16;
    }
    
    printf("%lld\n", decimal);
    
    return 0;
}