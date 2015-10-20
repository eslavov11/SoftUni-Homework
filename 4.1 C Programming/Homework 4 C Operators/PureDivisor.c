#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    int number, result;
    scanf("%d", &number);
    result = (number%9 && number%11 && number%13)^1;
    printf("%d\n", result);
    return (EXIT_SUCCESS);
}
//Write a program that prints if a number is divided by 9, 11 or 13 without remainder.
