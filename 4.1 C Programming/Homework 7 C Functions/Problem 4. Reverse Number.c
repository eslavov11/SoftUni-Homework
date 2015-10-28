#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define STRING_LENGTH 30
double reverse(char* number, int *error);

int main() 
{
    char input[STRING_LENGTH];
    fgets(input, STRING_LENGTH, stdin);
    int error;
    double reversed = reverse(input, &error);
    if (error != 1)
    {
        printf("%.3lf", reversed);
    }
    else
    {
        printf("Invalid format");
    }
    
    return 0;
}

double reverse(char* number, int *error)
{
    *error = 0;
    
    int i,j, length = strlen(number);
    char reversed[length];
    for (i = 0, j = length - 2; i < length; i++, j--)
    {
        reversed[i] = number[j];
    }

    char* remainder;
    double reversedNum = strtod(reversed, &remainder);
    if (*remainder != '\0')
    {
        *error = 1;
        return 0;
    }
    
    return reversedNum;
    
}