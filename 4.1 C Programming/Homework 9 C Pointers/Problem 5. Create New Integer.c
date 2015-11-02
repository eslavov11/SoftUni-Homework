#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int new_int();
int* new_int_ptr();

int main()
{
    printf("%d\n", new_int());
    printf("%d\n", *new_int_ptr());
    return 0;
}

int new_int()
{ 
    int number=55555555;
    return number;
}

int* new_int_ptr()
{
    int *number = malloc(sizeof(int));
    *number = 666666666;
    return number;
}