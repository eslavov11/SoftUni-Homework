#include <stdio.h>
#include <string.h>

#define BUFFER_SIZE 50
/*
 * Using loops write a program that converts a binary integer number 
 * to its decimal form. The input is entered as string. The output should 
 * be a variable of type long
 */
int main() 
{
    char binaryNum[BUFFER_SIZE];
    fgets(binaryNum, BUFFER_SIZE, stdin);
    long decimal = 0;
    int twos = 1, i;
    size_t binaryLength = strlen(binaryNum);
    
    for (i = binaryLength - 2; i >= 0; i--)
    {
        int number = binaryNum[i] - 48;
        decimal += number * twos;
        twos *= 2;
    }
    
    printf("%ld\n", decimal);
    
    return 0;
}